program Lab51;

{$APPTYPE CONSOLE}

{$R *.res}

uses
  System.SysUtils;

Const
N=3;
M=5;
Type
 Mas=array [1..N, 1..M] of real;
var
X: Mas;
i,j,ZeroX,v,k,c,r:Integer;
begin
 for I := 1 to N do
   for j := 1 to M do
   begin
     write('Вводите элемент', 'X[',i,',',j,']=');
     readln(x[i,j]);
   end;
   ZeroX:=0;
   r:=n;
   c:=m;
   for i := 1 to N do
    for J := 1 to M do
     if X[i,j] = 0 then
       for v:=i to N-1 do
        for k :=j to M-1 do
         X[v,k] := X[v+1, k+1];
        {begin
          X[v,j]:=x[i+1,j+1];
          r:=r-1;
          c:=c-1;
        end;}
writeln('Преобразованный массив');
for i:=1 to N do
 for j:=1 to M do
  write(X[i,j]:6:2,' ');
readln(c);


end.
