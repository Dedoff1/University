unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, Grids, Mask, AdvSpin, AdvObj, BaseGrid, AdvGrid,ListUnit,
  ExtCtrls;
const
  Infinity = 100000; //���������� ������� ��������
  Rad= 15;  //������ ���������� �� �����
  ArrowLen = 15; //����� ���������
  ArrowRot= Pi/12; //���� �������� ����� ����������� ��������� �����. �����
type
  TPoint = record
      Name:Byte;
      X,Y:Integer;
    end;

  DeykstRes = array of Integer;
  Matr = array of array of Integer;
  TForm1 = class(TForm)
    lbl1: TLabel;
    btnSort: TButton;
    mmoWays: TMemo;
    lbl2: TLabel;
    nudCount: TAdvSpinEdit;
    lbl4: TLabel;
    nudFist: TAdvSpinEdit;
    lbl5: TLabel;
    nudLast: TAdvSpinEdit;
    stg1: TAdvStringGrid;
    imgGraph: TImage;
    lblLong: TLabel;
    lblShort: TLabel;
    lblCenter: TLabel;
    procedure btnSortClick(Sender: TObject);
    procedure nudCountChange(Sender: TObject);
    function FindWays:TList;
    procedure FormCreate(Sender: TObject);  //����� ����� ����� ���������
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;
  A:Matr; //������� ���������
  Ways:TList; //������ �����
implementation

{$R *.dfm}

procedure DrawPoint(var bmp:TBitmap; Point:TPoint);
begin
  bmp.Canvas.Ellipse(Point.X - Rad ,Point.Y - Rad,Point.X + Rad ,Point.Y + Rad);
  bmp.Canvas.FloodFill(Point.X,Point.Y,clBlack,fsBorder);
  bmp.Canvas.TextOut(Point.X - 4,Point.Y - 8,IntToStr(Point.Name));
end;

//��������� ����
function Draw(BmpHeight,BmpWidth:Integer; Center:Byte):TBitmap;
var
  BmpRad:Integer; //������ ���������� � ������� ���������� ����;
  AngleStep:Real; //��� ������� ���������� ����� ��������� �����
  i,j:Integer;
  Points:array of TPoint;
  X1,X2,Y1,Y2,X3,Y3:Integer;
  Phi:Real;
begin
  SetLength(Points,High(A)+1);
  Result:=TBitmap.Create;
  Result.Height:=BmpHeight;
  Result.Width:=BmpWidth;
  Result.Canvas.Brush.Color:=clGreen;

  //������ (����� �������� � �������� �����������)
  if BmpHeight < BmpWidth then
    BmpRad:=(BmpHeight div 2) - Rad - 5
  else
    BmpRad:=(BmpWidth div 2) - Rad - 5;
  AngleStep:= 2*Pi/(High(A));

  //���� �������
  j:=0;
  for i:= 0 to High(A) do
  begin
    if i= Center Then Continue; //����� ����� ������ ��������
    //������� ������� � ������
    Points[i].Name:=i;
    Points[i].X:=BmpRad + 2*Rad + 10 + Round(BmpRad * Cos(Pi /10   + j*AngleStep));
    Points[i].Y:=BmpRad + Rad + 5 - Round(BmpRad * Sin(Pi /10  + j*AngleStep));
    //������
    DrawPoint(Result,Points[i]);
    j:=j+1;
  end;
  //����� �����
  Points[Center].Name:=Center;
  Points[Center].X:=BmpRad + Rad + 5;
  Points[Center].Y:=BmpRad + Rad + 5;
  DrawPoint(Result,Points[Center]);
  
  //и���
  for i:= 0 to High(A) do
    for j:= 0 to High(A) do
      if A[i,j] <> Infinity then
      begin
        if Abs(Points[i].Y - Points[j].Y) < Rad*2 then  //�������������� ������� � ����������� �� ������
        begin
          Y1:=Points[i].Y;
          Y2:=Points[j].Y;
          //���� �� ������ ���� ������� � ������� ���� ������
          if Points[i].X < Points[j].X then
          begin
            X1:=Points[i].X + Rad;
            X2:=Points[j].X - Rad
          end
          else
          begin
            X1:=Points[i].X - Rad;
            X2:=Points[j].X + Rad
          end
        end
        else
        begin         //������� �������� �� ������
          X1:=Points[i].X;
          X2:=Points[j].X;
          //���� �� ������� ���� �������� � �������� ���� �������
          if Points[i].Y < Points[j].Y then
          begin
            Y1:=Points[i].Y + Rad;
            Y2:=Points[j].Y - Rad
          end
          else
          begin
            Y1:=Points[i].Y - Rad;
            Y2:=Points[j].Y + Rad
          end
        end;

        Result.Canvas.MoveTo(X1,Y1);
        Result.Canvas.LineTo(X2,Y2);


        //���������!!!!!!!!
        Phi:=ArcTan(Abs(Y1-Y2) / Abs(X1-X2)); //��������� ����� � �������� ����������� � ������� � ������� ���������
        //arctg �� ���������� �������� ����
        if Y2-Y1 < 0 then
          Phi:=-Phi;
        if X2-X1 > 0 then
          Phi:=Pi - Phi;
        //���� ���������
        X1:=X2 + Round(ArrowLen*Cos(Phi-ArrowRot));
        Y1:=Y2 - Round(ArrowLen*Sin(Phi-ArrowRot));
        Result.Canvas.LineTo(X1,Y1);
        X3:=X2 + Round(ArrowLen*Cos(Phi+ArrowRot));
        Y3:=Y2 - Round(ArrowLen*Sin(Phi+ArrowRot));
        Result.Canvas.MoveTo(X2,Y2);
        Result.Canvas.LineTo(X3,Y3);
        Result.Canvas.LineTo(X1,Y1);

        //�������
        X1:=X2 + Round(ArrowLen*3*Cos(Phi));
        Y1:=Y2 - Round(ArrowLen*3*Sin(Phi));
        Result.Canvas.Brush.Color:=clBlue;
        Result.Canvas.TextOut(X1,Y1,IntToStr(A[i,j]));
        Result.Canvas.Brush.Color:=clGreen;
      end;
