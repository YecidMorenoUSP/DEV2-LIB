Option Strict Off
Option Explicit On
Module Module1

'*********************************************************************
'                   maxon motor ag, CH-6072 Sachseln
'*********************************************************************
'
' File:             Definitions.vb
'
' Description:      Function definitions for EposCmd64.dll library for Developer Platform Microsoft Visual Basic
'
' Dev. Platform:    Microsoft Visual Basic 2010
'
' Target:           Windows 64-Bit Operating Systems
'
' Written by:       maxon motor ag, CH-6072 Sachseln
'
' History:          See chapter History in the document EPOS Command Library
'
' Copyright © 2003 - 2021, maxon motor ag.
' All rights reserved.
'*********************************************************************

' --------------------------------------------------------------------------
'                   IMPORTED FUNCTIONS PROTOTYPE
' --------------------------------------------------------------------------

'*************************************************************************************************************************************
' INITIALISATION FUNCTIONS
'************************************************************************************************************************************/

'Communication
Declare Function VCS_OpenDevice Lib "EposCmd64.dll" Alias "VCS_OpenDevice" (ByVal DeviceName As String, ByVal ProtocolStackName As String, ByVal InterfaceName As String, ByVal PortName As String, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_OpenDeviceDlg Lib "EposCmd64.dll" Alias "VCS_OpenDeviceDlg" (ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_SetProtocolStackSettings Lib "EposCmd64.dll" Alias "VCS_SetProtocolStackSettings" (ByVal KeyHandle As Integer, ByVal Baudrate As UInteger, ByVal Timeout As UInteger, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_GetProtocolStackSettings Lib "EposCmd64.dll" Alias "VCS_GetProtocolStackSettings" (ByVal KeyHandle As Integer, ByRef pBaudrate As UInteger, ByRef pTimeout As UInteger, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_FindDeviceCommunicationSettings Lib "EposCmd64.dll" Alias "VCS_FindDeviceCommunicationSettings" (ByRef KeyHandle As Integer, ByVal pDeviceName As String, ByVal pProtocolStackName As String, ByVal pInterfaceName As String, ByVal pPortName As String, ByVal SizeName As UShort, ByRef pBaudrate As UInteger, ByRef pTimeout As UInteger, ByRef pNodeId As UShort, ByVal DialogMode As Integer, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_CloseAllDevices Lib "EposCmd64.dll" Alias "VCS_CloseAllDevices" (ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_CloseDevice Lib "EposCmd64.dll" Alias "VCS_CloseDevice" (ByVal KeyHandle As Integer, ByRef pErrorCode As UInteger) As Integer

'Gateway
Declare Function VCS_SetGatewaySettings Lib "EposCmd64.dll" Alias "VCS_SetGatewaySettings" (ByVal KeyHandle As Integer, ByVal Baudrate As UInteger, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_GetGatewaySettings Lib "EposCmd64.dll" Alias "VCS_GetGatewaySettings" (ByVal KeyHandle As Integer, ByRef pBaudrate As UInteger, ByRef pErrorCode As UInteger) As Integer

'Subdevice
Declare Function VCS_OpenSubDevice Lib "EposCmd64.dll" Alias "VCS_OpenSubDevice" (ByVal DeviceHandle As Integer, ByVal DeviceName As String, ByVal ProtocolStackName As String, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_OpenSubDeviceDlg Lib "EposCmd64.dll" Alias "VCS_OpenSubDeviceDlg" (ByVal DeviceHandle As Integer, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_FindSubDeviceCommunicationSettings Lib "EposCmd64.dll" Alias "VCS_FindSubDeviceCommunicationSettings" (ByVal DeviceHandle As Integer, ByRef pKeyHandle As Integer, ByVal pDeviceName As String, ByVal pProtocolStackName As String, ByVal SizeName As UShort, ByRef pBaudrate As UInteger, ByRef pNodeId As UShort, ByVal DialogMode As Integer, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_CloseSubDevice Lib "EposCmd64.dll" Alias "VCS_CloseSubDevice" (ByVal KeyHandle As Integer, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_CloseAllSubDevices Lib "EposCmd64.dll" Alias "VCS_CloseAllSubDevices" (ByVal DeviceHandle As Integer, ByRef pErrorCode As UInteger) As Integer

'Info
Declare Function VCS_GetDriverInfo Lib "EposCmd64.dll" Alias "VCS_GetDriverInfo" (ByVal pLibraryName As String, ByVal MaxStrNameSize As UShort, ByVal pLibraryVersion As String, ByVal MaxStrVersionSize As UShort, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_GetVersion Lib "EposCmd64.dll" Alias "VCS_GetVersion" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByRef pHardwareVersion As UShort, ByRef pSoftwareVersion As UShort, ByRef pApplicationNumber As UShort, ByRef pApplicationVersion As UShort, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_GetErrorInfo Lib "EposCmd64.dll" Alias "VCS_GetErrorInfo" (ByVal ErrorCodeValue As Integer, ByVal pErrorInfo As String, ByVal MaxStrSize As UShort) As Integer

'Advanced Functions
Declare Function VCS_GetDeviceNameSelection Lib "EposCmd64.dll" Alias "VCS_GetDeviceNameSelection" (ByVal StartOfSelection As Integer, ByVal pDeviceNameSel As String, ByVal MaxStrSize As UShort, ByRef pEndOfSelection As Integer, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_GetProtocolStackNameSelection Lib "EposCmd64.dll" Alias "VCS_GetProtocolStackNameSelection" (ByVal DeviceName As String, ByVal StartOfSelection As Integer, ByVal pProtocolStackNameSel As String, ByVal MaxStrSize As UShort, ByRef pEndOfSelection As Integer, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_GetInterfaceNameSelection Lib "EposCmd64.dll" Alias "VCS_GetInterfaceNameSelection" (ByVal DeviceName As String, ByVal ProtocolStackName As String, ByVal StartOfSelection As Integer, ByVal pInterfaceNameSel As String, ByVal MaxStrSize As UShort, ByRef pEndOfSelection As Integer, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_GetPortNameSelection Lib "EposCmd64.dll" Alias "VCS_GetPortNameSelection" (ByVal DeviceName As String, ByVal ProtocolStackName As String, ByVal InterfaceName As String, ByVal StartOfSelection As Integer, ByVal pPortSel As String, ByVal MaxStrSize As UShort, ByRef pEndOfSelection As Integer, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_ResetPortNameSelection Lib "EposCmd64.dll" Alias "VCS_ResetPortNameSelection" (ByVal DeviceName As String, ByVal ProtocolStackName As String, ByVal InterfaceName As String, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_GetBaudrateSelection Lib "EposCmd64.dll" Alias "VCS_GetBaudrateSelection" (ByVal DeviceName As String, ByVal ProtocolStackName As String, ByVal InterfaceName As String, ByVal PortName As String, ByVal StartOfSelection As Integer, ByRef pBaudrateSel As Integer, ByRef pEndOfSelection As Integer, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_GetKeyHandle Lib "EposCmd64.dll" Alias "VCS_GetKeyHandle" (ByVal DeviceName As String, ByVal ProtocolStackName As String, ByVal InterfaceName As String, ByVal PortName As String, ByRef pKeyHandle As Integer, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_GetDeviceName Lib "EposCmd64.dll" Alias "VCS_GetDeviceName" (ByVal KeyHandle As Integer, ByVal pDeviceName As String, ByVal MaxStrSize As UShort, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_GetProtocolStackName Lib "EposCmd64.dll" Alias "VCS_GetProtocolStackName" (ByVal KeyHandle As Integer, ByVal pProtocolStackName As String, ByVal MaxStrSize As UShort, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_GetInterfaceName Lib "EposCmd64.dll" Alias "VCS_GetInterfaceName" (ByVal KeyHandle As Integer, ByVal pInterfaceName As String, ByVal MaxStrSize As UShort, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_GetPortName Lib "EposCmd64.dll" Alias "VCS_GetPortName" (ByVal KeyHandle As Integer, ByVal pPortName As String, ByVal MaxStrSize As UShort, ByRef pErrorCode As UInteger) As Integer

'*************************************************************************************************************************************
' CONFIGURATION FUNCTIONS
'************************************************************************************************************************************/

'General
Declare Function VCS_ImportParameter Lib "EposCmd64.dll" Alias "VCS_ImportParameter" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByVal pParameterFileName As String, ByVal ShowDlg As Integer, ByVal ShowMsg As Integer, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_ExportParameter Lib "EposCmd64.dll" Alias "VCS_ExportParameter" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByVal pParameterFileName As String, ByVal pFirmwareFileName As String, ByVal pUserID As String, ByVal pComment As String, ByVal ShowDlg As Integer, ByVal ShowMsg As Integer, ByRef pErrorCode As UInteger) As Integer

Declare Function VCS_SetObject Lib "EposCmd64.dll" Alias "VCS_SetObject" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByVal ObjectIndex As UShort, ByVal ObjectSubIndex As Byte, ByRef Data As SByte, ByVal NbOfBytesToWrite As Integer, ByRef pNbOfBytesWritten As Integer, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_SetObject Lib "EposCmd64.dll" Alias "VCS_SetObject" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByVal ObjectIndex As UShort, ByVal ObjectSubIndex As Byte, ByRef Data As Integer, ByVal NbOfBytesToWrite As Integer, ByRef pNbOfBytesWritten As Integer, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_SetObject Lib "EposCmd64.dll" Alias "VCS_SetObject" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByVal ObjectIndex As UShort, ByVal ObjectSubIndex As Byte, ByRef Data As Long, ByVal NbOfBytesToWrite As Integer, ByRef pNbOfBytesWritten As Integer, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_SetObject Lib "EposCmd64.dll" Alias "VCS_SetObject" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByVal ObjectIndex As UShort, ByVal ObjectSubIndex As Byte, ByRef Data As Byte, ByVal NbOfBytesToWrite As Integer, ByRef pNbOfBytesWritten As Integer, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_SetObject Lib "EposCmd64.dll" Alias "VCS_SetObject" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByVal ObjectIndex As UShort, ByVal ObjectSubIndex As Byte, ByRef Data As UShort, ByVal NbOfBytesToWrite As Integer, ByRef pNbOfBytesWritten As Integer, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_SetObject Lib "EposCmd64.dll" Alias "VCS_SetObject" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByVal ObjectIndex As UShort, ByVal ObjectSubIndex As Byte, ByRef Data As UInteger, ByVal NbOfBytesToWrite As Integer, ByRef pNbOfBytesWritten As Integer, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_SetObject Lib "EposCmd64.dll" Alias "VCS_SetObject" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByVal ObjectIndex As UShort, ByVal ObjectSubIndex As Byte, ByRef Data As ULong, ByVal NbOfBytesToWrite As Integer, ByRef pNbOfBytesWritten As Integer, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_SetObject Lib "EposCmd64.dll" Alias "VCS_SetObject" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByVal ObjectIndex As UShort, ByVal ObjectSubIndex As Byte, ByRef Data As String, ByVal NbOfBytesToWrite As Integer, ByRef pNbOfBytesWritten As Integer, ByRef pErrorCode As UInteger) As Integer

Declare Function VCS_GetObject Lib "EposCmd64.dll" Alias "VCS_GetObject" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByVal ObjectIndex As UShort, ByVal ObjectSubIndex As Byte, ByRef pData As SByte, ByVal NbOfBytesToRead As Integer, ByRef pNbOfBytesRead As Integer, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_GetObject Lib "EposCmd64.dll" Alias "VCS_GetObject" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByVal ObjectIndex As UShort, ByVal ObjectSubIndex As Byte, ByRef pData As Integer, ByVal NbOfBytesToRead As Integer, ByRef pNbOfBytesRead As Integer, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_GetObject Lib "EposCmd64.dll" Alias "VCS_GetObject" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByVal ObjectIndex As UShort, ByVal ObjectSubIndex As Byte, ByRef pData As Long, ByVal NbOfBytesToRead As Integer, ByRef pNbOfBytesRead As Integer, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_GetObject Lib "EposCmd64.dll" Alias "VCS_GetObject" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByVal ObjectIndex As UShort, ByVal ObjectSubIndex As Byte, ByRef pData As Byte, ByVal NbOfBytesToRead As Integer, ByRef pNbOfBytesRead As Integer, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_GetObject Lib "EposCmd64.dll" Alias "VCS_GetObject" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByVal ObjectIndex As UShort, ByVal ObjectSubIndex As Byte, ByRef pData As UShort, ByVal NbOfBytesToRead As Integer, ByRef pNbOfBytesRead As Integer, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_GetObject Lib "EposCmd64.dll" Alias "VCS_GetObject" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByVal ObjectIndex As UShort, ByVal ObjectSubIndex As Byte, ByRef pData As UInteger, ByVal NbOfBytesToRead As Integer, ByRef pNbOfBytesRead As Integer, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_GetObject Lib "EposCmd64.dll" Alias "VCS_GetObject" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByVal ObjectIndex As UShort, ByVal ObjectSubIndex As Byte, ByRef pData As ULong, ByVal NbOfBytesToRead As Integer, ByRef pNbOfBytesRead As Integer, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_GetObject Lib "EposCmd64.dll" Alias "VCS_GetObject" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByVal ObjectIndex As UShort, ByVal ObjectSubIndex As Byte, ByRef pData As String, ByVal NbOfBytesToRead As Integer, ByRef pNbOfBytesRead As Integer, ByRef pErrorCode As UInteger) As Integer

Declare Function VCS_Restore Lib "EposCmd64.dll" Alias "VCS_Restore" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_Store Lib "EposCmd64.dll" Alias "VCS_Store" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByRef pErrorCode As UInteger) As Integer

'Advanced Functions
'Motor
Declare Function VCS_SetMotorType Lib "EposCmd64.dll" Alias "VCS_SetMotorType" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByVal MotorType As UShort, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_SetDcMotorParameter Lib "EposCmd64.dll" Alias "VCS_SetDcMotorParameter" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByVal NominalCurrent As UShort, ByVal MaxOutputCurrent As UShort, ByVal ThermalTimeConstant As UShort, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_SetDcMotorParameterEx Lib "EposCmd64.dll" Alias "VCS_SetDcMotorParameterEx" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByVal NominalCurrent As UInteger, ByVal MaxOutputCurrent As UInteger, ByVal ThermalTimeConstant As UShort, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_SetEcMotorParameter Lib "EposCmd64.dll" Alias "VCS_SetEcMotorParameter" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByVal NominalCurrent As UShort, ByVal MaxOutputCurrent As UShort, ByVal ThermalTimeConstant As UShort, ByVal NbOfPolePairs As Byte, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_SetEcMotorParameterEx Lib "EposCmd64.dll" Alias "VCS_SetEcMotorParameterEx" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByVal NominalCurrent As UInteger, ByVal MaxOutputCurrent As UInteger, ByVal ThermalTimeConstant As UShort, ByVal NbOfPolePairs As Byte, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_GetMotorType Lib "EposCmd64.dll" Alias "VCS_GetMotorType" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByRef pMotorType As UShort, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_GetDcMotorParameter Lib "EposCmd64.dll" Alias "VCS_GetDcMotorParameter" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByRef pNominalCurrent As UShort, ByRef pMaxOutputCurrent As UShort, ByRef pThermalTimeConstant As UShort, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_GetDcMotorParameterEx Lib "EposCmd64.dll" Alias "VCS_GetDcMotorParameterEx" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByRef pNominalCurrent As UInteger, ByRef pMaxOutputCurrent As UInteger, ByRef pThermalTimeConstant As UShort, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_GetEcMotorParameter Lib "EposCmd64.dll" Alias "VCS_GetEcMotorParameter" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByRef pNominalCurrent As UShort, ByRef pMaxOutputCurrent As UShort, ByRef pThermalTimeConstant As UShort, ByRef pNbOfPolePairs As Byte, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_GetEcMotorParameterEx Lib "EposCmd64.dll" Alias "VCS_GetEcMotorParameterEx" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByRef pNominalCurrent As UInteger, ByRef pMaxOutputCurrent As UInteger, ByRef pThermalTimeConstant As UShort, ByRef pNbOfPolePairs As Byte, ByRef pErrorCode As UInteger) As Integer

'Sensor
Declare Function VCS_SetSensorType Lib "EposCmd64.dll" Alias "VCS_SetSensorType" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByVal SensorType As UShort, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_SetIncEncoderParameter Lib "EposCmd64.dll" Alias "VCS_SetIncEncoderParameter" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByVal EncoderResolution As UInteger, ByVal InvertedPolarity As Integer, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_SetHallSensorParameter Lib "EposCmd64.dll" Alias "VCS_SetHallSensorParameter" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByVal InvertedPolarity As Integer, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_SetSsiAbsEncoderParameter Lib "EposCmd64.dll" Alias "VCS_SetSsiAbsEncoderParameter" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByVal DataRate As UShort, ByVal NbOfMultiTurnDataBits As UShort, ByVal NbOfSingleTurnDataBits As UShort, ByVal InvertedPolarity As Integer, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_GetSensorType Lib "EposCmd64.dll" Alias "VCS_GetSensorType" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByRef pSensorType As UShort, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_GetIncEncoderParameter Lib "EposCmd64.dll" Alias "VCS_GetIncEncoderParameter" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByRef pEncoderResolution As Integer, ByRef pInvertedPolarity As Integer, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_GetHallSensorParameter Lib "EposCmd64.dll" Alias "VCS_GetHallSensorParameter" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByRef pInvertedPolarity As Integer, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_GetSsiAbsEncoderParameter Lib "EposCmd64.dll" Alias "VCS_GetSsiAbsEncoderParameter" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByRef pDataRate As UShort, ByRef pNbOfMultiTurnDataBits As UShort, ByRef pNbOfSingleTurnDataBits As UShort, ByRef pInvertedPolarity As Integer, ByRef pErrorCode As UInteger) As Integer

'Safety
Declare Function VCS_SetMaxFollowingError Lib "EposCmd64.dll" Alias "VCS_SetMaxFollowingError" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByVal MaxFollowingError As UInteger, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_GetMaxFollowingError Lib "EposCmd64.dll" Alias "VCS_GetMaxFollowingError" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByRef pMaxFollowingError As UInteger, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_SetMaxProfileVelocity Lib "EposCmd64.dll" Alias "VCS_SetMaxProfileVelocity" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByVal MaxProfileVelocity As UInteger, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_GetMaxProfileVelocity Lib "EposCmd64.dll" Alias "VCS_GetMaxProfileVelocity" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByRef pMaxProfileVelocity As UInteger, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_SetMaxAcceleration Lib "EposCmd64.dll" Alias "VCS_SetMaxAcceleration" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByVal MaxAcceleration As UInteger, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_GetMaxAcceleration Lib "EposCmd64.dll" Alias "VCS_GetMaxAcceleration" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByRef pMaxAcceleration As UInteger, ByRef pErrorCode As UInteger) As Integer

'Controller Gains
Declare Function VCS_SetControllerGain Lib "EposCmd64.dll" Alias "VCS_SetControllerGain" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByVal EController As UShort, ByVal EGain As UShort, ByVal Value As ULong, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_GetControllerGain Lib "EposCmd64.dll" Alias "VCS_GetControllerGain" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByVal EController As UShort, ByVal EGain As UShort, ByRef pValue As ULong, ByRef pErrorCode As UInteger) As Integer

'Inputs/Outputs
Declare Function VCS_DigitalInputConfiguration Lib "EposCmd64.dll" Alias "VCS_DigitalInputConfiguration" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByVal DigInputNb As UShort, ByVal Configuration As UShort, ByVal Mask As Integer, ByVal Polarity As Integer, ByVal ExecutionMask As Integer, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_DigitalOutputConfiguration Lib "EposCmd64.dll" Alias "VCS_DigitalOutputConfiguration" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByVal DigOutputNb As UShort, ByVal Configuration As UShort, ByVal State As Integer, ByVal Mask As Integer, ByVal Polarity As Integer, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_AnalogInputConfiguration Lib "EposCmd64.dll" Alias "VCS_AnalogInputConfiguration" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByVal AnalogInputNb As UShort, ByVal Configuration As UShort, ByVal ExecutionMask As Integer, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_AnalogOutputConfiguration Lib "EposCmd64.dll" Alias "VCS_AnalogOutputConfiguration" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByVal AnalogOutputNb As UShort, ByVal Configuration As UShort, ByRef pErrorCode As UInteger) As Integer

'Units
Declare Function VCS_SetVelocityUnits Lib "EposCmd64.dll" Alias "VCS_SetVelocityUnits" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByVal VelDimension As Byte, ByVal VelNotation As SByte, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_GetVelocityUnits Lib "EposCmd64.dll" Alias "VCS_GetVelocityUnits" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByRef pVelDimension As Byte, ByRef pVelNotation As SByte, ByRef pErrorCode As UInteger) As Integer

'Compatibility Functions (do not use)
Declare Function VCS_SetMotorParameter Lib "EposCmd64.dll" Alias "VCS_SetMotorParameter" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByVal MotorType As UShort, ByVal ContinuousCurrent As UShort, ByVal PeakCurrent As UShort, ByVal PolePair As Byte, ByVal ThermalTimeConstant As UShort, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_GetMotorParameter Lib "EposCmd64.dll" Alias "VCS_GetMotorParameter" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByRef pMotorType As UShort, ByRef pContinuousCurrent As UShort, ByRef pPeakCurrent As UShort, ByRef pPolePair As Byte, ByRef pThermalTimeConstant As UShort, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_SetEncoderParameter Lib "EposCmd64.dll" Alias "VCS_SetEncoderParameter" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByVal Counts As UShort, ByVal PositionSensorType As UShort, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_GetEncoderParameter Lib "EposCmd64.dll" Alias "VCS_GetEncoderParameter" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByRef pCounts As UShort, ByRef pPositionSensorType As UShort, ByRef pErrorCode As UInteger) As Integer

Declare Function VCS_SetPositionRegulatorGain Lib "EposCmd64.dll" Alias "VCS_SetPositionRegulatorGain" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByVal P As UShort, ByVal I As UShort, ByVal D As UShort, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_SetPositionRegulatorFeedForward Lib "EposCmd64.dll" Alias "VCS_SetPositionRegulatorFeedForward" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByVal VelocityFeedForward As UShort, ByVal AccelerationFeedForward As UShort, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_GetPositionRegulatorGain Lib "EposCmd64.dll" Alias "VCS_GetPositionRegulatorGain" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByRef pP As UShort, ByRef pI As UShort, ByRef pD As UShort, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_GetPositionRegulatorFeedForward Lib "EposCmd64.dll" Alias "VCS_GetPositionRegulatorFeedForward" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByRef pVelocityFeedForward As UShort, ByRef pAccelerationFeedForward As UShort, ByRef pErrorCode As UInteger) As Integer

Declare Function VCS_SetVelocityRegulatorGain Lib "EposCmd64.dll" Alias "VCS_SetVelocityRegulatorGain" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByVal P As UShort, ByVal I As UShort, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_SetVelocityRegulatorFeedForward Lib "EposCmd64.dll" Alias "VCS_SetVelocityRegulatorFeedForward" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByVal VelocityFeedForward As UShort, ByVal AccelerationFeedForward As UShort, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_GetVelocityRegulatorGain Lib "EposCmd64.dll" Alias "VCS_GetVelocityRegulatorGain" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByRef pP As UShort, ByRef pI As UShort, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_GetVelocityRegulatorFeedForward Lib "EposCmd64.dll" Alias "VCS_GetVelocityRegulatorFeedForward" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByRef pVelocityFeedForward As UShort, ByRef pAccelerationFeedForward As UShort, ByRef pErrorCode As UInteger) As Integer

Declare Function VCS_SetCurrentRegulatorGain Lib "EposCmd64.dll" Alias "VCS_SetCurrentRegulatorGain" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByVal P As UShort, ByVal I As UShort, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_GetCurrentRegulatorGain Lib "EposCmd64.dll" Alias "VCS_GetCurrentRegulatorGain" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByRef pP As UShort, ByRef pI As UShort, ByRef pErrorCode As UInteger) As Integer

'*************************************************************************************************************************************
' OPERATION FUNCTIONS
'************************************************************************************************************************************/

'OperationMode
Declare Function VCS_SetOperationMode Lib "EposCmd64.dll" Alias "VCS_SetOperationMode" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByVal Mode As SByte, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_GetOperationMode Lib "EposCmd64.dll" Alias "VCS_GetOperationMode" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByRef pMode As SByte, ByRef pErrorCode As UInteger) As Integer

'StateMachine
Declare Function VCS_ResetDevice Lib "EposCmd64.dll" Alias "VCS_ResetDevice" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_SetState Lib "EposCmd64.dll" Alias "VCS_SetState" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByVal State As UShort, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_SetEnableState Lib "EposCmd64.dll" Alias "VCS_SetEnableState" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_SetDisableState Lib "EposCmd64.dll" Alias "VCS_SetDisableState" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_SetQuickStopState Lib "EposCmd64.dll" Alias "VCS_SetQuickStopState" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_ClearFault Lib "EposCmd64.dll" Alias "VCS_ClearFault" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_GetState Lib "EposCmd64.dll" Alias "VCS_GetState" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByRef pState As UShort, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_GetEnableState Lib "EposCmd64.dll" Alias "VCS_GetEnableState" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByRef pIsEnabled As Integer, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_GetDisableState Lib "EposCmd64.dll" Alias "VCS_GetDisableState" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByRef pIsDisabled As Integer, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_GetQuickStopState Lib "EposCmd64.dll" Alias "VCS_GetQuickStopState" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByRef pIsQuickStopped As Integer, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_GetFaultState Lib "EposCmd64.dll" Alias "VCS_GetFaultState" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByRef pIsInFault As Integer, ByRef pErrorCode As UInteger) As Integer

'ErrorHandling
Declare Function VCS_GetNbOfDeviceError Lib "EposCmd64.dll" Alias "VCS_GetNbOfDeviceError" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByRef pNbDeviceError As Byte, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_GetDeviceErrorCode Lib "EposCmd64.dll" Alias "VCS_GetDeviceErrorCode" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByVal DeviceErrorNumber As Byte, ByRef pDeviceErrorCode As UInteger, ByRef pErrorCode As UInteger) As Integer

'Motion Info
Declare Function VCS_GetMovementState Lib "EposCmd64.dll" Alias "VCS_GetMovementState" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByRef pTargetReached As Integer, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_GetPositionIs Lib "EposCmd64.dll" Alias "VCS_GetPositionIs" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByRef pPositionIs As Integer, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_GetVelocityIs Lib "EposCmd64.dll" Alias "VCS_GetVelocityIs" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByRef pVelocityIs As Integer, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_GetVelocityIsAveraged Lib "EposCmd64.dll" Alias "VCS_GetVelocityIsAveraged" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByRef pVelocityIsAveraged As Integer, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_GetCurrentIs Lib "EposCmd64.dll" Alias "VCS_GetCurrentIs" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByRef pCurrentIs As Short, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_GetCurrentIsEx Lib "EposCmd64.dll" Alias "VCS_GetCurrentIsEx" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByRef pCurrentIs As Integer, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_GetCurrentIsAveraged Lib "EposCmd64.dll" Alias "VCS_GetCurrentIsAveraged" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByRef pCurrentIsAveraged As Short, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_GetCurrentIsAveragedEx Lib "EposCmd64.dll" Alias "VCS_GetCurrentIsAveragedEx" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByRef pCurrentIsAveraged As Integer, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_WaitForTargetReached Lib "EposCmd64.dll" Alias "VCS_WaitForTargetReached" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByVal Timeout As UInteger, ByRef pErrorCode As UInteger) As Integer

'Profile Position Mode
Declare Function VCS_ActivateProfilePositionMode Lib "EposCmd64.dll" Alias "VCS_ActivateProfilePositionMode" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_SetPositionProfile Lib "EposCmd64.dll" Alias "VCS_SetPositionProfile" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByVal ProfileVelocity As UInteger, ByVal ProfileAcceleration As UInteger, ByVal ProfileDeceleration As UInteger, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_GetPositionProfile Lib "EposCmd64.dll" Alias "VCS_GetPositionProfile" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByRef pProfileVelocity As UInteger, ByRef pProfileAcceleration As UInteger, ByRef pProfileDeceleration As UInteger, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_MoveToPosition Lib "EposCmd64.dll" Alias "VCS_MoveToPosition" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByVal TargetPosition As Integer, ByVal Absolute As Integer, ByVal Immediately As Integer, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_GetTargetPosition Lib "EposCmd64.dll" Alias "VCS_GetTargetPosition" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByRef pTargetPosition As Integer, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_HaltPositionMovement Lib "EposCmd64.dll" Alias "VCS_HaltPositionMovement" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByRef pErrorCode As UInteger) As Integer

'Advanced Functions
Declare Function VCS_EnablePositionWindow Lib "EposCmd64.dll" Alias "VCS_EnablePositionWindow" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByVal PositionWindow As UInteger, ByVal PositionWindowTime As UShort, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_DisablePositionWindow Lib "EposCmd64.dll" Alias "VCS_DisablePositionWindow" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByRef pErrorCode As UInteger) As Integer

'Profile Velocity Mode
Declare Function VCS_ActivateProfileVelocityMode Lib "EposCmd64.dll" Alias "VCS_ActivateProfileVelocityMode" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_SetVelocityProfile Lib "EposCmd64.dll" Alias "VCS_SetVelocityProfile" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByVal ProfileAcceleration As UInteger, ByVal ProfileDeceleration As UInteger, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_GetVelocityProfile Lib "EposCmd64.dll" Alias "VCS_GetVelocityProfile" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByRef pProfileAcceleration As UInteger, ByRef pProfileDeceleration As UInteger, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_MoveWithVelocity Lib "EposCmd64.dll" Alias "VCS_MoveWithVelocity" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByVal TargetVelocity As Integer, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_GetTargetVelocity Lib "EposCmd64.dll" Alias "VCS_GetTargetVelocity" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByRef pTargetVelocity As Integer, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_HaltVelocityMovement Lib "EposCmd64.dll" Alias "VCS_HaltVelocityMovement" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByRef pErrorCode As UInteger) As Integer

'Advanced Functions
Declare Function VCS_EnableVelocityWindow Lib "EposCmd64.dll" Alias "VCS_EnableVelocityWindow" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByVal VelocityWindow As UInteger, ByVal VelocityWindowTime As UShort, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_DisableVelocityWindow Lib "EposCmd64.dll" Alias "VCS_DisableVelocityWindow" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByRef pErrorCode As UInteger) As Integer

