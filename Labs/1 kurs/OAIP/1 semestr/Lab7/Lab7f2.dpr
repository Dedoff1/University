program Lab7f2;

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
var Mat:array[1..nmax,1..nmax] of integer;
    Str,St,StrMat,StMat,k:integer;
    TempMat:integer;
begin
 repeat
 write('���������� ����� Str= ');
 readln(Str);
 write('���������� �������� St= ');
 readln(St);
 until (Str in [1..nmax])and(St in [1..nmax]);
 writeln('�������� �������: ');
for StrMat:=1 to Str do
 begin
   for StMat:=1 to St do
    begin
     writeln('Mat[',StrMat,' , ',Stmat,']= ');
     readln(Mat[StrMat,StMat]);
    end;
   writeln;
 end;
writeln;
writeln('�������� �������:');
 for StrMat:=1 to Str do
   begin
    for StMat:=1 to St do
    write(Mat[StrMat,StMat]:4,' ');
    writeln;
   end;
 writeln;
 for StrMat:=1 to Str do
  for StMat:=1 to St-1 do
   for k:=StMat+1 to St do
    if Mat[StrMat,StMat]>Mat[StrMat,k] then
     begin
      TempMat:=Mat[StrMat,StMat];
      Mat[StrMat,StMat]:=Mat[StrMat,k];
      Mat[StrMat,k]:=TempMat;
     end;
for k:=1 to Str do
    for StrMat:=1 to Str-1 do
     if Mat[StrMat,St]<Mat[StrMat+1,St] then
      begin
      for StMat:=1 to St do
        swap(Mat[StrMat,StMat],Mat[StrMat+1,StMat]);
      end;
 writeln('��������������� ������: ');
 for StrMat:=1 to Str do
  begin
   for StMat:=1 to St do
   write(Mat[StrMat,StMat]:4);
   writeln;
  end;
 readln
end.
