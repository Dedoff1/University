unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, Grids, AdvObj, BaseGrid, AdvGrid, StdCtrls, Mask, AdvSpin,
  AdvGlowButton, ExtCtrls;
const
  Rad=15; //Радиус элемента дерева
  Len=40;//Расстояние между уровнями по вертикали
  PenColor=clBlack;
  BrushColor=clBlue;
  BackColor=clWhite;
type
  Tree=^TreeEl;

  TreeEl = record
    Left:Tree;
    Right:Tree;
    Value:Integer;
    Thread:Boolean; //Признак правой нити
    X,Y:Integer;    //Координаты кужка
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

//Удаление элемента из дерева
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
    if Der^.Value = val then //Нашли
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
  //Ишим что удалять
  prev:=PrevEl;
  El:=Find(val,Der);
  if El = nil then
  begin
    MessageBoxW(0, 'Удаляемый элемент не найден в дереве', 'Ошибка', MB_OK + 
      MB_ICONSTOP + MB_TOPMOST);
    Exit;
  end;
  if (El^.Left = nil) then //Лист или только правое поддерево
  begin
    if prev^.Left = El then
      prev^.Left:=El^.Right
    else
      prev^.Right:=El^.Right;
    Dispose(El);
  end
  else if (El^.Right = nil) or (El^.Thread) then //Только левое поддерево
  begin
    if prev^.Left = El then
      prev^.Left:=El^.Left
    else
      prev^.Right:=El^.Left;
    Dispose(El);
  end
  else //Оба поддерева
  begin
    //Поиск самого левого элмента правого поддерева
    x:=El^.Right;
    while x^.Left <> nil do
      x:=x^.Left;
    El^.Value:=x^.Value;    //Запоминаем его значение
    DelEl(x^.Value,El^.Right,El) //Удаляем этот элемент
  end;
end;

//Пугктирная линия между 2-мя точками
procedure PunktLineTo(x0,y0,x,y:Integer; var bmp:TBitmap);
var
  x1,y1,x2,y2,i:Integer;
begin
  //Идём от левого к правому
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


  //Часть по оси 0x
  i:=x1;
  while i<=x2 do
  begin
    bmp.Canvas.MoveTo(i,y1);
    bmp.Canvas.LineTo(i+5,y1);
    i:=i+10;
  end;

  //Часть по оси 0y
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

//Обратный обход
function Obr(El:Tree):string;
begin
  if El = nil then
  begin
    Result:='0 ';
    Exit;
  end;

  Result:=IntToStr(El^.Value) + ' ';
  //Левое поддерево
  Result:=Result+Obr(El^.Left);
  Result:=Result+IntToStr(El^.Value)+ ' ';

  //Правое поддерево
  Result:=Result+Obr(El^.Right);


  Result:=Result + '('+IntToStr(El^.Value) + ')' + ' ';
end;

//Удаление нитей
procedure DelThread(var El:Tree);
begin
  if El = nil then Exit;

  //Левое поддерево
  DelThread(El^.Left);
  if El^.Thread = False then
    DelThread(El^.Right);
  if El^.Thread then
  begin
    El^.Thread:=False;
    El^.Right:=nil;
  end;
end;

//Прямой обход
function Pram(El:Tree):string;
begin
  if El = nil then
  begin
    Result:='0 ';
    Exit;
  end;

  Result:=Result + '('+IntToStr(El^.Value) + ')' + ' ';

  //Левое поддерево
  Result:=Result+Pram(El^.Left);
  Result:=Result+IntToStr(El^.Value)+ ' ';

  //Правое поддерево
  Result:=Result+Pram(El^.Right);
  Result:=Result +IntToStr(El^.Value) + ' ';
end;

//Симметричный обход и прошивка (правая симметричная)
function SimAndSew(El:Tree; var bmp:TBitmap):string;
var
  prev:Tree;
  //Рекурсивны вызов. Сама прошивка  и обход
  function Sim(El:Tree; var bmp:TBitmap):string;
  begin
    if El = nil then
    begin
      Result:='0 ';
      Exit;
    end;

    Result:=IntToStr(El^.Value) + ' ';
    //Левое поддерево
    Result:=Result+Sim(El^.Left,bmp);
    Result:=Result + '('+IntToStr(El^.Value) + ')' + ' ';

    //Прошивка
    if (prev^.Right = nil) or (prev^.Thread = true) then
    begin
      prev^.Thread:=True; //Нить
      prev^.Right:=El;    //Указываем на текущий
      PunktLineTo(prev^.X+Rad,prev^.Y,El^.X,El^.Y+Rad,bmp);
    end
    else
      prev^.Thread:=False; //Занято - не нить
    prev:=El;

    //Правое поддерево
    if Not El^.Thread then
    begin
      Result:=Result+Sim(El^.Right,bmp);
      Result:=Result+IntToStr(El^.Value)+ ' ';
    end
    else
      Result:=Result + '0 ' + IntToStr(El^.Value)+ ' ';
  end;
begin
  prev:=El^.Left; //начальное знаение предыдущёёго элемента
  Result:=Sim(El^.Left,bmp);  //Сама прошвка и обход
  //Если надо - заводим линию на голову из последнего элемента
  if (prev^.Right = nil) then
  begin
    prev^.Thread:=True; //Нить
    prev^.Right:=El;    //Указываем на текущий
    PunktLineTo(prev^.X+Rad,prev^.Y,bmp.Width-10,prev^.Y,bmp); //Линию в парвую часть экрана
    PunktLineTo(bmp.Width-10,prev^.Y,El^.X,El^.Y+Rad,bmp);
  end;
