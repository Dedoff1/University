program ��1;

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
  first := nil;{��������� ����������}
  cur := nil;

  repeat
  begin
    Write('N=');
    readln(N);
  end;
  until n<=64;

  Write('K=');
  Readln(K);

  for i := 1 to N do {�������� ������ � ����������}
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
    for i := 2 to K - 1 do
      cur := cur^.next;
    temp := cur^.next;
    cur^.next := temp^.next;
    cur := cur^.next;
    dispose(temp);{�������� ��������}
  end;
  writeln(cur^.number);
  readln;

end.