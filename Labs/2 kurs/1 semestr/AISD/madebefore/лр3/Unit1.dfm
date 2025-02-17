object Form1: TForm1
  Left = 259
  Top = 113
  Width = 1019
  Height = 486
  Caption = 'Form1'
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  OldCreateOrder = False
  PixelsPerInch = 96
  TextHeight = 13
  object cht1: TChart
    Left = 8
    Top = 8
    Width = 497
    Height = 377
    BackWall.Brush.Color = clWhite
    BackWall.Color = clWhite
    Title.Text.Strings = (
      #1050#1055#1044' '#1089#1080#1089#1090#1077#1084#1099' '#1076#1083#1103' '#1088#1072#1079#1083#1080#1095#1085#1086#1075#1086' '#1074#1088#1077#1084#1077#1085#1080' '#1074#1074#1086#1076#1072)
    BackColor = clWhite
    BottomAxis.Title.Caption = #1042#1088#1077#1084#1103' '#1086#1076#1085#1086#1075#1086' '#1090#1072#1082#1090#1072
    LeftAxis.Title.Caption = #1050#1055#1044' '#1089#1080#1089#1090#1077#1084#1099
    Legend.ColorWidth = 50
    Legend.LegendStyle = lsSeries
    View3D = False
    BevelOuter = bvNone
    TabOrder = 0
    object Series1: TLineSeries
      Marks.ArrowLength = 8
      Marks.Visible = False
      SeriesColor = clRed
      Title = '1 '#1091'.'#1077'.'#1074'.'
      LinePen.Width = 2
      Pointer.InflateMargins = True
      Pointer.Style = psRectangle
      Pointer.Visible = False
      XValues.DateTime = False
      XValues.Name = 'X'
      XValues.Multiplier = 1.000000000000000000
      XValues.Order = loAscending
      YValues.DateTime = False
      YValues.Name = 'Y'
      YValues.Multiplier = 1.000000000000000000
      YValues.Order = loNone
    end
    object Series2: TLineSeries
      Marks.ArrowLength = 8
      Marks.Visible = False
      SeriesColor = clGreen
      Title = '2 '#1091'.'#1077'.'#1074'.'
      LinePen.Width = 2
      Pointer.InflateMargins = True
      Pointer.Style = psRectangle
      Pointer.Visible = False
      XValues.DateTime = False
      XValues.Name = 'X'
      XValues.Multiplier = 1.000000000000000000
      XValues.Order = loAscending
      YValues.DateTime = False
      YValues.Name = 'Y'
      YValues.Multiplier = 1.000000000000000000
      YValues.Order = loNone
    end
    object Series3: TLineSeries
      Marks.ArrowLength = 8
      Marks.Visible = False
      SeriesColor = clYellow
      Title = '3 '#1091'.'#1077'.'#1074'.'
      LinePen.Width = 2
      Pointer.InflateMargins = True
      Pointer.Style = psRectangle
      Pointer.Visible = False
      XValues.DateTime = False
      XValues.Name = 'X'
      XValues.Multiplier = 1.000000000000000000
      XValues.Order = loAscending
      YValues.DateTime = False
      YValues.Name = 'Y'
      YValues.Multiplier = 1.000000000000000000
      YValues.Order = loNone
    end
    object Series4: TLineSeries
      Marks.ArrowLength = 8
      Marks.Visible = False
      SeriesColor = clBlue
      Title = '4 '#1091'.'#1077'.'#1074'.'
      LinePen.Width = 2
      Pointer.InflateMargins = True
      Pointer.Style = psRectangle
      Pointer.Visible = False
      XValues.DateTime = False
      XValues.Name = 'X'
      XValues.Multiplier = 1.000000000000000000
      XValues.Order = loAscending
      YValues.DateTime = False
      YValues.Name = 'Y'
      YValues.Multiplier = 1.000000000000000000
      YValues.Order = loNone
    end
    object Series5: TLineSeries
      Marks.ArrowLength = 8
      Marks.Visible = False
      SeriesColor = clBlack
      Title = '5 '#1091'.'#1077'.'#1074'.'
      LinePen.Width = 2
      Pointer.InflateMargins = True
      Pointer.Style = psRectangle
      Pointer.Visible = False
      XValues.DateTime = False
      XValues.Name = 'X'
      XValues.Multiplier = 1.000000000000000000
      XValues.Order = loAscending
      YValues.DateTime = False
      YValues.Name = 'Y'
      YValues.Multiplier = 1.000000000000000000
      YValues.Order = loNone
    end
  end
  object btn1: TButton
    Left = 440
    Top = 400
    Width = 105
    Height = 25
    Caption = #1055#1088#1086#1074#1077#1089#1090#1080' '#1088#1072#1089#1095#1105#1090
    TabOrder = 1
    OnClick = btn1Click
  end
  object cht2: TChart
    Left = 512
    Top = 0
    Width = 489
    Height = 377
    BackWall.Brush.Color = clWhite
    BackWall.Color = clWhite
    Title.Text.Strings = (
      #1042#1088#1077#1084#1103' '#1087#1088#1086#1089#1090#1086#1103' '#1076#1083#1103' '#1088#1072#1079#1083#1080#1095#1085#1086#1075#1086' '#1074#1088#1077#1084#1077#1085#1080' '#1074#1074#1086#1076#1072)
    BackColor = clWhite
    BottomAxis.Title.Caption = #1042#1088#1077#1084#1103' '#1086#1076#1085#1086#1075#1086' '#1090#1072#1082#1090#1072
    LeftAxis.Title.Caption = #1042#1088#1077#1084#1103' '#1087#1088#1086#1089#1090#1086#1103
    Legend.ColorWidth = 50
    Legend.LegendStyle = lsSeries
    View3D = False
    BevelOuter = bvNone
    TabOrder = 2
    object LineSeries1: TLineSeries
      Marks.ArrowLength = 8
      Marks.Visible = False
      SeriesColor = clRed
      Title = '1 '#1091'.'#1077'.'#1074'.'
      LinePen.Width = 2
      Pointer.InflateMargins = True
      Pointer.Style = psRectangle
      Pointer.Visible = False
      XValues.DateTime = False
      XValues.Name = 'X'
      XValues.Multiplier = 1.000000000000000000
      XValues.Order = loAscending
      YValues.DateTime = False
      YValues.Name = 'Y'
      YValues.Multiplier = 1.000000000000000000
      YValues.Order = loNone
    end
    object LineSeries2: TLineSeries
      Marks.ArrowLength = 8
      Marks.Visible = False
      SeriesColor = clGreen
      Title = '2 '#1091'.'#1077'.'#1074'.'
      LinePen.Width = 2
      Pointer.InflateMargins = True
      Pointer.Style = psRectangle
      Pointer.Visible = False
      XValues.DateTime = False
      XValues.Name = 'X'
      XValues.Multiplier = 1.000000000000000000
      XValues.Order = loAscending
      YValues.DateTime = False
      YValues.Name = 'Y'
      YValues.Multiplier = 1.000000000000000000
      YValues.Order = loNone
    end
    object LineSeries3: TLineSeries
      Marks.ArrowLength = 8
      Marks.Visible = False
      SeriesColor = clYellow
      Title = '3 '#1091'.'#1077'.'#1074'.'
      LinePen.Width = 2
      Pointer.InflateMargins = True
      Pointer.Style = psRectangle
      Pointer.Visible = False
      XValues.DateTime = False
      XValues.Name = 'X'
      XValues.Multiplier = 1.000000000000000000
      XValues.Order = loAscending
      YValues.DateTime = False
      YValues.Name = 'Y'
      YValues.Multiplier = 1.000000000000000000
      YValues.Order = loNone
    end
    object LineSeries4: TLineSeries
      Marks.ArrowLength = 8
      Marks.Visible = False
      SeriesColor = clBlue
      Title = '4 '#1091'.'#1077'.'#1074'.'
      LinePen.Width = 2
      Pointer.InflateMargins = True
      Pointer.Style = psRectangle
      Pointer.Visible = False
      XValues.DateTime = False
      XValues.Name = 'X'
      XValues.Multiplier = 1.000000000000000000
      XValues.Order = loAscending
      YValues.DateTime = False
      YValues.Name = 'Y'
      YValues.Multiplier = 1.000000000000000000
      YValues.Order = loNone
    end
    object LineSeries5: TLineSeries
      Marks.ArrowLength = 8
      Marks.Visible = False
      SeriesColor = clBlack
      Title = '5 '#1091'.'#1077'.'#1074'.'
      LinePen.Width = 2
      Pointer.InflateMargins = True
      Pointer.Style = psRectangle
      Pointer.Visible = False
      XValues.DateTime = False
      XValues.Name = 'X'
      XValues.Multiplier = 1.000000000000000000
      XValues.Order = loAscending
      YValues.DateTime = False
      YValues.Name = 'Y'
      YValues.Multiplier = 1.000000000000000000
      YValues.Order = loNone
    end
  end
end
