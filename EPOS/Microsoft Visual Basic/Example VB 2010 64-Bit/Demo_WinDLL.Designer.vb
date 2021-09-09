<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class Demo_WinDLL
#Region "Windows Form Designer generated code "
    <System.Diagnostics.DebuggerNonUserCode()> Public Sub New()
        MyBase.New()
        'This call is required by the Windows Form Designer.
        InitializeComponent()
    End Sub
    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
        If Disposing Then
            If Not components Is Nothing Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(Disposing)
    End Sub
    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer
    Public ToolTip1 As System.Windows.Forms.ToolTip
    Public WithEvents DeviceSettings As System.Windows.Forms.Button
    Public WithEvents MoveToPos As System.Windows.Forms.Button
    Public WithEvents OK As System.Windows.Forms.Button
    Public WithEvents Halt As System.Windows.Forms.Button
    Public WithEvents Disable As System.Windows.Forms.Button
    Public WithEvents Enable As System.Windows.Forms.Button
    Public WithEvents PositionActual As System.Windows.Forms.TextBox
    Public WithEvents PositionStart As System.Windows.Forms.TextBox
    Public WithEvents Label6 As System.Windows.Forms.Label
    Public WithEvents _Label3_1 As System.Windows.Forms.Label
    Public WithEvents Label5 As System.Windows.Forms.Label
    Public WithEvents Label4 As System.Windows.Forms.Label
    Public WithEvents Frame3 As System.Windows.Forms.GroupBox
    Public WithEvents RadioAbsolute As System.Windows.Forms.RadioButton
    Public WithEvents RadioRelative As System.Windows.Forms.RadioButton
    Public WithEvents TargetPosition As System.Windows.Forms.TextBox
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents _Label3_0 As System.Windows.Forms.Label
    Public WithEvents Frame2 As System.Windows.Forms.GroupBox
    Public WithEvents NodeID As System.Windows.Forms.TextBox
    Public WithEvents Timer1 As System.Windows.Forms.Timer
    Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents ActiveOperationMode As System.Windows.Forms.Label
    Public WithEvents Frame1 As System.Windows.Forms.GroupBox
    Public WithEvents Label3 As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Demo_WinDLL))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.DeviceSettings = New System.Windows.Forms.Button
        Me.MoveToPos = New System.Windows.Forms.Button
        Me.OK = New System.Windows.Forms.Button
        Me.Halt = New System.Windows.Forms.Button
        Me.Disable = New System.Windows.Forms.Button
        Me.Enable = New System.Windows.Forms.Button
        Me.Frame3 = New System.Windows.Forms.GroupBox
        Me.PositionActual = New System.Windows.Forms.TextBox
        Me.PositionStart = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me._Label3_1 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Frame2 = New System.Windows.Forms.GroupBox
        Me.RadioAbsolute = New System.Windows.Forms.RadioButton
        Me.RadioRelative = New System.Windows.Forms.RadioButton
        Me.TargetPosition = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me._Label3_0 = New System.Windows.Forms.Label
        Me.Frame1 = New System.Windows.Forms.GroupBox
        Me.NodeID = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.ActiveOperationMode = New System.Windows.Forms.Label
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Label3 = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.Frame3.SuspendLayout()
        Me.Frame2.SuspendLayout()
        Me.Frame1.SuspendLayout()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DeviceSettings
        '
        Me.DeviceSettings.BackColor = System.Drawing.SystemColors.Control
        Me.DeviceSettings.Cursor = System.Windows.Forms.Cursors.Default
        Me.DeviceSettings.ForeColor = System.Drawing.SystemColors.ControlText
        Me.DeviceSettings.Location = New System.Drawing.Point(280, 24)
        Me.DeviceSettings.Name = "DeviceSettings"
        Me.DeviceSettings.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DeviceSettings.Size = New System.Drawing.Size(121, 25)
        Me.DeviceSettings.TabIndex = 20
        Me.DeviceSettings.Text = "Device Settings"
        Me.DeviceSettings.UseVisualStyleBackColor = False
        '
        'MoveToPos
        '
        Me.MoveToPos.BackColor = System.Drawing.SystemColors.Control
        Me.MoveToPos.Cursor = System.Windows.Forms.Cursors.Default
        Me.MoveToPos.ForeColor = System.Drawing.SystemColors.ControlText
        Me.MoveToPos.Location = New System.Drawing.Point(280, 160)
        Me.MoveToPos.Name = "MoveToPos"
        Me.MoveToPos.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.MoveToPos.Size = New System.Drawing.Size(121, 25)
        Me.MoveToPos.TabIndex = 19
        Me.MoveToPos.Text = "&Move"
        Me.MoveToPos.UseVisualStyleBackColor = False
        '
        'OK
        '
        Me.OK.BackColor = System.Drawing.SystemColors.Control
        Me.OK.Cursor = System.Windows.Forms.Cursors.Default
        Me.OK.ForeColor = System.Drawing.SystemColors.ControlText
        Me.OK.Location = New System.Drawing.Point(320, 256)
        Me.OK.Name = "OK"
        Me.OK.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.OK.Size = New System.Drawing.Size(81, 25)
        Me.OK.TabIndex = 18
        Me.OK.Text = "&OK"
        Me.OK.UseVisualStyleBackColor = False
        '
        'Halt
        '
        Me.Halt.BackColor = System.Drawing.SystemColors.Control
        Me.Halt.Cursor = System.Windows.Forms.Cursors.Default
        Me.Halt.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Halt.Location = New System.Drawing.Point(280, 192)
        Me.Halt.Name = "Halt"
        Me.Halt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Halt.Size = New System.Drawing.Size(121, 25)
        Me.Halt.TabIndex = 17
        Me.Halt.Text = "&Halt"
        Me.Halt.UseVisualStyleBackColor = False
        '
        'Disable
        '
        Me.Disable.BackColor = System.Drawing.SystemColors.Control
        Me.Disable.Cursor = System.Windows.Forms.Cursors.Default
        Me.Disable.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Disable.Location = New System.Drawing.Point(280, 120)
        Me.Disable.Name = "Disable"
        Me.Disable.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Disable.Size = New System.Drawing.Size(121, 25)
        Me.Disable.TabIndex = 16
        Me.Disable.Text = "&Disable"
        Me.Disable.UseVisualStyleBackColor = False
        '
        'Enable
        '
        Me.Enable.BackColor = System.Drawing.SystemColors.Control
        Me.Enable.Cursor = System.Windows.Forms.Cursors.Default
        Me.Enable.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Enable.Location = New System.Drawing.Point(280, 88)
        Me.Enable.Name = "Enable"
        Me.Enable.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Enable.Size = New System.Drawing.Size(121, 25)
        Me.Enable.TabIndex = 15
        Me.Enable.Text = "&Enable"
        Me.Enable.UseVisualStyleBackColor = False
        '
        'Frame3
        '
        Me.Frame3.BackColor = System.Drawing.SystemColors.Control
        Me.Frame3.Controls.Add(Me.PositionActual)
        Me.Frame3.Controls.Add(Me.PositionStart)
        Me.Frame3.Controls.Add(Me.Label6)
        Me.Frame3.Controls.Add(Me._Label3_1)
        Me.Frame3.Controls.Add(Me.Label5)
        Me.Frame3.Controls.Add(Me.Label4)
        Me.Frame3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame3.Location = New System.Drawing.Point(8, 208)
        Me.Frame3.Name = "Frame3"
        Me.Frame3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame3.Size = New System.Drawing.Size(249, 77)
        Me.Frame3.TabIndex = 8
        Me.Frame3.TabStop = False
        Me.Frame3.Text = "Actual Values"
        '
        'PositionActual
        '
        Me.PositionActual.AcceptsReturn = True
        Me.PositionActual.BackColor = System.Drawing.SystemColors.Window
        Me.PositionActual.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.PositionActual.Enabled = False
        Me.PositionActual.ForeColor = System.Drawing.SystemColors.WindowText
        Me.PositionActual.Location = New System.Drawing.Point(128, 47)
        Me.PositionActual.MaxLength = 0
        Me.PositionActual.Name = "PositionActual"
        Me.PositionActual.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.PositionActual.Size = New System.Drawing.Size(89, 20)
        Me.PositionActual.TabIndex = 12
        Me.PositionActual.Text = "0"
        '
        'PositionStart
        '
        Me.PositionStart.AcceptsReturn = True
        Me.PositionStart.BackColor = System.Drawing.SystemColors.Window
        Me.PositionStart.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.PositionStart.Enabled = False
        Me.PositionStart.ForeColor = System.Drawing.SystemColors.WindowText
        Me.PositionStart.Location = New System.Drawing.Point(128, 23)
        Me.PositionStart.MaxLength = 0
        Me.PositionStart.Name = "PositionStart"
        Me.PositionStart.ReadOnly = True
        Me.PositionStart.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.PositionStart.Size = New System.Drawing.Size(89, 20)
        Me.PositionStart.TabIndex = 11
        Me.PositionStart.Text = "0"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(224, 48)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(20, 17)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "qc"
        '
        '_Label3_1
        '
        Me._Label3_1.BackColor = System.Drawing.SystemColors.Control
        Me._Label3_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label3_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.SetIndex(Me._Label3_1, CType(1, Short))
        Me._Label3_1.Location = New System.Drawing.Point(224, 24)
        Me._Label3_1.Name = "_Label3_1"
        Me._Label3_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label3_1.Size = New System.Drawing.Size(20, 17)
        Me._Label3_1.TabIndex = 13
        Me._Label3_1.Text = "qc"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(16, 48)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(113, 17)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Position Actual Value"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(16, 24)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(73, 17)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Position Start"
        '
        'Frame2
        '
        Me.Frame2.BackColor = System.Drawing.SystemColors.Control
        Me.Frame2.Controls.Add(Me.RadioAbsolute)
        Me.Frame2.Controls.Add(Me.RadioRelative)
        Me.Frame2.Controls.Add(Me.TargetPosition)
        Me.Frame2.Controls.Add(Me.Label2)
        Me.Frame2.Controls.Add(Me._Label3_0)
        Me.Frame2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame2.Location = New System.Drawing.Point(8, 96)
        Me.Frame2.Name = "Frame2"
        Me.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame2.Size = New System.Drawing.Size(249, 97)
        Me.Frame2.TabIndex = 1
        Me.Frame2.TabStop = False
        Me.Frame2.Text = "Profile"
        '
        'RadioAbsolute
        '
        Me.RadioAbsolute.BackColor = System.Drawing.SystemColors.Control
        Me.RadioAbsolute.Cursor = System.Windows.Forms.Cursors.Default
        Me.RadioAbsolute.ForeColor = System.Drawing.SystemColors.ControlText
        Me.RadioAbsolute.Location = New System.Drawing.Point(128, 72)
        Me.RadioAbsolute.Name = "RadioAbsolute"
        Me.RadioAbsolute.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.RadioAbsolute.Size = New System.Drawing.Size(105, 17)
        Me.RadioAbsolute.TabIndex = 7
        Me.RadioAbsolute.TabStop = True
        Me.RadioAbsolute.Text = "Absolute Move"
        Me.RadioAbsolute.UseVisualStyleBackColor = False
        '
        'RadioRelative
        '
        Me.RadioRelative.BackColor = System.Drawing.SystemColors.Control
        Me.RadioRelative.Checked = True
        Me.RadioRelative.Cursor = System.Windows.Forms.Cursors.Default
        Me.RadioRelative.ForeColor = System.Drawing.SystemColors.ControlText
        Me.RadioRelative.Location = New System.Drawing.Point(128, 50)
        Me.RadioRelative.Name = "RadioRelative"
        Me.RadioRelative.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.RadioRelative.Size = New System.Drawing.Size(97, 17)
        Me.RadioRelative.TabIndex = 6
        Me.RadioRelative.TabStop = True
        Me.RadioRelative.Text = "Relative Move"
        Me.RadioRelative.UseVisualStyleBackColor = False
        '
        'TargetPosition
        '
        Me.TargetPosition.AcceptsReturn = True
        Me.TargetPosition.BackColor = System.Drawing.SystemColors.Window
        Me.TargetPosition.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TargetPosition.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TargetPosition.Location = New System.Drawing.Point(128, 20)
        Me.TargetPosition.MaxLength = 0
        Me.TargetPosition.Name = "TargetPosition"
        Me.TargetPosition.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TargetPosition.Size = New System.Drawing.Size(89, 20)
        Me.TargetPosition.TabIndex = 2
        Me.TargetPosition.Text = "2000"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(16, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(89, 17)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Target Position"
        '
        '_Label3_0
        '
        Me._Label3_0.BackColor = System.Drawing.SystemColors.Control
        Me._Label3_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label3_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.SetIndex(Me._Label3_0, CType(0, Short))
        Me._Label3_0.Location = New System.Drawing.Point(224, 24)
        Me._Label3_0.Name = "_Label3_0"
        Me._Label3_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label3_0.Size = New System.Drawing.Size(20, 17)
        Me._Label3_0.TabIndex = 3
        Me._Label3_0.Text = "qc"
        '
        'Frame1
        '
        Me.Frame1.BackColor = System.Drawing.SystemColors.Control
        Me.Frame1.Controls.Add(Me.NodeID)
        Me.Frame1.Controls.Add(Me.Label1)
        Me.Frame1.Controls.Add(Me.ActiveOperationMode)
        Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame1.Location = New System.Drawing.Point(8, 8)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(249, 77)
        Me.Frame1.TabIndex = 0
        Me.Frame1.TabStop = False
        Me.Frame1.Text = "Active Operation Mode"
        '
        'NodeID
        '
        Me.NodeID.AcceptsReturn = True
        Me.NodeID.BackColor = System.Drawing.SystemColors.Window
        Me.NodeID.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.NodeID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.NodeID.Location = New System.Drawing.Point(128, 47)
        Me.NodeID.MaxLength = 0
        Me.NodeID.Name = "NodeID"
        Me.NodeID.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.NodeID.Size = New System.Drawing.Size(89, 20)
        Me.NodeID.TabIndex = 22
        Me.NodeID.Text = "1"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(16, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(97, 17)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Node ID"
        '
        'ActiveOperationMode
        '
        Me.ActiveOperationMode.BackColor = System.Drawing.SystemColors.Control
        Me.ActiveOperationMode.Cursor = System.Windows.Forms.Cursors.Default
        Me.ActiveOperationMode.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ActiveOperationMode.Location = New System.Drawing.Point(16, 24)
        Me.ActiveOperationMode.Name = "ActiveOperationMode"
        Me.ActiveOperationMode.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ActiveOperationMode.Size = New System.Drawing.Size(169, 17)
        Me.ActiveOperationMode.TabIndex = 4
        Me.ActiveOperationMode.Text = "Profile Position Mode"
        '
        'Timer1
        '
        '
        'Demo_WinDLL
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(413, 294)
        Me.Controls.Add(Me.DeviceSettings)
        Me.Controls.Add(Me.MoveToPos)
        Me.Controls.Add(Me.OK)
        Me.Controls.Add(Me.Halt)
        Me.Controls.Add(Me.Disable)
        Me.Controls.Add(Me.Enable)
        Me.Controls.Add(Me.Frame3)
        Me.Controls.Add(Me.Frame2)
        Me.Controls.Add(Me.Frame1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(34, 45)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Demo_WinDLL"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "EPOS Command Library with Microsoft Visual Basic 2005 64-Bit"
        Me.Frame3.ResumeLayout(False)
        Me.Frame3.PerformLayout()
        Me.Frame2.ResumeLayout(False)
        Me.Frame2.PerformLayout()
        Me.Frame1.ResumeLayout(False)
        Me.Frame1.PerformLayout()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
#End Region
End Class