'Homing Mode
Declare Function VCS_ActivateHomingMode Lib "EposCmd64.dll" Alias "VCS_ActivateHomingMode" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_SetHomingParameter Lib "EposCmd64.dll" Alias "VCS_SetHomingParameter" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByVal HomingAcceleration As UInteger, ByVal SpeedSwitch As UInteger, ByVal SpeedIndex As UInteger, ByVal HomeOffset As Integer, ByVal CurrentThreshold As UShort, ByVal HomePosition As Integer, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_GetHomingParameter Lib "EposCmd64.dll" Alias "VCS_GetHomingParameter" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByRef pHomingAcceleration As UInteger, ByRef pSpeedSwitch As UInteger, ByRef pSpeedIndex As UInteger, ByRef pHomeOffset As Integer, ByRef pCurrentThreshold As UShort, ByRef pHomePosition As Integer, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_FindHome Lib "EposCmd64.dll" Alias "VCS_FindHome" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByVal HomingMode As SByte, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_StopHoming Lib "EposCmd64.dll" Alias "VCS_StopHoming" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_DefinePosition Lib "EposCmd64.dll" Alias "VCS_DefinePosition" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByVal HomePosition As Integer, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_WaitForHomingAttained Lib "EposCmd64.dll" Alias "VCS_WaitForHomingAttained" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByVal Timeout As UInteger, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_GetHomingState Lib "EposCmd64.dll" Alias "VCS_GetHomingState" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByRef pHomingAttained As Integer, ByRef pHomingError As Integer, ByRef pErrorCode As UInteger) As Integer

