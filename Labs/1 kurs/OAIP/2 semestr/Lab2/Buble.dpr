program Buble;

{$APPTYPE CONSOLE}

{$R *.res}

uses
  System.SysUtils;

var a:array [1..50] of integer;
i,j,n,b:integer;
begin
write('¬вод кол-ва элементов -> ');
read(n);
writeln('»сходный массив:');
for i:=1 to n do
    begin
    a[i]:=random(21)-10;
    write(a[i]:4);
    end;
for j:=1 to n-1 do
for i:=1 to n-j do
if a[i]>a[i+1] then
   begin
   b:=a[i];
   a[i]:=a[i+1];
   a[i+1]:=b;
   end;
writeln;
writeln('”пор€доченный массив:');
for i:=1 to n do
write(a[i]:4);
readln(i);
end.
