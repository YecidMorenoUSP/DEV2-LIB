unit Demo_WinDLL;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  StdCtrls, Definitions, ExtCtrls;

type
  TDemoDlg = class(TForm)
    GroupBox1: TGroupBox;
    OperationMode: TLabel;
    GroupBox2: TGroupBox;
    Label2: TLabel;
    PositionTarget: TEdit;
    Label3: TLabel;
    RadioRelative: TRadioButton;
    RadioAbsolute: TRadioButton;
    GroupBox3: TGroupBox;
    Label4: TLabel;
    Label5: TLabel;
    PositionStart: TEdit;
    PositionActual: TEdit;
    Label6: TLabel;
    Label7: TLabel;
    Timer: TTimer;
    Enable: TButton;
    Disable: TButton;
    Move: TButton;
    Halt: TButton;
    OK: TButton;
    DeviceSettings: TButton;
    Label1: TLabel;
    NodeId: TEdit;
    procedure EnableClick(Sender: TObject);
    procedure DisableClick(Sender: TObject);
    procedure MoveClick(Sender: TObject);
    procedure HaltClick(Sender: TObject);
    procedure FormDestroy(Sender: TObject);
    procedure Create(Sender: TObject); 
    procedure OnTimer(Sender: TObject);
    procedure OKClick(Sender: TObject);
    procedure DeviceSettingsClick(Sender: TObject);
    procedure NodeIdChange(Sender: TObject);

  public
    m_lPositionTarget: Longint;
    m_lPositionActual: Longint;
    m_lPositionStart: Longint;

  private
    m_oInitialisation: Boolean;
    m_oImmediately: Boolean;
    m_oUpdateActive: Boolean;
    m_KeyHandle: Longint;
    m_wNodeId: Word;
    m_dErrorCode: Longword;
    m_uMode: Shortint;
    m_dProfileVelocity: Longword;
    m_dProfileAcceleration: Longword;
    m_dProfileDeceleration: Longword;
    function UpdateStatus: Boolean;
    function OpenDevice: Boolean;
    function RestoreEPOS: Boolean;
    function ShowErrorInformation(dErrorCode:longword): Boolean;
    function StopTimer: Boolean;
    { Private-Deklarationen}

  end;

var
  DemoDlg: TDemoDlg;

implementation

{$R *.DFM}

{************************************************************************
Sets device to enable state
************************************************************************}
procedure TDemoDlg.EnableClick(Sender: TObject);
var
     oFault : LongBool;
begin
     NodeId.Text := IntToStr(m_wNodeId);

     oFault := false;

     if(VCS_GetFaultState(m_KeyHandle,m_wNodeId,oFault,m_dErrorCode)=false) then
     begin
     	ShowErrorInformation(m_dErrorCode);
     	exit
     end;

     if(oFault=true) then
     begin
     	if(VCS_ClearFault(m_KeyHandle,m_wNodeId,m_dErrorCode)=false) then
     	begin
     		ShowErrorInformation(m_dErrorCode);
     		exit
     	end
     end;

     if(VCS_SetEnableState(m_KeyHandle,m_wNodeId,m_dErrorCode)=false) then
     begin
     	ShowErrorInformation(m_dErrorCode);
     end;
end;

{************************************************************************
Restores the old settings, stops the timer and delete the key handle
************************************************************************}
function TDemoDlg.RestoreEPOS: boolean;
begin
     if(m_oInitialisation) then
       begin
          VCS_SetDisableState(m_KeyHandle,m_wNodeId,m_dErrorCode);
          VCS_SetOperationMode(m_KeyHandle,m_wNodeId,m_uMode,m_dErrorCode);
          VCS_SetPositionProfile(m_KeyHandle,m_wNodeId,m_dProfileVelocity,m_dProfileAcceleration,m_dProfileDeceleration,m_dErrorCode);
     end;

     StopTimer();

     VCS_CloseAllDevices(m_dErrorCode);

     result := True;
end;

{************************************************************************
Sets device to disable state
************************************************************************}
procedure TDemoDlg.DisableClick(Sender: TObject);
begin
     NodeId.Text := IntToStr(m_wNodeId);

     if(VCS_SetDisableState(m_KeyHandle,m_wNodeId,m_dErrorCode)=false) then
       begin
          Timer.Enabled := false;
          Application.MessageBox('Communication Error!','Error',mb_OK);
     end
