program Lab1v2;

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
  first := nil;{Обнуление указателей}
  cur := nil;

  repeat
  begin
    Write('Количество человек ');
    readln(NumberPeople);
  end;
  until NumberPeople<=64;

  Writeln('Какой человек выбывает?');
  Write('Каждый ');
  Readln(NumberOut);
  Writeln('Удаленные элементы (по порядку)');
  for i := 1 to NumberPeople do {Создание списка и заполнение}
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
  cur^.next := first;
  cur := first;
  while cur^.next <> cur do
  begin
    for i := 2 to NumberOut - 1 do
      cur := cur^.next;
    temp := cur^.next;
    writeln(temp^.number);
    cur^.next := temp^.next;
    cur := cur^.next;
    dispose(temp);{удаление элемента}
  end;
  writeln('Остался ',cur^.number, '-ый');
  readln;

end.