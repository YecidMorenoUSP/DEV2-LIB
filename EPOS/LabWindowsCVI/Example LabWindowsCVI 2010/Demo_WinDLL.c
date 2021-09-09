#include <ansi_c.h>
#include <userint.h>
#include "Demo_WinDLL.h"
#include "Definitions.h"

static int EPOS_Demo;

BOOL m_oImmediately;
BOOL m_oInitialisation;
BOOL m_oMovement;
BOOL m_oUpdateActive;
BYTE m_uMode;
HANDLE m_KeyHandle;
long m_lPositionActual;
long m_lPositionStart;
long m_lPositionTarget;
unsigned int m_dErrorCode;
unsigned int m_dProfileAcceleration;
unsigned int m_dProfileDeceleration;
unsigned int m_dProfileVelocity;
WORD m_wNodeId;

/************************************************************************
Init variables with default values
************************************************************************/
void Init()
{
	m_KeyHandle = 0;

	m_lPositionStart = 0;
	m_lPositionTarget = 2000;

	m_oImmediately = 1;
	m_oMovement = 0;
	m_oUpdateActive = 0;
}

/************************************************************************
Shows a message box with error description of the input error code
************************************************************************/
int ShowErrorInformation(unsigned int dErrorCode)
{
	char* pStrErrorInfo;

	if((pStrErrorInfo = (char*)malloc(100)) == NULL)
	{
		MessagePopup("System Error","Not enough memory to allocate buffer\n");

		return 0;
	}

	if(VCS_GetErrorInfo(dErrorCode,pStrErrorInfo,100))
	{
		MessagePopup("Error Information",pStrErrorInfo);

		free(pStrErrorInfo);

		return 1;
	}
	else
	{
		free(pStrErrorInfo);
		MessagePopup("Information","Error information can't be read!");

		return 0;
	}
}

