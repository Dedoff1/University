program ���������;

{$APPTYPE CONSOLE}

{$R *.res}

uses
  System.SysUtils;

type prod=(hl,ml,ms,sr,kl);//������������ ��� ��� �������� ��������
     mnz=set of prod;//��� ��������
const n=3;
      nn=5;
      //������ ���������
      sp:array[0..nn-1] of string=('����','������','�����','���','�������');
var m:array[1..n] of mnz;//������ ��������
    res:mnz; //�������������� ���������
    j:prod;//������� ������ �� ���������
    i,k,p:byte;//������������� �������� ������
begin
writeln('����������� ����� �������� ���� � ��������:');
for i:=1 to n do
 begin
  writeln('������� ',i);
  m[i]:=[];
  writeln('0-���� 1-������ 2-����� 3-��� 4-�������');
  writeln('5-�����');
  repeat
   readln(k);
   if k in [0..4] then m[i]:=m[i]+[prod(k)];
  until k=5;
 end;
writeln('������� � ������ ��������');
res:=[];
for j:=hl to kl do
 begin
  k:=0;
  for i:=1 to n do
  if j in m[i] then k:=k+1;
  if k=n then res:=res+[j];
 end;
if res=[] then writeln('����� ������� ���')
else
 for j:=hl to kl do
 if j in res then write(sp[ord(j)],' ');
writeln;
writeln('���� ���� �� � ����� ��������:');
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
