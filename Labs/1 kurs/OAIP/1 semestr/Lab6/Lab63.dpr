program Lab63;

{$APPTYPE CONSOLE}

{$R *.res}

uses
  System.SysUtils;

var
 year , color, Animal : integer;
begin
  Writeln('Введите год');
  Readln(Year);
  if year >= 1 then
  begin
   if year < 4 then
   color:= 5
   else
   begin
    Year:= Year mod 60;
    if Year <= 12 then
    Color:= 1
    else
    Color:= Year div 12;
    Year:= Year mod 12;
   end;
   Animal:= Year;
   case Color of
    1: write('зеленой(ого) ');
    2: write('красной(ого) ');
    3: write('желтой(ого) ');
    4: write('белой(ого) ');
    5: write('черной(ого) ');
   end;
   case Animal of
     1: write('курицы');
     2: write('собаки');
     3:  write('свиньи');
     13: write('курицы');
     14: write('собаки');
     15:  write('свиньи');
     4: write('крысы');
     5: write('коровы');
     6: write('тигра');
     7: write('зайца');
     8: write('дракона');
     9: write('змея');
     10: write('лошади');
     11: write('овцы');
     12: write('обезьяны');
   end;
  end
   else
    writeln('Проверьте данные');
   readln;
 end.