end;

//����� ��. �����
function GraphCenter (FloidRes:Matr):Byte;
var
  MaxWay:array of Integer; //����� ������� ���� �� ������ �������
  i,j:Integer;
begin
  SetLength(MaxWay,High(A)+1);
  //����� ���� ������� ��������� ��� ������ �������
  for i:= 0 to High(A)  do
  begin
    MaxWay[i]:=FloidRes[0,i];
    for j:= 0 to High(A) do
      if MaxWay[i] < FloidRes[j,i] then
        MaxWay[i]:= FloidRes[j,i];
  end;

  //��������� �� ���������� �����
  Result:=0;
  for i := 0 to High(A) do
    if MaxWay[i] < MaxWay[Result] then
      Result:=i;
end;

//�������� ������
function Floid:Matr;
var
  i,j,k:Integer;
begin
  SetLength(Result,High(A)+1,High(A)+1);
  //��������� ������� �� ������� ���
  for i:= 0 to High(A) do
    for j:= 0 to High(A) do
      Result[i,j]:=A[i,j];

  //��� ��������
  for k:=0 to High(A) do
    for i:= 0 to High(A) do
      for j := 0 to High(A) do
        if Result[i,k] + Result[k,j] < Result[i,j] then
          Result[i,j]:= Result[i,k] + Result[k,j];
end;

//�������� ��������
function Deykstra(start:Byte; out Way:DeykstRes) : DeykstRes;
var
  Used: Mn; //��������� ���������� ������
  i,j,min:integer;
begin
  Used:= [];
  SetLength(Result,High(A)+1); //����������� ����������
  SetLength(Way,High(A)+1);
  for i := 0 to High(Result) do
  begin
    Result[i]:=A[start,i];    //������ ����
    Way[i]:=start;
  end;

  for j := 0 to High(A) do    //������ ������ �������� ������ �������
  begin
    Used:=Used + [start];
    //��� ������� ������ ���. �������
    for i := 0 to High(Result) do
      if Not (i in Used) then //������ ��� � �����
        if Result[i] > Result[start] + A[start,i] then
        begin
          Result[i] := Result[start] + A[start,i];
          Way[i]:=start;
        end;
    //��. �������  - ����������� ��� �������������  �����
    min:=MaxInt;
    for i := 0 to High(Result) do
      if Not (i in Used) And (Result[i] < min) then
      begin
        min:=Result[i];
        start:=i;
      end;
  end;
