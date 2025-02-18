program lr1v4;

{$APPTYPE CONSOLE}

{$R *.res}

uses
  System.SysUtils,
  Windows;

{$APPTYPE CONSOLE}


Type
  Pt = ^Elem;
  Elem = Record
    Data: Record
      Abonent, Number: String[30];
      end;
    Next: Pt;
    Prev: Pt;
  end;

  Pt2 = ^Elem2;
  Elem2 = Record
    Data: Record
      Abon, Num: String[30];
      end;
    Next: Pt2;
    end;
  TString = String[30];

Var
  SPservice: Integer;
  First: Pt;
  First2: Pt2;
  Y: Pt;
  Z: Pt2;
  F: Boolean;

procedure input(var Y: pt);
var x: pt;
i, N: integer;
begin
  writeln ('Ââåäèòå êîëè÷åñòâî íîìåğîâ òåëåôîíîâ:');
  readln (N);
  new (x);
  first := x;
  x^.prev := nil;
  for i := 1 to N do
  begin
    writeln ('Èìÿ:');
    y := x;
    readln (y^.data.abonent);
    writeln ('Òåëåôîííûé íîìåğ:');
    readln (y^.data.number);
    if i <> N then
    begin
      new (x);
      y^.next := x;
      x^.prev := y;
    end
  else
  y^.next := nil;
  end;
end;

procedure output (Y: pt);
begin
   y := first;
  writeln ('ÑÏÈÑÎÊ ÍÎÌÅĞÎÂ ÒÅËÅÔÎÍÎÂ:');
  while y <> nil do
  begin
    writeln (' ', y^.data.abonent,' ',y^.data.number);
    y := y^.next;
  end;
end;

procedure the_did (var F: boolean; var Y: pt; var Z: pt2; var First2: pt2;
var Service: integer);
begin
  Service := 0;
  f := false;
  new (z);
  first2 := z;
  while y <> nil do
    begin
    if length (y^.data.number)=7 then
    begin
      f := true;
      new (z^.next);
      z := z^.next;
      z^.data.abon := y^.data.abonent;
      z^.data.num := y^.data.number;
    end;
    writeln (' ', y^.data.abonent,' ',y^.data.number);
    if length (y^.data.number) = 3 then inc (Service);
    y := y^.prev;
  end;
  z^.next := nil;
end;

procedure Sort (var Z, First2: pt2);
var
  i, j, k: integer;
  S1, S2: TString;
begin
  k := 0;
  z := first2;
  while (z <> nil) do
  begin
    inc (k);
    z := z^.next;
  end;
  for j := 1 to k - 1 do
  begin
    z := first2;
    for i := 1 to k - j do
    begin
      if z^.data.num > z^.next^.data.num then
      begin
        S1 := z^.data.num;
        S2 := z^.data.abon;
        z^.data.num := z^.next^.data.num;
        z^.data.abon := z^.next^.data.abon;
        z^.next^.data.num := S1;
        z^.next^.data.abon := S2;
      end;
      z := z^.next;
    end;
  end;
end;

procedure output2 (var F: boolean; Var Z: pt2);
begin
  Z := First2;
  WriteLn;
  WriteLn ('ÑÏÈÑÎÊ ÍÎÌÅĞÎÂ ÀÁÎÍÅÍÒÎÂ:');
  while z <> nil do
  begin
    Write(' ',z^.data.abon,' ',z^.data.num);
    WriteLn;
    Z := z^.next;
  end;
  writeln;
  if SPservice <> 0 then writeln ('Â ÑÏÈÑÊÅ ',SPservice,' ÍÎÌÅĞ(À) ÑÏÅÖÑËÓÆÁ(Û).');
  if F = False then writeln ('Â ÑÏÈÑÊÅ ÍÅÒ ÍÈ ÎÄÍÎÃÎ ÍÎÌÅĞÀ ÀÁÎÍÅÍÒÎÂ.');
end;

begin
  setconsoleCP (1251);
  setconsoleoutputCP (1251);
  input (Y);
  writeln;
  writeln('___________________________________________');
  writeln;
  output (Y);
  writeln;
  writeln ('ÑÏÈÑÎÊ ÍÎÌÅĞÎÂ ÒÅËÅÔÎÍÎÂ (ÑÏĞÀÂÀ ÍÀËÅÂÎ):');
  the_did (F, Y, Z, First2, SPservice);
  Sort (Z, First2);
  output2 (F, Z);
  writeln;
  writeln;
  readln;
end.
