VERSION 5.00
Begin VB.Form Form1 
   BorderStyle     =   3  'Fester Dialog
   Caption         =   " Demo EPOS WinDLL with Microsoft Visual Basic 6.0"
   ClientHeight    =   4410
   ClientLeft      =   510
   ClientTop       =   675
   ClientWidth     =   6195
   Icon            =   "Demo_WinDLL.frx":0000
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   4410
   ScaleWidth      =   6195
   ShowInTaskbar   =   0   'False
   Begin VB.CommandButton DeviceSettings 
      Caption         =   "Device Settings"
      Height          =   375
      Left            =   4200
      TabIndex        =   20
      Top             =   360
      Width           =   1815
   End
   Begin VB.CommandButton MoveToPos 
      Caption         =   "&Move"
      Height          =   375
      Left            =   4200
      TabIndex        =   19
      Top             =   2400
      Width           =   1815
   End
   Begin VB.CommandButton OK 
      Caption         =   "&OK"
      Height          =   375
      Left            =   4800
      TabIndex        =   18
      Top             =   3840
      Width           =   1215
   End
   Begin VB.CommandButton Halt 
      Caption         =   "&Halt"
      Height          =   375
      Left            =   4200
      TabIndex        =   17
      Top             =   2880
      Width           =   1815
   End
   Begin VB.CommandButton Disable 
      Caption         =   "&Disable"
      Height          =   375
      Left            =   4200
      TabIndex        =   16
      Top             =   1800
      Width           =   1815
   End
   Begin VB.CommandButton Enable 
      Caption         =   "&Enable"
      Height          =   375
      Left            =   4200
      TabIndex        =   15
      Top             =   1320
      Width           =   1815
   End
   Begin VB.Frame Frame3 
      Caption         =   "Actual Values"
      Height          =   1150
      Left            =   120
      TabIndex        =   8
      Top             =   3120
      Width           =   3735
      Begin VB.TextBox PositionActual 
         BeginProperty DataFormat 
            Type            =   1
            Format          =   "0"
            HaveTrueFalseNull=   0
            FirstDayOfWeek  =   0
            FirstWeekOfYear =   0
            LCID            =   2055
            SubFormatType   =   1
         EndProperty
         Enabled         =   0   'False
         Height          =   285
         Left            =   1920
         TabIndex        =   12
         Text            =   "0"
         Top             =   705
         Width           =   1335
      End
      Begin VB.TextBox PositionStart 
         BeginProperty DataFormat 
            Type            =   1
            Format          =   "0"
            HaveTrueFalseNull=   0
            FirstDayOfWeek  =   0
            FirstWeekOfYear =   0
            LCID            =   2055
            SubFormatType   =   1
         EndProperty
         Enabled         =   0   'False
         Height          =   285
         Left            =   1920
         Locked          =   -1  'True
         TabIndex        =   11
         Text            =   "0"
         Top             =   345
         Width           =   1335
      End
      Begin VB.Label Label6 
         Caption         =   "qc"
         Height          =   255
         Left            =   3360
         TabIndex        =   14
         Top             =   720
         Width           =   255
      End
      Begin VB.Label Label3 
         Caption         =   "qc"
         Height          =   255
         Index           =   1
         Left            =   3360
         TabIndex        =   13
         Top             =   360
         Width           =   255
      End
      Begin VB.Label Label5 
         Caption         =   "Position Actual Value"
         Height          =   255
         Left            =   240
         TabIndex        =   10
         Top             =   720
         Width           =   1695
      End
      Begin VB.Label Label4 
         Caption         =   "Position Start"
         Height          =   255
         Left            =   240
         TabIndex        =   9
         Top             =   360
         Width           =   1095
      End
   End
   Begin VB.Frame Frame2 
      Caption         =   "Profile"
      Height          =   1455
      Left            =   120
      TabIndex        =   1
      Top             =   1440
      Width           =   3735
      Begin VB.OptionButton RadioAbsolute 
         Caption         =   "Absolute Move"
         Height          =   255
         Left            =   1920
         TabIndex        =   7
         Top             =   1080
         Width           =   1575
      End
      Begin VB.OptionButton RadioRelative 
         Caption         =   "Relative Move"
         Height          =   255
         Left            =   1920
         TabIndex        =   6
         Top             =   750
         Value           =   -1  'True
         Width           =   1455
      End
      Begin VB.TextBox TargetPosition 
         BeginProperty DataFormat 
            Type            =   1
            Format          =   "0"
            HaveTrueFalseNull=   0
            FirstDayOfWeek  =   0
            FirstWeekOfYear =   0
            LCID            =   2055
            SubFormatType   =   1
         EndProperty
         Height          =   285
         Left            =   1920
         TabIndex        =   2
         Text            =   "2000"
         Top             =   300
         Width           =   1335
      End
      Begin VB.Label Label2 
         Caption         =   "Target Position"
         Height          =   255
         Left            =   240
         TabIndex        =   5
         Top             =   360
         Width           =   1335
      End
      Begin VB.Label Label3 
         Caption         =   "qc"
         Height          =   255
         Index           =   0
         Left            =   3360
         TabIndex        =   3
         Top             =   360
         Width           =   255
      End
   End
   Begin VB.Frame Frame1 
      Caption         =   "Active Operation Mode"
      Height          =   1150
      Left            =   120
      TabIndex        =   0
      Top             =   120
      Width           =   3735
      Begin VB.TextBox NodeID 
         BeginProperty DataFormat 
            Type            =   1
            Format          =   "0"
            HaveTrueFalseNull=   0
            FirstDayOfWeek  =   0
            FirstWeekOfYear =   0
            LCID            =   2055
            SubFormatType   =   1
         EndProperty
         Height          =   285
         Left            =   1920
         TabIndex        =   22
         Text            =   "1"
         Top             =   705
         Width           =   1335
      End
      Begin VB.Timer Timer1 
         Enabled         =   0   'False
         Interval        =   100
         Left            =   3120
         Top             =   240
      End
      Begin VB.Label Label1 
         Caption         =   "Node ID"
         Height          =   255
         Left            =   240
         TabIndex        =   21
         Top             =   720
         Width           =   1455
      End
      Begin VB.Label ActiveOperationMode 
         Caption         =   "Profile Position Mode"
         Height          =   255
         Left            =   240
         TabIndex        =   4
         Top             =   360
         Width           =   2535
      End
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit
Dim m_wNodeId As Integer
Dim m_lErrorCode As Long
Dim m_lImmediately As Long
Dim m_lProfileAcceleration As Long
Dim m_lProfileDeceleration As Long
Dim m_lProfileVelocity As Long
Dim m_KeyHandle As Long
Dim m_uMode As Byte
Dim m_oInitialisation As Boolean
Dim m_oUpdateActive As Boolean