'Interpolated Position Mode
Declare Function VCS_ActivateInterpolatedPositionMode Lib "EposCmd64.dll" Alias "VCS_ActivateInterpolatedPositionMode" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_SetIpmBufferParameter Lib "EposCmd64.dll" Alias "VCS_SetIpmBufferParameter" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByVal UnderflowWarningLimit As UShort, ByVal OverflowWarningLimit As UShort, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_GetIpmBufferParameter Lib "EposCmd64.dll" Alias "VCS_GetIpmBufferParameter" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByRef pUnderflowWarningLimit As UShort, ByRef pOverflowWarningLimit As UShort, ByRef pMaxBufferSize As UInteger, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_ClearIpmBuffer Lib "EposCmd64.dll" Alias "VCS_ClearIpmBuffer" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_GetFreeIpmBufferSize Lib "EposCmd64.dll" Alias "VCS_GetFreeIpmBufferSize" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByRef pBufferSize As UInteger, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_AddPvtValueToIpmBuffer Lib "EposCmd64.dll" Alias "VCS_AddPvtValueToIpmBuffer" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByVal Position As Integer, ByVal Velocity As Integer, ByVal Time As Byte, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_StartIpmTrajectory Lib "EposCmd64.dll" Alias "VCS_StartIpmTrajectory" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_StopIpmTrajectory Lib "EposCmd64.dll" Alias "VCS_StartIpmTrajectory" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_GetIpmStatus Lib "EposCmd64.dll" Alias "VCS_GetIpmStatus" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByRef pTrajectoryRunning As Integer, ByRef pIsUnderflowWarning As Integer, ByRef pIsOverflowWarning As Integer, ByRef pIsVelocityWarning As Integer, ByRef pIsAccelerationWarning As Integer, ByRef pIsUnderflowError As Integer, ByRef pIsOverflowError As Integer, ByRef pIsVelocityError As Integer, ByRef pIsAccelerationError As Integer, ByRef pErrorCode As UInteger) As Integer

