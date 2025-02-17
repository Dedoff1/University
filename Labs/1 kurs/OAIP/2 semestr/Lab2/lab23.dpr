program lab23;

{$APPTYPE CONSOLE}

{$R *.res}

uses
  System.SysUtils;

const n=200;
var x:array[1..n] of integer;
    i:integer;
procedure sort(l,r:integer); {l����� ����� ������,r-������ �����}
var
  i,j,x1,y1,m: integer;
begin
  i:=l;
  j:=r;
  m:=round ((l+r)/2);{������� �������}
  x1:=x[m];
  repeat
    while x[i]<x1 do inc(i);{���� ����� ������ ��������, ��������� ����� ���� ������ }
    while x[j]>x1 do dec(j);{���� ������ ������ ��������, ��������� ����� ������}
    if i<=j then {���� ����� � ������ ��������}
     begin
      y1:=x[i];
      x[i]:=x[j];{������ ����� � ������}
      x[j]:=y1;
      inc(i); {����� ������}
      dec(j); {������ �����}
     end;
  until i>j;{����� ����� ������������}
  if l<j then sort(l,j);{���������� ���������}
  if i<r then sort(i,r);{��� ����� ��� ������ �����}
end;

begin
randomize;
writeln('�������� ������:');
for i:=1 to n do
  begin
   x[i]:=random(1000);
   write(x[i]:4);
  end;
writeln;
sort(1,n);
writeln('������ ����� ����������: ');
for i:=1 to n do
write(x[i]:4);
readln;
end.