/************************************************************************
Opens communication interface via the OpenDeviceDlg
************************************************************************/
int OpenDevice()
{
	BOOL oSame = 0;
	char* pStrProtocolStackName;
	HANDLE* pKeyHandle;

	Init();

	//Allocate memory for string
	if((pStrProtocolStackName = (char*)malloc(100)) == NULL)
	{
		MessagePopup("System Error","Not enough memory to allocate buffer\n");
		exit(1);
	}

	m_KeyHandle = VCS_OpenDeviceDlg(&m_dErrorCode);
	if(m_KeyHandle)
	{
		//Clear Error History
		if(VCS_ClearFault(m_KeyHandle,m_wNodeId,&m_dErrorCode))
		{
			//Read Operation Mode
			if(VCS_GetOperationMode(m_KeyHandle,m_wNodeId,&m_uMode,&m_dErrorCode))
			{
				//Read Position Profile Objects
				if(VCS_GetPositionProfile(m_KeyHandle,m_wNodeId,&m_dProfileVelocity,&m_dProfileAcceleration,&m_dProfileDeceleration,&m_dErrorCode))
				{
					//Write Profile Position Mode
					if(VCS_SetOperationMode(m_KeyHandle,m_wNodeId,0x01/*Profile Position Mode*/,&m_dErrorCode))
					{
						//Write Profile Position Objects
						if(VCS_SetPositionProfile(m_KeyHandle,m_wNodeId,100,1000,1000,&m_dErrorCode))
						{
							//Read Actual Position
							if(VCS_GetPositionIs(m_KeyHandle,m_wNodeId,&m_lPositionStart,&m_dErrorCode))
							{
								return 1;
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
		MessagePopup("Open Interface","Can't open device!");
		free(pStrProtocolStackName);
	}

	return 0;
}

/************************************************************************
Main Program
************************************************************************/
int main (int argc, char *argv[])
{
	if (InitCVIRTE (0, argv, 0) == 0)
		return -1;	/* out of memory */
	if ((EPOS_Demo = LoadPanel (0, "Demo_WinDLL.uir", PANEL)) < 0)
		return -1;

	if(OpenDevice())
	{
		m_oInitialisation = 1;
		m_oUpdateActive = 1;
	}
	else
	{
		m_oInitialisation = 0;
	}

	DisplayPanel (EPOS_Demo);
	RunUserInterface ();
	DiscardPanel (EPOS_Demo);
	return 0;
}

/************************************************************************
Sets new communication settings via button 'Device Settings'
************************************************************************/
int CVICALLBACK DeviceSettings (int panel, int control, int event,
		void *callbackData, int eventData1, int eventData2)
{
	switch (event)
	{
		case EVENT_COMMIT:
			if(OpenDevice())
			{
				m_oInitialisation = 1;
				m_oUpdateActive = 1;
			}
			break;
	}
	return 0;
}

/************************************************************************
Stops the movement
************************************************************************/
int CVICALLBACK Halt (int panel, int control, int event,
		void *callbackData, int eventData1, int eventData2)
{
	switch (event)
	{
		case EVENT_COMMIT:
			if(!VCS_HaltPositionMovement(m_KeyHandle,m_wNodeId,&m_dErrorCode))
			{
				ShowErrorInformation(m_dErrorCode);
			}
			break;
	}
	return 0;
}

/************************************************************************
Starts the movement
************************************************************************/
int CVICALLBACK Move (int panel, int control, int event,
		void *callbackData, int eventData1, int eventData2)
{
	switch (event)
	{
		case EVENT_COMMIT:
 			if(!VCS_GetPositionIs(m_KeyHandle,m_wNodeId,&m_lPositionStart,&m_dErrorCode))
			{
				MessagePopup("Button Move ...", "Function GetPositionIs failed!");
			}

			if(!VCS_MoveToPosition(m_KeyHandle,m_wNodeId,m_lPositionTarget,m_oMovement,m_oImmediately,&m_dErrorCode))
			{
				MessagePopup("Button Move ...", "Function 'MoveToPosition' failed!"); 				
			}

			break;
	}
	return 0;
}

/************************************************************************
Sets device to disable state
************************************************************************/
int CVICALLBACK Disable (int panel, int control, int event,
		void *callbackData, int eventData1, int eventData2)
{
	BOOL oResult;

	switch (event)
	{
		case EVENT_COMMIT:
			oResult = VCS_SetDisableState(m_KeyHandle,m_wNodeId,&m_dErrorCode);
			break;
	}
	return 0;
}

/************************************************************************
Sets device to enable state
************************************************************************/
int CVICALLBACK Enable (int panel, int control, int event,
		void *callbackData, int eventData1, int eventData2)
{
	BOOL oResult;

	switch (event)
	{
		case EVENT_COMMIT:
			oResult = VCS_SetEnableState(m_KeyHandle,m_wNodeId,&m_dErrorCode);
			break;
	}
	return 0;
}

/************************************************************************
Stops timer. Status will be displayed as disconnected
************************************************************************/
void StopTimer()
{
	m_oUpdateActive = 0;
}

/************************************************************************
Restores the old settings, stops the timer and delete the key handle
************************************************************************/
int RestoreEPOS()
{
	if(m_oInitialisation)
	{
		VCS_SetDisableState(m_KeyHandle,m_wNodeId,&m_dErrorCode);
		VCS_SetOperationMode(m_KeyHandle,m_wNodeId,m_uMode/*Old Mode*/,&m_dErrorCode);
		VCS_SetPositionProfile(m_KeyHandle,m_wNodeId,m_dProfileVelocity,m_dProfileAcceleration,m_dProfileDeceleration,&m_dErrorCode);
	}

	StopTimer();

	VCS_CloseAllDevices(&m_dErrorCode);

	return 1;
}

/************************************************************************
Closes the dialog
************************************************************************/
int CVICALLBACK OkCallback (int panel, int control, int event,
		void *callbackData, int eventData1, int eventData2)
{
	BOOL oResult;

	switch (event)
	{
		case EVENT_COMMIT:

			RestoreEPOS();

			QuitUserInterface (0);
			break;
	}
	return 0;
}

/************************************************************************
Sets state to relative movement
************************************************************************/
int CVICALLBACK RadioMove1 (int panel, int control, int event,
		void *callbackData, int eventData1, int eventData2)
{
	switch (event)
	{
		case EVENT_COMMIT:
			m_oMovement = 0;
			break;
	}
	return 0;
}

/************************************************************************
Sets state to absolute movement
************************************************************************/
int CVICALLBACK RadioMove2 (int panel, int control, int event,
		void *callbackData, int eventData1, int eventData2)
{
	switch (event)
	{
		case EVENT_COMMIT:
			m_oMovement = 1;
			break;
	}
	return 0;
}

/************************************************************************
Updates the display
************************************************************************/
int UpdateStatus(int panel)
{
	BOOL oEnable = 1;
	BOOL oResult = m_oUpdateActive;
	char* strActiveMode;

	if(m_oMovement != 0)
	{
		SetCtrlVal(panel,PANEL_RADIOBUTTON_1,0);
		SetCtrlVal(panel,PANEL_RADIOBUTTON_2,1);
		SetCtrlAttribute(panel,PANEL_ButtonMove,ATTR_LABEL_TEXT,"__Move Absolute");
	}
	else
	{
		SetCtrlVal(panel,PANEL_RADIOBUTTON_1,1);
		SetCtrlVal(panel,PANEL_RADIOBUTTON_2,0);
		SetCtrlAttribute(panel,PANEL_ButtonMove,ATTR_LABEL_TEXT,"__Move Relative");
	}

	if(oResult)
	{
		oResult = VCS_GetOperationMode(m_KeyHandle,m_wNodeId,&m_uMode,&m_dErrorCode);
		if(oResult)
		{
			switch(m_uMode)
			{
				case -6: strActiveMode = "Step/Direction Mode"; break;
				case -5: strActiveMode = "Master Encoder Mode"; break;
				case -3: strActiveMode = "Current Mode"; break;
				case -2: strActiveMode = "Velocity Mode"; break;
				case -1: strActiveMode = "Position Mode"; break;
				case 1: strActiveMode = "Profile Position Mode"; break;
				case 3: strActiveMode = "Profile Velocity Mode"; break;
				case 6: strActiveMode = "Homing Mode"; break;
				case 7: strActiveMode = "Interpolated Position Mode"; break;
				default: strActiveMode = "Unknown Mode";
			}
		}
		else
		{
			StopTimer();
			ShowErrorInformation(m_dErrorCode);

			strActiveMode = "Unknown Mode";
		}
	}
	else
	{
		strActiveMode = "Unknown Mode";
	}

	if(oResult)
	{
		oResult = VCS_GetEnableState(m_KeyHandle,m_wNodeId,&oEnable,&m_dErrorCode);

		if(oResult)
		{
			SetCtrlAttribute(panel,PANEL_DeviceSettings,ATTR_DIMMED,oEnable);
			SetCtrlAttribute(panel,PANEL_ButtonEnable,ATTR_DIMMED,oEnable);
			SetCtrlAttribute(panel,PANEL_ButtonDisable,ATTR_DIMMED,!oEnable);
			SetCtrlAttribute(panel,PANEL_ButtonMove,ATTR_DIMMED,!oEnable);
			SetCtrlAttribute(panel,PANEL_ButtonHalt,ATTR_DIMMED,!oEnable);
		}
		else
		{
			StopTimer();
			ShowErrorInformation(m_dErrorCode);
			
			SetCtrlAttribute(panel,PANEL_DeviceSettings,ATTR_DIMMED,oEnable);
			SetCtrlAttribute(panel,PANEL_ButtonEnable,ATTR_DIMMED,!oEnable);
			SetCtrlAttribute(panel,PANEL_ButtonDisable,ATTR_DIMMED,oEnable);
			SetCtrlAttribute(panel,PANEL_ButtonMove,ATTR_DIMMED,oEnable);
			SetCtrlAttribute(panel,PANEL_ButtonHalt,ATTR_DIMMED,oEnable);
		}
	}
	else
	{
		SetCtrlAttribute(panel,PANEL_DeviceSettings,ATTR_DIMMED,!oEnable);
		SetCtrlAttribute(panel,PANEL_ButtonEnable,ATTR_DIMMED,oEnable);
		SetCtrlAttribute(panel,PANEL_ButtonDisable,ATTR_DIMMED,oEnable);
		SetCtrlAttribute(panel,PANEL_ButtonMove,ATTR_DIMMED,oEnable);
		SetCtrlAttribute(panel,PANEL_ButtonHalt,ATTR_DIMMED,oEnable);
		SetCtrlAttribute(panel,PANEL_ButtonEnable,ATTR_DIMMED,oEnable);
	}

	if(oResult)
	{
		oResult = VCS_GetPositionIs(m_KeyHandle,m_wNodeId,&m_lPositionActual,&m_dErrorCode);
		if(!oResult)
		{
			StopTimer();
			ShowErrorInformation(m_dErrorCode);

			m_lPositionActual = 0;
			m_lPositionStart = 0;
		}
	}
	else
	{
		m_lPositionActual = 0;
		m_lPositionStart = 0;
	}

	SetCtrlVal(panel,PANEL_StateActiveMode,strActiveMode);
	SetCtrlVal(panel,PANEL_PositionActual,m_lPositionActual);
	SetCtrlVal(panel,PANEL_PositionStart,m_lPositionStart);

	SetCtrlVal(panel,PANEL_NodeId,m_wNodeId);

	return oResult;
}

/************************************************************************
If timer was started all 100ms this function will be called
************************************************************************/
int CVICALLBACK MonitorTimer (int panel, int control, int event,
		void *callbackData, int eventData1, int eventData2)
{
	switch (event)
	{
		case EVENT_TIMER_TICK:

			if(!UpdateStatus(panel))
			{
				StopTimer();
				
			break;
	}
		}
	return 0;
}

/************************************************************************
Changes target position
************************************************************************/
int CVICALLBACK PositionTarget (int panel, int control, int event,
		void *callbackData, int eventData1, int eventData2)
{
	switch (event)
	{
		case EVENT_COMMIT:		
			GetCtrlVal(panel,control,&m_lPositionTarget);
			break;
	}
	return 0;
}

/************************************************************************
Changes node id
************************************************************************/
int CVICALLBACK NodeId (int panel, int control, int event,
		void *callbackData, int eventData1, int eventData2)
{
	switch (event)
	{
		case EVENT_COMMIT:
			GetCtrlVal(panel,control,&m_wNodeId);
			break;
	}
	return 0;
}