'Position Mode
Declare Function VCS_ActivatePositionMode Lib "EposCmd64.dll" Alias "VCS_ActivatePositionMode" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_SetPositionMust Lib "EposCmd64.dll" Alias "VCS_SetPositionMust" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByVal PositionMust As Integer, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_GetPositionMust Lib "EposCmd64.dll" Alias "VCS_GetPositionMust" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByRef pPositionMust As Integer, ByRef pErrorCode As UInteger) As Integer

'Advanced Functions
Declare Function VCS_ActivateAnalogPositionSetpoint Lib "EposCmd64.dll" Alias "VCS_ActivateAnalogPositionSetpoint" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByVal AnalogInputNumber As UShort, ByVal Scaling As Single, ByVal Offset As Integer, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_DeactivateAnalogPositionSetpoint Lib "EposCmd64.dll" Alias "VCS_DeactivateAnalogPositionSetpoint" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByVal AnalogInputNumber As UShort, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_EnableAnalogPositionSetpoint Lib "EposCmd64.dll" Alias "VCS_EnableAnalogPositionSetpoint" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_DisableAnalogPositionSetpoint Lib "EposCmd64.dll" Alias "VCS_DisableAnalogPositionSetpoint" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByRef pErrorCode As UInteger) As Integer

