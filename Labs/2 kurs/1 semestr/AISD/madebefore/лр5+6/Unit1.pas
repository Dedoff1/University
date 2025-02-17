unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, Grids, AdvObj, BaseGrid, AdvGrid, StdCtrls, Mask, AdvSpin,
  AdvGlowButton, ExtCtrls;
const
  Rad=15; //������ �������� ������
  Len=40;//���������� ����� �������� �� ���������
  PenColor=clBlack;
  BrushColor=clBlue;
  BackColor=clWhite;
type
  Tree=^TreeEl;

  TreeEl = record
    Left:Tree;
    Right:Tree;
    Value:Integer;
    Thread:Boolean; //������� ������ ����
    X,Y:Integer;    //���������� �����
  end;

  TForm1 = class(TForm)
    lbl1: TLabel;
    nudElCount: TAdvSpinEdit;
    stgEls: TAdvStringGrid;
    btnBuild: TAdvGlowButton;
    imgTree: TImage;
    lbl2: TLabel;
    nudDelEl: TAdvSpinEdit;
    btnDel: TAdvGlowButton;
    lblPram: TLabel;
    lblSim: TLabel;
    lblObr: TLabel;
    procedure nudElCountChange(Sender: TObject);
    procedure btnBuildClick(Sender: TObject);
    procedure FormCreate(Sender: TObject);
    procedure btnDelClick(Sender: TObject);
  private
    { Private declarations }
  public
    NowTree:Tree;
  end;

  procedure Add(El:Integer;var Rez:Tree);
  procedure Draw(El:Tree;Y,X1,X2:Integer;var bmp:TBitmap);
  function Obr(El:Tree):string;
  function SimAndSew(El:Tree;var bmp:TBitmap):string;
  function Pram(El:Tree):string;
  procedure PunktLineTo(x0,y0,x,y:Integer;var bmp:TBitmap);
  procedure DelEl(val:Integer; var Der,PrevEl:Tree);
var
  Form1: TForm1;

implementation

{$R *.dfm}

procedure TForm1.nudElCountChange(Sender: TObject);
begin
  stgEls.ColCount:=nudElCount.Value;
end;

//�������� �������� �� ������
procedure DelEl(val:Integer; var Der,PrevEl:Tree);
var
  prev,El,x:Tree;
  function Find(val:Integer; var Der:Tree):Tree;
  begin
    if Der = nil then
    begin
      Result:=Der;
      Exit;
    end;
    if Der^.Value = val then //�����
      Result:=Der
    else
    begin
      prev:=Der;
      if Der^.Value < val then
        Result:=Find(val,Der^.Right)
      else
        Result:=Find(val,Der^.Left)
    end;
  end;
begin
  //���� ��� �������
  prev:=PrevEl;
  El:=Find(val,Der);
  if El = nil then
  begin
    MessageBoxW(0, '��������� ������� �� ������ � ������', '������', MB_OK + 
      MB_ICONSTOP + MB_TOPMOST);
    Exit;
  end;
  if (El^.Left = nil) then //���� ��� ������ ������ ���������
  begin
    if prev^.Left = El then
      prev^.Left:=El^.Right
    else
      prev^.Right:=El^.Right;
    Dispose(El);
  end
  else if (El^.Right = nil) or (El^.Thread) then //������ ����� ���������
  begin
    if prev^.Left = El then
      prev^.Left:=El^.Left
    else
      prev^.Right:=El^.Left;
    Dispose(El);
  end
  else //��� ���������
  begin
    //����� ������ ������ ������� ������� ���������
    x:=El^.Right;
    while x^.Left <> nil do
      x:=x^.Left;
    El^.Value:=x^.Value;    //���������� ��� ��������
    DelEl(x^.Value,El^.Right,El) //������� ���� �������
  end;
end;

//���������� ����� ����� 2-�� �������
procedure PunktLineTo(x0,y0,x,y:Integer; var bmp:TBitmap);
var
  x1,y1,x2,y2,i:Integer;
begin
  //��� �� ������ � �������
  if x>x0 then
  begin
    x1:=x0; y1:=y0;
    x2:=x;  y2:=y;
  end
  else
  begin
    x1:=x;  y1:=y;
    x2:=x0; y2:=y0;
  end;


  //����� �� ��� 0x
  i:=x1;
  while i<=x2 do
  begin
    bmp.Canvas.MoveTo(i,y1);
    bmp.Canvas.LineTo(i+5,y1);
    i:=i+10;
  end;

  //����� �� ��� 0y
  i:=y1;
  if y1 > y2 then
    while i>=y2 do
    begin
      bmp.Canvas.MoveTo(x2,i);
      bmp.Canvas.LineTo(x2,i-5);
      i:=i-10;
    end
  else
    while i<=y2 do
    begin
      bmp.Canvas.MoveTo(x2,i);
      bmp.Canvas.LineTo(x2,i+5);
      i:=i+10;
    end;
