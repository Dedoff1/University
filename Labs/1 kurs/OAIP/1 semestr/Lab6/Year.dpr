program lab4;

{$APPTYPE CONSOLE}

{$R *.res}

uses
  System.SysUtils;

var
 year , i, color, Animal : integer;
begin
  Writeln('������� ���');
  Readln(Year);
  while Year >= 60 do
  Year:= Year - 60;
  while Year >= 12 do
  begin
  Year:= Year - 12;
  Color:= Color + 1;
  end;
  while year > 0 do
  begin
  Year:= Year - 1;
  Animal:= Animal + 1;
  end;
  if color = 1 then
  writeln('�������');
  if color = 2 then
  writeln('�������');
  if color = 3 then
  writeln('������');
  if color = 4 then
  writeln('�����');
  if color = 5 then
  writeln('������');
  if animal = 1 then
  writeln('�������');
  if animal = 1 then
  writeln('�����');
  if animal = 2 then
  writeln('������');
  if animal = 3 then
  writeln('����');
  if animal = 4 then
  writeln('����');
  if animal = 5 then
  writeln('������');
  if animal = 6 then
  writeln('����');
  if animal = 7 then
  writeln('������');
  if animal = 8 then
  writeln('����');
  if animal = 9 then
  writeln('��������');
  if animal = 10 then
  writeln('������');
  if animal = 11 then
  writeln('������');
  if animal = 12 then
  writeln('������');
  readln;
end.
