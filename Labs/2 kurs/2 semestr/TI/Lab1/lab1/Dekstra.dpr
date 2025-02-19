program Dekstra;

{$APPTYPE CONSOLE}

uses
  SysUtils;

const V=6; inf=100000;
type vektor=array[1..V] of integer;
 Mas=array[1..V,1..V] of Integer;
var start: integer;

const Arr: Mas=(
(0, 80, 0, 0, 0, 0,50),
(0, 0, 0, 12, 0, 0),
(4, 0, 0, 7, 0, 0),
(0, 12, 7, 0, 0, 2),
(0, 0, 0, 0, 0, 8),
(0, 0, 0, 2, 8, 0));
{???????? ????????}
procedure Dijkstra(const GR:Mas; st: integer);
var count, index, i, u, m, min: integer;
distance: vektor;
visited: array[1..V] of boolean;
begin
m:=st;
for i:=1 to V do
begin
distance[i]:=inf; visited[i]:=false;
end;
distance[st]:=0;
for count:=1 to V-1 do
begin
min:=inf;
for i:=1 to V do
if (not visited[i]) and (distance[i]<=min) then
begin
min:=distance[i]; index:=i;
end;
u:=index;
visited[u]:=true;
for i:=1 to V do
if (not visited[i]) and (GR[u, i]<>0) and (distance[u]<>inf) and
(distance[u]+GR[u, i]<distance[i]) then
distance[i]:=distance[u]+GR[u, i];
end;
write('????????? ???? ?? ????????? ??????? ?? ?????????:'); writeln;
for i:=1 to V do
if distance[i]<>inf then
writeln(m,' > ', i,' = ', distance[i])
else writeln(m,' > ', i,' = ', '??????? ??????????');
end;
{???????? ???? ?????????}
begin
write('????????? ??????? >> '); read(start);
Dijkstra(Arr, start);
Readln;
Readln;
end.
