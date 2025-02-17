program Project6;

{$APPTYPE CONSOLE}

{$R *.res}

uses
  System.SysUtils;

var
a:integer;
b:integer;
v:integer;

Procedure calc(var i,sh,n:integer);
var f:integer;
// Variable declaration section


{
  i,j Ц counter variables;
  k Ц sign variable.
}

Begin
  // Determining the coefficient value
  f:=n;
  if (n>=3) and (n<>4) then
  begin
   sh:=sh+1;
   n:=n-3
  end
  else
  begin
  i:=i+1;
  n:=n-2
  end;
End;


begin
  writeln('¬ведите количество крючков');
  readln(v);
  while v > 0 do
  calc(a,b,v);
  writeln(a, ' и ',b, ' ш' );
  readln(v);

end.
