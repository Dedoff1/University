program Recursion;

{$APPTYPE CONSOLE}

{$R *.res}

uses
  System.SysUtils;

var
 i: integer;
 s,l: string;
 f:boolean;


begin
 writeln('������� ������');
 readln(s);
 i:=1;
 f:=true;
 while i < length(s) do
 begin
  while (s[i] <> ' ') or (s[i] = '.')  do
  begin
  l[i] := s[i];
  i:=i+1;
  end;
  if ((l[i] in ['a' .. 'z']) and (l[i+1] = ' ')) or (l='True') or (l='False')  then
  i:=i+1
  else
  begin
   f := false;
   break
  end;
 end;
 if f=true  then
 writeln('������ �����')
 else
 writeln('������ �� �����');
 readln(i);





end.
