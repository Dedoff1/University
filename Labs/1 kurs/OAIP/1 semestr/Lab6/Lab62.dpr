program Lab62;

{$APPTYPE CONSOLE}

{$R *.res}

uses
  System.SysUtils;

var
 Year , Color, Animal : integer;
begin
  Writeln('������� ���');
  Readln(Year);
  if year >= 1 then
  begin
   write(Year, ' �, ��� ����� ');
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
    1: write('�������(���) ');
    2: write('�������(���) ');
    3: write('������(���) ');
    4: write('�����(���) ');
    5: write('������(���) ');
    end;
   case Animal of
     1: write('������');
     2: write('������');
     3:  write('������');
     4: write('�����');
     5: write('������');
     6: write('�����');
     7: write('�����');
     8: write('�������');
     9: write('����');
     10: write('������');
     11: write('����');
     12: write('��������');
     13: write('������');
     14: write('������');
     15:  write('������');
   end;
  end
  else
   if year > 0 then
   begin
     write(Year, ' �, ��� ����� ������ ');
     case Year of
     1: write('������');
     2: write('������');
     3:  write('������');
     end;
   end
   else
    writeln('������������ ������, ������������� ���������');
   readln;
 end.
