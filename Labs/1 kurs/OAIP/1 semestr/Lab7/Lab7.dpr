program Project2;

{$APPTYPE CONSOLE}

uses
  Windows,
  SysUtils;
procedure swap(var x,y:integer);
var t:integer;
begin
t:=x;
x:=y;
y:=t;
end;
const nmax=20;
var a:array[1..nmax,1..nmax] of integer;
    m,n,i,j,k:byte;
    x:integer;
begin
 randomize;
 repeat
 write('���������� ����� Str= ');
 readln(m);
 write('���������� �������� St= ');
 readln(n);
 until (m in [1..nmax])and(n in [1..nmax]);
 writeln('�������� �������: ');
 for i:=1 to m do
  begin
   for j:=1 to n do
    begin
     a[i,j]:=random(20);
     write(a[i,j]:4);
    end;
   writeln;
  end;
 for i:=1 to m do
  for j:=1 to n-1 do
   for k:=j+1 to n do
    if a[i,j]>a[i,k] then
     begin
      x:=a[i,j];
      a[i,j]:=a[i,k];
      a[i,k]:=x;
     end;
for k:=1 to m do
    for i:=1 to m-1 do
     if a[i,n]<a[i+1,n] then
      begin
      for j:=1 to n do
        swap(a[i,j],a[i+1,j]);
      end;
 writeln('��������������� ������: ');
 for i:=1 to m do
  begin
   for j:=1 to n do
   write(a[i,j]:4);
   writeln;
  end;
 readln
end.
