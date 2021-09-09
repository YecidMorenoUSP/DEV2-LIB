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

#define  PANEL                            1
#define  PANEL_OKBUTTON                   2       /* control type: command, callback function: OkCallback */
#define  PANEL_DECORATION                 3       /* control type: deco, callback function: (none) */
#define  PANEL_MonitorTimer               4       /* control type: timer, callback function: MonitorTimer */
#define  PANEL_DECORATION_3               5       /* control type: deco, callback function: (none) */
#define  PANEL_DeviceSettings             6       /* control type: command, callback function: DeviceSettings */
#define  PANEL_DECORATION_2               7       /* control type: deco, callback function: (none) */
#define  PANEL_TEXTMSG                    8       /* control type: textMsg, callback function: (none) */
#define  PANEL_StateActiveMode            9       /* control type: textMsg, callback function: (none) */
#define  PANEL_TEXTMSG_14                 10      /* control type: textMsg, callback function: (none) */
#define  PANEL_TEXTMSG_13                 11      /* control type: textMsg, callback function: (none) */
#define  PANEL_TEXTMSG_12                 12      /* control type: textMsg, callback function: (none) */
#define  PANEL_TEXTMSG_10                 13      /* control type: textMsg, callback function: (none) */
#define  PANEL_TEXTMSG_11                 14      /* control type: textMsg, callback function: (none) */
#define  PANEL_ButtonEnable               15      /* control type: command, callback function: Enable */
#define  PANEL_ButtonDisable              16      /* control type: command, callback function: Disable */
#define  PANEL_ButtonMove                 17      /* control type: command, callback function: Move */
#define  PANEL_ButtonHalt                 18      /* control type: command, callback function: Halt */
#define  PANEL_PositionTarget             19      /* control type: numeric, callback function: PositionTarget */
#define  PANEL_NodeId                     20      /* control type: numeric, callback function: NodeId */
#define  PANEL_PositionStart              21      /* control type: numeric, callback function: (none) */
#define  PANEL_PositionActual             22      /* control type: numeric, callback function: (none) */
#define  PANEL_RADIOBUTTON_2              23      /* control type: radioButton, callback function: RadioMove2 */
#define  PANEL_RADIOBUTTON_1              24      /* control type: radioButton, callback function: RadioMove1 */

     /* Control Arrays: */

          /* (no control arrays in the resource file) */

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
