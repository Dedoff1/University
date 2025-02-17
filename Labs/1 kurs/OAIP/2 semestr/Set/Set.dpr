program множества;

{$APPTYPE CONSOLE}

{$R *.res}

uses
  System.SysUtils;

type prod=(hl,ml,ms,sr,kl);//перечислимый тип для создания множеств
     mnz=set of prod;//тип множеств
const n=3;
      nn=5;
      //список продуктов
      sp:array[0..nn-1] of string=('хлеб','молоко','масло','сыр','колбаса');
var m:array[1..n] of mnz;//массив множеств
    res:mnz; //результирующее множество
    j:prod;//счетчик циклов по продуктам
    i,k,p:byte;//челочисленные счетчики циклов
begin
writeln('Перечислите какие продукты есть в магазине:');
for i:=1 to n do
 begin
  writeln('Магазин ',i);
  m[i]:=[];
  writeln('0-хлеб 1-молоко 2-масло 3-сыр 4-колбаса');
  writeln('5-выход');
  repeat
   readln(k);
   if k in [0..4] then m[i]:=m[i]+[prod(k)];
  until k=5;
 end;
writeln('Имеются в каждом магазине');
res:=[];
for j:=hl to kl do
 begin
  k:=0;
  for i:=1 to n do
  if j in m[i] then k:=k+1;
  if k=n then res:=res+[j];
 end;
if res=[] then writeln('Таких товаров нет')
else
 for j:=hl to kl do
 if j in res then write(sp[ord(j)],' ');
writeln;
writeln('Есть хотя бы в одном магазине:');
res:=[];
for j:=hl to kl do
 begin
  for i:=1 to n do
  if j in m[i] then res:=res+[j];
 end;
for j:=hl to kl do
if j in res then write(sp[ord(j)],' ');
readln;
end.