end;

//�������� �����
function Obr(El:Tree):string;
begin
  if El = nil then
  begin
    Result:='0 ';
    Exit;
  end;

  Result:=IntToStr(El^.Value) + ' ';
  //����� ���������
  Result:=Result+Obr(El^.Left);
  Result:=Result+IntToStr(El^.Value)+ ' ';

  //������ ���������
  Result:=Result+Obr(El^.Right);


  Result:=Result + '('+IntToStr(El^.Value) + ')' + ' ';
end;

//�������� �����
procedure DelThread(var El:Tree);
begin
  if El = nil then Exit;

  //����� ���������
  DelThread(El^.Left);
  if El^.Thread = False then
    DelThread(El^.Right);
  if El^.Thread then
  begin
    El^.Thread:=False;
    El^.Right:=nil;
  end;
end;

//������ �����
function Pram(El:Tree):string;
begin
  if El = nil then
  begin
    Result:='0 ';
    Exit;
  end;

  Result:=Result + '('+IntToStr(El^.Value) + ')' + ' ';

  //����� ���������
  Result:=Result+Pram(El^.Left);
  Result:=Result+IntToStr(El^.Value)+ ' ';

  //������ ���������
  Result:=Result+Pram(El^.Right);
  Result:=Result +IntToStr(El^.Value) + ' ';
end;

//������������ ����� � �������� (������ ������������)
function SimAndSew(El:Tree; var bmp:TBitmap):string;
var
  prev:Tree;
  //���������� �����. ���� ��������  � �����
  function Sim(El:Tree; var bmp:TBitmap):string;
  begin
    if El = nil then
    begin
      Result:='0 ';
      Exit;
    end;

    Result:=IntToStr(El^.Value) + ' ';
    //����� ���������
    Result:=Result+Sim(El^.Left,bmp);
    Result:=Result + '('+IntToStr(El^.Value) + ')' + ' ';

    //��������
    if (prev^.Right = nil) or (prev^.Thread = true) then
    begin
      prev^.Thread:=True; //����
      prev^.Right:=El;    //��������� �� �������
      PunktLineTo(prev^.X+Rad,prev^.Y,El^.X,El^.Y+Rad,bmp);
    end
    else
      prev^.Thread:=False; //������ - �� ����
    prev:=El;

    //������ ���������
    if Not El^.Thread then
    begin
      Result:=Result+Sim(El^.Right,bmp);
      Result:=Result+IntToStr(El^.Value)+ ' ';
    end
    else
      Result:=Result + '0 ' + IntToStr(El^.Value)+ ' ';
  end;
begin
  prev:=El^.Left; //��������� ������� ������������ ��������
  Result:=Sim(El^.Left,bmp);  //���� ������� � �����
  //���� ���� - ������� ����� �� ������ �� ���������� ��������
  if (prev^.Right = nil) then
  begin
    prev^.Thread:=True; //����
    prev^.Right:=El;    //��������� �� �������
    PunktLineTo(prev^.X+Rad,prev^.Y,bmp.Width-10,prev^.Y,bmp); //����� � ������ ����� ������
    PunktLineTo(bmp.Width-10,prev^.Y,El^.X,El^.Y+Rad,bmp);
  end;
end;
//���������� �������� � ������
procedure Add(El:Integer;var Rez:Tree);
begin
  if Rez= nil then  //���� - ���������
  begin
    New(Rez);
    Rez^.Value:=El;
    Rez^.Left:=nil;
    Rez^.Right:=nil;
    Rez^.Thread:=False;
  end
  else if El<Rez^.Value then Add(El,Rez^.Left)     //������� �����
  else Add(El,Rez^.Right)                          //������� ������
end;

//��������� �����. Y - ���������� �� ����� �� ������,X1,X2 - ��������� ���������� X
procedure Draw(El:Tree;Y,X1,X2:Integer;var bmp:TBitmap);
  //����������� ����� - ���������� ���������
  procedure DrawRec(El:Tree;Y,X1,X2:Integer;var bmp:TBitmap);
  begin
    //������� �������
    bmp.Canvas.Brush.Color:=BackColor;
    bmp.Height:=bmp.Height + Rad*2 + Len;
    bmp.Canvas.Ellipse((X2+X1) div 2 - Rad,Y,(X2+X1) div 2 + Rad,Y+Rad*2);
    bmp.Canvas.Brush.Color:=BrushColor;
    bmp.Canvas.FloodFill((X2+X1) div 2,Y + Rad,PenColor,fsBorder);
    bmp.Canvas.TextOut((X2+X1) div 2 - Rad+8,Y+7,IntToStr(El^.Value));
    bmp.Canvas.Brush.Color:=BackColor;
    El^.X:=(X2+X1) div 2;
    El^.Y:=Y+Rad;

    //����� ���������
    if El^.Left <> nil then
    begin
      //�����
      bmp.Canvas.MoveTo((X1+X2) div 2,Y+Rad*2);
      bmp.Canvas.LineTo(((X1+X2) div 2 + X1) div 2,Y+Rad*2 + Len);
      //���������
      DrawRec(El^.Left,Y+Rad*2+Len,X1,(X1+X2) div 2,bmp);
    end;

    if (El^.Right <> nil) and (Not El^.Thread) then
    begin
      //�����
      bmp.Canvas.MoveTo((X1+X2) div 2,Y+Rad*2);
      bmp.Canvas.LineTo(((X1+X2) div 2 + X2) div 2,Y+Rad*2 + Len);
      //���������
      DrawRec(El^.Right,Y+Rad*2+Len,(X1+X2) div 2,X2,bmp);
    end;
  end;
