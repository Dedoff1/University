program Lab2;

{$APPTYPE CONSOLE}

{$R *.res}

uses
  System.SysUtils;

var
 M,I: integer;
begin
 writeln('Введите число M');
 readln(M);
 if (M > 1) then
 begin
  I:= 2;
  writeln('Для числа ', M, ' простыми множителями являются ');
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
  writeln('Простых множителей у числа ',M,' нет')
  else writeln ('Некорректные данные, перезапустите программу');
 readln;

end.
