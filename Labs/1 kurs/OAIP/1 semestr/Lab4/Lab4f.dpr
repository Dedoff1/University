program Lab4f;

{$APPTYPE CONSOLE}

{$R *.res}

uses
  System.SysUtils;

const
N=5;
var
X,A:array[1..N] of real;
i,v,L,W,t,e:integer;
r,k:boolean;
m:real;
begin
 for i:=1 to n do
 begin
   write('������� ������� �������', 'X[',i,']= ');
   Readln(X[i]);
 end;
 k:=false;
 for I := 1 to n do
  M:=X[i];
  r:=false;
 for v := i+1 to n do
  if X[v] = M then
  begin
  k:=true;
   if r= false then
   begin
    r:=true;
    A[w]:= M;
    w:=w+1;
   end;
  A[w]:=X[v];
  w:=w+1;
  end;
  i:=i+1;
  t:=1;
  l:=0;
  while i <=n do
  begin
   M:=A[i];
   while A[i+1] = M do
   begin
    t:=t+1;
    i:=i+1;
   end;
   l:=t;
   i:=t+1;
  end;
 if k = false then
  writeln('7')
 else
   begin
    if t = 5 then
     writeln('1');
    if t = 4 then
     writeln('2');
    if ((t = 3) and (l = 2)) or ((l = 3) and (t = 2))  then
     writeln('3');
    if (t=3) and (l=0) then
     writeln('4');
    if (t=2) and (l=2) then
     writeln('4');
    if (t=2) and (l=0) then
     writeln('6');
   end;
 readln(i);
end.
