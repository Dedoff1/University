program Project2;

{$APPTYPE CONSOLE}

uses
  SysUtils;

type
  pt=^elem;
  elem = record
            Pow:Integer;
            Koef:Integer;
            Next:pt;
  end;
var
  A,B,C:pt;
  x:integer;


function ReadMN(): pt;
var
  rez,x,y:pt;
  i,t,n:integer;
begin
  write('������� ������� ����������: ');
  read(n);
  writeln('������� ������������ ����������');
  new(x);
  rez:=x;
  for i :=n downto 0 do
  begin
    read(t);
    if t<>0 then
    begin
      x^.Koef := t;
      x^.Pow:=i;
      y:=x;
      new(x);
      y^.Next :=x;
    end;
  end;
  y^.Next:=nil;
  Readln;

  ReadMN:=rez;
end;


procedure WriteMN(mn:pt);
var
  start:boolean;
begin
  start:=true;
  while mn <> nil do
  begin
    if (mn^.Koef >0) and (not start) then write('+');
    start:=false;
    if mn^.Pow <> 0 then write(IntToStr(mn^.Koef),'x^',IntToStr(mn^.Pow))
                    else write(IntToStr(mn^.Koef));
    mn:=mn^.Next;
  end;
  writeln;
end;

function Equality(p,q:pt):boolean;
var
  rez:boolean;
begin
  rez:=true;
  while (p<>nil) and (q<>nil) and rez do
  begin
    if (p=nil) and (q=nil) then
      rez:=false
    else
    begin
      if (p^.Pow <> q^.Pow) or (p^.Koef <> q^.Koef) then
        rez:=false;
      p:=p^.Next;
      q:=q^.Next;
    end
  end;
  Equality:=rez;
end;

function Meaning(p:pt;x:integer):integer;
var
  rez:integer;
begin
  rez:=0;
  while p <> nil do
  begin
    rez:=rez + p^.Koef * Round(exp( p^.Pow * ln(x)));
    p:=p^.Next;
  end;
  Meaning:=rez;
end;

procedure Add (out p:pt; q,r:pt);
var
  x,y:pt;
begin
  new(x);
  p:=x;
  while (q<>nil) and (r<>nil) do
  begin
    if q^.Pow > r^.Pow then
    begin
      x^.Pow := q^.Pow;
      x^.Koef := q^.Koef;
      q:=q^.Next;
    end
    else if q^.Pow < r^.Pow then
    begin
      x^.Pow := r^.Pow;
      x^.Koef := r^.Koef;
      r:=r^.Next;
    end
    else
    begin
      x^.Pow := r^.Pow;
      x^.Koef := r^.Koef + q^.Koef;
      q:=q^.Next;
      r:=r^.Next;
    end;
    y:=x;
    new(x);
    y^.Next := x;
  end;
  y^.Next := nil;
end;



begin
  writeln('������ ���������. ');
  A:=ReadMN;
  write('���������� ���������: ');
  WriteMN(A);
  writeln;

  writeln('������ ���������.');
  B:=ReadMN;
  write('���������� ���������: ');
  WriteMN(B);
  writeln;

  write('���������� ');
  if not Equality(A,B) then write('�� ');
  write('�����');
  writeln;
  writeln;

  write('������� �������� ��� x: ');
  readln(x);
  writeln('�������� ������� ���������� ��� x ������ ', x, ': ',Meaning(A,x));
  writeln('�������� ������� ���������� ��� x ������ ', x, ': ',Meaning(B,x));
  writeln;

  Add(C,A,B);
  write('����� �����������: ');
  WriteMN(C);
  readln;
end.
