program Lab44;

{$APPTYPE CONSOLE}

{$R *.res}

uses
  System.SysUtils;
const
n=5;
var
A:array[1..N] of real;
i,v,L,t,e:integer;
r,f:boolean;
m,w:real;
begin
 for i:=1 to n do
 begin
   write('¬ведите элемент массива', 'X[',i,']= ');
   Readln(A[i]);
 end;
 l:=1;
 t:=0;
 r:=false;
 w:=0;
 for i := 1 to n-1 do
 begin
   M:=A[i];
   for v := i to n-1 do
   if (M=A[v+1]) and ((A[v+1]<> w) or (r=False)) then
   l:=l+1;
   if (t > 0) and (l > 1) then
   break;
   if l > 1 then
   begin
   t:=l;
   l:=1;
   r:=true;
   w:=m;
   end;
 end;
if r = false then
  writeln('7')
else
begin
    if t = 5 then
     writeln('1');
    if t = 4 then
     writeln('2');
    if ((t = 3) and (l = 2)) or ((l = 3) and (t = 2))  then
     writeln('3');
    if (l=1) and (t=3) then
     writeln('4');
    if (t=2) and (l=2) then
     writeln('5');
    if (l=1) and (t=2) then
     writeln('6');
   end;





 readln(I);
end.
