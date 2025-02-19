unit Unit2;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, ExtCtrls, StdCtrls;
type
  TDirectory = (DTop,DDown,DLeft,DRight);
  TForm2 = class(TForm)
    Shape1: TShape;
    Shape2: TShape;
    Shape3: TShape;
    Shape4: TShape;
    Shape5: TShape;
    Shape6: TShape;
    Shape7: TShape;
    Shape8: TShape;
    qwe:TShape;
    Button1: TButton;
    Button2: TButton;
    Button3: TButton;
    Button4: TButton;
    Shape9: TShape;
    Shape10: TShape;
    Shape11: TShape;
    Shape12: TShape;
    Shape13: TShape;
    Shape14: TShape;
    Shape15: TShape;
    Shape16: TShape;
    Shape17: TShape;
    Shape18: TShape;
    Shape19: TShape;
    Shape20: TShape;
    Shape21: TShape;
    Shape22: TShape;
    Shape23: TShape;
    Shape24: TShape;
    Shape25: TShape;
    Shape26: TShape;
    Shape27: TShape;
    Shape28: TShape;
    Shape29: TShape;
    Shape30: TShape;
    Shape31: TShape;
    Shape32: TShape;
    Shape33: TShape;
    Shape34: TShape;
    Panel2: TPanel;
    Shape35: TShape;
    Shape36: TShape;
    Shape37: TShape;
    Shape38: TShape;
    Shape39: TShape;
    procedure FormCreate(Sender: TObject);
    function InterSect1:Boolean;
    procedure Moveqwe1(directory:TDirectory);
    procedure FormKeyPress (Sender:TObject; var Key:Char);
    procedure Button1Click(Sender: TObject);
    procedure Button2Click(Sender: TObject);
    procedure Button4Click(Sender: TObject);
    procedure Button3Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form2: TForm2;

implementation

{$R *.dfm}
uses Unit1,Unit3, Unit4;

procedure TForm2.FormCreate(Sender: TObject);
begin
  Clientwidth:=shape4.Left+shape4.Width;
  Clientheight:=shape3.Top+shape3.Height;
  KeyPreview:=True;

end;

function TForm2.InterSect1:Boolean;
var
  i:Integer;
  rect:TRect;
begin
  for i:=0 to pred(ComponentCount) do
  if (Components[i] is TShape) and ((Components[i] as TShape).Name <> 'qwe')   then
  if IntersectRect(rect,qwe.BoundsRect,(Components[i] as TShape).BoundsRect) then
    begin
      Result:=True;
      Exit;
    end;
    Result:=False;
end;

procedure TForm2.Moveqwe1(directory:TDirectory);
const
  step=15;
var
  i:Integer;
begin
  case directory of
    DTop:begin qwe.Top:=qwe.Top-step; if InterSect1 then qwe.Top:=qwe.Top+step; end;
    DDown:begin qwe.Top:=qwe.Top+step; if InterSect1 then qwe.Top:=qwe.Top-step; end;
    DLeft:begin qwe.Left:=qwe.Left-step; if InterSect1 then qwe.Left:=qwe.Left+step; end;
    DRight:begin qwe.Left:=qwe.Left+step; if InterSect1 then qwe.Left:=qwe.Left-step; end;
  end;
end;

procedure TForm2.FormKeyPress(Sender:TObject; var Key:Char);
var
  t:TRect;
begin
  case Key of
    'a','A','ô','Ô':Moveqwe1(DLeft);
    's','S','³','²','û','Û':Moveqwe1(DDown);
    'd','D','â','Â':Moveqwe1(DRight);
    'w','W','ö','Ö':Moveqwe1(DTop);
  end;
  If InterSectRect(t,qwe.BoundsRect,Panel2.BoundsRect) then
  begin
    Form2.Hide;
    Form4.Show;
    qwe.Top:=32; qwe.Left:=32;
  end;
end;


procedure TForm2.Button1Click(Sender: TObject);
var
  t:TRect;
begin
  Moveqwe1(DLeft);
  If InterSectRect(t,qwe.BoundsRect,Panel2.BoundsRect) then
  begin
    Form2.Hide;
    Form4.Show;
    qwe.Top:=32; qwe.Left:=32;
  end;
end;

procedure TForm2.Button2Click(Sender: TObject);
var
  t:TRect;
begin
  Moveqwe1(DRight);
  If InterSectRect(t,qwe.BoundsRect,Panel2.BoundsRect) then
  begin
    Form2.Hide;
    Form4.Show;
    qwe.Top:=32; qwe.Left:=32;
  end;
end;

procedure TForm2.Button4Click(Sender: TObject);
var
  t:TRect;
begin
  Moveqwe1(DDown);
  If InterSectRect(t,qwe.BoundsRect,Panel2.BoundsRect) then
  begin
    Form2.Hide;
    Form4.Show;
    qwe.Top:=32; qwe.Left:=32;
  end;
end;

procedure TForm2.Button3Click(Sender: TObject);
var
  t:TRect;
begin
  Moveqwe1(DTop);
  If InterSectRect(t,qwe.BoundsRect,Panel2.BoundsRect) then
  begin
    Form2.Hide;
    Form4.Show;
    qwe.Top:=32; qwe.Left:=32;
  end;
end;

end.

