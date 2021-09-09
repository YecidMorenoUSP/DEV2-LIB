//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "Demo_WinDLL.h"
#include "Definitions.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"
TDemoDlg *DemoDlg;
//---------------------------------------------------------------------------
__fastcall TDemoDlg::TDemoDlg(TComponent* Owner)
        : TForm(Owner)
{
}
//---------------------------------------------------------------------------

/************************************************************************
Sets device to enable state
************************************************************************/
void __fastcall TDemoDlg::EnableClick(TObject *Sender)
{
    BOOL oFault = FALSE;

    NodeId->Text = IntToStr(m_wNodeId);

    if(!VCS_GetFaultState(m_KeyHandle, m_wNodeId, &oFault, &m_dErrorCode))
    {
        ShowErrorInformation(m_dErrorCode);
        return;
    }

    if(oFault)
    {
        if(!VCS_ClearFault(m_KeyHandle, m_wNodeId, &m_dErrorCode))
        {
            ShowErrorInformation(m_dErrorCode);
            return;
        }
    }

    if(!VCS_SetEnableState(m_KeyHandle, m_wNodeId, &m_dErrorCode))
    {
        ShowErrorInformation(m_dErrorCode);
        Timer->Enabled = false;
    }
}
//---------------------------------------------------------------------------

/************************************************************************
Sets device to disable state
************************************************************************/
void __fastcall TDemoDlg::DisableClick(TObject *Sender)
{
    NodeId->Text = IntToStr(m_wNodeId);

    if(!VCS_SetDisableState(m_KeyHandle, m_wNodeId, &m_dErrorCode))
    {
        Timer->Enabled = false;
        Application->MessageBoxA("Communication error", "Error", MB_OK);
    }
}
//---------------------------------------------------------------------------

/************************************************************************
Stops the movement
************************************************************************/
void __fastcall TDemoDlg::HaltClick(TObject *Sender)
{
    NodeId->Text = IntToStr(m_wNodeId);

    if(!VCS_HaltPositionMovement(m_KeyHandle, m_wNodeId, &m_dErrorCode))
    {
        Timer->Enabled = false;
        Application->MessageBoxA("Communication error", "Error", MB_OK);
    }
}
//---------------------------------------------------------------------------

/************************************************************************
Starts the movement
************************************************************************/
void __fastcall TDemoDlg::MoveClick(TObject *Sender)
{
    m_lTargetPosition = StrToInt(PositionTarget->Text);

    if(VCS_GetPositionIs(m_KeyHandle, m_wNodeId, &m_lStartPosition, &m_dErrorCode))
    {
        PositionStart->Text = IntToStr(m_lStartPosition);

        if(!VCS_MoveToPosition(m_KeyHandle, m_wNodeId, m_lTargetPosition, RadioAbsolute->Checked, m_oImmediately, &m_dErrorCode))
        {
            Timer->Enabled = false;
            Application->MessageBoxA("Communication error", "Error", MB_OK);
        }
    }
}
//---------------------------------------------------------------------------

/************************************************************************
Restores the old settings, stops the timer and delete the key handle
************************************************************************/
BOOL TDemoDlg::RestoreEPOS()
{
    if(m_oInitialisation)
        {
              VCS_SetDisableState(m_KeyHandle, m_wNodeId, &m_dErrorCode);
          VCS_SetOperationMode(m_KeyHandle, m_wNodeId, m_uMode/*Old Mode*/, &m_dErrorCode);
          VCS_SetPositionProfile(m_KeyHandle, m_wNodeId, m_dProfileVelocity, m_dProfileAcceleration, m_dProfileDeceleration, &m_dErrorCode);
        }

        Timer->Enabled = false;

        VCS_CloseAllDevices(&m_dErrorCode);

        return TRUE;
}

