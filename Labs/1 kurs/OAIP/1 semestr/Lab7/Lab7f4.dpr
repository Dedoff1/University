program Lab7f4;

{$APPTYPE CONSOLE}

uses
  Windows,
  SysUtils;
procedure swap(var x,y:real);
var t:real;
begin
t:=x;
x:=y;
y:=t;
end;
const nmax=20;
var Mat:array[1..nmax,1..nmax] of real;
    Str,St,StrMat,StMat,j,id_max,k:integer;
    TempMat,max:real;
begin
 repeat
 write('Количество строк Str= ');
 readln(Str);
 write('Количество столбцов St= ');
 readln(St);
 until (Str in [1..nmax])and(St in [1..nmax]);
 writeln('Исходная матрица: ');
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
writeln('Исходная матрица:');
 for Strmat:=1 to str do
   begin
    for stmat:=1 to st do
    begin
    if Frac(mat[strmat,stmat])=0 then
      write(Trunc(mat[strmat,stmat]),' ')
    else
    write(mat[strmat,stmat]:3:1,' ');
    end;
    writeln;
   end;
   writeln;

   for StrMat:=1 to Str do
   begin

    j:=st;
    while j > 1 do
    begin
        stmat:=1;
        max := mat[strmat,stmat];
        id_max := Stmat;
        for stmat := 2 to j do
            if mat[strmat,stmat] > max then
            begin
                max := mat[strmat,stmat];
                id_max := stmat;
            end;
        Mat[strmat,id_max] := mat[strmat,j];
        mat[strmat,j] := max;
        j := j - 1;
    end;
   end;

   {for k:=StMat+1 to St do
    if Mat[StrMat,StMat]>Mat[StrMat,k] then
     begin
      TempMat:=Mat[StrMat,StMat];
      Mat[StrMat,StMat]:=Mat[StrMat,k];
      Mat[StrMat,k]:=TempMat;
     end;}
for j:=1 to Str do
    for StrMat:=1 to Str-1 do
     if Mat[StrMat,St]<Mat[StrMat+1,St] then
      for StMat:=1 to St do
        swap(Mat[StrMat,StMat],Mat[StrMat+1,StMat]);
 writeln('Преобразованная матрица');
  for Strmat:=1 to str do
   begin
    for stmat:=1 to st do
    begin
    if Frac(mat[strmat,stmat])=0 then
      write(Trunc(mat[strmat,stmat]),' ')
    else
    write(mat[strmat,stmat]:3:1,' ');
    end;
    writeln;
   end;
   writeln;
 readln
end.