end;

{************************************************************************
Starts the movement
************************************************************************}
procedure TDemoDlg.MoveClick(Sender: TObject);
var
     oMotion : LongBool;
begin
     NodeId.Text := IntToStr(m_wNodeId);
     m_lPositionTarget := StrToInt(PositionTarget.Text);

     if(RadioAbsolute.Checked) then
          oMotion := True
     else
          oMotion := False;

     if(VCS_GetPositionIs(m_KeyHandle,m_wNodeId,m_lPositionStart,m_dErrorCode)) then
          PositionStart.Text := IntToStr(m_lPositionStart);

     if(VCS_MoveToPosition(m_KeyHandle,m_wNodeId,m_lPositionTarget,oMotion,m_oImmediately,m_dErrorCode)=false) then
       begin
          Timer.Enabled := False;
          Application.MessageBox('Communication Error!','Error',mb_OK);
     end
end;

{************************************************************************
Stops the movement
************************************************************************}
procedure TDemoDlg.HaltClick(Sender: TObject);
begin
     NodeId.Text := IntToStr(m_wNodeId);
     
     if(VCS_HaltPositionMovement(m_KeyHandle,m_wNodeId,m_dErrorCode)=False) then
       begin
          Timer.Enabled := False;
          Application.MessageBox('Communication Error!','Error',mb_OK);
     end
end;

{************************************************************************
Updates the dialog display
************************************************************************}
function TDemoDlg.UpdateStatus: Boolean;
var
     oEnable : LongBool;
begin
     oEnable := True;
     result := m_oUpdateActive;

     if(RadioAbsolute.Checked)then
          Move.Caption := 'Move Absolute'
     else
          Move.Caption := 'Move Relative';

     if result then
       begin
          if not VCS_GetPositionIs(m_KeyHandle,m_wNodeId,m_lPositionActual,m_dErrorCode) then result := False;
          if result then
            begin
               PositionActual.Text := IntToStr(m_lPositionActual);
            end
          else
            begin
               StopTimer();
               ShowErrorInformation(m_dErrorCode);

               PositionActual.Text := IntToStr(0);
          end;
       end
     else
       begin
          PositionActual.Text := IntToStr(0);
     end;

     if result then
       begin
          if not VCS_GetOperationMode(m_KeyHandle,m_wNodeId,m_uMode,m_dErrorCode) then result := False;
          if result then
            begin
               case m_uMode of
                   -6: OperationMode.Caption := 'Step/Direction Mode';
                   -5: OperationMode.Caption := 'Master Encoder Mode';
                   -3: OperationMode.Caption := 'Current Mode';
                   -2: OperationMode.Caption := 'Velocity Mode';
                   -1: OperationMode.Caption := 'Position Mode';
                    1: OperationMode.Caption := 'Profile Position Mode';
                    3: OperationMode.Caption := 'Profile Velocity Mode';
                    6: OperationMode.Caption := 'Homing Mode';
                    7: OperationMode.Caption := 'Interpolated Position Mode';
               else
                 begin
                    StopTimer();
                    ShowErrorInformation(m_dErrorCode);

                    OperationMode.Caption := 'Unknown Mode';
                 end
               end
          end;
       end
     else
         OperationMode.Caption := 'Unknown Mode';

     if result then
       begin
          if not VCS_GetEnableState(m_KeyHandle,m_wNodeId,oEnable,m_dErrorCode) then result := False;
          if result then
            begin
                DeviceSettings.Enabled := not oEnable;
                Enable.Enabled := not oEnable;
                Disable.Enabled := oEnable;
                Move.Enabled := oEnable;
                Halt.Enabled := oEnable;
            end
          else
            begin
               StopTimer();
               ShowErrorInformation(m_dErrorCode);

               DeviceSettings.Enabled := oEnable;
               Enable.Enabled := oEnable;
               Disable.Enabled := not oEnable;
               Move.Enabled := not oEnable;
               Halt.Enabled := not oEnable;
          end;
       end
     else
       begin
         DeviceSettings.Enabled := oEnable;
         Enable.Enabled := not oEnable;
         Disable.Enabled := not oEnable;
         Move.Enabled := not oEnable;
         Halt.Enabled := not oEnable;
     end;
end;

{************************************************************************
Close dialog
************************************************************************}
procedure TDemoDlg.FormDestroy(Sender: TObject);
begin
     RestoreEPOS();