end;
//Добавление элемента в дерево
procedure Add(El:Integer;var Rez:Tree);
begin
  if Rez= nil then  //Лист - вставляем
  begin
    New(Rez);
    Rez^.Value:=El;
    Rez^.Left:=nil;
    Rez^.Right:=nil;
    Rez^.Thread:=False;
  end
  else if El<Rez^.Value then Add(El,Rez^.Left)     //Меньшие влево
  else Add(El,Rez^.Right)                          //Большие вправо
end;

//Рисование древа. Y - расстояние от верха до уровня,X1,X2 - граничные гоординаты X
procedure Draw(El:Tree;Y,X1,X2:Integer;var bmp:TBitmap);
  //Рекурсивный вызов - собственно рисование
  procedure DrawRec(El:Tree;Y,X1,X2:Integer;var bmp:TBitmap);
  begin
    //Текущий элемент
    bmp.Canvas.Brush.Color:=BackColor;
    bmp.Height:=bmp.Height + Rad*2 + Len;
    bmp.Canvas.Ellipse((X2+X1) div 2 - Rad,Y,(X2+X1) div 2 + Rad,Y+Rad*2);
    bmp.Canvas.Brush.Color:=BrushColor;
    bmp.Canvas.FloodFill((X2+X1) div 2,Y + Rad,PenColor,fsBorder);
    bmp.Canvas.TextOut((X2+X1) div 2 - Rad+8,Y+7,IntToStr(El^.Value));
    bmp.Canvas.Brush.Color:=BackColor;
    El^.X:=(X2+X1) div 2;
    El^.Y:=Y+Rad;

    //Левое поддерево
    if El^.Left <> nil then
    begin
      //Линия
      bmp.Canvas.MoveTo((X1+X2) div 2,Y+Rad*2);
      bmp.Canvas.LineTo(((X1+X2) div 2 + X1) div 2,Y+Rad*2 + Len);
      //Поддерево
      DrawRec(El^.Left,Y+Rad*2+Len,X1,(X1+X2) div 2,bmp);
    end;

    if (El^.Right <> nil) and (Not El^.Thread) then
    begin
      //Линия
      bmp.Canvas.MoveTo((X1+X2) div 2,Y+Rad*2);
      bmp.Canvas.LineTo(((X1+X2) div 2 + X2) div 2,Y+Rad*2 + Len);
      //Поддерево
      DrawRec(El^.Right,Y+Rad*2+Len,(X1+X2) div 2,X2,bmp);
    end;
  end;
begin
  //Головной элемент
  bmp.Canvas.Brush.Color:=BackColor;
  bmp.Height:=bmp.Height + Rad*2 + Len;
  bmp.Canvas.Brush.Color:=BrushColor;
  bmp.Canvas.FillRect(Bounds( (X1+X2) div 2 - 25,Y,50,Rad*2 ));
  bmp.Canvas.TextOut((X1+X2) div 2 - 15,Y+7,'HEAD');
  //Линия вниз
  bmp.Canvas.MoveTo((X1+X2) div 2 ,Y+Rad*2);
  bmp.Canvas.LineTo((X1+X2) div 2,Y+Rad*2 + (Len div 2));
  El^.X:=(X1+X2) div 2 +25;
  El^.Y:=Y;
  //Остальное дерево
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

  //Проверка на допустимость и запись
  try
    for i:= Low(Elements) to High(Elements) do
      Elements[i]:=StrToInt(stgEls.Cells[i,0]);
  except
    MessageBoxW(0, 'Элементы дерева должны иметь числовые значния', 'Ошибка',
      MB_OK + MB_ICONSTOP + MB_TOPMOST);
    Exit;
  end;

  //Строим дерево
  NowTree:=nil;
  for i:= Low(Elements) to High(Elements) do
    Add(Elements[i],NowTree);
  //Добавляем головную вершину
  New(x);
  x^.Left:=NowTree;
  x^.Right:=x;
  x^.Value:=-1;
  NowTree:=x;

  //Отображаем
  bmp:=TBitmap.Create;
  with bmp do
  begin
    Canvas.Pen.Color:=PenColor;
    Canvas.Brush.Color:=BackColor;
    Width:=imgTree.Width;
   // Height:=imgTree.Height;
  end;
  Draw(NowTree,0,0,imgTree.Width,bmp);


  //Обходы
  lblObr.Caption:='Концевой обход: '+Obr(NowTree^.Left);
  lblPram.Caption:= 'Прямой обход: ' + Pram(NowTree^.Left);
  lblSim.Caption:='Симметричный обход: ' + SimAndSew(NowTree,bmp);
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

//Удаление
procedure TForm1.btnDelClick(Sender: TObject);
var
  bmp:TBitmap;
begin
  DelThread(NowTree^.Left);
  DelEl(nudDelEl.Value,NowTree^.Left,NowTree);
   //Отображаем
  bmp:=TBitmap.Create;
  with bmp do
  begin
    Canvas.Pen.Color:=PenColor;
    Canvas.Brush.Color:=BackColor;
    Width:=imgTree.Width;
   // Height:=imgTree.Height;
  end;
  Draw(NowTree,0,0,imgTree.Width,bmp);


  //Обходы
  lblObr.Caption:='Концевой обход: '+Obr(NowTree^.Left);
  lblPram.Caption:= 'Прямой обход: ' + Pram(NowTree^.Left);
  lblSim.Caption:='Симметричный обход: ' + SimAndSew(NowTree,bmp);   
  imgTree.Picture:=TPicture(bmp);
end;

end.