'Velocity Mode
Declare Function VCS_ActivateVelocityMode Lib "EposCmd64.dll" Alias "VCS_ActivateVelocityMode" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_SetVelocityMust Lib "EposCmd64.dll" Alias "VCS_SetVelocityMust" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByVal VelocityMust As Integer, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_GetVelocityMust Lib "EposCmd64.dll" Alias "VCS_GetVelocityMust" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByRef pVelocityMust As Integer, ByRef pErrorCode As UInteger) As Integer

'Advanced Functions
Declare Function VCS_ActivateAnalogVelocitySetpoint Lib "EposCmd64.dll" Alias "VCS_ActivateAnalogVelocitySetpoint" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByVal AnalogInputNumber As UShort, ByVal Scaling As Single, ByVal Offset As Integer, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_DeactivateAnalogVelocitySetpoint Lib "EposCmd64.dll" Alias "VCS_DeactivateAnalogVelocitySetpoint" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByVal AnalogInputNumber As UShort, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_EnableAnalogVelocitySetpoint Lib "EposCmd64.dll" Alias "VCS_EnableAnalogVelocitySetpoint" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_DisableAnalogVelocitySetpoint Lib "EposCmd64.dll" Alias "VCS_DisableAnalogVelocitySetpoint" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByRef pErrorCode As UInteger) As Integer

'Current Mode
Declare Function VCS_ActivateCurrentMode Lib "EposCmd64.dll" Alias "VCS_ActivateCurrentMode" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_SetCurrentMust Lib "EposCmd64.dll" Alias "VCS_SetCurrentMust" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByVal CurrentMust As Short, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_SetCurrentMustEx Lib "EposCmd64.dll" Alias "VCS_SetCurrentMustEx" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByVal CurrentMust As Integer, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_GetCurrentMust Lib "EposCmd64.dll" Alias "VCS_GetCurrentMust" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByRef pCurrentMust As Short, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_GetCurrentMustEx Lib "EposCmd64.dll" Alias "VCS_GetCurrentMustEx" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByRef pCurrentMust As Integer, ByRef pErrorCode As UInteger) As Integer

'Advanced Functions
Declare Function VCS_ActivateAnalogCurrentSetpoint Lib "EposCmd64.dll" Alias "VCS_ActivateAnalogCurrentSetpoint" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByVal AnalogInputNumber As UShort, ByVal Scaling As Single, ByVal Offset As Short, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_DeactivateAnalogCurrentSetpoint Lib "EposCmd64.dll" Alias "VCS_DeactivateAnalogCurrentSetpoint" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByVal AnalogInputNumber As UShort, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_EnableAnalogCurrentSetpoint Lib "EposCmd64.dll" Alias "VCS_EnableAnalogCurrentSetpoint" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_DisableAnalogCurrentSetpoint Lib "EposCmd64.dll" Alias "VCS_DisableAnalogCurrentSetpoint" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByRef pErrorCode As UInteger) As Integer

