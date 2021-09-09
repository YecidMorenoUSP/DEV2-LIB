/**************************************************************************/
/* LabWindows/CVI User Interface Resource (UIR) Include File              */
/* Copyright (c) National Instruments 2010. All Rights Reserved.          */
/*                                                                        */
/* WARNING: Do not add to, delete from, or otherwise modify the contents  */
/*          of this include file.                                         */
/**************************************************************************/

#include <userint.h>

#ifdef __cplusplus
    extern "C" {
#endif

     /* Panels and Controls: */

#define  PANEL                           1
#define  PANEL_NodeId                    2       /* callback function: NodeId */
#define  PANEL_PositionTarget            3       /* callback function: PositionTarget */
#define  PANEL_PositionActual            4
#define  PANEL_PositionStart             5
#define  PANEL_StateActiveMode           6
#define  PANEL_OKBUTTON                  7       /* callback function: OkCallback */
#define  PANEL_DECORATION                8
#define  PANEL_MonitorTimer              9       /* callback function: MonitorTimer */
#define  PANEL_TEXTMSG_2                 10
#define  PANEL_TEXTMSG_4                 11
#define  PANEL_TEXTMSG_5                 12
#define  PANEL_DECORATION_3              13
#define  PANEL_RADIOBUTTON_2             14      /* callback function: RadioMove2 */
#define  PANEL_RADIOBUTTON_1             15      /* callback function: RadioMove1 */
#define  PANEL_TEXTMSG_6                 16
#define  PANEL_TEXTMSG_7                 17
#define  PANEL_TEXTMSG_8                 18
#define  PANEL_DeviceSettings            19      /* callback function: DeviceSettings */
#define  PANEL_ButtonHalt                20      /* callback function: Halt */
#define  PANEL_ButtonMove                21      /* callback function: Move */
#define  PANEL_ButtonDisable             22      /* callback function: Disable */
#define  PANEL_ButtonEnable              23      /* callback function: Enable */
#define  PANEL_DECORATION_2              24

     /* Menu Bars, Menus, and Menu Items: */

          /* (no menu bars in the resource file) */

     /* Callback Prototypes: */

int  CVICALLBACK DeviceSettings(int panel, int control, int event, void *callbackData, int eventData1, int eventData2);
int  CVICALLBACK Disable(int panel, int control, int event, void *callbackData, int eventData1, int eventData2);
int  CVICALLBACK Enable(int panel, int control, int event, void *callbackData, int eventData1, int eventData2);
int  CVICALLBACK Halt(int panel, int control, int event, void *callbackData, int eventData1, int eventData2);
int  CVICALLBACK MonitorTimer(int panel, int control, int event, void *callbackData, int eventData1, int eventData2);
int  CVICALLBACK Move(int panel, int control, int event, void *callbackData, int eventData1, int eventData2);
int  CVICALLBACK NodeId(int panel, int control, int event, void *callbackData, int eventData1, int eventData2);
int  CVICALLBACK OkCallback(int panel, int control, int event, void *callbackData, int eventData1, int eventData2);
int  CVICALLBACK PositionTarget(int panel, int control, int event, void *callbackData, int eventData1, int eventData2);
int  CVICALLBACK RadioMove1(int panel, int control, int event, void *callbackData, int eventData1, int eventData2);
int  CVICALLBACK RadioMove2(int panel, int control, int event, void *callbackData, int eventData1, int eventData2);

#ifdef __cplusplus
    }
#endif