end;

procedure TForm1.btnSortClick(Sender: TObject);
var
  i,j:integer;
  Rez:Integer;
  Code:Integer;
  x,Ways:TList;
  ShortWay,Way:DeykstRes;
  WayName:string;
  Center:Byte;
begin
  //������� �������� �������
  SetLength (A,stg1.RowCount,stg1.RowCount);

  //���������� �������
  for i:= 0 to stg1.RowCount - 1 do
    for j:=0 to stg1.ColCount -1 do
    begin
      Val(stg1.Cells[j,i],Rez,Code);     //�������� ������������ �����
      if Code = 0 then
        if Rez = 0 then //��� ����� - 255
          A[i,j]:=Infinity
        else
          A[i,j]:=Rez
      else
      begin
         MessageDlg('������������ �������� � ������ (' + IntToStr(i+1) + ',' + IntToStr(j+1) + ')' ,  mtError,
      [mbOK], 0);
        Exit;
      end;
    end;

  //��� ����
  Ways:=FindWays;
  //����� �����
  x:=Ways^.Next;
  while x<> nil do
  begin
    mmoWays.Lines.Add( IntToStr(x^.Way.Cost) + ' - ' + x^.Way.Name );
    x:=x^.Next;
  end;

  //����� ������� ����
  x:=Ways;
  while x^.Next<> nil do
    x:=x^.Next;
  lblLong.Caption:= '����� ������� ����: ' + x^.Way.Name + '(' +
                                      IntToStr(x^.Way.Cost) + ')';
  //������� ���������� ���� ( �������� ��������)
  ShortWay:=Deykstra(nudFist.Value,Way);
  lblShort.Caption:= '����� �������� ����: ';
  //������� ��� ����
  WayName:=IntToStr(nudLast.Value);
  i:=Way[nudLast.Value];
  while i <> nudFist.Value do
  begin
    WayName:=WayName + IntToStr(i);
    i:=Way[i];
  end;
  WayName := WayName + IntToStr(nudFist.Value);
  //������������� ������
  for i:= Length(WayName) downto 1 do
    lblShort.Caption:=lblShort.Caption + WayName[i] + ' ';
  //������������� - ���� ���
  lblShort.Caption:=lblShort.Caption +'(' +  IntToStr(ShortWay[nudLast.Value]) + ')' ;


  //����� �����
  Center:= GraphCenter(Floid);
  lblCenter.Caption:='����� �����: ' + IntToStr(Center);

  //������ ����
  imgGraph.Picture:= TPicture(Draw(imgGraph.Height, imgGraph.Width,Center));

  stg1.SaveToFile('d.txt')
end;

procedure TForm1.nudCountChange(Sender: TObject);
begin
  //������� stg1
  stg1.RowCount := nudCount.Value;
  stg1.ColCount:= nudCount.Value;
  nudFist.MaxValue:= nudCount.Value-1;
  nudLast.MaxValue:= nudCount.Value-1;
end;


//����� ����� ����� ���������
function TForm1.FindWays:TList;
var
  Src, Dest: Integer;
  NullWay:TWay;

  procedure FindRoute(V: Integer; Way:TWay);
  var
    i: Integer;
    NewWay:TWay;
  begin
    if V = Dest then                   //�����
      AddToSortedList(Way,Ways)
    else
    for i := 0 to High(A[V]) do     //��� ������ �������
      if (A[V, i] <> Infinity) and Not( i in Way.Used) then        //���� ���� ������� � ��� ��� �� ����
      begin
        NewWay.Used:= Way.Used + [i];
        NewWay.Name:= Way.Name + IntToStr(i) + ' ';
        NewWay.Cost:=Way.Cost + A[V,i];
        FindRoute(i,NewWay);
      end;
  end;

begin
  Ways:=NewList;
  mmoWays.Clear;
  Src := nudFist.Value; //������� - ��������
  Dest := nudLast.Value;//������� ��������
  with NullWay do
  begin
    Name:= IntToStr(Src) + ' ';
    Cost:=0;
    Used:= [Src];
  end;
  FindRoute(Src,NullWay);
  Result:=Ways;
end;
procedure TForm1.FormCreate(Sender: TObject);
begin
  //��������� ����������
  stg1.LoadFromFile('d.txt');
  mmoWays.Clear;
end;

end.