'MasterEncoder Mode
Declare Function VCS_ActivateMasterEncoderMode Lib "EposCmd64.dll" Alias "VCS_ActivateMasterEncoderMode" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_SetMasterEncoderParameter Lib "EposCmd64.dll" Alias "VCS_SetMasterEncoderParameter" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByVal ScalingNumerator As UShort, ByVal ScalingDenominator As UShort, ByVal Polarity As Byte, ByVal MaxVelocity As UInteger, ByVal MaxAcceleration As UInteger, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_GetMasterEncoderParameter Lib "EposCmd64.dll" Alias "VCS_GetMasterEncoderParameter" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByRef pScalingNumerator As UShort, ByRef pScalingDenominator As UShort, ByRef pPolarity As Byte, ByRef pMaxVelocity As UInteger, ByRef pMaxAcceleration As UInteger, ByRef pErrorCode As UInteger) As Integer

'StepDirection Mode
Declare Function VCS_ActivateStepDirectionMode Lib "EposCmd64.dll" Alias "VCS_ActivateStepDirectionMode" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_SetStepDirectionParameter Lib "EposCmd64.dll" Alias "VCS_SetStepDirectionParameter" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByVal ScalingNumerator As UShort, ByVal ScalingDenominator As UShort, ByVal Polarity As Byte, ByVal MaxVelocity As UInteger, ByVal MaxAcceleration As UInteger, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_GetStepDirectionParameter Lib "EposCmd64.dll" Alias "VCS_GetStepDirectionParameter" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByRef pScalingNumerator As UShort, ByRef pScalingDenominator As UShort, ByRef pPolarity As Byte, ByRef pMaxVelocity As UInteger, ByRef pMaxAcceleration As UInteger, ByRef pErrorCode As UInteger) As Integer

'Inputs Outputs
'General
Declare Function VCS_GetAllDigitalInputs Lib "EposCmd64.dll" Alias "VCS_GetAllDigitalInputs" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByRef pInputs As UShort, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_GetAllDigitalOutputs Lib "EposCmd64.dll" Alias "VCS_GetAllDigitalOutputs" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByRef pOutputs As UShort, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_SetAllDigitalOutputs Lib "EposCmd64.dll" Alias "VCS_SetAllDigitalOutputs" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByVal Outputs As UShort, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_GetAnalogInput Lib "EposCmd64.dll" Alias "VCS_GetAnalogInput" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByVal Number As UShort, ByRef pAnalog As UShort, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_GetAnalogInputVoltage Lib "EposCmd64.dll" Alias "VCS_GetAnalogInputVoltage" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByVal Number As UShort, ByRef pVoltageValue As Integer, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_GetAnalogInputState Lib "EposCmd64.dll" Alias "VCS_GetAnalogInputState" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByVal Configuration As UShort, ByRef pStateValue As Integer, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_SetAnalogOutput Lib "EposCmd64.dll" Alias "VCS_SetAnalogOutput" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByVal OutputNumber As UShort, ByVal AnalogValue As UShort, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_SetAnalogOutputVoltage Lib "EposCmd64.dll" Alias "VCS_SetAnalogOutputVoltage" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByVal OutputNumber As UShort, ByVal VoltageValue As Integer, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_SetAnalogOutputState Lib "EposCmd64.dll" Alias "VCS_SetAnalogOutputState" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByVal Configuration As UShort, ByVal StateValue As Integer, ByRef pErrorCode As UInteger) As Integer

'Position Compare
Declare Function VCS_SetPositionCompareParameter Lib "EposCmd64.dll" Alias "VCS_SetPositionCompareParameter" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByVal OperationalMode As Byte, ByVal IntervalMode As Byte, ByVal DirectionDependency As Byte, ByVal IntervalWidth As UShort, ByVal IntervalRepetitions As UShort, ByVal PulseWidth As UShort, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_GetPositionCompareParameter Lib "EposCmd64.dll" Alias "VCS_GetPositionCompareParameter" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByRef pOperationalMode As Byte, ByRef pIntervalMode As Byte, ByRef pDirectionDependency As Byte, ByRef pIntervalWidth As UShort, ByRef pIntervalRepetitions As UShort, ByRef pPulseWidth As UShort, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_ActivatePositionCompare Lib "EposCmd64.dll" Alias "VCS_ActivatePositionCompare" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByVal DigitalOutputNumber As UShort, ByVal Polarity As Integer, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_DeactivatePositionCompare Lib "EposCmd64.dll" Alias "VCS_DeactivatePositionCompare" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByVal DigitalOutputNumber As UShort, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_EnablePositionCompare Lib "EposCmd64.dll" Alias "VCS_EnablePositionCompare" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_DisablePositionCompare Lib "EposCmd64.dll" Alias "VCS_DisablePositionCompare" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_SetPositionCompareReferencePosition Lib "EposCmd64.dll" Alias "VCS_SetPositionCompareReferencePosition" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByVal ReferencePosition As Integer, ByRef pErrorCode As UInteger) As Integer

'Position Marker
Declare Function VCS_SetPositionMarkerParameter Lib "EposCmd64.dll" Alias "VCS_SetPositionMarkerParameter" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByVal PositionMarkerEdgeType As Byte, ByVal PositionMarkerMode As Byte, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_GetPositionMarkerParameter Lib "EposCmd64.dll" Alias "VCS_GetPositionMarkerParameter" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByRef pPositionMarkerEdgeType As Byte, ByRef pPositionMarkerMode As Byte, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_ActivatePositionMarker Lib "EposCmd64.dll" Alias "VCS_ActivatePositionMarker" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByVal DigitalInputNumber As UShort, ByVal Polarity As Integer, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_DeactivatePositionMarker Lib "EposCmd64.dll" Alias "VCS_DeactivatePositionMarker" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByVal DigitalInputNumber As UShort, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_ReadPositionMarkerCounter Lib "EposCmd64.dll" Alias "VCS_ReadPositionMarkerCounter" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByRef pCount As UShort, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_ReadPositionMarkerCapturedPosition Lib "EposCmd64.dll" Alias "VCS_ReadPositionMarkerCapturedPosition" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByVal CounterIndex As UShort, ByRef pCapturedPosition As Integer, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_ResetPositionMarkerCounter Lib "EposCmd64.dll" Alias "VCS_ResetPositionMarkerCounter" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByRef pErrorCode As UInteger) As Integer

'*************************************************************************************************************************************
' DATA RECORDING FUNCTIONS
'************************************************************************************************************************************/

'DataRecorder Setup
Declare Function VCS_SetRecorderParameter Lib "EposCmd64.dll" Alias "VCS_SetRecorderParameter" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByVal SamplingPeriod As UShort, ByVal NbOfPrecedingSamples As UShort, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_GetRecorderParameter Lib "EposCmd64.dll" Alias "VCS_GetRecorderParameter" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByRef pSamplingPeriod As UShort, ByRef pNbOfPrecedingSamples As UShort, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_EnableTrigger Lib "EposCmd64.dll" Alias "VCS_EnableTrigger" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByVal TriggerType As Byte, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_DisableAllTriggers Lib "EposCmd64.dll" Alias "VCS_DisableAllTriggers" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_ActivateChannel Lib "EposCmd64.dll" Alias "VCS_ActivateChannel" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByVal ChannelNumber As Byte, ByVal ObjectIndex As UShort, ByVal ObjectSubIndex As Byte, ByVal ObjectSize As Byte, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_DeactivateAllChannels Lib "EposCmd64.dll" Alias "VCS_DeactivateAllChannels" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByRef pErrorCode As UInteger) As Integer

'DataRecorder Status
Declare Function VCS_StartRecorder Lib "EposCmd64.dll" Alias "VCS_StartRecorder" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_StopRecorder Lib "EposCmd64.dll" Alias "VCS_StopRecorder" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_ForceTrigger Lib "EposCmd64.dll" Alias "VCS_ForceTrigger" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_IsRecorderRunning Lib "EposCmd64.dll" Alias "VCS_IsRecorderRunning" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByRef pRunning As Integer, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_IsRecorderTriggered Lib "EposCmd64.dll" Alias "VCS_IsRecorderTriggered" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByRef pTriggered As Integer, ByRef pErrorCode As UInteger) As Integer