end;

{************************************************************************
Init on program start
************************************************************************}
procedure TDemoDlg.Create(Sender: TObject);
begin
     m_oImmediately := True;
     m_wNodeId := 1;

     if(OpenDevice()) then
       begin
          m_oInitialisation := True;
          m_oUpdateActive := True;
          Timer.Enabled := True;
     end
     else
       begin
          m_oInitialisation := False;
          m_oUpdateActive := False;
     end;
end;

{************************************************************************
If timer was started all 100ms this function will be called
************************************************************************}
procedure TDemoDlg.OnTimer(Sender: TObject);
begin
     if(UpdateStatus()=False) then
       begin
          StopTimer();
     end;
end;

{************************************************************************
Close dialog
************************************************************************}
procedure TDemoDlg.OKClick(Sender: TObject);
begin
     Close;
end;

{************************************************************************
Sets new communication settings via button 'Device Settings'
************************************************************************}
procedure TDemoDlg.DeviceSettingsClick(Sender: TObject);
begin
     NodeId.Text := IntToStr(m_wNodeId);
     if(OpenDevice()) then
       begin
          m_oInitialisation := True;
          m_oUpdateActive := True;
          Timer.Enabled := True;
     end
     else
       begin
          m_oInitialisation := False;
          StopTimer();
     end;
end;

{************************************************************************
Opens communication interface via the OpenDeviceDlg
************************************************************************}
function TDemoDlg.OpenDevice: boolean;
const
     Size : WORD = 100;
begin
     result := False;
     m_KeyHandle := VCS_OpenDeviceDlg(m_dErrorCode);
     if(m_KeyHandle >= 1) then
       begin
          if(VCS_ClearFault(m_KeyHandle,m_wNodeId,m_dErrorCode))then
            begin
               if(VCS_GetOperationMode(m_KeyHandle,m_wNodeId,m_uMode,m_dErrorCode))then
                 begin
                    if(VCS_GetPositionProfile(m_KeyHandle,m_wNodeId,m_dProfileVelocity,m_dProfileAcceleration,m_dProfileDeceleration,m_dErrorCode))then
                      begin
                         if(VCS_SetOperationMode(m_KeyHandle,m_wNodeId,1,m_dErrorCode))then
                           begin
                              if(VCS_SetPositionProfile(m_KeyHandle,m_wNodeId,100,1000,1000,m_dErrorCode))then
                                begin
                                   if(VCS_GetPositionIs(m_KeyHandle,m_wNodeId,m_lPositionStart,m_dErrorCode))then
                                     begin
                                        PositionStart.Text := IntToStr(m_lPositionStart);
                                        result := True;
                                   end
                              end
                         end
                    end
               end
          end
     end;

     if not result then
       begin
          ShowErrorInformation(m_dErrorCode);
     end;
end;

{************************************************************************
Changes node id
************************************************************************}
procedure TDemoDlg.NodeIdChange(Sender: TObject);
begin
     if not (NodeId.Text = '')then
       begin
          Timer.Enabled := true;
          m_oUpdateActive := true;
          m_wNodeId := StrToInt(NodeId.Text);
     end;
end;

{************************************************************************
Stops timer. Status will be displayed as disconnected
************************************************************************}
function TDemoDlg.StopTimer;
begin
     Timer.Enabled := False;
     m_oUpdateActive := False;
     UpdateStatus();

     result := True;
end;

{************************************************************************
Shows a message box with error description of the input error code
************************************************************************}
function TDemoDlg.ShowErrorInformation(dErrorCode:longword): boolean;
const
     Size : WORD = 100;
var
     pStrErrorInfo: PAnsiChar;
     pWideStrErrorInfo: PWideChar;

begin
     GetMem(pStrErrorInfo, Size);
     pWideStrErrorInfo := WideStrAlloc(Size);

     if(VCS_GetErrorInfo(dErrorCode, pStrErrorInfo, Size))then
       begin
          StrPCopy(pWideStrErrorInfo, pStrErrorInfo);
          Application.MessageBox(pWideStrErrorInfo, 'Error', mb_OK);
          FreeMem(pStrErrorInfo,Size);
          result := True;
       end
     else
       begin
          Application.MessageBox('Error information can not be read!', 'Error', mb_OK);
          FreeMem(pStrErrorInfo,Size);
          result := False;
       end;
end;

end.