'Sets new communication settings via button 'Device Settings'
Private Sub DeviceSettings_Click()
    NodeID.Text = m_wNodeId
    
    If (OpenDevice()) Then
        m_oInitialisation = True
        m_oUpdateActive = True
        Timer1.Enabled = True
    Else
        m_oInitialisation = StopTimer()
        m_oInitialisation = False
    End If
    
End Sub

'Sets device to disable state
Private Sub Disable_Click()
    Dim oResult As Boolean

    NodeID.Text = m_wNodeId
    
    oResult = VCS_SetDisableState(m_KeyHandle, m_wNodeId, m_lErrorCode)
    If Not oResult Then
        oResult = ShowErrorInformation(m_lErrorCode)
    End If
    
End Sub

'Sets device to enable state
Private Sub Enable_Click()
    Dim oResult As Boolean
    
    NodeID.Text = m_wNodeId
    
    oResult = VCS_SetEnableState(m_KeyHandle, m_wNodeId, m_lErrorCode)
    If Not oResult Then
        oResult = ShowErrorInformation(m_lErrorCode)
    End If

End Sub

Private Sub Form_Load()
     
    m_lImmediately = 0
    m_wNodeId = 1
    
    If (OpenDevice()) Then
        m_oInitialisation = True
        m_oUpdateActive = True
        Timer1.Enabled = True
    Else
        m_oInitialisation = False
        m_oUpdateActive = False
    End If

