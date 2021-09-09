{*********************************************************************
**                  maxon motor ag, CH-6072 Sachseln
**********************************************************************
**
** File:            Definitions.pas
**
** Description:     Functions definitions for EposCmd.dll library
**
** Date:            13.11.2003
**
** Dev. Platform:   Turbo Pascal Interface Unit for EposCmd.dll
**
** Target:          Windows Operating Systems
**
** Written by:      maxon motor ag, CH-6072 Sachseln
**
** History:         See chapter History in the document EPOS Command Library
**
** Copyright © 2003 - 2021, maxon motor ag.
** All rights reserved.
********************************************************************}
{$D+,S+,L+}

Unit Definitions;

interface

uses Windows, Messages, SysUtils,  Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, ComCtrls, ImgList, ToolWin, ExtCtrls, CheckLst, Menus,
  ActiveX, Buttons;

{ --------------------------------------------------------------------------
                    IMPORTED FUNCTIONS PROTOTYPE
  -------------------------------------------------------------------------}

{Initialisation}
    function VCS_OpenDevice(DeviceName: PAnsiChar; ProtocolStackName: PAnsiChar; InterfaceName: PAnsiChar; PortName: PAnsiChar; var pErrorCode: LongWord): Longint; stdcall; external 'EposCmd.dll' name '_VCS_OpenDevice@20';
    function VCS_OpenDeviceDlg(var pErrorCode: LongWord): Longint; stdcall; external 'EposCmd.dll' name '_VCS_OpenDeviceDlg@4';
    function VCS_SetProtocolStackSettings(KeyHandle: Longint; Baudrate: Longword; Timeout: Longword; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_SetProtocolStackSettings@16';
    function VCS_GetProtocolStackSettings(KeyHandle: Longint; var pBaudrate: Longword; var pTimeout: Longword; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_GetProtocolStackSettings@16';
    function VCS_FindDeviceCommunicationSettings(var KeyHandle: Longint; pDeviceName: PAnsiChar; pProtocolStackName: PAnsiChar; pInterfaceName: PAnsiChar; pPortName: PAnsiChar; SizeName: Word; var pBaudrate: Longword; var pTimeout: Longword; var pNodeId: Word; DialogMode: LongInt; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_FindDeviceCommunicationSettings@44';
    function VCS_CloseAllDevices(var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_CloseAllDevices@4';
    function VCS_CloseDevice(KeyHandle: Longint; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_CloseDevice@8';

  {Gateway}
    function VCS_SetGatewaySettings(KeyHandle: Longint; Baudrate: Longword; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_SetGatewaySettings@12';
    function VCS_GetGatewaySettings(KeyHandle: Longint; var pBaudrate: Longword; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_GetGatewaySettings@12';

  {Subdevice}
    function VCS_OpenSubDevice(DeviceHandle: Longint; DeviceName: PAnsiChar; ProtocolStackName: PAnsiChar; var pErrorCode: LongWord): Longint; stdcall; external 'EposCmd.dll' name '_VCS_OpenSubDevice@16';
    function VCS_OpenSubDeviceDlg(DeviceHandle: Longint; var pErrorCode: LongWord): Longint; stdcall; external 'EposCmd.dll' name '_VCS_OpenSubDeviceDlg@8';
    function VCS_FindSubDeviceCommunicationSettings(DeviceHandle: Longint; var KeyHandle: Longint; pDeviceName: PAnsiChar; pProtocolStackName: PAnsiChar; SizeName: Word; var pBaudrate: Longword; var pNodeId: Word; DialogMode: LongInt; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_FindSubDeviceCommunicationSettings@36';
    function VCS_CloseAllSubDevices(DeviceHandle: Longint; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_CloseAllSubDevices@8';
    function VCS_CloseSubDevice(KeyHandle: Longint; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_CloseSubDevice@8';

  {Info}
    function VCS_GetDriverInfo(pLibraryName: PAnsiChar; MaxStrNameSize: Smallint; pLibraryVersion: PAnsiChar; MaxStrVersionSize: Smallint; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_GetDriverInfo@20';
    function VCS_GetVersion(KeyHandle: Longint; NodeID: Word; var pHardwareVersion: Smallint; var pSoftwareVersion: Smallint; var pApplicationNumber: Smallint; var pApplicationVersion: Smallint; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_GetVersion@28';
    function VCS_GetErrorInfo(ErrorCodeValue: Longint; pErrorInfo: PAnsiChar; MaxStrSize: Word): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_GetErrorInfo@12';

  {Advanced functions}
    function VCS_GetDeviceNameSelection(StartOfSelection: LongBool; pDeviceNameSel: PAnsiChar; MaxStrSize: Word; var pEndOfSelection: LongBool; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_GetDeviceNameSelection@20';
    function VCS_GetProtocolStackNameSelection(DeviceName: PAnsiChar; StartOfSelection: LongBool; pProtocolStackNameSel: PAnsiChar; MaxStrSize: Word; var pEndOfSelection: LongBool; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_GetProtocolStackNameSelection@24';
    function VCS_GetInterfaceNameSelection(DeviceName: PAnsiChar; ProtocolStackName: PAnsiChar; StartOfSelection: LongBool; pInterfaceNameSel: PAnsiChar; MaxStrSize: Word; var pEndOfSelection: LongBool; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_GetInterfaceNameSelection@28';
    function VCS_GetPortNameSelection(DeviceName: PAnsiChar; ProtocolStackName: PAnsiChar; InterfaceName: PAnsiChar; StartOfSelection: LongBool; pPortSel: PAnsiChar; MaxStrSize: Word; var pEndOfSelection: LongBool; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_GetPortNameSelection@32';
    function VCS_ResetPortNameSelection(DeviceName: PAnsiChar; ProtocolStackName: PAnsiChar; InterfaceName: PAnsiChar; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_ResetPortNameSelection@16';
    function VCS_GetBaudrateSelection(DeviceName: PAnsiChar; ProtocolStackName: PAnsiChar; InterfaceName: PAnsiChar; PortName: PAnsiChar; StartOfSelection: LongBool; var pBaudrateSel: Longint; var pEndOfSelection: LongBool; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_GetBaudrateSelection@32';
    function VCS_GetKeyHandle(DeviceName: PAnsiChar; ProtocolStackName: PAnsiChar; InterfaceName: PAnsiChar; PortName: PAnsiChar; var pKeyHandle: Longint; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_GetKeyHandle@24';
    function VCS_GetDeviceName(KeyHandle: Longint; pDeviceName: PAnsiChar; MaxStrSize: Word; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_GetDeviceName@16';
    function VCS_GetProtocolStackName(KeyHandle: Longint; pProtocolStackName: PAnsiChar; MaxStrSize: Word; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_GetProtocolStackName@16';
    function VCS_GetInterfaceName(KeyHandle: Longint; pInterfaceName: PAnsiChar; MaxStrSize: Word; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_GetInterfaceName@16';
    function VCS_GetPortName(KeyHandle: Longint; pPortName: PAnsiChar; MaxStrSize: Word; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_GetPortName@16';

  {General}
    function VCS_ImportParameter(KeyHandle: Longint; NodeID: Word; pParameterFileName: PAnsiChar; ShowDlg: LongBool; ShowMsg: LongBool; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_ImportParameter@24';
    function VCS_ExportParameter(KeyHandle: Longint; NodeID: Word; pParameterFileName: PAnsiChar; pFirmwareFileName: PAnsiChar; pUserID: PAnsiChar; pComment: PAnsiChar; ShowDlg: LongBool; ShowMsg: LongBool; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_ExportParameter@36';
    function VCS_SetObject(KeyHandle: Longint; NodeID: Word; ObjectIndex: Word; ObjectSubIndex: Byte; Data: Pointer; NbOfBytesToWrite: LongWord; var pNbOfBytesWritten: LongWord; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_SetObject@32';
    function VCS_GetObject(KeyHandle: Longint; NodeID: Word; ObjectIndex: Word; ObjectSubIndex: Byte; pData: Pointer; NbOfBytesToRead: LongWord; var pNbOfBytesRead: LongWord; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_GetObject@32';
    function VCS_Restore(KeyHandle: Longint; NodeID: Word; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_Restore@12';
    function VCS_Store(KeyHandle: Longint; NodeID: Word; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_Store@12';

{Advanced functions}
  {Motor}
    function VCS_SetMotorType(KeyHandle: Longint; NodeID: Word; MotorType: Smallint; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_SetMotorType@16';
    function VCS_SetDcMotorParameter(KeyHandle: Longint; NodeID: Word; NominalCurrent: Smallint; MaxOutputCurrent: Smallint; ThermalTimeConstant: Smallint; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_SetDcMotorParameter@24';
    function VCS_SetDcMotorParameterEx(KeyHandle: Longint; NodeID: Word; NominalCurrent: LongWord; MaxOutputCurrent: LongWord; ThermalTimeConstant: Smallint; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_SetDcMotorParameterEx@24';
    function VCS_SetEcMotorParameter(KeyHandle: Longint; NodeID: Word; NominalCurrent: Smallint; MaxOutputCurrent: Smallint; ThermalTimeConstant: Smallint; NbOfPolePairs: Byte; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_SetEcMotorParameter@28';
    function VCS_SetEcMotorParameterEx(KeyHandle: Longint; NodeID: Word; NominalCurrent: LongWord; MaxOutputCurrent: LongWord; ThermalTimeConstant: Smallint; NbOfPolePairs: Byte; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_SetEcMotorParameterEx@28';
    function VCS_GetMotorType(KeyHandle: Longint; NodeID: Word; var pMotorType: Smallint; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_GetMotorType@16';
    function VCS_GetDcMotorParameter(KeyHandle: Longint; NodeID: Word; var pNominalCurrent: Smallint; var pMaxOutputCurrent: Smallint; var pThermalTimeConstant: Smallint; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_GetDcMotorParameter@24';
    function VCS_GetDcMotorParameterEx(KeyHandle: Longint; NodeID: Word; var pNominalCurrent: LongWord; var pMaxOutputCurrent: LongWord; var pThermalTimeConstant: Smallint; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_GetDcMotorParameterEx@24';
    function VCS_GetEcMotorParameter(KeyHandle: Longint; NodeID: Word; var pNominalCurrent: Smallint; var pMaxOutputCurrent: Smallint; var pThermalTimeConstant: Smallint; var pNbOfPolePairs: Byte; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_GetEcMotorParameter@28';
    function VCS_GetEcMotorParameterEx(KeyHandle: Longint; NodeID: Word; var pNominalCurrent: LongWord; var pMaxOutputCurrent: LongWord; var pThermalTimeConstant: Smallint; var pNbOfPolePairs: Byte; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_GetEcMotorParameterEx@28';

  {Sensor}
    function VCS_SetSensorType(KeyHandle: Longint; NodeID: Word; SensorType: Smallint; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_SetSensorType@16';
    function VCS_SetIncEncoderParameter(KeyHandle: Longint; NodeID: Word; EncoderResolution: Longint; InvertedPolarity: Longint; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_SetIncEncoderParameter@20';
    function VCS_SetHallSensorParameter(KeyHandle: Longint; NodeID: Word; InvertedPolarity: Longint; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_SetHallSensorParameter@16';
    function VCS_SetSsiAbsEncoderParameter(KeyHandle: Longint; NodeID: Word; DataRate: Smallint; NbOfMultiTurnDataBits: Smallint; NbOfSingleTurnDataBits: Smallint; InvertedPolarity: Longint; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_SetSsiAbsEncoderParameter@28';
    function VCS_SetSsiAbsEncoderParameterEx(KeyHandle: Longint; NodeID: Word; DataRate: Smallint; NbOfMultiTurnDataBits: Smallint; NbOfSingleTurnDataBits: Smallint; NbOfSpecialDataBits: Smallint; InvertedPolarity: Longint; Timeout: Smallint; PowerupTime: Smallint; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_SetSsiAbsEncoderParameterEx@40';
    function VCS_GetSensorType(KeyHandle: Longint; NodeID: Word; var pSensorType: Smallint; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_GetSensorType@16';
    function VCS_GetIncEncoderParameter(KeyHandle: Longint; NodeID: Word; var pEncoderResolution: Longint; var pInvertedPolarity: Longint; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_GetIncEncoderParameter@20';
    function VCS_GetHallSensorParameter(KeyHandle: Longint; NodeID: Word; var pInvertedPolarity: Longint; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_GetHallSensorParameter@16';
    function VCS_GetSsiAbsEncoderParameter(KeyHandle: Longint; NodeID: Word; var pDataRate: Smallint; var pNbOfMultiTurnDataBits: Smallint; var pNbOfSingleTurnDataBits: Smallint; var pInvertedPolarity: Longint; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_GetSsiAbsEncoderParameter@28';
    function VCS_GetSsiAbsEncoderParameterEx(KeyHandle: Longint; NodeID: Word; var pDataRate: Smallint; var pNbOfMultiTurnDataBits: Smallint; var pNbOfSingleTurnDataBits: Smallint; var pNbOfSpecialDataBits: Smallint; var pInvertedPolarity: Longint; var pTimeout: Smallint; var pPowerupTime: Smallint; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_GetSsiAbsEncoderParameterEx@40';

  {Safety}
    function VCS_SetMaxFollowingError(KeyHandle: Longint; NodeID: Word; MaxFollowingError: Longint; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_SetMaxFollowingError@16';
    function VCS_GetMaxFollowingError(KeyHandle: Longint; NodeID: Word; var pMaxFollowingError: Longint; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_GetMaxFollowingError@16';
    function VCS_SetMaxProfileVelocity(KeyHandle: Longint; NodeID: Word; MaxProfileVelocity: Longword; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_SetMaxProfileVelocity@16';
    function VCS_GetMaxProfileVelocity(KeyHandle: Longint; NodeID: Word; var pMaxProfileVelocity: Longword; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_GetMaxProfileVelocity@16';
    function VCS_SetMaxAcceleration(KeyHandle: Longint; NodeID: Word; MaxAcceleration: Longword; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_SetMaxAcceleration@16';
    function VCS_GetMaxAcceleration(KeyHandle: Longint; NodeID: Word; var pMaxAcceleration: Longword; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_GetMaxAcceleration@16';

  {Controller Gains}
    function VCS_SetControllerGain(KeyHandle: Longint; NodeID: Word; EController: Word; EGain: Word; Value: Int64; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_SetControllerGain@28';
    function VCS_GetControllerGain(KeyHandle: Longint; NodeID: Word; EController: Word; EGain: Word; var pValue: Int64; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_GetControllerGain@24';

  {Inputs Outputs}
    function VCS_DigitalInputConfiguration(KeyHandle: Longint; NodeID: Word; DigInputNb: Word; Configuration: Word; Mask: LongBool; Polarity: LongBool; ExecutionMask: LongBool; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_DigitalInputConfiguration@32';
    function VCS_DigitalOutputConfiguration(KeyHandle: Longint; NodeID: Word; DigOutputNb: Word; Configuration: Word; State: LongBool; Mask: LongBool; Polarity: LongBool; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_DigitalOutputConfiguration@32';
    function VCS_AnalogInputConfiguration(KeyHandle: Longint; NodeID: Word; AnalogInputNb: Word; Configuration: Word; ExecutionMask: LongBool; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_AnalogInputConfiguration@24';
    function VCS_AnalogOutputConfiguration(KeyHandle: Longint; NodeID: Word; AnalogOutputNb: Word; Configuration: Word; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_AnalogOutputConfiguration@20';

  {Units}
    function VCS_SetVelocityUnits(KeyHandle: Longint; NodeID: Word; VelDimension: Byte; VelNotation: Shortint; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_SetVelocityUnits@20';
    function VCS_GetVelocityUnits(KeyHandle: Longint; NodeID: Word; var pVelDimension: Byte; var pVelNotation: Shortint; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_GetVelocityUnits@20';

  {Compatibility Functions (do not use)}
    function VCS_SetMotorParameter(KeyHandle: Longint; NodeID: Word; MotorType: Word; ContinuousCurrent: Word; PeakCurrent: Word; PolePair: Byte; ThermalTimeConstant: Word; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_SetMotorParameter@32';
    function VCS_GetMotorParameter(KeyHandle: Longint; NodeID: Word; var pMotorType: Word; var pContinuousCurrent: Word; var pPeakCurrent: Word; var pPolePair: Byte; var pThermalTimeConstant: Word; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_GetMotorParameter@32';
    function VCS_SetEncoderParameter(KeyHandle: Longint; NodeID: Word; Counts: Word; PositionSensorType: Word; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_SetEncoderParameter@20';
    function VCS_GetEncoderParameter(KeyHandle: Longint; NodeID: Word; var pCounts: Word; var pPositionSensorType: Word; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_GetEncoderParameter@20';

    function VCS_SetPositionRegulatorGain(KeyHandle: Longint; NodeID: Word; P: Word; I: Word; D: Word; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_SetPositionRegulatorGain@24';
    function VCS_SetPositionRegulatorFeedForward(KeyHandle: Longint; NodeID: Word; VelocityFeedForward: Word; AccelerationFeedForward: Word; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_SetPositionRegulatorFeedForward@20';
    function VCS_GetPositionRegulatorGain(KeyHandle: Longint; NodeID: Word; var pP: Word; var pI: Word; var pD: Word; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_GetPositionRegulatorGain@24';
    function VCS_GetPositionRegulatorFeedForward(KeyHandle: Longint; NodeID: Word; var pVelocityFeedForward: Word; var pAccelerationFeedForward: Word; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_GetPositionRegulatorFeedForward@20';

    function VCS_SetVelocityRegulatorGain(KeyHandle: Longint; NodeID: Word; P: Word; I: Word; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_SetVelocityRegulatorGain@20';
    function VCS_SetVelocityRegulatorFeedForward(KeyHandle: Longint; NodeID: Word; VelocityFeedForward: Word; AccelerationFeedForward: Word; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_SetVelocityRegulatorFeedForward@20';
    function VCS_GetVelocityRegulatorGain(KeyHandle: Longint; NodeID: Word; var pP: Word; var pI: Word; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_GetVelocityRegulatorGain@20';
    function VCS_GetVelocityRegulatorFeedForward(KeyHandle: Longint; NodeID: Word; var pVelocityFeedForward: Word; var pAccelerationFeedForward: Word; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_GetVelocityRegulatorFeedForward@20';

    function VCS_SetCurrentRegulatorGain(KeyHandle: Longint; NodeID: Word; P: Word; I: Word; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_SetCurrentRegulatorGain@20';
    function VCS_GetCurrentRegulatorGain(KeyHandle: Longint; NodeID: Word; var pP: Word; var pI: Word; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_GetCurrentRegulatorGain@20';

{Operational Mode}
    function VCS_SetOperationMode(KeyHandle: Longint; NodeID: Word; Mode: Shortint; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_SetOperationMode@16';
    function VCS_GetOperationMode(KeyHandle: Longint; NodeID: Word; var pMode: Shortint; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_GetOperationMode@16';

{State Machine}
    function VCS_ResetDevice(KeyHandle: Longint; NodeID: Word; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_ResetDevice@12';
    function VCS_SetState(KeyHandle: Longint; NodeID: Word; State: Word; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_SetState@16';
    function VCS_SetEnableState(KeyHandle: Longint; NodeID: Word; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_SetEnableState@12';
    function VCS_SetDisableState(KeyHandle: Longint; NodeID: Word; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_SetDisableState@12';
    function VCS_SetQuickStopState(KeyHandle: Longint; NodeID: Word; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_SetQuickStopState@12';
    function VCS_ClearFault(KeyHandle: Longint; NodeID: Word; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_ClearFault@12';
    function VCS_GetState(KeyHandle: Longint; NodeID: Word; var pState: Word; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_GetState@16';
    function VCS_GetEnableState(KeyHandle: Longint; NodeID: Word; var pIsEnabled: LongBool; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_GetEnableState@16';
    function VCS_GetDisableState(KeyHandle: Longint; NodeID: Word; var pIsDisabled: LongBool; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_GetDisableState@16';
    function VCS_GetQuickStopState(KeyHandle: Longint; NodeID: Word; var pIsQuickStopped: LongBool; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_GetQuickStopState@16';
    function VCS_GetFaultState(KeyHandle: Longint; NodeID: Word; var pIsInFault: LongBool; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_GetFaultState@16';

{Error Handling}
    function VCS_GetNbOfDeviceError(KeyHandle: Longint; NodeID: Word; var pNbDeviceError: Byte; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_GetNbOfDeviceError@16';
    function VCS_GetDeviceErrorCode(KeyHandle: Longint; NodeID: Word; DeviceErrorNumber: Byte; var pDeviceErrorCode: Longint; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_GetDeviceErrorCode@20';

{Motion Info}
    function VCS_GetMovementState(KeyHandle: Longint; NodeID: Word; var pTargetReached: LongBool; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_GetMovementState@16';
    function VCS_GetPositionIs(KeyHandle: Longint; NodeID: Word; var pPositionIs: Longint; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_GetPositionIs@16';
    function VCS_GetVelocityIs(KeyHandle: Longint; NodeID: Word; var pVelocityIs: Longint; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_GetVelocityIs@16';
    function VCS_GetVelocityIsAveraged(KeyHandle: Longint; NodeID: Word; var pVelocityIsAveraged: Longint; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_GetVelocityIsAveraged@16';
    function VCS_GetCurrentIs(KeyHandle: Longint; NodeID: Word; var pCurrentIs: Smallint; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_GetCurrentIs@16';
    function VCS_GetCurrentIsEx(KeyHandle: Longint; NodeID: Word; var pCurrentIs: Longint; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_GetCurrentIsEx@16';
    function VCS_GetCurrentIsAveraged(KeyHandle: Longint; NodeID: Word; var pCurrentIsAveraged: Smallint; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_GetCurrentIsAveraged@16';
    function VCS_GetCurrentIsAveragedEx(KeyHandle: Longint; NodeID: Word; var pCurrentIsAveraged: Longint; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_GetCurrentIsAveragedEx@16';
    function VCS_WaitForTargetReached(KeyHandle: Longint; NodeID: Word; Timeout: Longint; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_WaitForTargetReached@16';

{Profile Position Mode }
    function VCS_ActivateProfilePositionMode(KeyHandle: Longint; NodeID: Word; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_ActivateProfilePositionMode@12';
    function VCS_SetPositionProfile(KeyHandle: Longint; NodeID: Word; ProfileVelocity: LongWord; ProfileAcceleration: LongWord; ProfileDeceleration: LongWord; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_SetPositionProfile@24';
    function VCS_GetPositionProfile(KeyHandle: Longint; NodeID: Word; var pProfileVelocity: LongWord; var pProfileAcceleration: LongWord; var pProfileDeceleration: LongWord; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_GetPositionProfile@24';
    function VCS_MoveToPosition(KeyHandle: Longint; NodeID: Word; TargetPosition: Longint; Absolute: LongBool; Immediately: LongBool; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_MoveToPosition@24';
    function VCS_GetTargetPosition(KeyHandle: Longint; NodeID: Word; var pTargetPosition: Longint; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_GetTargetPosition@16';
    function VCS_HaltPositionMovement(KeyHandle: Longint; NodeID: Word; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_HaltPositionMovement@12';
  {Advanced Functions}
    function VCS_EnablePositionWindow(KeyHandle: Longint; NodeID: Word; PositionWindow: Longint; PositionWindowTime: Smallint; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_EnablePositionWindow@20';
    function VCS_DisablePositionWindow(KeyHandle: Longint; NodeID: Word; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_DisablePositionWindow@12';

{Profile Velocity Mode}
    function VCS_ActivateProfileVelocityMode(KeyHandle: Longint; NodeID: Word; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_ActivateProfileVelocityMode@12';
    function VCS_SetVelocityProfile(KeyHandle: Longint; NodeID: Word; ProfileAcceleration: LongWord; ProfileDeceleration: LongWord; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_SetVelocityProfile@20';
    function VCS_GetVelocityProfile(KeyHandle: Longint; NodeID: Word; var pProfileAcceleration: LongWord; var pProfileDeceleration: LongWord; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_GetVelocityProfile@20';
    function VCS_MoveWithVelocity(KeyHandle: Longint; NodeID: Word; TargetVelocity: LongInt; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_MoveWithVelocity@16';
    function VCS_GetTargetVelocity(KeyHandle: Longint; NodeID: Word; var pTargetVelocity: LongInt; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_GetTargetVelocity@16';
    function VCS_HaltVelocityMovement(KeyHandle: Longint; NodeID: Word; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_HaltVelocityMovement@12';
  {Advanced Functions}
    function VCS_EnableVelocityWindow(KeyHandle: Longint; NodeID: Word; VelocityWindow: Longint; VelocityWindowTime: Smallint; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_EnableVelocityWindow@20';
    function VCS_DisableVelocityWindow(KeyHandle: Longint; NodeID: Word; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_DisableVelocityWindow@12';

{Homing Mode}
    function VCS_ActivateHomingMode(KeyHandle: Longint; NodeID: Word; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_ActivateHomingMode@12';
    function VCS_SetHomingParameter(KeyHandle: Longint; NodeID: Word; HomingAcceleration: LongWord; SpeedSwitch: LongWord; SpeedIndex: LongWord; HomeOffset: Longint; CurrentThreshold: Word; HomePosition: Longint; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_SetHomingParameter@36';
    function VCS_GetHomingParameter(KeyHandle: Longint; NodeID: Word; var pHomingAcceleration: LongWord; var pSpeedSwitch: LongWord; var pSpeedIndex: LongWord; var pHomeOffset: Longint; var pCurrentThreshold: Word; var pHomePosition: Longint; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_GetHomingParameter@36';
    function VCS_FindHome(KeyHandle: Longint; NodeID: Word; HomingMode: Shortint; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_FindHome@16';
    function VCS_StopHoming(KeyHandle: Longint; NodeID: Word; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_StopHoming@12';
    function VCS_DefinePosition(KeyHandle: Longint; NodeID: Word; HomePosition: Longint; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_DefinePosition@16';
    function VCS_WaitForHomingAttained(KeyHandle: Longint; NodeID: Word; Timeout: Longint; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_WaitForHomingAttained@16';
    function VCS_GetHomingState(KeyHandle: Longint; NodeID: Word; var pHomingAttained: LongBool; var pHomingError: LongBool; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_GetHomingState@20';

{Interpolated Position Mode}
    function VCS_ActivateInterpolatedPositionMode(KeyHandle: Longint; NodeID: Word; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_ActivateInterpolatedPositionMode@12';
    function VCS_SetIpmBufferParameter(KeyHandle: Longint; NodeID: Word; UnderflowWarningLimit: Smallint; OverflowWarningLimit: Smallint; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_SetIpmBufferParameter@20';
    function VCS_GetIpmBufferParameter(KeyHandle: Longint; NodeID: Word; var pUnderflowWarningLimit: Smallint; var pOverflowWarningLimit: Smallint; var pMaxBufferSize: Longint; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_GetIpmBufferParameter@24';
    function VCS_ClearIpmBuffer(KeyHandle: Longint; NodeID: Word; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_ClearIpmBuffer@12';
    function VCS_GetFreeIpmBufferSize(KeyHandle: Longint; NodeID: Word; var pBufferSize: Longint; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_GetFreeIpmBufferSize@16';
    function VCS_AddPvtValueToIpmBuffer(KeyHandle: Longint; NodeID: Word; Position: Longint; Velocity: Longint; Time: Byte; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_AddPvtValueToIpmBuffer@24';
    function VCS_StartIpmTrajectory(KeyHandle: Longint; NodeID: Word; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_StartIpmTrajectory@12';
    function VCS_StopIpmTrajectory(KeyHandle: Longint; NodeID: Word; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_StartIpmTrajectory@12';
    function VCS_GetIpmStatus(KeyHandle: Longint; NodeID: Word; var pTrajectoryRunning: Longint; var pIsUnderflowWarning: Longint; var pIsOverflowWarning: Longint; var pIsVelocityWarning: Longint; var pIsAccelerationWarning: Longint; var pIsUnderflowError: Longint; var pIsOverflowError: Longint; var pIsVelocityError: Longint; var pIsAccelerationError: Longint; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_GetIpmStatus@48';

{Position Mode}
    function VCS_ActivatePositionMode(KeyHandle: Longint; NodeID: Word; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_ActivatePositionMode@12';
    function VCS_SetPositionMust(KeyHandle: Longint; NodeID: Word; PositionMust: Longint; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_SetPositionMust@16';
    function VCS_GetPositionMust(KeyHandle: Longint; NodeID: Word; var pPositionMust: Longint; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_GetPositionMust@16';

  {Advanced Functions}
    function VCS_ActivateAnalogPositionSetpoint(KeyHandle: Longint; NodeID: Word; AnalogInputNumber: Smallint; Scaling: Single; Offset: Longint; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_ActivateAnalogPositionSetpoint@24';
    function VCS_DeactivateAnalogPositionSetpoint(KeyHandle: Longint; NodeID: Word; AnalogInputNumber: Smallint; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_DeactivateAnalogPositionSetpoint@16';
    function VCS_EnableAnalogPositionSetpoint(KeyHandle: Longint; NodeID: Word; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_EnableAnalogPositionSetpoint@12';
    function VCS_DisableAnalogPositionSetpoint(KeyHandle: Longint; NodeID: Word; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_DisableAnalogPositionSetpoint@12';

{Velocity Mode}
    function VCS_ActivateVelocityMode(KeyHandle: Longint; NodeID: Word; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_ActivateVelocityMode@12';
    function VCS_SetVelocityMust(KeyHandle: Longint; NodeID: Word; VelocityMust: Longint; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_SetVelocityMust@16';
    function VCS_GetVelocityMust(KeyHandle: Longint; NodeID: Word; var pVelocityMust: Longint; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_GetVelocityMust@16';

  {Advanced Functions}
    function VCS_ActivateAnalogVelocitySetpoint(KeyHandle: Longint; NodeID: Word; AnalogInputNumber: Smallint; Scaling: Single; Offset: Longint; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_ActivateAnalogVelocitySetpoint@24';
    function VCS_DeactivateAnalogVelocitySetpoint(KeyHandle: Longint; NodeID: Word; AnalogInputNumber: Smallint; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_DeactivateAnalogVelocitySetpoint@16';
    function VCS_EnableAnalogVelocitySetpoint(KeyHandle: Longint; NodeID: Word; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_EnableAnalogVelocitySetpoint@12';
    function VCS_DisableAnalogVelocitySetpoint(KeyHandle: Longint; NodeID: Word; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_DisableAnalogVelocitySetpoint@12';

{Current Mode}
    function VCS_ActivateCurrentMode(KeyHandle: Longint; NodeID: Word; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_ActivateCurrentMode@12';
    function VCS_SetCurrentMust(KeyHandle: Longint; NodeID: Word; CurrentMust: Smallint; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_SetCurrentMust@16';
    function VCS_SetCurrentMustEx(KeyHandle: Longint; NodeID: Word; CurrentMust: Longint; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_SetCurrentMustEx@16';
    function VCS_GetCurrentMust(KeyHandle: Longint; NodeID: Word; var pCurrentMust: Smallint; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_GetCurrentMust@16';
    function VCS_GetCurrentMustEx(KeyHandle: Longint; NodeID: Word; var pCurrentMust: Longint; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_GetCurrentMustEx@16';

  {Advanced Functions}
    function VCS_ActivateAnalogCurrentSetpoint(KeyHandle: Longint; NodeID: Word; AnalogInputNumber: Smallint; Scaling: Single; Offset: Smallint; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_ActivateAnalogCurrentSetpoint@24';
    function VCS_DeactivateAnalogCurrentSetpoint(KeyHandle: Longint; NodeID: Word; AnalogInputNumber: Smallint; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_DeactivateAnalogCurrentSetpoint@16';
    function VCS_EnableAnalogCurrentSetpoint(KeyHandle: Longint; NodeID: Word; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_EnableAnalogCurrentSetpoint@12';
    function VCS_DisableAnalogCurrentSetpoint(KeyHandle: Longint; NodeID: Word; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_DisableAnalogCurrentSetpoint@12';

{Master Encoder Mode}
    function VCS_ActivateMasterEncoderMode(KeyHandle: Longint; NodeID: Word; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_ActivateMasterEncoderMode@12';
    function VCS_SetMasterEncoderParameter(KeyHandle: Longint; NodeID: Word; ScalingNumerator: Smallint; ScalingDenominator: Smallint; Polarity: Byte; MaxVelocity: Longint; MaxAcceleration: Longint; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_SetMasterEncoderParameter@32';
    function VCS_GetMasterEncoderParameter(KeyHandle: Longint; NodeID: Word; var pScalingNumerator: Smallint; var pScalingDenominator: Smallint; var pPolarity: Byte; var pMaxVelocity: Longint; var pMaxAcceleration: Longint; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_GetMasterEncoderParameter@32';

{Step Directio Mode}
    function VCS_ActivateStepDirectionMode(KeyHandle: Longint; NodeID: Word; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_ActivateStepDirectionMode@12';
    function VCS_SetStepDirectionParameter(KeyHandle: Longint; NodeID: Word; ScalingNumerator: Smallint; ScalingDenominator: Smallint; Polarity: Byte; MaxVelocity: Longint; MaxAcceleration: Longint; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_SetStepDirectionParameter@32';
    function VCS_GetStepDirectionParameter(KeyHandle: Longint; NodeID: Word; var pScalingNumerator: Smallint; var pScalingDenominator: Smallint; var pPolarity: Byte; var pMaxVelocity: Longint; var pMaxAcceleration: Longint; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_GetStepDirectionParameter@32';

{Inputs and Outputs}
  {General}
    function VCS_GetAllDigitalInputs(KeyHandle: Longint; NodeID: Word; var pInputs: Word; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_GetAllDigitalInputs@16';
    function VCS_GetAllDigitalOutputs(KeyHandle: Longint; NodeID: Word; var pOutputs: Word; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_GetAllDigitalOutputs@16';
    function VCS_SetAllDigitalOutputs(KeyHandle: Longint; NodeID: Word; Outputs: Word; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_SetAllDigitalOutputs@16';
    function VCS_GetAnalogInput(KeyHandle: Longint; NodeID: Word; Number: Word; var pAnalog: Word; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_GetAnalogInput@20';
    function VCS_GetAnalogInputVoltage(KeyHandle: Longint; NodeID: Word; Number: Word; var pVoltageValue: Longint; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_GetAnalogInputVoltage@20';
    function VCS_GetAnalogInputState(KeyHandle: Longint; NodeID: Word; Configuration: Word; var pStateValue: Longint; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_GetAnalogInputState@20';
    function VCS_SetAnalogOutput(KeyHandle: Longint; NodeID: Word; OutputNumber: Smallint; AnalogValue: Smallint; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_SetAnalogOutput@20';
    function VCS_SetAnalogOutputVoltage(KeyHandle: Longint; NodeID: Word; OutputNumber: Word; VoltageValue: Longint; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_SetAnalogOutputVoltage@20';
    function VCS_SetAnalogOutputState(KeyHandle: Longint; NodeID: Word; Configuration: Word; StateValue: Longint; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_SetAnalogOutputState@20';

  {Position Compare}
    function VCS_SetPositionCompareParameter(KeyHandle: Longint; NodeID: Word; OperationalMode: Byte; IntervalMode: Byte; DirectionDependency: Byte; IntervalWidth: Smallint; IntervalRepetitions: Smallint; PulseWidth: Smallint; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_SetPositionCompareParameter@36';
    function VCS_GetPositionCompareParameter(KeyHandle: Longint; NodeID: Word; var pOperationalMode: Byte; var pIntervalMode: Byte; var pDirectionDependency: Byte; var pIntervalWidth: Smallint; var pIntervalRepetitions: Smallint; var pPulseWidth: Smallint; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_GetPositionCompareParameter@36';
    function VCS_ActivatePositionCompare(KeyHandle: Longint; NodeID: Word; DigitalOutputNumber: Smallint; Polarity: Longint; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_ActivatePositionCompare@20';
    function VCS_DeactivatePositionCompare(KeyHandle: Longint; NodeID: Word; DigitalOutputNumber: Smallint; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_DeactivatePositionCompare@16';
    function VCS_EnablePositionCompare(KeyHandle: Longint; NodeID: Word; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_EnablePositionCompare@12';
    function VCS_DisablePositionCompare(KeyHandle: Longint; NodeID: Word; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_DisablePositionCompare@12';
    function VCS_SetPositionCompareReferencePosition(KeyHandle: Longint; NodeID: Word; ReferencePosition: Longint; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_SetPositionCompareReferencePosition@16';

    {Position Marker}
    function VCS_SetPositionMarkerParameter(KeyHandle: Longint; NodeID: Word; PositionMarkerEdgeType: Byte; PositionMarkerMode: Byte; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_SetPositionMarkerParameter@20';
    function VCS_GetPositionMarkerParameter(KeyHandle: Longint; NodeID: Word; var pPositionMarkerEdgeType: Byte; var pPositionMarkerMode: Byte; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_GetPositionMarkerParameter@20';
    function VCS_ActivatePositionMarker(KeyHandle: Longint; NodeID: Word; DigitalInputNumber: Smallint; Polarity: Longint; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_ActivatePositionMarker@20';
    function VCS_DeactivatePositionMarker(KeyHandle: Longint; NodeID: Word; DigitalInputNumber: Smallint; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_DeactivatePositionMarker@16';
    function VCS_ReadPositionMarkerCounter(KeyHandle: Longint; NodeID: Word; var pCount: Smallint; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_ReadPositionMarkerCounter@16';
    function VCS_ReadPositionMarkerCapturedPosition(KeyHandle: Longint; NodeID: Word; CounterIndex: Smallint; var pCapturedPosition: Longint; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_ReadPositionMarkerCapturedPosition@20';
    function VCS_ResetPositionMarkerCounter(KeyHandle: Longint; NodeID: Word; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_ResetPositionMarkerCounter@12';

{Data Recorder}
  {Setup}
    function VCS_SetRecorderParameter(KeyHandle: Longint; NodeID: Word; SamplingPeriod: Smallint; NbOfPrecedingSamples: Smallint; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_SetRecorderParameter@20';
    function VCS_GetRecorderParameter(KeyHandle: Longint; NodeID: Word; var pSamplingPeriod: Smallint; var pNbOfPrecedingSamples: Smallint; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_GetRecorderParameter@20';
    function VCS_EnableTrigger(KeyHandle: Longint; NodeID: Word; TriggerType: Byte; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_EnableTrigger@16';
    function VCS_DisableAllTriggers(KeyHandle: Longint; NodeID: Word; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_DisableAllTriggers@12';
    function VCS_ActivateChannel(KeyHandle: Longint; NodeID: Word; ChannelNumber: Byte; ObjectIndex: Smallint; ObjectSubIndex: Byte; ObjectSize: Byte; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_ActivateChannel@28';
    function VCS_DeactivateAllChannels(KeyHandle: Longint; NodeID: Word; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_DeactivateAllChannels@12';

  {Status}
    function VCS_StartRecorder(KeyHandle: Longint; NodeID: Word; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_StartRecorder@12';
    function VCS_StopRecorder(KeyHandle: Longint; NodeID: Word; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_StopRecorder@12';
    function VCS_ForceTrigger(KeyHandle: Longint; NodeID: Word; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_ForceTrigger@12';
    function VCS_IsRecorderRunning(KeyHandle: Longint; NodeID: Word; var pRunning: Longint; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_IsRecorderRunning@16';
    function VCS_IsRecorderTriggered(KeyHandle: Longint; NodeID: Word; var pTriggered: Longint; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_IsRecorderTriggered@16';

  {Data}
    function VCS_ReadChannelVectorSize(KeyHandle: Longint; NodeID: Word; var pVectorSize: Longint; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_ReadChannelVectorSize@16';
    function VCS_ReadChannelDataVector(KeyHandle: Longint; NodeID: Word; ChannelNumber: Byte; pDataVectorBuffer: Pointer; VectorBufferSize: Longint; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_ReadChannelDataVector@24';
    function VCS_ShowChannelDataDlg(KeyHandle: Longint; NodeID: Word; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_ShowChannelDataDlg@12';
    function VCS_ExportChannelDataToFile(KeyHandle: Longint; NodeID: Word; FileName: PAnsiChar; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_ExportChannelDataToFile@16';

  {Advanced Functions}
    function VCS_ReadDataBuffer(KeyHandle: Longint; NodeID: Word; pDataBuffer: Pointer; BufferSizeToRead: Longint; var pBufferSizeRead: Longint; var pVectorStartOffset: Smallint; var pMaxNbOfSamples: Smallint; var pNbOfRecordedSamples: Smallint; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_ReadDataBuffer@36';
    function VCS_ExtractChannelDataVector(KeyHandle: Longint; NodeID: Word; ChannelNumber: Byte; pDataBuffer: Pointer; BufferSize: Longint; pDataVectorBuffer: Pointer; VectorBufferSize: Longint; VectorStartOffset: Smallint; MaxNbOfSamples: Smallint; NbOfRecordedSamples: Smallint; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_ExtractChannelDataVector@44';

{CAN Layer Functions}
    function VCS_SendCANFrame(KeyHandle: Longint; CobID: Word; Length: Word; pData: Pointer; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_SendCANFrame@20';
    function VCS_ReadCANFrame(KeyHandle: Longint; CobID: Word; Length: Word; pData: Pointer; Timeout: Longint; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_ReadCANFrame@24';
    function VCS_RequestCANFrame(KeyHandle: Longint; CobID: Word; Length: Word; pData: Pointer; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_RequestCANFrame@20';
    function VCS_SendNMTService(KeyHandle: Longint; NodeID: Word; CommandSpecifier: Word; var pErrorCode: LongWord): LongBool; stdcall; external 'EposCmd.dll' name '_VCS_SendNMTService@16';

const
     TEST : Word = 100;

{Communication}
    {Dialog Mode}
    DM_PROGRESS_DLG                 : LongInt   = 0;
    DM_PROGRESS_AND_CONFIRM_DLG     : LongInt   = 1;
    DM_CONFIRM_DLG                  : LongInt   = 2;
    DM_NO_DLG                       : LongInt   = 3;

{Configuration}
    {MotorType}
    MT_DC_MOTOR                     :Smallint   = 1;
    MT_EC_SINUS_COMMUTATED_MOTOR    :Smallint   = 10;
    MT_EC_BLOCK_COMMUTATED_MOTOR    :Smallint   = 11;

{Configuration}
    {SensorType}
    ST_UNKNOWN                      :Smallint   = 0;
    ST_INC_ENCODER_3CHANNEL         :Smallint   = 1;
    ST_INC_ENCODER_2CHANNEL         :Smallint   = 2;
    ST_HALL_SENSORS                 :Smallint   = 3;
    ST_SSI_ABS_ENCODER_BINARY       :Smallint   = 4;
    ST_SSI_ABS_ENCODER_GREY         :Smallint   = 5;
    ST_INC_ENCODER2_3CHANNEL        :Smallint   = 6;
    ST_INC_ENCODER2_2CHANNEL        :Smallint   = 7;
    ST_ANALOG_INC_ENCODER_3CHANNEL  :Smallint   = 8;
    ST_ANALOG_INC_ENCODER_2CHANNEL  :Smallint   = 9;

{In- and outputs}
    {Digital input configuration}
    DIC_NEGATIVE_LIMIT_SWITCH       :Word       = 0;
    DIC_POSITIVE_LIMIT_SWITCH       :Word       = 1;
    DIC_HOME_SWITCH                 :Word       = 2;
    DIC_POSITION_MARKER             :Word       = 3;
    DIC_DRIVE_ENABLE                :Word       = 4;
    DIC_QUICK_STOP                  :Word       = 5;
    DIC_GENERAL_PURPOSE_J           :Word       = 6;
    DIC_GENERAL_PURPOSE_I           :Word       = 7;
    DIC_GENERAL_PURPOSE_H           :Word       = 8;
    DIC_GENERAL_PURPOSE_G           :Word       = 9;
    DIC_GENERAL_PURPOSE_F           :Word       = 10;
    DIC_GENERAL_PURPOSE_E           :Word       = 11;
    DIC_GENERAL_PURPOSE_D           :Word       = 12;
    DIC_GENERAL_PURPOSE_C           :Word       = 13;
    DIC_GENERAL_PURPOSE_B           :Word       = 14;
    DIC_GENERAL_PURPOSE_A           :Word       = 15;

    {Digital output configuration}
    DOC_READY_FAULT                 :Word       = 0;
    DOC_POSITION_COMPARE            :Word       = 1;
    DOC_GENERAL_PURPOSE_H           :Word       = 8;
    DOC_GENERAL_PURPOSE_G           :Word       = 9;
    DOC_GENERAL_PURPOSE_F           :Word       = 10;
    DOC_GENERAL_PURPOSE_E           :Word       = 11;
    DOC_GENERAL_PURPOSE_D           :Word       = 12;
    DOC_GENERAL_PURPOSE_C           :Word       = 13;
    DOC_GENERAL_PURPOSE_B           :Word       = 14;
    DOC_GENERAL_PURPOSE_A           :Word       = 15;

    {Analog input configuration}
    AIC_ANALOG_CURRENT_SETPOINT     :Word       = 0;
    AIC_ANALOG_VELOCITY_SETPOINT    :Word       = 1;
    AIC_ANALOG_POSITION_SETPOINT    :Word       = 2;
    AIC_GENERAL_PURPOSE_H           :Word       = 8;
    AIC_GENERAL_PURPOSE_G           :Word       = 9;
    AIC_GENERAL_PURPOSE_F           :Word       = 10;
    AIC_GENERAL_PURPOSE_E           :Word       = 11;
    AIC_GENERAL_PURPOSE_D           :Word       = 12;
    AIC_GENERAL_PURPOSE_C           :Word       = 13;
    AIC_GENERAL_PURPOSE_B           :Word       = 14;
    AIC_GENERAL_PURPOSE_A           :Word       = 15;

    {Analog output configuration}
    AOC_GENERAL_PURPOSE_A           :Word       = 0;
    AOC_GENERAL_PURPOSE_B           :Word       = 1;

{Units}
    {VelocityDimension}
    VD_RPM                          :Byte       = $A4;

    {VelocityNotation}
    VN_STANDARD                     :Shortint   = 0;
    VN_DECI                         :Shortint   = -1;
    VN_CENTI                        :Shortint   = -2;
    VN_MILLI                        :Shortint   = -3;

{Operational mode}
    OMD_PROFILE_POSITION_MODE       :Shortint   = 1;
    OMD_PROFILE_VELOCITY_MODE       :Shortint   = 3;
    OMD_HOMING_MODE                 :Shortint   = 6;
    OMD_INTERPOLATED_POSITION_MODE  :Shortint   = 7;
    OMD_POSITION_MODE               :Shortint   = -1;
    OMD_VELOCITY_MODE               :Shortint   = -2;
    OMD_CURRENT_MODE                :Shortint   = -3;
    OMD_MASTER_ENCODER_MODE         :Shortint   = -5;
    OMD_STEP_DIRECTION_MODE         :Shortint   = -6;

{States}
    ST_DISABLED                     :Word       = 0;
    ST_ENABLED                      :Word       = 1;
    ST_QUICKSTOP                    :Word       = 2;
    ST_FAULT                        :Word       = 3;

{Homing mode}
    {Homing method}
    HM_ACTUAL_POSITION                              :Shortint   = 35;
    HM_NEGATIVE_LIMIT_SWITCH                        :Shortint   = 17;
    HM_NEGATIVE_LIMIT_SWITCH_AND_INDEX              :Shortint   = 1;
    HM_POSITIVE_LIMIT_SWITCH                        :Shortint   = 18;
    HM_POSITIVE_LIMIT_SWITCH_AND_INDEX              :Shortint   = 2;
    HM_HOME_SWITCH_POSITIVE_SPEED                   :Shortint   = 23;
    HM_HOME_SWITCH_POSITIVE_SPEED_AND_INDEX         :Shortint   = 7;
    HM_HOME_SWITCH_NEGATIVE_SPEED                   :Shortint   = 27;
    HM_HOME_SWITCH_NEGATIVE_SPEED_AND_INDEX         :Shortint   = 11;
    HM_CURRENT_THRESHOLD_POSITIVE_SPEED             :Shortint   = -3;
    HM_CURRENT_THRESHOLD_POSITIVE_SPEED_AND_INDEX   :Shortint   = -1;
    HM_CURRENT_THRESHOLD_NEGATIVE_SPEED             :Shortint   = -4;
    HM_CURRENT_THRESHOLD_NEGATIVE_SPEED_AND_INDEX   :Shortint   = -2;
    HM_INDEX_POSITIVE_SPEED                         :Shortint   = 34;
    HM_INDEX_NEGATIVE_SPEED                         :Shortint   = 33;

{Input Output PositionMarker}
    {PositionMarkerEdgeType}
    PET_BOTH_EDGES                  :Byte       = 0;
    PET_RISING_EDGE                 :Byte       = 1;
    PET_FALLING_EDGE                :Byte       = 2;

    //PositionMarkerMode}
    PM_CONTINUOUS                   :Byte       = 0;
    PM_SINGLE                       :Byte       = 1;
    PM_MULTIPLE                     :Byte       = 2;

{Input Output PositionCompare}
    {PositionCompareOperationalMode}
    PCO_SINGLE_POSITION_MODE        :Byte       = 0;
    PCO_POSITION_SEQUENCE_MODE      :Byte       = 1;

    {PositionCompareIntervalMode}
    PCI_NEGATIVE_DIR_TO_REFPOS      :Byte       = 0;
    PCI_POSITIVE_DIR_TO_REFPOS      :Byte       = 1;
    PCI_BOTH_DIR_TO_REFPOS          :Byte       = 2;

    {PositionCompareDirectionDependency}
    PCD_MOTOR_DIRECTION_NEGATIVE    :Byte       = 0;
    PCD_MOTOR_DIRECTION_POSITIVE    :Byte       = 1;
    PCD_MOTOR_DIRECTION_BOTH        :Byte       = 2;

{Data recorder}
    {Trigger type}
    DR_MOVEMENT_START_TRIGGER       :Byte       = 1;
    DR_ERROR_TRIGGER                :Byte       = 2;
    DR_DIGITAL_INPUT_TRIGGER        :Byte       = 4;
    DR_MOVEMENT_END_TRIGGER         :Byte       = 8;

{CanLayer Functions}
    NCS_START_REMOTE_NODE           :Word       = 1;
    NCS_STOP_REMOTE_NODE            :Word       = 2;
    NCS_ENTER_PRE_OPERATIONAL       :Word       = 128;
    NCS_RESET_NODE                  :Word       = 129;
    NCS_RESET_COMMUNICATION         :Word       = 130;

{Controller Gains}
  {EController}
    EC_PI_CURRENT_CONTROLLER                    :Word   = 1;
    EC_PI_VELOCITY_CONTROLLER                   :Word   = 10;
    EC_PI_VELOCITY_CONTROLLER_WITH_OBSERVER     :Word   = 11;
    EC_PID_POSITION_CONTROLLER                  :Word   = 20;
    EC_DUAL_LOOP_POSITION_CONTROLLER            :Word   = 21;

  {EGain (EC_PI_CURRENT_CONTROLLER)}
    EG_PICC_P_GAIN                              :Word   = 1;
    EG_PICC_I_GAIN                              :Word   = 2;

    {EGain (EC_PI_VELOCITY_CONTROLLER)}
    EG_PIVC_P_GAIN                              :Word   = 1;
    EG_PIVC_I_GAIN                              :Word   = 2;
    EG_PIVC_FEED_FORWARD_VELOCITY_GAIN          :Word   = 10;
    EG_PIVC_FEED_FORWARD_ACCELERATION_GAIN      :Word   = 11;

    {EGain (EC_PI_VELOCITY_CONTROLLER_WITH_OBSERVER)}
    EG_PIVCWO_P_GAIN                            :Word   = 1;
    EG_PIVCWO_I_GAIN                            :Word   = 2;
    EG_PIVCWO_FEED_FORWARD_VELOCITY_GAIN        :Word   = 10;
    EG_PIVCWO_FEED_FORWARD_ACCELERATION_GAIN    :Word   = 11;
    EG_PIVCWO_OBSERVER_THETA_GAIN               :Word   = 20;
    EG_PIVCWO_OBSERVER_OMEGA_GAIN               :Word   = 21;
    EG_PIVCWO_OBSERVER_TAU_GAIN                 :Word   = 22;

    {EGain (EC_PID_POSITION_CONTROLLER)}
    EG_PIDPC_P_GAIN                             :Word   = 1;
    EG_PIDPC_I_GAIN                             :Word   = 2;
    EG_PIDPC_D_GAIN                             :Word   = 3;
    EG_PIDPC_FEED_FORWARD_VELOCITY_GAIN         :Word   = 10;
    EG_PIDPC_FEED_FORWARD_ACCELERATION_GAIN     :Word   = 11;

    {EGain (EC_DUAL_LOOP_POSITION_CONTROLLER)}
    EG_DLPC_AUXILIARY_LOOP_P_GAIN                           :Word    = 1;
    EG_DLPC_AUXILIARY_LOOP_I_GAIN                           :Word    = 2;
    EG_DLPC_AUXILIARY_LOOP_FEED_FORWARD_VELOCITY_GAIN       :Word    = 10;
    EG_DLPC_AUXILIARY_LOOP_FEED_FORWARD_ACCELERATION_GAIN   :Word   = 11;
    EG_DLPC_AUXILIARY_LOOP_OBSERVER_THETA_GAIN              :Word   = 20;
    EG_DLPC_AUXILIARY_LOOP_OBSERVER_OMEGA_GAIN              :Word   = 21;
    EG_DLPC_AUXILIARY_LOOP_OBSERVER_TAU_GAIN                :Word   = 22;
    EG_DLPC_MAIN_LOOP_P_GAIN_LOW                            :Word   = 101;
    EG_DLPC_MAIN_LOOP_P_GAIN_HIGH                           :Word   = 102;
    EG_DLPC_MAIN_LOOP_GAIN_SCHEDULING_WEIGHT                :Word   = 110;
    EG_DLPC_MAIN_LOOP_FILTER_COEFFICIENT_A                  :Word   = 120;
    EG_DLPC_MAIN_LOOP_FILTER_COEFFICIENT_B                  :Word   = 121;
    EG_DLPC_MAIN_LOOP_FILTER_COEFFICIENT_C                  :Word   = 122;
    EG_DLPC_MAIN_LOOP_FILTER_COEFFICIENT_D                  :Word   = 123;
    EG_DLPC_MAIN_LOOP_FILTER_COEFFICIENT_E                  :Word   = 124;

implementation
end.
