program lab1v2v2;

{$APPTYPE CONSOLE}

{$R *.res}

uses
  System.SysUtils;

type
  pt = ^elem;
  elem = record
    Number: integer;
    next: pt;
  end;

var
  first, cur, temp: pt;
  i, NumberPeople, NumberOut: integer;

begin
  first := nil;{��������� ����������}
  cur := nil;



  Writeln('����� ������� �������� ?');
  Write('������ ');
  Readln(NumberOut);
  writeln('���������� ������� ����� ����������� ��������� �������');
  for NumberPeople := 1 to 64 do
  begin
   for i := 1 to NumberPeople do {�������� ������ � ����������}
   begin
    if first = nil then
    begin
      new(first);
      first^.number := i;
      first^.next := nil;
      cur := first;
    end
    else
    begin
      new(temp);
      temp^.number := i;
      temp^.next := nil;
      cur^.next := temp;
      cur := cur^.next;
    end;
   end;
   cur^.next := first;{������������ ������}
   cur := first;{������� �� ������}
   while cur^.next <> cur do
   begin
    for i := 2 to NumberOut - 1 do
      cur := cur^.next;
    temp := cur^.next;
    cur^.next := temp^.next;
    cur := cur^.next;

    dispose(temp);{�������� ��������}
   end;
   if NumberPeople < 10 then
   write('          ', NumberPeople, '             ')
   else
   write('          ', NumberPeople, '            ');
   write(NumberOut, '                     ');
   writeln(cur^.number);
  end;
  readln;

end.
