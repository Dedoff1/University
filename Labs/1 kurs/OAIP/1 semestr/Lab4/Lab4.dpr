program Lab4;

{$APPTYPE CONSOLE}

{$R *.res}

uses
  System.SysUtils;

const
N=5;
var
X:array[1..N] of real;
i,v,L,W,t,e:integer;
r:boolean;
m:real;
begin
 for i:=1 to n do
 begin
   write('������� ������� �������', 'X[',i,']= ');
   Readln(X[i]);
 end;
 L:=1;
 r:=false;
 for i:= 1 to n do
 begin
   M := X[i];
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

 end;
 readln(I);
end.
