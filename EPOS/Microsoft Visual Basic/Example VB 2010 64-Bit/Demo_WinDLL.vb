Option Strict Off
Option Explicit On
Friend Class Demo_WinDLL
    Inherits System.Windows.Forms.Form
    Dim m_usNodeId As UShort
    Dim m_lErrorCode As UInteger
    Dim m_lImmediately As Boolean
    Dim m_lProfileAcceleration As UInteger
    Dim m_lProfileDeceleration As UInteger
    Dim m_lProfileVelocity As UInteger
    Dim m_KeyHandle As Integer
    Dim m_uMode As SByte
    Dim m_oInitialisation As Boolean
    Dim m_oUpdateActive As Boolean

    'Sets new communication settings via button 'Device Settings'
    Private Sub DeviceSettings_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles DeviceSettings.Click
        NodeID.Text = CStr(m_usNodeId)

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
    Private Sub Disable_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Disable.Click
        Dim oResult As Boolean

        NodeID.Text = CStr(m_usNodeId)

        oResult = VCS_SetDisableState(m_KeyHandle, m_usNodeId, m_lErrorCode)
        If Not oResult Then
            oResult = ShowErrorInformation(m_lErrorCode)
        End If

    End Sub

    'Sets device to enable state
    Private Sub Enable_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Enable.Click
        Dim oResult As Boolean

        NodeID.Text = CStr(m_usNodeId)

        oResult = VCS_SetEnableState(m_KeyHandle, m_usNodeId, m_lErrorCode)
        If Not oResult Then
            oResult = ShowErrorInformation(m_lErrorCode)
        End If

    End Sub

    Private Sub Form1_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

        m_lImmediately = 0
        m_usNodeId = 1

        If (OpenDevice()) Then
            m_oInitialisation = True
            m_oUpdateActive = True
            Timer1.Enabled = True
        Else
            m_oInitialisation = False
            m_oUpdateActive = False
        End If

    End Sub

    Private Sub Form1_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Dim oResult As Boolean

        oResult = RestoreEPOS()
    End Sub

    'Opens communication interface via the OpenDeviceDlg
    Private Function OpenDevice() As Boolean

        Dim oResult As Boolean
        Dim lValue As Integer

        m_KeyHandle = VCS_OpenDeviceDlg(m_lErrorCode)
        If m_KeyHandle Then
            'Deletes the error history
            oResult = VCS_ClearFault(m_KeyHandle, m_usNodeId, m_lErrorCode)
            If oResult Then
                'Reads Operational Mode
                oResult = VCS_GetOperationMode(m_KeyHandle, m_usNodeId, m_uMode, m_lErrorCode)
                If oResult Then
                    'Reads Position Profile Objects
                    oResult = VCS_GetPositionProfile(m_KeyHandle, m_usNodeId, m_lProfileVelocity, m_lProfileAcceleration, m_lProfileDeceleration, m_lErrorCode)
                    If oResult Then
                        'Write Opeational Mode (Profile Position Mode)
                        oResult = VCS_SetOperationMode(m_KeyHandle, m_usNodeId, 1, m_lErrorCode)
                        If oResult Then
                            'Write Position Profile Objects
                            oResult = VCS_SetPositionProfile(m_KeyHandle, m_usNodeId, 100, 1000, 1000, m_lErrorCode)
                            If oResult Then
                                'Reads the actual position
                                oResult = VCS_GetPositionIs(m_KeyHandle, m_usNodeId, lValue, m_lErrorCode)
                                If oResult Then
                                    PositionStart.Text = CStr(lValue)
                                End If
                            End If
                        End If
                    End If
                End If
            End If

            If Not oResult Then
                ShowErrorInformation(m_lErrorCode)
            End If

        End If

        OpenDevice = oResult
    End Function

    'Restores the old settings, stops the timer and delete the key handle
    Private Function RestoreEPOS() As Boolean
        Dim oResult As Boolean

        If m_oInitialisation Then
            oResult = VCS_SetDisableState(m_KeyHandle, m_usNodeId, m_lErrorCode)
            oResult = VCS_SetOperationMode(m_KeyHandle, m_usNodeId, m_uMode, m_lErrorCode)
            oResult = VCS_SetPositionProfile(m_KeyHandle, m_usNodeId, m_lProfileVelocity, m_lProfileAcceleration, m_lProfileDeceleration, m_lErrorCode)
        End If

        oResult = StopTimer()

        oResult = VCS_CloseAllDevices(m_lErrorCode)

        RestoreEPOS = oResult

    End Function

    'Updates the display
    Private Function UpdateStatus() As Boolean
        Dim oResult As Boolean
        Dim oTemp As Boolean
        Dim lEnable As Integer
        Dim lValue As Integer

        lEnable = 1
        oResult = m_oUpdateActive

        If (RadioRelative.Checked) Then
            MoveToPos.Text = "&Move Relative"
        Else
            MoveToPos.Text = "&Move Absolute"
        End If

        If oResult Then
            oResult = VCS_GetOperationMode(m_KeyHandle, m_usNodeId, m_uMode, m_lErrorCode)

            If (oResult) Then
                Select Case m_uMode
                    Case 1 : ActiveOperationMode.Text = "Profile Position Mode"
                    Case 3 : ActiveOperationMode.Text = "Profile Velocity Mode"
                    Case 6 : ActiveOperationMode.Text = "Homing Mode"
                    Case 7 : ActiveOperationMode.Text = "Interpolated Position Mode"
                    Case -6 : ActiveOperationMode.Text = "Step/Direction Mode"
                    Case -5 : ActiveOperationMode.Text = "Master Encoder Mode"
                    Case -3 : ActiveOperationMode.Text = "Current Mode"
                    Case -2 : ActiveOperationMode.Text = "Velocity Mode"
                    Case -1 : ActiveOperationMode.Text = "Position Mode"
                    Case Else : ActiveOperationMode.Text = "Unknown Mode"
                End Select
            Else
                oTemp = StopTimer()
                oTemp = ShowErrorInformation(m_lErrorCode)

                ActiveOperationMode.Text = "Unknown Mode"
            End If
        Else
            ActiveOperationMode.Text = "Unknown Mode"
        End If

        If (oResult) Then
            oResult = VCS_GetEnableState(m_KeyHandle, m_usNodeId, lEnable, m_lErrorCode)

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
            oResult = VCS_GetPositionIs(m_KeyHandle, m_usNodeId, lValue, m_lErrorCode)
            If oResult Then
                PositionActual.Text = CStr(lValue)
            Else
                oTemp = StopTimer()
                oTemp = ShowErrorInformation(m_lErrorCode)

                PositionActual.Text = CStr(0)
            End If
        Else
            PositionActual.Text = CStr(0)
        End If

        UpdateStatus = oResult

    End Function

    'Stops the movement
    Private Sub Halt_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Halt.Click
        Dim oResult As Boolean

        NodeID.Text = CStr(m_usNodeId)

        oResult = VCS_HaltPositionMovement(m_KeyHandle, m_usNodeId, m_lErrorCode)
        If Not oResult Then
            oResult = ShowErrorInformation(m_lErrorCode)
        End If

    End Sub

    'Starts the movement
    Private Sub MoveToPos_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MoveToPos.Click
        Dim oResult As Boolean
        Dim lValue As Integer

        NodeID.Text = CStr(m_usNodeId)

        oResult = VCS_GetPositionIs(m_KeyHandle, m_usNodeId, lValue, m_lErrorCode)
        If oResult Then
            PositionStart.Text = CStr(lValue)

            If RadioAbsolute.Checked Then
                oResult = VCS_MoveToPosition(m_KeyHandle, m_usNodeId, CInt(TargetPosition.Text), True, m_lImmediately, m_lErrorCode)
            Else
                oResult = VCS_MoveToPosition(m_KeyHandle, m_usNodeId, CInt(TargetPosition.Text), False, m_lImmediately, m_lErrorCode)
            End If

            If Not oResult Then
                oResult = ShowErrorInformation(m_lErrorCode)
            End If
        End If

    End Sub

    'Changes node id
    Private Sub NodeID_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles NodeID.TextChanged
        If (NodeID.Text = "") Then
        Else
            Timer1.Enabled = True
            m_usNodeId = CShort(NodeID.Text)
        End If

    End Sub

    Private Sub OK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles OK.Click
        Dim oResult As Boolean

        oResult = RestoreEPOS()
        End
    End Sub

    'closes the dialog
    Private Sub Timer1_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Timer1.Tick
        Dim oResult As Boolean

        oResult = UpdateStatus()
        If Not oResult Then
            oResult = StopTimer()
        End If

    End Sub

    'example to show how any object can be written or read
    Private Function SetObject() As Boolean
        Dim oResult As Boolean

        Dim index As UShort
        Dim subIndex As Byte
        Dim Data As Integer
        Dim NbOfBytesToWrite As Integer
        Dim NbOfBytesWritten As Integer

        'Min. Position Limit
        index = &H607DS
        subIndex = &H1S
        Data = 0
        NbOfBytesToWrite = 4
        'All information about index, subindex, data range and length are from document 'EPOS Firmware Specification'

        oResult = VCS_GetObject(m_KeyHandle, m_usNodeId, index, subIndex, Data, NbOfBytesToWrite, NbOfBytesWritten, m_lErrorCode)

        If (oResult) Then
            Data = -588
            ' Value from "EPOS Firmware Specification" in Value range
            oResult = VCS_SetObject(m_KeyHandle, m_usNodeId, index, subIndex, Data, NbOfBytesToWrite, NbOfBytesWritten, m_lErrorCode)
        End If

        If (oResult) Then
            oResult = VCS_Store(m_KeyHandle, m_usNodeId, m_lErrorCode)
        End If

        If Not oResult Then
            oResult = ShowErrorInformation(m_lErrorCode)
        End If

        SetObject = oResult

    End Function

    'Stops timer. Status will be displayed as disconnected
    Private Function StopTimer() As Boolean

        Timer1.Enabled = False

        m_oUpdateActive = False

        StopTimer = UpdateStatus()

    End Function

    'Shows a message box with error description of the input error code
    Private Function ShowErrorInformation(ByVal lErrorCode As Integer) As Boolean
        Const MAX_STR_SIZE As Short = 100

        Dim oResult As Boolean
        Dim pStrErrorInfo As New VB6.FixedLengthString(MAX_STR_SIZE)

        CodeString(lErrorCode)

        oResult = VCS_GetErrorInfo(lErrorCode, pStrErrorInfo.Value, MAX_STR_SIZE)

        If oResult Then
            MsgBox(pStrErrorInfo.Value, MsgBoxStyle.OkOnly, "Error")
        Else
            MsgBox("Error information can't be read!", MsgBoxStyle.OkOnly, "Error")
        End If

        ShowErrorInformation = oResult

    End Function

    'Example CodeString
    Private Function CodeString(ByVal lErrorCodeValue As Integer) As Boolean
        Const MAX_STR_SIZE As Short = 30

        Dim oResult As Boolean
        Dim ErrorInfo As New VB6.FixedLengthString(MAX_STR_SIZE)
        Dim RetErrorInfo As String

        'Execute Function
        oResult = VCS_GetErrorInfo(lErrorCodeValue, ErrorInfo.Value, MAX_STR_SIZE)

        'Convert null terminated String to VB String
        RetErrorInfo = Microsoft.VisualBasic.Left(ErrorInfo.Value, InStr(ErrorInfo.Value, Chr(0)) - 1)

        CodeString = oResult

    End Function

    'Example Code DataBuffer
    Private Function CodeDataBuffer() As Boolean
        Const MAX_STR_SIZE As Short = 19

        Dim oResult As Boolean

        Dim DataVectorBuffer(MAX_STR_SIZE) As Byte
        Dim ChannelNumber As Byte
        Dim VectorSize As Long

        'Execute Function
        ChannelNumber = 1
        VectorSize = MAX_STR_SIZE + 1
        oResult = VCS_ReadChannelDataVector(m_KeyHandle, m_usNodeId, ChannelNumber, DataVectorBuffer(0), VectorSize, m_lErrorCode)

        CodeDataBuffer = oResult

    End Function

End Class