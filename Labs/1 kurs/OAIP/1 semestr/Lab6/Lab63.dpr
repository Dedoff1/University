program Lab63;

{$APPTYPE CONSOLE}

{$R *.res}

uses
  System.SysUtils;

var
 year , color, Animal : integer;
begin
  Writeln('������� ���');
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
     13: write('������');
     14: write('������');
     15:  write('������');
     4: write('�����');
     5: write('������');
     6: write('�����');
     7: write('�����');
     8: write('�������');
     9: write('����');
     10: write('������');
     11: write('����');
     12: write('��������');
   end;
  end
   else
    writeln('��������� ������');
   readln;
 end.
