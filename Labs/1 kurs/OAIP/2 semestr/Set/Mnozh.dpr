program Mnozh;

{$APPTYPE CONSOLE}

{$R *.res}

uses
  System.SysUtils;

const
  nmax=100;
var
glas: set of 'A'..'Z';
s : string;
temp: array [1..nmax] of string ;
i,v,number:integer;
bukv:string;
procedure print(words,kola,kolw,kole,koly,kolu,kolangli,kolo:integer);
begin
  if kola=words then
  writeln('a');
  if kolw=words then
  writeln('w');
  if kole=words then
  writeln('e');
  if koly=words then
  writeln('y');
  if kolangli=words then
  writeln('i');
  if kolo=words then
  writeln('o');

end;
procedure glaspos(strings: array of string);
var
l: char;
t: string;
aOp,wOp,eOp,yOp,uOp,iOp,oOp:boolean;
a,w,e,y,u,angli,o: integer;
begin
  for i:=1 to High(strings) do
    begin
       t:=strings[i];
       aOp:=false;
       wOp:=false;
       eOp:=false;
       yOp:=false;
       uOp:=false;
       iOp:=false;
       oOp:=false;
       for v:=1 to length(t) do
        L:=t[v];
         case l of
          'A': if aOp=false then
               begin
                a:=a+1;
                aOp:=true;
               end;
          'W': if wOp=false then
               begin
                w:=w+1;
                wOp:=true;
               end;
          'E': if eOp=false then
               begin
                e:=e+1;
                eOp:=true;
               end;
          'Y': if yOp=false then
               begin
                y:=y+1;
                yOp:=true;
               end;
          'U': if uOp=false then
               begin
                u:=u+1;
                uOp:=true;
               end;
          'I': if iOp=false then
               begin
                angli:=angli+1;
                iOp:=true;
               end;
          'O': if oOp=false then
               begin
                o:=o+1;
                oOp:=true;
               end;
         end;
    end;
    print(number,a,w,e,y,u,angli,o);
end;


begin
  glas := ['A','W','E','Y','U','I','O'];
  writeln('¬ведите строку');
  readln(s);
  bukv:=s[1];
  //for I := 1 to High(temp) do
     //temp[i]:='';
  i:=1;
  v:=1;
  while v < length(s) do
  begin
   while (bukv <> ',') and (bukv <> '.')  do
   begin
    temp[i]:=temp[i]+bukv;
    v:=v+1;
    bukv:=s[v];
   end;
   i:=i+1;
   v:=v+1;
   bukv:=s[v];
   number:=number+1;
  end;
  glaspos(temp);
   readln(i);

end.