End Sub

Private Sub Form_Unload(Cancel As Integer)
    Dim oResult As Boolean
    
    oResult = RestoreEPOS()
End Sub

'Opens communication interface via the OpenDeviceDlg
Private Function OpenDevice() As Boolean
    Const Size = 100
    
    Dim oResult As Boolean
    Dim lValue As Long
    
    m_KeyHandle = VCS_OpenDeviceDlg(m_lErrorCode)
    If m_KeyHandle Then
        'Deletes the error history
        oResult = VCS_ClearFault(m_KeyHandle, m_wNodeId, m_lErrorCode)
        If oResult Then
            'Reads Operational Mode
            oResult = VCS_GetOperationMode(m_KeyHandle, m_wNodeId, m_uMode, m_lErrorCode)
            If oResult Then
                'Reads Position Profile Objects
                oResult = VCS_GetPositionProfile(m_KeyHandle, m_wNodeId, m_lProfileVelocity, m_lProfileAcceleration, m_lProfileDeceleration, m_lErrorCode)
                If oResult Then
                    'Write Opeational Mode (Profile Position Mode)
                    oResult = VCS_SetOperationMode(m_KeyHandle, m_wNodeId, 1, m_lErrorCode)
                    If oResult Then
                        'Write Position Profile Objects
                        oResult = VCS_SetPositionProfile(m_KeyHandle, m_wNodeId, 100, 1000, 1000, m_lErrorCode)
                        If oResult Then
                            'Reads the actual position
                            oResult = VCS_GetPositionIs(m_KeyHandle, m_wNodeId, lValue, m_lErrorCode)
                            If oResult Then
                                PositionStart.Text = lValue
                            End If
                        End If
                    End If
                End If
            End If
        End If
        
        If Not oResult Then
            ShowErrorInformation (m_lErrorCode)
        End If
        
    End If
    
    OpenDevice = oResult
End Function

'Restores the old settings, stops the timer and delete the key handle
Private Function RestoreEPOS() As Boolean
    Dim oResult As Boolean
    
    If m_oInitialisation Then
        oResult = VCS_SetDisableState(m_KeyHandle, m_wNodeId, m_lErrorCode)
        oResult = VCS_SetOperationMode(m_KeyHandle, m_wNodeId, m_uMode, m_lErrorCode)
        oResult = VCS_SetPositionProfile(m_KeyHandle, m_wNodeId, m_lProfileVelocity, m_lProfileAcceleration, m_lProfileDeceleration, m_lErrorCode)
    End If
    
    oResult = StopTimer()
         
    oResult = VCS_CloseAllDevices(m_lErrorCode)
    
    RestoreEPOS = oResult

End Function

