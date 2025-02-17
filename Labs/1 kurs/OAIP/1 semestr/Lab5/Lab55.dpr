program Lab55;

{$APPTYPE CONSOLE}

{$R *.res}

uses
  System.SysUtils;

const nmax=20;
var X:array [1..nmax,1..nmax] of integer;
    St:array[1..20] of integer;
    n,m,i,j,k,p,t,e,y,w:byte;
    f: boolean;
begin
 randomize;
 writeln('»сходна€ матрица:');
 repeat
 write(' оличество строк до ',nmax,' n=');
 readln(n);
 until n in [1..nmax];
 repeat
 write(' оличество столбцов до ',nmax,' m=');
 readln(m);
 until m in [1..nmax];
 writeln('»сходна€ матрица:');
 for i:=1 to n do
 begin
  for j:=1 to m do
   begin
    X[i,j]:=random(10);
    write(X[i,j]:3);
   end;
  writeln;
 end;
 writeln;
{Udalenie strok s 0}
 i:=1;
 w:=1;
 f:=False;
 while i<=n do
 begin
  k:=0;
  for j:=1 to m do
   if X[i,j]=0 then
   begin
   St[w]:=j; 
   k:=1;
   w:=w+1;
   end;
  if k=1 then//если в строке есть ноль
  begin
   f:=True;//фиксируем
   for t:=1 to m do//элементы всех строк
   for p:=i to n-1 do//от последней до следующей за найденной
    X[p,t]:=X[p+1,t];//поднимаем на 1 вверх
   n:=n-1;//уменьшаем количество строк
  end
  else i:=i+1;
 end;
 if f= true then
 begin
   for y := 1 to w do
    for p:=1 to n do//элементы всех строк
     for t:=st[y] to n-1 do//от последней до следующей за найденной
         X[p,t]:=X[p,t+1];//поднимаем на 1 вверх
       m:=m-1;//уменьшаем количество строк
 end;
  {while i<=n do
  begin
   k:=0;
   for i:=1 to n do
    if X[i,j]=0 then k:=1;
    if k=1 then//если в строке есть ноль
      begin
       for t:=1 to m do//элементы всех строк
        for p:=j to n-1 do//от последней до следующей за найденной
         x[p,t]:=x[p,t+1];//поднимаем на 1 вверх
       m:=m-1;//уменьшаем количество строк
      end
    else j:=j+1;
  end;
 end;}
 

 
 
  {j:=1;
  while i<=n do
  begin
   k:=0;
   for i:=1 to n do
    if a[i,j]=0 then k:=1;
    if k=1 then//если в строке есть ноль
      begin
       for t:=1 to m do//элементы всех строк
        for p:=j to n-1 do//от последней до следующей за найденной
         a[p,t]:=a[p,t+1];//поднимаем на 1 вверх
       m:=m-1;//уменьшаем количество строк
      end
    else j:=j+1;
  end; }

 if f=False then write('¬ матрице нет нолей!')
 else
  if n=0 then write('¬се строки удалены!')
  else
  begin
   writeln('—троки с нол€ми удалены:');
   for i:=1 to n do
   begin
    for j:=1 to m do
    write(X[i,j]:3);
    writeln
   end;
  end;
 readln
end.