/************************************************************************
Updates the display
************************************************************************/
BOOL TDemoDlg::UpdateStatus()
{
    BOOL oEnable = true;
        BOOL oResult = m_oUpdateActive;
        signed long lPositionActual;

    if(RadioAbsolute->Checked)
    {
        Move->Caption = "Move Absolute";
    }
    else
    {
        Move->Caption = "Move Relative";
    }

    if(oResult)
    {
        oResult = VCS_GetOperationMode(m_KeyHandle, m_wNodeId, &m_uMode, &m_dErrorCode);
        if(oResult)
        {
            switch(m_uMode)
            {
                case -6: ActiveMode->Caption = "Step/Direction Mode"; break;
                case -5: ActiveMode->Caption = "Master Encoder Mode"; break;
                case -3: ActiveMode->Caption = "Current Mode"; break;
                case -2: ActiveMode->Caption = "Velocity Mode"; break;
                case -1: ActiveMode->Caption = "Position Mode"; break;
                case 1: ActiveMode->Caption = "Profile Position Mode"; break;
                case 3: ActiveMode->Caption = "Profile Velocity Mode"; break;
                case 6: ActiveMode->Caption = "Homing Mode"; break;
                                case 7: ActiveMode->Caption = "Interpolated Position Mode"; break;
                default: ActiveMode->Caption = "Unknown Mode";
            }
        }
        else
        {
            StopTimer();
            ShowErrorInformation(m_dErrorCode);

            ActiveMode->Caption = "Unknown Mode";
        }
    }
    else
    {
        ActiveMode->Caption = "Unknown Mode";
    }

    if(oResult)
    {
        oResult = VCS_GetEnableState(m_KeyHandle, m_wNodeId, &oEnable, &m_dErrorCode);

        if(oResult)
        {
                        DeviceSettings->Enabled = !oEnable;
                Enable->Enabled = !oEnable;
                Disable->Enabled = oEnable;
                Move->Enabled = oEnable;
                Halt->Enabled = oEnable;
                }
                else
                {
            StopTimer();
            ShowErrorInformation(m_dErrorCode);

                        DeviceSettings->Enabled = oEnable;
                 Enable->Enabled = oEnable;
                 Disable->Enabled = !oEnable;
                Move->Enabled = !oEnable;
                Halt->Enabled = !oEnable;
            }
        }
        else
        {
                DeviceSettings->Enabled = oEnable;
                Enable->Enabled = !oEnable;
                Disable->Enabled = !oEnable;
                Move->Enabled = !oEnable;
                Halt->Enabled = !oEnable;
        }

    if(oResult)
    {
        oResult = VCS_GetPositionIs(m_KeyHandle, m_wNodeId, &lPositionActual, &m_dErrorCode);
        if(oResult)
                {
                        PositionActual->Text = IntToStr(lPositionActual);
                }
                else
        {
            StopTimer();
            ShowErrorInformation(m_dErrorCode);

                        PositionActual->Text = IntToStr(0);
                        PositionStart->Text = IntToStr(0);
         }
    }
    else
    {
                PositionActual->Text = IntToStr(0);
                PositionStart->Text = IntToStr(0);
       }

    return oResult;
}

void __fastcall TDemoDlg::Create(TObject *Sender)
{
     m_oImmediately = TRUE;
     m_wNodeId = 1;

     if(OpenDevice())
     {
         m_oInitialisation = true;
         m_oUpdateActive = true;
         Timer->Enabled = true;
     }
     else
     {
         m_oInitialisation = false;
         m_oUpdateActive = false;
         Application->MessageBoxA("Communication error", "Error", MB_OK);
         Enable->Enabled = false;
         Disable->Enabled = false;
         Move->Enabled = false;
         Halt->Enabled = false;
     }
}
//---------------------------------------------------------------------------

/************************************************************************
Closes the dialog
************************************************************************/
void __fastcall TDemoDlg::Destroy(TObject *Sender)
{
     RestoreEPOS();
}
//---------------------------------------------------------------------------

/************************************************************************
If timer was started all 100ms this function will be called
************************************************************************/
void __fastcall TDemoDlg::OnTimer(TObject *Sender)
{
     if(m_oUpdateActive && !UpdateStatus())
     {
          StopTimer();
     }
}
//---------------------------------------------------------------------------

/************************************************************************
Closes the dialog
************************************************************************/
void __fastcall TDemoDlg::OKClick(TObject *Sender)
{
     RestoreEPOS();

     Close();
}
//---------------------------------------------------------------------------

