program Project55;

{$APPTYPE CONSOLE}

{$R *.res}

uses
  System.SysUtils;

var
N,i,P: integer;
 B : array[1..1000] of boolean;
begin
  writeln ('������� N ');
read(N);
   while N > 1 do
   begin
   for P := 2 to N do
    B[P]:=true;
    P:=2;

    while (P*P <= N) do
    begin
      i:=P*P;
      if B[P] then
       while i <= N do
       begin
        B[i]:=false;
        i:=i+P;
       end;
       P:=P+1;
    end;
     for P := 2 to N do
      if B[P]= true then
      begin
      write(P, ' ');
      N := N div P;
      break;
      end;
      end;


readln(N);
end.
