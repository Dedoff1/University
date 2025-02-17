program Lab5f;

{$APPTYPE CONSOLE}

{$R *.res}

uses
  System.SysUtils;

const nmax=20;
var a:array [1..nmax,1..nmax] of real;
    n,m,i,j,k,f,p,t:integer;
begin
writeln('Исходная матрица:');
repeat
write('Количество строк до ',nmax,' n=');
readln(n);
until n in [1..nmax];
repeat
write('Количество столбцов до ',nmax,' m=');
readln(m);
until m in [1..nmax];
writeln('Исходная матрица:');
for i:=1 to n do
 begin
   for j:=1 to m do
    begin
     writeln('X[',i,' , ',j,']= ');
     readln(a[i,j]);
    end;
   writeln;
 end;
writeln;
writeln('Исходная матрица:');
 for i:=1 to n do
   begin
    for j:=1 to m do
    begin
    if Frac(a[i,j])=0 then
      write(Trunc(a[i,j]),' ')
    else
    write(a[i,j]:3:1,' ');
    end;
    writeln;
   end;
 writeln;
{Udalenie strok s 0}
i:=1;f:=0;
while i<=n do
 begin
  k:=0;
  for j:=1 to m do
  if a[i,j]=0 then
  begin
   k:=1;
   for p:=1 to n do//элементы всех строк
    for t:=j to m-1 do//от последней до следующей за найденной
    a[p,t]:=a[p,t+1];//поднимаем на 1 вверх
    m:=m-1;
  end;
  if k=1 then//если в строке есть ноль
   begin
    f:=1;//фиксируем
    for t:=1 to m do//элементы всех строк
    for p:=i to n-1 do//от последней до следующей за найденной
    a[p,t]:=a[p+1,t];//поднимаем на 1 вверх
    n:=n-1;//уменьшаем количество строк
   end
  else i:=i+1;
 end;
if f=0 then write('В матрице нет нолей')
else
 if (n=0) and (m=0) then
  write('Все строки и столбцы удалены')
 else
 begin
  writeln('Преобразованная матрица');
  for i:=1 to n do
   begin
    for j:=1 to m do
    begin
    if Frac(a[i,j])=0 then
      write(Trunc(a[i,j]),' ')
    else
    write(a[i,j]:3:1,' ');
    end;
    writeln;
   end;
   writeln;
 end;
readln
end.