'DataRecorder Data
Declare Function VCS_ReadChannelVectorSize Lib "EposCmd64.dll" Alias "VCS_ReadChannelVectorSize" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByRef pVectorSize As UInteger, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_ReadChannelDataVector Lib "EposCmd64.dll" Alias "VCS_ReadChannelDataVector" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByVal ChannelNumber As Byte, ByRef pDataVectorBuffer_FirstElement As Byte, ByVal VectorBufferSize As UInteger, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_ShowChannelDataDlg Lib "EposCmd64.dll" Alias "VCS_ShowChannelDataDlg" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_ExportChannelDataToFile Lib "EposCmd64.dll" Alias "VCS_ExportChannelDataToFile" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByVal FileName As String, ByRef pErrorCode As UInteger) As Integer

'Advanced Functions
Declare Function VCS_ReadDataBuffer Lib "EposCmd64.dll" Alias "VCS_ReadDataBuffer" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByRef pDataBuffer_FirstElement As Byte, ByVal BufferSizeToRead As UInteger, ByRef pBufferSizeRead As UInteger, ByRef pVectorStartOffset As UShort, ByRef pMaxNbOfSamples As UShort, ByRef pNbOfRecordedSamples As UShort, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_ExtractChannelDataVector Lib "EposCmd64.dll" Alias "VCS_ExtractChannelDataVector" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByVal ChannelNumber As Byte, ByRef pDataBuffer_FirstElement As Byte, ByVal BufferSize As UInteger, ByRef pDataVectorBuffer_FirstElement As Byte, ByVal VectorBufferSize As UInteger, ByVal VectorStartOffset As UShort, ByVal MaxNbOfSamples As UShort, ByVal NbOfRecordedSamples As UShort, ByRef pErrorCode As UInteger) As Integer

'*************************************************************************************************************************************
' LOW LAYER FUNCTIONS
'************************************************************************************************************************************/

