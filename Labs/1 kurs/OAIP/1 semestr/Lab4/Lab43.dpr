program Lab43;

{$APPTYPE CONSOLE}

{$R *.res}

uses
  System.SysUtils;
var
X,A:array[1..5] of real;
i,v,L,n,W,t,e:integer;
r,f:boolean;
m:real;
begin
n:=5;
 for i:=1 to n do
 begin
   write('¬ведите элемент массива', 'X[',i,']= ');
   Readln(X[i]);
 end;
 i:=1;
 l:=1;
 r:=false;
while i < n do
begin
M:=X[i];
for v:=1 to n-1 do
X[v]:=X[v+1];
n:=n-1;
for v:=1 to n do
if M=X[v] then
begin
l:=l+1;
for w := v to n do
 begin
  X[w]:=X[w+1];
  n:=n-1;
 end;
end;
if l > 1 then
begin
  t:=l;
  l:=1;
  r:=true;
end;
end;
if r = false then
  writeln('7')
 else
   begin
    if l = 5 then
     writeln('1');
    if l = 4 then
     writeln('2');
    if ((t = 3) and (l = 2)) or ((l = 3) and (t = 2))  then
     writeln('3');
    if (l=3) and (t=0) then
     writeln('4');
    if (t=2) and (l=2) then
     writeln('4');
    if (l=2) and (t=0) then
     writeln('6');
   end;





 readln(I);
end.