'Updates the display
Private Function UpdateStatus() As Boolean
    Dim oResult As Boolean
    Dim oTemp As Boolean
    Dim lEnable As Long
    Dim lValue As Long
           
    lEnable = 1
    oResult = m_oUpdateActive
    
    If (RadioRelative.Value) Then
        MoveToPos.Caption = "&Move Relative"
    Else
        MoveToPos.Caption = "&Move Absolute"
    End If
      
    If oResult Then
        oResult = VCS_GetOperationMode(m_KeyHandle, m_wNodeId, m_uMode, m_lErrorCode)
        ' Type of m_uMode is Byte. The DLL returns negative values, but
        ' Visual Basic does not have an unsigned type for the size of 1Byte
        ' Attention: For functions VCS_SetOperationMode, VCS_GetOperationMode, FindHome!!!!!!!!!!!!!!!!!!!!!!
        
        If (oResult) Then
            Select Case m_uMode
                Case 1: ActiveOperationMode.Caption = "Profile Position Mode"
                Case 3: ActiveOperationMode.Caption = "Profile Velocity Mode"
                Case 6: ActiveOperationMode.Caption = "Homing Mode"
                Case 7: ActiveOperationMode.Caption = "Interpolated Position Mode"
                Case 250: ActiveOperationMode.Caption = "Step/Direction Mode"
                Case 251: ActiveOperationMode.Caption = "Master Encoder Mode"
                Case 253: ActiveOperationMode.Caption = "Current Mode"
                Case 254: ActiveOperationMode.Caption = "Velocity Mode"
                Case 255: ActiveOperationMode.Caption = "Position Mode"
                Case Else: ActiveOperationMode.Caption = "Unknown Mode"
            End Select
        Else
            oTemp = StopTimer()
            oTemp = ShowErrorInformation(m_lErrorCode)
            
            ActiveOperationMode.Caption = "Unknown Mode"
        End If
    Else
        ActiveOperationMode.Caption = "Unknown Mode"
    End If
    
    If (oResult) Then
        oResult = VCS_GetEnableState(m_KeyHandle, m_wNodeId, lEnable, m_lErrorCode)
    
        If oResult Then
            DeviceSettings.Enabled = Not lEnable
            Enable.Enabled = Not lEnable
            Disable.Enabled = lEnable
            MoveToPos.Enabled = lEnable
            Halt.Enabled = lEnable
        Else
            oTemp = StopTimer()
            oTemp = ShowErrorInformation(m_lErrorCode)
            
            DeviceSettings.Enabled = lEnable
            Enable.Enabled = lEnable
            Disable.Enabled = Not lEnable
            MoveToPos.Enabled = Not lEnable
            Halt.Enabled = Not lEnable
        End If
    Else
        DeviceSettings.Enabled = lEnable
        Enable.Enabled = Not lEnable
        Disable.Enabled = Not lEnable
        MoveToPos.Enabled = Not lEnable
        Halt.Enabled = Not lEnable
    End If
    
    If oResult Then
        oResult = VCS_GetPositionIs(m_KeyHandle, m_wNodeId, lValue, m_lErrorCode)
        If oResult Then
            PositionActual.Text = lValue
        Else
            oTemp = StopTimer()
            oTemp = ShowErrorInformation(m_lErrorCode)
            
            PositionActual.Text = 0
        End If
    Else
        PositionActual.Text = 0
    End If
        
    UpdateStatus = oResult

End Function

'Stops the movement
Private Sub Halt_Click()
    Dim oResult As Boolean

    NodeID.Text = m_wNodeId
    
    oResult = VCS_HaltPositionMovement(m_KeyHandle, m_wNodeId, m_lErrorCode)
    If Not oResult Then
        oResult = ShowErrorInformation(m_lErrorCode)
    End If

End Sub

'Starts the movement
Private Sub MoveToPos_Click()
    Dim oResult As Boolean
    Dim lValue As Long

    NodeID.Text = m_wNodeId
    
    oResult = VCS_GetPositionIs(m_KeyHandle, m_wNodeId, lValue, m_lErrorCode)
    If oResult Then
        PositionStart.Text = lValue
    
        If RadioAbsolute.Value Then
            oResult = VCS_MoveToPosition(m_KeyHandle, m_wNodeId, TargetPosition.Text, True, m_lImmediately, m_lErrorCode)
        Else
            oResult = VCS_MoveToPosition(m_KeyHandle, m_wNodeId, TargetPosition.Text, False, m_lImmediately, m_lErrorCode)
        End If
               
        If Not oResult Then
            oResult = ShowErrorInformation(m_lErrorCode)
        End If
    End If
            
End Sub

