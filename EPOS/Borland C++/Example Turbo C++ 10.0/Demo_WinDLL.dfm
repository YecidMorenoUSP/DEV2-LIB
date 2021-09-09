object DemoDlg: TDemoDlg
  Left = 528
  Top = 341
  BorderIcons = [biSystemMenu]
  BorderStyle = bsSingle
  Caption = ' Demo EPOS WinDLL for Borland C++Builder 10.0'
  ClientHeight = 291
  ClientWidth = 419
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  OnCreate = Create
  OnDestroy = Destroy
  PixelsPerInch = 96
  TextHeight = 13
  object GroupBox1: TGroupBox
    Left = 8
    Top = 8
    Width = 249
    Height = 75
    Caption = 'Actual Operation Mode/Node ID'
    TabOrder = 0
    object ActiveMode: TLabel
      Left = 16
      Top = 24
      Width = 127
      Height = 16
      Caption = 'Profile Position Mode'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -15
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
    end
    object Label1: TLabel
      Left = 16
      Top = 48
      Width = 40
      Height = 13
      Caption = 'Node ID'
    end
    object NodeId: TEdit
      Left = 136
      Top = 44
      Width = 73
      Height = 21
      TabOrder = 0
      Text = '1'
      OnChange = OnChangeNodeId
    end
  end
  object GroupBox2: TGroupBox
    Left = 8
    Top = 96
    Width = 249
    Height = 97
    Caption = 'Profile'
    TabOrder = 1
    object Label2: TLabel
      Left = 16
      Top = 24
      Width = 71
      Height = 13
      Caption = 'Target Position'
    end
    object Label3: TLabel
      Left = 216
      Top = 24
      Width = 12
      Height = 13
      Caption = 'qc'
    end
    object PositionTarget: TEdit
      Left = 136
      Top = 20
      Width = 73
      Height = 21
      TabOrder = 0
      Text = '2000'
    end
    object RadioRelative: TRadioButton
      Left = 136
      Top = 48
      Width = 105
      Height = 17
      Caption = 'Relative Move'
      Checked = True
      TabOrder = 1
      TabStop = True
    end
    object RadioAbsolute: TRadioButton
      Left = 136
      Top = 72
      Width = 105
      Height = 17
      Caption = 'Absolute Move'
      TabOrder = 2
    end
  end
  object GroupBox3: TGroupBox
    Left = 8
    Top = 208
    Width = 249
    Height = 75
    Caption = 'Actual Values'
    TabOrder = 2
    object Label4: TLabel
      Left = 16
      Top = 24
      Width = 62
      Height = 13
      Caption = 'Position Start'
    end
    object Label5: TLabel
      Left = 16
      Top = 48
      Width = 100
      Height = 13
      Caption = 'Position Actual Value'
    end
    object Label6: TLabel
      Left = 216
      Top = 24
      Width = 12
      Height = 13
      Caption = 'qc'
    end
    object Label7: TLabel
      Left = 216
      Top = 48
      Width = 12
      Height = 13
      Caption = 'qc'
    end
    object PositionStart: TEdit
      Left = 136
      Top = 20
      Width = 73
      Height = 21
      Enabled = False
      TabOrder = 0
      Text = '0'
    end
    object PositionActual: TEdit
      Left = 136
      Top = 44
      Width = 73
      Height = 21
      Enabled = False
      TabOrder = 1
      Text = '0'
    end
  end
  object Enable: TButton
    Left = 280
    Top = 96
    Width = 129
    Height = 25
    Caption = 'Enable'
    TabOrder = 4
    OnClick = EnableClick
  end
  object Disable: TButton
    Left = 280
    Top = 128
    Width = 129
    Height = 25
    Caption = 'Disable'
    TabOrder = 5
    OnClick = DisableClick
  end
  object Move: TButton
    Left = 280
    Top = 168
    Width = 129
    Height = 25
    Caption = 'Move'
    TabOrder = 6
    OnClick = MoveClick
  end
  object Halt: TButton
    Left = 280
    Top = 200
    Width = 129
    Height = 25
    Caption = 'Halt'
    TabOrder = 7
    OnClick = HaltClick
  end
  object OK: TButton
    Left = 328
    Top = 256
    Width = 81
    Height = 25
    Caption = 'Exit'
    TabOrder = 8
    OnClick = OKClick
  end
  object DeviceSettings: TButton
    Left = 280
    Top = 16
    Width = 129
    Height = 25
    Caption = 'Device Settings'
    TabOrder = 3
    OnClick = DeviceSettingsClick
  end
  object Timer: TTimer
    Enabled = False
    Interval = 100
    OnTimer = OnTimer
    Left = 376
    Top = 56
  end
end
