program Lab61;

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
   while Year >= 0 do
   Year:= Year - 60;
   if Year < -48 then
   Color:= Color + 1
   else
   begin
    while Year >= -48 do
    begin
     Year:= Year - 12;
     Color:= Color + 1;
    end;
   end;
   year:=year - 4;
   while year >= -60 do
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
   1: write('крысы');
   2: write('коровы');
   3: write('тигра');
   4: write('зайца');
   5: write('дракона');
   6: write('змея');
   7: write('лошади');
   8: write('овцы');
   9: write('обезьяны');
   10: write('курицы');
   11: write('собаки');
   12:  write('свиньи');
   end;
  end
   else
    writeln('Некорректные данные, перезапустите программу.');
   readln;

 end.
