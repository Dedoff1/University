program Lab2;

{$APPTYPE CONSOLE}

{$R *.res}

uses
  System.SysUtils;

var
 M,I: integer;
begin
 writeln('������� ����� M');
 readln(M);
 if (M > 1) then
 begin
  I:= 2;
  writeln('��� ����� ', M, ' �������� ����������� �������� ');
  while (M > 1) do
  begin
   if (M mod I <> 0) then
   I:= I + 1
   else
   begin
    writeln(I);
   M:= M div I;
  end;
 end;
 end
 else
 if (M = 1) then
  writeln('������� ���������� � ����� ',M,' ���')
  else writeln ('������������ ������, ������������� ���������');
 readln;

end.
