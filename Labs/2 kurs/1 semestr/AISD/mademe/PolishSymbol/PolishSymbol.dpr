program PolishSymbol;

{$APPTYPE CONSOLE}

{$R *.res}

uses
  System.SysUtils;
const
oper1=['^'];
oper2=['+','-'];
oper3=['*','/'];
alpha=['A'..'Z', 'a'..'z'];
var
soriginal,sbuffer,sfin: string;
oper:boolean;
procedure checking(st:string);
var
sym:char;
  I: Integer;
begin
 for I := 1 to length(soriginal) do
  sym:=st[i];
  if (sym in oper1) or (sym in oper2) or (sym in oper3) then
    oper:=true
    else
    oper:=false;
end;
procedure sorting(sy:char;str,strfin:string;j:integer);
var
v:integer;
temp: char;
begin
  if sy in oper1 then
  while (str[j-1] in oper2) or (str[j-1] in oper3) or (str[j-1] in alpha)  do



end;



begin
  s:='';
  s1:='';
  writeln('Введите выражение');
  readln(s);
  writeln('Преобразованная строка');
  readln(s1);
  sleep(1234);
end.