/************************************************************************
Sets new communication settings via button 'Device Settings'
************************************************************************/
void __fastcall TDemoDlg::DeviceSettingsClick(TObject *Sender)
{
     NodeId->Text = IntToStr(m_wNodeId);

     if(OpenDevice())
     {
          m_oInitialisation = true;
          m_oUpdateActive = true;
          Timer->Enabled = true;
     }
     else
     {
          m_oInitialisation = false;
          StopTimer();
     }
}
//---------------------------------------------------------------------------

/************************************************************************
Opens communication interface via the OpenDeviceDlg
************************************************************************/
BOOL TDemoDlg::OpenDevice()
{
     char *pStrProtocolStackName;

    //Allocate memory for string
    if((pStrProtocolStackName = (char*)malloc(100)) == NULL)
    {
       Application->MessageBoxA("Not enough memory to allocate buffer\n", "System", MB_OK);
       exit(1);   // Exit the program, if not enough memory
    }

     m_KeyHandle = VCS_OpenDeviceDlg(&m_dErrorCode);
     if(m_KeyHandle)
     {
           //Clear Error History
           if(VCS_ClearFault(m_KeyHandle, m_wNodeId, &m_dErrorCode))
           {
                 //Read Operation Mode
                 if(VCS_GetOperationMode(m_KeyHandle, m_wNodeId, &m_uMode, &m_dErrorCode))
                 {
                       //Read Position Profile Objects
                       if(VCS_GetPositionProfile(m_KeyHandle, m_wNodeId, &m_dProfileVelocity, &m_dProfileAcceleration, &m_dProfileDeceleration, &m_dErrorCode))
                       {
                             //Write Operational Mode (Profile Position Mode)
                             if(VCS_SetOperationMode(m_KeyHandle, m_wNodeId, 1, &m_dErrorCode))
                             {
                                   //Write Position Profile Objects
                                   if(VCS_SetPositionProfile(m_KeyHandle, m_wNodeId, 100, 1000, 1000, &m_dErrorCode))
                                   {
                                         //Read Actual Position
                                         if(VCS_GetPositionIs(m_KeyHandle, m_wNodeId, &m_lStartPosition, &m_dErrorCode))
                                         {
                                               PositionStart->Text = IntToStr(m_lStartPosition);
                                               return TRUE;
                                         }
                                   }
                             }
                       }
                 }
           }

           ShowErrorInformation(m_dErrorCode);
     }
     else
     {
         free(pStrProtocolStackName);
     }
     return FALSE;
}
//---------------------------------------------------------------------------

/************************************************************************
Changes node id
************************************************************************/
void __fastcall TDemoDlg::OnChangeNodeId(TObject *Sender)
{
    if(NodeId->Text != "")
    {
        m_wNodeId = StrToInt(NodeId->Text);
        if(m_wNodeId >= 1 && m_wNodeId <= 128)
        {
            Timer->Enabled = true;
                        m_oUpdateActive = true;
        }
        else
        {
            Application->MessageBoxA("Node ID from 1 to 127!", "Node ID", MB_OK);
         }
    }
}
//---------------------------------------------------------------------------

/************************************************************************
Shows a message box with error description of the input error code
************************************************************************/
bool TDemoDlg::ShowErrorInformation(DWORD dErrorCode)
{
     char* pStrErrorInfo;

    if((pStrErrorInfo = (char*)malloc(100)) == NULL)
    {
        Application->MessageBoxA("Not enough memory to allocate buffer for error information string\n", "System Error", MB_OK);

        return FALSE;
    }

    if(VCS_GetErrorInfo(dErrorCode, pStrErrorInfo, 100))
    {
        Application->MessageBoxA(pStrErrorInfo, "Error Information", MB_ICONINFORMATION);

        free(pStrErrorInfo);

        return TRUE;
    }
    else
    {
        free(pStrErrorInfo);
        Application->MessageBoxA("Error information can't be read!", "Error Information", MB_ICONINFORMATION);

        return FALSE;
    }
}

/************************************************************************
Stops timer. Status will be displayed to disconnected
************************************************************************/
void TDemoDlg::StopTimer()
{
        Timer->Enabled = false;

        m_oUpdateActive = false;

        UpdateStatus();
}
