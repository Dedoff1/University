program Lab61;

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
    1: write('�������(���) ');
    2: write('�������(���) ');
    3: write('������(���) ');
    4: write('�����(���) ');
    5: write('������(���) ');
    end;
    case Animal of
   1: write('�����');
   2: write('������');
   3: write('�����');
   4: write('�����');
   5: write('�������');
   6: write('����');
   7: write('������');
   8: write('����');
   9: write('��������');
   10: write('������');
   11: write('������');
   12:  write('������');
   end;
  end
   else
    writeln('������������ ������, ������������� ���������.');
   readln;

 end.
