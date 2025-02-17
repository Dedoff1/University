object Form1: TForm1
  Left = 243
  Top = 198
  Width = 1032
  Height = 641
  Caption = #1043#1088#1072#1092#1099
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
    Left = 8
    Top = 24
    Width = 86
    Height = 13
    Caption = #1063#1080#1089#1083#1086' '#1101#1083#1077#1084#1077#1085#1090#1086#1074
  end
  object lbl2: TLabel
    Left = 16
    Top = 336
    Width = 25
    Height = 13
    Caption = #1055#1091#1090#1080
  end
  object lbl4: TLabel
    Left = 184
    Top = 24
    Width = 12
    Height = 13
    Caption = #1086#1090
  end
  object lbl5: TLabel
    Left = 272
    Top = 24
    Width = 13
    Height = 13
    Caption = #1076#1086
  end
  object imgGraph: TImage
    Left = 488
    Top = 8
    Width = 505
    Height = 441
  end
  object lblLong: TLabel
    Left = 488
    Top = 472
    Width = 156
    Height = 19
    Caption = #1057#1072#1084#1099#1081' '#1076#1083#1080#1085#1085#1099#1081' '#1087#1091#1090#1100
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -16
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
  end
  object lblShort: TLabel
    Left = 488
    Top = 504
    Width = 160
    Height = 19
    Caption = #1057#1072#1084#1099#1081' '#1082#1086#1088#1086#1090#1082#1080#1081' '#1087#1091#1090#1100
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -16
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
  end
  object lblCenter: TLabel
    Left = 488
    Top = 536
    Width = 100
    Height = 19
    Caption = #1062#1077#1085#1090#1088' '#1075#1088#1072#1092#1072':'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -16
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
  end
  object btnSort: TButton
    Left = 160
    Top = 296
    Width = 75
    Height = 25
    Caption = #1053#1072#1081#1090#1080' '#1087#1091#1090#1080
    TabOrder = 0
    OnClick = btnSortClick
  end
  object mmoWays: TMemo
    Left = 16
    Top = 352
    Width = 457
    Height = 233
    Lines.Strings = (
      'mmoWays')
    TabOrder = 1
  end
  object nudCount: TAdvSpinEdit
    Left = 96
    Top = 16
    Width = 73
    Height = 22
    Value = 7
    FloatValue = 7.000000000000000000
    TimeValue = 0.291666666666666700
    HexValue = 0
    IncrementFloat = 0.100000000000000000
    IncrementFloatPage = 1.000000000000000000
    LabelFont.Charset = DEFAULT_CHARSET
    LabelFont.Color = clWindowText
    LabelFont.Height = -11
    LabelFont.Name = 'Tahoma'
    LabelFont.Style = []
    MaxValue = 10
    MinValue = 1
    TabOrder = 2
    Visible = True
    Version = '1.5.2.1'
    OnChange = nudCountChange
  end
  object nudFist: TAdvSpinEdit
    Left = 200
    Top = 16
    Width = 57
    Height = 22
    Value = 4
    FloatValue = 4.000000000000000000
    TimeValue = 0.166666666666666700
    HexValue = 0
    IncrementFloat = 0.100000000000000000
    IncrementFloatPage = 1.000000000000000000
    LabelFont.Charset = DEFAULT_CHARSET
    LabelFont.Color = clWindowText
    LabelFont.Height = -11
    LabelFont.Name = 'Tahoma'
    LabelFont.Style = []
    MaxValue = 10
    TabOrder = 3
    Visible = True
    Version = '1.5.2.1'
  end
  object nudLast: TAdvSpinEdit
    Left = 296
    Top = 16
    Width = 57
    Height = 22
    Value = 2
    FloatValue = 2.000000000000000000
    TimeValue = 0.083333333333333330
    HexValue = 0
    IncrementFloat = 0.100000000000000000
    IncrementFloatPage = 1.000000000000000000
    LabelFont.Charset = DEFAULT_CHARSET
    LabelFont.Color = clWindowText
    LabelFont.Height = -11
    LabelFont.Name = 'Tahoma'
    LabelFont.Style = []
    MaxValue = 10
    TabOrder = 4
    Visible = True
    Version = '1.5.2.1'
  end
  object stg1: TAdvStringGrid
    Left = 8
    Top = 48
    Width = 465
    Height = 217
    Cursor = crDefault
    ColCount = 7
    FixedCols = 0
    RowCount = 7
    FixedRows = 0
    Options = [goFixedVertLine, goFixedHorzLine, goVertLine, goHorzLine, goRangeSelect, goEditing, goTabs]
    ScrollBars = ssBoth
    TabOrder = 5
    HoverRowCells = [hcNormal, hcSelected]
    ActiveCellFont.Charset = DEFAULT_CHARSET
    ActiveCellFont.Color = clWindowText
    ActiveCellFont.Height = -11
    ActiveCellFont.Name = 'Tahoma'
    ActiveCellFont.Style = [fsBold]
    ControlLook.FixedGradientHoverFrom = clGray
    ControlLook.FixedGradientHoverTo = clWhite
    ControlLook.FixedGradientDownFrom = clGray
    ControlLook.FixedGradientDownTo = clSilver
    ControlLook.DropDownHeader.Font.Charset = DEFAULT_CHARSET
    ControlLook.DropDownHeader.Font.Color = clWindowText
    ControlLook.DropDownHeader.Font.Height = -11
    ControlLook.DropDownHeader.Font.Name = 'Tahoma'
    ControlLook.DropDownHeader.Font.Style = []
    ControlLook.DropDownHeader.Visible = True
    ControlLook.DropDownHeader.Buttons = <>
    ControlLook.DropDownFooter.Font.Charset = DEFAULT_CHARSET
    ControlLook.DropDownFooter.Font.Color = clWindowText
    ControlLook.DropDownFooter.Font.Height = -11
    ControlLook.DropDownFooter.Font.Name = 'Tahoma'
    ControlLook.DropDownFooter.Font.Style = []
    ControlLook.DropDownFooter.Visible = True
    ControlLook.DropDownFooter.Buttons = <>
    Filter = <>
    FilterDropDown.Font.Charset = DEFAULT_CHARSET
    FilterDropDown.Font.Color = clWindowText
    FilterDropDown.Font.Height = -11
    FilterDropDown.Font.Name = 'Tahoma'
    FilterDropDown.Font.Style = []
    FilterDropDownClear = '(All)'
    FixedRowHeight = 22
    FixedFont.Charset = DEFAULT_CHARSET
    FixedFont.Color = clWindowText
    FixedFont.Height = -11
    FixedFont.Name = 'Tahoma'
    FixedFont.Style = [fsBold]
    FloatFormat = '%.2f'
    PrintSettings.DateFormat = 'dd/mm/yyyy'
    PrintSettings.Font.Charset = DEFAULT_CHARSET
    PrintSettings.Font.Color = clWindowText
    PrintSettings.Font.Height = -11
    PrintSettings.Font.Name = 'Tahoma'
    PrintSettings.Font.Style = []
    PrintSettings.FixedFont.Charset = DEFAULT_CHARSET
    PrintSettings.FixedFont.Color = clWindowText
    PrintSettings.FixedFont.Height = -11
    PrintSettings.FixedFont.Name = 'Tahoma'
    PrintSettings.FixedFont.Style = []
    PrintSettings.HeaderFont.Charset = DEFAULT_CHARSET
    PrintSettings.HeaderFont.Color = clWindowText
    PrintSettings.HeaderFont.Height = -11
    PrintSettings.HeaderFont.Name = 'Tahoma'
    PrintSettings.HeaderFont.Style = []
    PrintSettings.FooterFont.Charset = DEFAULT_CHARSET
    PrintSettings.FooterFont.Color = clWindowText
    PrintSettings.FooterFont.Height = -11
    PrintSettings.FooterFont.Name = 'Tahoma'
    PrintSettings.FooterFont.Style = []
    PrintSettings.PageNumSep = '/'
    SearchFooter.FindNextCaption = 'Find &next'
    SearchFooter.FindPrevCaption = 'Find &previous'
    SearchFooter.Font.Charset = DEFAULT_CHARSET
    SearchFooter.Font.Color = clWindowText
    SearchFooter.Font.Height = -11
    SearchFooter.Font.Name = 'Tahoma'
    SearchFooter.Font.Style = []
    SearchFooter.HighLightCaption = 'Highlight'
    SearchFooter.HintClose = 'Close'
    SearchFooter.HintFindNext = 'Find next occurrence'
    SearchFooter.HintFindPrev = 'Find previous occurrence'
    SearchFooter.HintHighlight = 'Highlight occurrences'
    SearchFooter.MatchCaseCaption = 'Match case'
    Version = '6.2.1.1'
  end
end