begin
  //�������� �������
  bmp.Canvas.Brush.Color:=BackColor;
  bmp.Height:=bmp.Height + Rad*2 + Len;
  bmp.Canvas.Brush.Color:=BrushColor;
  bmp.Canvas.FillRect(Bounds( (X1+X2) div 2 - 25,Y,50,Rad*2 ));
  bmp.Canvas.TextOut((X1+X2) div 2 - 15,Y+7,'HEAD');
  //����� ����
  bmp.Canvas.MoveTo((X1+X2) div 2 ,Y+Rad*2);
  bmp.Canvas.LineTo((X1+X2) div 2,Y+Rad*2 + (Len div 2));
  El^.X:=(X1+X2) div 2 +25;
  El^.Y:=Y;
  //��������� ������
  DrawRec(El^.Left,Y+Rad*2+(Len div 2),X1,X2,bmp);
end;

procedure TForm1.btnBuildClick(Sender: TObject);
var
  i:Integer;
  Elements:array of Integer;
  bmp:TBitmap;
  x:Tree;
begin
  SetLength(Elements,nudElCount.Value);

  //�������� �� ������������ � ������
  try
    for i:= Low(Elements) to High(Elements) do
      Elements[i]:=StrToInt(stgEls.Cells[i,0]);
  except
    MessageBoxW(0, '�������� ������ ������ ����� �������� �������', '������',
      MB_OK + MB_ICONSTOP + MB_TOPMOST);
    Exit;
  end;

  //������ ������
  NowTree:=nil;
  for i:= Low(Elements) to High(Elements) do
    Add(Elements[i],NowTree);
  //��������� �������� �������
  New(x);
  x^.Left:=NowTree;
  x^.Right:=x;
  x^.Value:=-1;
  NowTree:=x;

  //����������
  bmp:=TBitmap.Create;
  with bmp do
  begin
    Canvas.Pen.Color:=PenColor;
    Canvas.Brush.Color:=BackColor;
    Width:=imgTree.Width;
   // Height:=imgTree.Height;
  end;
  Draw(NowTree,0,0,imgTree.Width,bmp);


  //������
  lblObr.Caption:='�������� �����: '+Obr(NowTree^.Left);
  lblPram.Caption:= '������ �����: ' + Pram(NowTree^.Left);
  lblSim.Caption:='������������ �����: ' + SimAndSew(NowTree,bmp);
  imgTree.Picture:=TPicture(bmp);
end;

procedure TForm1.FormCreate(Sender: TObject);
begin
  stgEls.Cells[0,0]:='10';
  stgEls.Cells[1,0]:='12';
  stgEls.Cells[2,0]:='6';
  stgEls.Cells[3,0]:='11';
  stgEls.Cells[4,0]:='4';
  stgEls.Cells[5,0]:='15';
  stgEls.Cells[6,0]:='9';
  stgEls.Cells[7,0]:='20';
  stgEls.Cells[8,0]:='14';
  stgEls.Cells[9,0]:='17';
end;

//��������
procedure TForm1.btnDelClick(Sender: TObject);
var
  bmp:TBitmap;
begin
  DelThread(NowTree^.Left);
  DelEl(nudDelEl.Value,NowTree^.Left,NowTree);
   //����������
  bmp:=TBitmap.Create;
  with bmp do
  begin
    Canvas.Pen.Color:=PenColor;
    Canvas.Brush.Color:=BackColor;
    Width:=imgTree.Width;
   // Height:=imgTree.Height;
  end;
  Draw(NowTree,0,0,imgTree.Width,bmp);


  //������
  lblObr.Caption:='�������� �����: '+Obr(NowTree^.Left);
  lblPram.Caption:= '������ �����: ' + Pram(NowTree^.Left);
  lblSim.Caption:='������������ �����: ' + SimAndSew(NowTree,bmp);   
  imgTree.Picture:=TPicture(bmp);
end;

end.
