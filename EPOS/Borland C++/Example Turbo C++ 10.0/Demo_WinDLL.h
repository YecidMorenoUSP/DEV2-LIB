//---------------------------------------------------------------------------

#ifndef Demo_WinDLLH
#define Demo_WinDLLH
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include <ExtCtrls.hpp>
//---------------------------------------------------------------------------
class TDemoDlg : public TForm
{
__published:    // Von der IDE verwaltete Komponenten
        TGroupBox *GroupBox1;
        TLabel *ActiveMode;
        TGroupBox *GroupBox2;
        TLabel *Label2;
        TLabel *Label3;
        TEdit *PositionTarget;
        TRadioButton *RadioRelative;
        TRadioButton *RadioAbsolute;
        TGroupBox *GroupBox3;
        TLabel *Label4;
        TLabel *Label5;
        TLabel *Label6;
        TLabel *Label7;
        TEdit *PositionStart;
        TEdit *PositionActual;
        TButton *Enable;
        TButton *Disable;
        TButton *Move;
        TButton *Halt;
        TButton *OK;
        TTimer *Timer;
        TButton *DeviceSettings;
        TLabel *Label1;
        TEdit *NodeId;
        void __fastcall EnableClick(TObject *Sender);
        void __fastcall DisableClick(TObject *Sender);
        void __fastcall HaltClick(TObject *Sender);
        void __fastcall MoveClick(TObject *Sender);
        void __fastcall Create(TObject *Sender);
        void __fastcall Destroy(TObject *Sender);
        void __fastcall OnTimer(TObject *Sender);
        void __fastcall OKClick(TObject *Sender);
        void __fastcall DeviceSettingsClick(TObject *Sender);
        void __fastcall OnChangeNodeId(TObject *Sender);
private:
        BOOL m_oInitialisation;
        BOOL m_oImmediately;
        BOOL m_oUpdateActive;
        HANDLE m_KeyHandle;
        unsigned short m_wNodeId;
        unsigned long m_dErrorCode;
        signed char m_uMode;
        signed long m_lStartPosition;
        signed long m_lTargetPosition;
        unsigned long m_dProfileVelocity;
        unsigned long m_dProfileAcceleration;
        unsigned long m_dProfileDeceleration;
        BOOL RestoreEPOS();
        BOOL UpdateStatus();
        BOOL OpenDevice();
        bool ShowErrorInformation(DWORD dErrorCode);
        void StopTimer();    // Anwender-Deklarationen
public:
        // Anwender-Deklarationen
        __fastcall TDemoDlg(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TDemoDlg *DemoDlg;
//---------------------------------------------------------------------------
#endif
