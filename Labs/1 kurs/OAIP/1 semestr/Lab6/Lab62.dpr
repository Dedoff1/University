program Lab62;

{$APPTYPE CONSOLE}

{$R *.res}

uses
  System.SysUtils;

var
 Year , Color, Animal : integer;
begin
  Writeln('Введите год');
  Readln(Year);
  if year >= 1 then
  begin
   write(Year, ' г, был годом ');
   while Year >= 60 do
   Year:= Year - 60;
   if year < 12 then
   Color:= Color + 1
   else
   begin
    while Year >= 12 do
    begin
     Year:= Year - 12;
     Color:= Color + 1;
    end;
   end;
   while year >= 0 do
   begin
    Year:= Year - 1;
    Animal:= Animal + 1;
   end;
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
     4: write('крысы');
     5: write('коровы');
     6: write('тигра');
     7: write('зайца');
     8: write('дракона');
     9: write('змея');
     10: write('лошади');
     11: write('овцы');
     12: write('обезьяны');
     13: write('курицы');
     14: write('собаки');
     15:  write('свиньи');
   end;
  end
  else
   if year > 0 then
   begin
     write(Year, ' г, был годом черной ');
     case Year of
     1: write('курицы');
     2: write('собаки');
     3:  write('свиньи');
     end;
   end
   else
    writeln('Некорректные данные, перезапустите программу');
   readln;
 end.
