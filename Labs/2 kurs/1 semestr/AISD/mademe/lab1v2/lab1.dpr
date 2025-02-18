program лр1;

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
  i, N, K: integer;

begin
  first := nil;{Обнуление указателей}
  cur := nil;

  repeat
  begin
    Write('N=');
    readln(N);
  end;
  until n<=64;

  Write('K=');
  Readln(K);

  for i := 1 to N do {Создание списка и заполнение}
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
  cur^.next := first;{Зацикливание списка}
  cur := first;{Переход на начало}
  while cur^.next <> cur do
  begin
    for i := 2 to K - 1 do
      cur := cur^.next;
    temp := cur^.next;
    cur^.next := temp^.next;
    cur := cur^.next;
    dispose(temp);{удаление элемента}
  end;
  writeln(cur^.number);
  readln;

end.