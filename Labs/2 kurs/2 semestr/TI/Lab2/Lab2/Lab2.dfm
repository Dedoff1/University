object Form1: TForm1
  Left = 78
  Top = 243
  BorderStyle = bsDialog
  Caption = #1055#1086#1090#1086#1082#1086#1074#1086#1077' '#1096#1080#1092#1088#1086#1074#1072#1085#1080#1077
  ClientHeight = 752
  ClientWidth = 1100
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  OldCreateOrder = False
  OnCreate = FormCreate
  PixelsPerInch = 96
  TextHeight = 13
  object lbl1: TLabel
    Left = 40
    Top = 64
    Width = 3
    Height = 13
  end
  object lbl2: TLabel
    Left = 184
    Top = 104
    Width = 51
    Height = 26
    Caption = #1048#1089#1093#1086#1076#1085#1099#1081#13#10'    '#1090#1077#1082#1089#1090':'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -11
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
  end
  object lbl3: TLabel
    Left = 720
    Top = 32
    Width = 32
    Height = 13
    Caption = #1050#1083#1102#1095':'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -11
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
  end
  object lbl4: TLabel
    Left = 712
    Top = 104
    Width = 50
    Height = 26
    Caption = #1048#1090#1086#1075#1086#1074#1099#1081#13#10'   '#1082#1083#1102#1095':'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -11
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
  end
  object lbl5: TLabel
    Left = 464
    Top = 328
    Width = 84
    Height = 26
    Caption = #1047#1072#1096#1080#1092#1088#1086#1074#1072#1085#1085#1099#1081#13#10'       '#1090#1077#1082#1089#1090':'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -11
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
  end
  object lbl6: TLabel
    Left = 192
    Top = 24
    Width = 85
    Height = 26
    Caption = #1042#1080#1076' '#1096#1080#1092#1088#1091#1077#1084#1086#1075#1086#13#10'      '#1092#1072#1081#1083#1072':'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -11
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
  end
  object lbl7: TLabel
    Left = 56
    Top = 640
    Width = 64
    Height = 13
    Caption = #1042#1080#1076' '#1088#1072#1073#1086#1090#1099':'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -11
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
    Visible = False
  end
  object mmo11: TMemo
    Left = 40
    Top = 136
    Width = 457
    Height = 169
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -19
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
    ReadOnly = True
    TabOrder = 0
  end
  object edtKey: TEdit
    Left = 512
    Top = 72
    Width = 457
    Height = 31
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -19
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
    TabOrder = 1
  end
  object mmoKey: TMemo
    Left = 512
    Top = 136
    Width = 457
    Height = 169
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -19
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
    ReadOnly = True
    TabOrder = 2
  end
  object mmo12: TMemo
    Left = 312
    Top = 368
    Width = 409
    Height = 177
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -19
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
    ReadOnly = True
    TabOrder = 3
  end
  object btn1: TButton
    Left = 544
    Top = 24
    Width = 105
    Height = 41
    Caption = #1047#1072#1096#1080#1092#1088#1086#1074#1072#1090#1100
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -11
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
    TabOrder = 4
    OnClick = btn1Click
  end
  object btn2: TButton
    Left = 800
    Top = 24
    Width = 105
    Height = 41
    Caption = #1056#1072#1089#1096#1080#1092#1088#1086#1074#1072#1090#1100
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -11
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
    TabOrder = 5
    OnClick = btn2Click
  end
  object btnRead1: TButton
    Left = 48
    Top = 24
    Width = 105
    Height = 41
    Caption = #1057#1095#1080#1090#1072#1090#1100' '#1080#1079' '#1092#1072#1081#1083#1072
    TabOrder = 6
    OnClick = btnRead1Click
  end
  object btnRead2: TButton
    Left = 352
    Top = 24
    Width = 105
    Height = 41
    Caption = #1047#1072#1075#1088#1091#1079#1080#1090#1100' '#1074' '#1092#1072#1081#1083
    TabOrder = 7
    OnClick = btnRead2Click
  end
  object cbbFile: TComboBox
    Left = 184
    Top = 72
    Width = 137
    Height = 21
    Style = csDropDownList
    ItemHeight = 13
    ItemIndex = 0
    TabOrder = 8
    Text = #1058#1077#1082#1089#1090#1086#1074#1099#1081
    Items.Strings = (
      #1058#1077#1082#1089#1090#1086#1074#1099#1081
      #1052#1091#1079#1099#1082#1072#1083#1100#1085#1099#1081
      #1060#1086#1090#1086
      #1042#1080#1076#1077#1086
      #1042#1086#1088#1076)
  end
  object cbbTypeFile: TComboBox
    Left = 40
    Top = 624
    Width = 121
    Height = 21
    Style = csDropDownList
    ItemHeight = 13
    TabOrder = 9
    Visible = False
    Items.Strings = (
      #1041#1099#1089#1090#1088#1099#1081
      #1042#1099#1073#1080#1088#1072#1102#1097#1080#1081)
  end
  object edtFile1: TEdit
    Left = 40
    Top = 72
    Width = 129
    Height = 21
    ReadOnly = True
    TabOrder = 10
  end
  object edtFile2: TEdit
    Left = 344
    Top = 72
    Width = 129
    Height = 21
    ReadOnly = True
    TabOrder = 11
  end
  object Button1: TButton
    Left = 920
    Top = 24
    Width = 105
    Height = 41
    Caption = #1054#1095#1080#1089#1090#1080#1090#1100
    TabOrder = 12
    OnClick = Button1Click
  end
  object ActionList1: TActionList
    Left = 1032
    Top = 24
    object Encryption: TAction
      Caption = 'Encryption'
    end
    object Decryption: TAction
      Caption = 'Decryption'
    end
    object StrToBits: TAction
      Caption = 'StrToBits'
    end
    object BitsToStr: TAction
      Caption = 'BitsToStr'
    end
    object WriteBits: TAction
      Caption = 'WriteBits'
    end
    object WriteBits2: TAction
      Caption = 'WriteBits2'
    end
    object BitToBool: TAction
      Caption = 'BitToBool'
    end
    object BoolToBit: TAction
      Caption = 'BoolToBit'
    end
    object StrToBitStr: TAction
      Caption = 'StrToBitStr'
    end
    object BitStrToStr: TAction
      Caption = 'BitStrToStr'
    end
    object ReadFileToString: TAction
      Caption = 'ReadFileToString'
    end
    object WriteStringToFile: TAction
      Caption = 'WriteStringToFile'
    end
    object Cheat: TAction
      Caption = 'Cheat'
    end
    object CreateInteger: TAction
      Caption = 'CreateInteger'
    end
    object EncString: TAction
      Caption = 'EncString'
    end
    object WriteAdd: TAction
      Caption = 'WriteAdd'
    end
  end
  object dlgOpen1: TOpenDialog
    Left = 1032
    Top = 96
  end
  object dlgOpen2: TOpenDialog
    Left = 1032
    Top = 168
  end
end