'CanLayer Functions
Declare Function VCS_SendCANFrame Lib "EposCmd64.dll" Alias "VCS_SendCANFrame" (ByVal KeyHandle As Integer, ByVal CobID As UShort, ByVal Length As UShort, ByRef pData_FirstElement As Byte, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_ReadCANFrame Lib "EposCmd64.dll" Alias "VCS_ReadCANFrame" (ByVal KeyHandle As Integer, ByVal CobID As UShort, ByVal Length As UShort, ByRef pData_FirstElement As Byte, ByVal Timeout As Integer, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_RequestCANFrame Lib "EposCmd64.dll" Alias "VCS_RequestCANFrame" (ByVal KeyHandle As Integer, ByVal CobID As UShort, ByVal Length As UShort, ByRef pData_FirstElement As Byte, ByRef pErrorCode As UInteger) As Integer
Declare Function VCS_SendNMTService Lib "EposCmd64.dll" Alias "VCS_SendNMTService" (ByVal KeyHandle As Integer, ByVal NodeID As UShort, ByVal CommandSpecifier As UShort, ByRef pErrorCode As UInteger) As Integer

'*************************************************************************************************************************************
' TYPE DEFINITIONS
'************************************************************************************************************************************/

'Communication
    'Dialog Mode
    Const DM_PROGRESS_DLG As Integer = 0
    Const DM_PROGRESS_AND_CONFIRM_DLG As Integer = 1
    Const DM_CONFIRM_DLG As Integer = 2
    Const DM_NO_DLG As Integer = 3

'Configuration
    'MotorType
    Const MT_DC_MOTOR As UShort = 1
    Const MT_EC_SINUS_COMMUTATED_MOTOR As UShort = 10
    Const MT_EC_BLOCK_COMMUTATED_MOTOR As UShort = 11

    'SensorType
    Const ST_UNKNOWN As UShort = 0
    Const ST_INC_ENCODER_3CHANNEL As UShort = 1
    Const ST_INC_ENCODER_2CHANNEL As UShort = 2
    Const ST_HALL_SENSORS As UShort = 3
    Const ST_SSI_ABS_ENCODER_BINARY As UShort = 4
    Const ST_SSI_ABS_ENCODER_GREY As UShort = 5
    Const ST_INC_ENCODER2_3CHANNEL As UShort = 6
    Const ST_INC_ENCODER2_2CHANNEL As UShort = 7
    Const ST_ANALOG_INC_ENCODER_3CHANNEL As UShort = 8
    Const ST_ANALOG_INC_ENCODER_2CHANNEL As UShort = 9

'In- and outputs
    'Digital input configuration
    Const DIC_NEGATIVE_LIMIT_SWITCH As UShort = 0
    Const DIC_POSITIVE_LIMIT_SWITCH As UShort = 1
    Const DIC_HOME_SWITCH As UShort = 2
    Const DIC_POSITION_MARKER As UShort = 3
    Const DIC_DRIVE_ENABLE As UShort = 4
    Const DIC_QUICK_STOP As UShort = 5
    Const DIC_GENERAL_PURPOSE_J As UShort = 6
    Const DIC_GENERAL_PURPOSE_I As UShort = 7
    Const DIC_GENERAL_PURPOSE_H As UShort = 8
    Const DIC_GENERAL_PURPOSE_G As UShort = 9
    Const DIC_GENERAL_PURPOSE_F As UShort = 10
    Const DIC_GENERAL_PURPOSE_E As UShort = 11
    Const DIC_GENERAL_PURPOSE_D As UShort = 12
    Const DIC_GENERAL_PURPOSE_C As UShort = 13
    Const DIC_GENERAL_PURPOSE_B As UShort = 14
    Const DIC_GENERAL_PURPOSE_A As UShort = 15

    'Digital output configuration
    Const DOC_READY_FAULT As UShort = 0
    Const DOC_POSITION_COMPARE As UShort = 1
    Const DOC_GENERAL_PURPOSE_H As UShort = 8
    Const DOC_GENERAL_PURPOSE_G As UShort = 9
    Const DOC_GENERAL_PURPOSE_F As UShort = 10
    Const DOC_GENERAL_PURPOSE_E As UShort = 11
    Const DOC_GENERAL_PURPOSE_D As UShort = 12
    Const DOC_GENERAL_PURPOSE_C As UShort = 13
    Const DOC_GENERAL_PURPOSE_B As UShort = 14
    Const DOC_GENERAL_PURPOSE_A As UShort = 15

    'Analog input configuration
    Const AIC_ANALOG_CURRENT_SETPOINT As UShort = 0
    Const AIC_ANALOG_VELOCITY_SETPOINT As UShort = 1
    Const AIC_ANALOG_POSITION_SETPOINT As UShort = 2
    Const AIC_GENERAL_PURPOSE_H As UShort = 8
    Const AIC_GENERAL_PURPOSE_G As UShort = 9
    Const AIC_GENERAL_PURPOSE_F As UShort = 10
    Const AIC_GENERAL_PURPOSE_E As UShort = 11
    Const AIC_GENERAL_PURPOSE_D As UShort = 12
    Const AIC_GENERAL_PURPOSE_C As UShort = 13
    Const AIC_GENERAL_PURPOSE_B As UShort = 14
    Const AIC_GENERAL_PURPOSE_A As UShort = 15

    'Analog output configuration
    Const AOC_GENERAL_PURPOSE_A As UShort = 0
    Const AOC_GENERAL_PURPOSE_B As UShort = 1

'Units
    'VelocityDimension
    Const VD_RPM As Byte = &HA4

    'VelocityNotation
    Const VN_STANDARD As SByte = 0
    Const VN_DECI As SByte = -1
    Const VN_CENTI As SByte = -2
    Const VN_MILLI As SByte = -3

'Operational mode
    Const OMD_PROFILE_POSITION_MODE As SByte = 1
    Const OMD_PROFILE_VELOCITY_MODE As SByte = 3
    Const OMD_HOMING_MODE As SByte = 6
    Const OMD_INTERPOLATED_POSITION_MODE As SByte = 7
    Const OMD_POSITION_MODE As SByte = -1
    Const OMD_VELOCITY_MODE As SByte = -2
    Const OMD_CURRENT_MODE As SByte = -3
    Const OMD_MASTER_ENCODER_MODE As SByte = -5
    Const OMD_STEP_DIRECTION_MODE As SByte = -6

'States
    Const ST_DISABLED As UShort = 0
    Const ST_ENABLED As UShort = 1
    Const ST_QUICKSTOP As UShort = 2
    Const ST_FAULT As UShort = 3

'Homing mode
    'Homing method
    Const HM_ACTUAL_POSITION As SByte = &H23
    Const HM_NEGATIVE_LIMIT_SWITCH As SByte = 17
    Const HM_NEGATIVE_LIMIT_SWITCH_AND_INDEX As SByte = 1
    Const HM_POSITIVE_LIMIT_SWITCH As SByte = 18
    Const HM_POSITIVE_LIMIT_SWITCH_AND_INDEX As SByte = 2
    Const HM_HOME_SWITCH_POSITIVE_SPEED As SByte = 23
    Const HM_HOME_SWITCH_POSITIVE_SPEED_AND_INDEX As SByte = 7
    Const HM_HOME_SWITCH_NEGATIVE_SPEED As SByte = 27
    Const HM_HOME_SWITCH_NEGATIVE_SPEED_AND_INDEX As SByte = 11
    Const HM_CURRENT_THRESHOLD_POSITIVE_SPEED As SByte = -3
    Const HM_CURRENT_THRESHOLD_POSITIVE_SPEED_AND_INDEX As SByte = -1
    Const HM_CURRENT_THRESHOLD_NEGATIVE_SPEED As SByte = -4
    Const HM_CURRENT_THRESHOLD_NEGATIVE_SPEED_AND_INDEX As SByte = -2
    Const HM_INDEX_POSITIVE_SPEED As SByte = 34
    Const HM_INDEX_NEGATIVE_SPEED As SByte = 33

'Input Output PositionMarker
    'PositionMarkerEdgeType
    Const PET_BOTH_EDGES As Byte = 0
    Const PET_RISING_EDGE As Byte = 1
    Const PET_FALLING_EDGE As Byte = 2

    'PositionMarkerMode
    Const PM_CONTINUOUS As Byte = 0
    Const PM_SINGLE As Byte = 1
    Const PM_MULTIPLE As Byte = 2

'Input Output PositionCompare
    'PositionCompareOperationalMode
    Const PCO_SINGLE_POSITION_MODE As Byte = 0
    Const PCO_POSITION_SEQUENCE_MODE As Byte = 1

    'PositionCompareIntervalMode
    Const PCI_NEGATIVE_DIR_TO_REFPOS As Byte = 0
    Const PCI_POSITIVE_DIR_TO_REFPOS As Byte = 1
    Const PCI_BOTH_DIR_TO_REFPOS As Byte = 2

    'PositionCompareDirectionDependency
    Const PCD_MOTOR_DIRECTION_NEGATIVE As Byte = 0
    Const PCD_MOTOR_DIRECTION_POSITIVE As Byte = 1
    Const PCD_MOTOR_DIRECTION_BOTH As Byte = 2

'Data recorder
    'Trigger type
    Const DR_MOVEMENT_START_TRIGGER As Byte = 1
    Const DR_ERROR_TRIGGER As Byte = 2
    Const DR_DIGITAL_INPUT_TRIGGER As Byte = 4
    Const DR_MOVEMENT_END_TRIGGER As Byte = 8

'CanLayer Functions
    Const NCS_START_REMOTE_NODE As Integer = 1
    Const NCS_STOP_REMOTE_NODE As Integer = 2
    Const NCS_ENTER_PRE_OPERATIONAL As Integer = 128
    Const NCS_RESET_NODE As Integer = 129
    Const NCS_RESET_COMMUNICATION As Integer = 130

'Controller Gains
    'EController
    Const EC_PI_CURRENT_CONTROLLER As Integer = 1
    Const EC_PI_VELOCITY_CONTROLLER As Integer = 10
    Const EC_PI_VELOCITY_CONTROLLER_WITH_OBSERVER As Integer = 11
    Const EC_PID_POSITION_CONTROLLER As Integer = 20
    Const EC_DUAL_LOOP_POSITION_CONTROLLER As Integer = 21

    'EGain (EC_PI_CURRENT_CONTROLLER)
    Const EG_PICC_P_GAIN As Integer = 1
    Const EG_PICC_I_GAIN As Integer = 2

    'EGain (EC_PI_VELOCITY_CONTROLLER)
    Const EG_PIVC_P_GAIN As Integer = 1
    Const EG_PIVC_I_GAIN As Integer = 2
    Const EG_PIVC_FEED_FORWARD_VELOCITY_GAIN As Integer = 10
    Const EG_PIVC_FEED_FORWARD_ACCELERATION_GAIN As Integer = 11

    'EGain (EC_PI_VELOCITY_CONTROLLER_WITH_OBSERVER)
    Const EG_PIVCWO_P_GAIN As Integer = 1
    Const EG_PIVCWO_I_GAIN As Integer = 2
    Const EG_PIVCWO_FEED_FORWARD_VELOCITY_GAIN As Integer = 10
    Const EG_PIVCWO_FEED_FORWARD_ACCELERATION_GAIN As Integer = 11
    Const EG_PIVCWO_OBSERVER_THETA_GAIN As Integer = 20
    Const EG_PIVCWO_OBSERVER_OMEGA_GAIN As Integer = 21
    Const EG_PIVCWO_OBSERVER_TAU_GAIN As Integer = 22

    'EGain (EC_PID_POSITION_CONTROLLER)
    Const EG_PIDPC_P_GAIN As Integer = 1
    Const EG_PIDPC_I_GAIN As Integer = 2
    Const EG_PIDPC_D_GAIN As Integer = 3
    Const EG_PIDPC_FEED_FORWARD_VELOCITY_GAIN As Integer = 10
    Const EG_PIDPC_FEED_FORWARD_ACCELERATION_GAIN As Integer = 11

    'EGain (EC_DUAL_LOOP_POSITION_CONTROLLER)
    Const EG_DLPC_AUXILIARY_LOOP_P_GAIN As Integer = 1
    Const EG_DLPC_AUXILIARY_LOOP_I_GAIN As Integer = 2
    Const EG_DLPC_AUXILIARY_LOOP_FEED_FORWARD_VELOCITY_GAIN As Integer = 10
    Const EG_DLPC_AUXILIARY_LOOP_FEED_FORWARD_ACCELERATION_GAIN As Integer = 11
    Const EG_DLPC_AUXILIARY_LOOP_OBSERVER_THETA_GAIN As Integer = 20
    Const EG_DLPC_AUXILIARY_LOOP_OBSERVER_OMEGA_GAIN As Integer = 21
    Const EG_DLPC_AUXILIARY_LOOP_OBSERVER_TAU_GAIN As Integer = 22
    Const EG_DLPC_MAIN_LOOP_P_GAIN_LOW As Integer = 101
    Const EG_DLPC_MAIN_LOOP_P_GAIN_HIGH As Integer = 102
    Const EG_DLPC_MAIN_LOOP_GAIN_SCHEDULING_WEIGHT As Integer = 110
    Const EG_DLPC_MAIN_LOOP_FILTER_COEFFICIENT_A As Integer = 120
    Const EG_DLPC_MAIN_LOOP_FILTER_COEFFICIENT_B As Integer = 121
    Const EG_DLPC_MAIN_LOOP_FILTER_COEFFICIENT_C As Integer = 122
    Const EG_DLPC_MAIN_LOOP_FILTER_COEFFICIENT_D As Integer = 123
    Const EG_DLPC_MAIN_LOOP_FILTER_COEFFICIENT_E As Integer = 124

End Module
