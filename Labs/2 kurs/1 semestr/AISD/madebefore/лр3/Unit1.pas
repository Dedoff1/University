unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs,Unit2, ExtCtrls, TeeProcs, TeEngine, Chart, Series,
  StdCtrls;

type
  TForm1 = class(TForm)
    cht1: TChart;
    Series1: TLineSeries;
    Series2: TLineSeries;
    Series3: TLineSeries;
    Series4: TLineSeries;
    Series5: TLineSeries;
    btn1: TButton;
    cht2: TChart;
    LineSeries1: TLineSeries;
    LineSeries2: TLineSeries;
    LineSeries3: TLineSeries;
    LineSeries4: TLineSeries;
    LineSeries5: TLineSeries;
    procedure btn1Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;

implementation

{$R *.dfm}

procedure TForm1.btn1Click(Sender: TObject);
var
  i,j,KPD,stand:Integer;
begin
  for i:=0 to 4 do
    for j:=1 to 5 do
    begin
      stand:=0;
      Initialize(j,i+1);
      KPD:=AllTakts(stand);
      cht1.SeriesList[i].AddXY(j,TimeNeed/KPD/j*100);
      cht2.SeriesList[i].AddXY(j,stand);
    end;
end;

end.