'Changes node id
Private Sub NodeID_Change()
    If (NodeID.Text = "") Then
    Else
        Timer1.Enabled = True
        m_wNodeId = NodeID.Text
    End If
 
End Sub

Private Sub OK_Click()
    Dim oResult As Boolean
    
    oResult = RestoreEPOS()
    End
End Sub

'closes the dialog
Private Sub Timer1_Timer()
    Dim oResult As Boolean

    oResult = UpdateStatus()
    If Not oResult Then
        oResult = StopTimer()
    End If
   
End Sub

'example to show how any object can be written or read
Private Function SetObject() As Boolean
    Dim oResult As Boolean
    
    Dim index As Integer
    Dim subIndex As Byte
    Dim Data As Long
    Dim NbOfBytesToWrite As Long
    Dim NbOfBytesWritten As Long
       
    'Min. Position Limit
    index = &H607D
    subIndex = &H1
    Data = 0
    NbOfBytesToWrite = 4
    'All information about index, subindex, data range and length are from document 'EPOS Firmware Specification'
    
    oResult = VCS_GetObject(m_KeyHandle, m_wNodeId, index, subIndex, Data, NbOfBytesToWrite, NbOfBytesWritten, m_lErrorCode)
    
    If (oResult) Then
        Data = -588
        ' Value from "EPOS Firmware Specification" in Value range
        oResult = VCS_SetObject(m_KeyHandle, m_wNodeId, index, subIndex, Data, NbOfBytesToWrite, NbOfBytesWritten, m_lErrorCode)
    End If
    
    If (oResult) Then
        oResult = VCS_Store(m_KeyHandle, m_wNodeId, m_lErrorCode)
    End If
    
    If Not oResult Then
        oResult = ShowErrorInformation(m_lErrorCode)
    End If
    
    SetObject = oResult
        
End Function

'Stops timer. Status will be displayed as disconnected
Private Function StopTimer() As Boolean
    Dim oResult As Boolean
    
    Timer1.Enabled = False
    
    m_oUpdateActive = False

    StopTimer = UpdateStatus()
    
End Function

'Shows a message box with error description of the input error code
Private Function ShowErrorInformation(lErrorCode As Long) As Boolean
    Const Size = 100
    
    Dim Response
    Dim oResult As Boolean
    Dim lValue As Long
    Dim pStrErrorInfo As String * Size
      
    oResult = VCS_GetErrorInfo(lErrorCode, pStrErrorInfo, Size)
    
    If oResult Then
        Response = MsgBox(pStrErrorInfo, vbOKOnly, "Error", "", 0)
    Else
        Response = MsgBox("Error information can't be read!", vbOKOnly, "Error", "", 0)
    End If
    
    ShowErrorInformation = oResult
    End Function

    'Example CodeString
    Private Function CodeString(lErrorCodeValue As Long) As Boolean
        Const MAX_STR_SIZE = 30

        Dim oResult As Boolean
        Dim ErrorInfo As String * MAX_STR_SIZE
        Dim RetErrorInfo As String

        'Execute Function
        oResult = VCS_GetErrorInfo(lErrorCodeValue, ErrorInfo, MAX_STR_SIZE)

        'Convert Nullterminated String to VB String
        RetErrorInfo = Left$(ErrorInfo, InStr(ErrorInfo, Chr$(0)) - 1)

        CodeString = oResult

    End Function

    'Example Code DataBuffer
    Private Function CodeDataBuffer() As Boolean
        Const MAX_STR_SIZE = 19

        Dim oResult As Boolean

        Dim DataVector(MAX_STR_SIZE) As Byte
        Dim ChannelNumber As Byte
        Dim VectorSize As Long

        'Exeucte Function
        ChannelNumber = 1
        VectorSize = MAX_STR_SIZE + 1
        oResult = VCS_ReadChannelDataVector(m_KeyHandle, m_wNodeId, ChannelNumber, DataVector(0), VectorSize, m_lErrorCode)

        CodeDataBuffer = oResult

    End Function


