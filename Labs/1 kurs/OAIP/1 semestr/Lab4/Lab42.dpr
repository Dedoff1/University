program Lab42;

{$APPTYPE CONSOLE}

{$R *.res}

uses
  System.SysUtils;

const
N=5;
var
X:array[1..N] of real;
L:array[1..2] of integer;
i,v,q,f:integer;
r:boolean;
m:real;
begin
 for i:=1 to n do
 begin
   write('¬ведите элемент массива', 'X[',i,']= ');
   Readln(X[i]);
 end;
 r:=false;
 for i:= 1 to n-1 do
 begin
   M := X[i];
   for f := i+1 to n-1 do
   if M = X[f] then
   begin
    L[Q]:= L[Q] + 1;
    for v:=f to n-1 do
     X[v]:=X[v+1];
   end;
   if (L[Q] > 1) then
    if (q = 1) then
     q:= 2
    else
     break;
   { else
     if (q = 2) and (i = n-1) then
      break;}
 end;
 if q = 1 then
  writeln('7')
 else
  begin
   if L[2] = 0 then
   begin
    if L[1] = 5 then
     writeln('1');
    if L[1] = 4 then
     writeln('2');
    if L[1] = 3 then
     writeln('4');
    if L[1] = 2 then
     writeln('6');
   end
   else
    if L[1] = L[2] then
     writeln('5')
    else
     writeln('3');
  end;


 {
   for v:=i+1 to n do
    if X[v] = M then
    begin
     L := L + 1;
     for e:=i+1 to n do
     X[e]:=X[e+1];
    end;
   if L > 3 then
   begin
    if L = 5 then
     writeln('1')
    else
     writeln('2');
    break;
    end
   else
    if (i = n) then
    begin
     if (L = 1) and (r = false) then
     begin
      writeln('7');
      break;
     end
     else
      if (r = false) and (L > 1) then
      begin
      r := true;
      W := L;
      L:= 1;
      end
      else
      begin
       if (L = 1) and (r = true) then
        if W = 2 then
         writeln('6')
        else
         writeln('4')
       else
        if L = W then
         writeln('5')
        else
         writeln('3');
      break;
      end;
    end;

 end; }
 readln(I);
end.
