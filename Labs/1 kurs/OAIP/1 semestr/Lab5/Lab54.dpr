program Lab54;

{$APPTYPE CONSOLE}

{$R *.res}

uses
  System.SysUtils;

const nmax=20;
var a:array [1..nmax,1..nmax] of integer;
    n,m,i,j,k,f,p,t:byte;
begin
randomize;
writeln('�������� �������:');
repeat
write('���������� ����� �� ',nmax,' n=');
readln(n);
until n in [1..nmax];
repeat
write('���������� �������� �� ',nmax,' m=');
readln(m);
until m in [1..nmax];
writeln('�������� �������:');
for i:=1 to n do
 begin
   for j:=1 to m do
    begin
     a[i,j]:=random(10);
     write(a[i,j]:3);
    end;
   writeln;
 end;
writeln;
{Udalenie strok s 0}
i:=1;f:=0;
while i<=n do
 begin
  k:=0;
  for j:=1 to m do
  if a[i,j]=0 then k:=1;
  if k=1 then//���� � ������ ���� ����
   begin
    f:=1;//���������
    for t:=1 to m do//�������� ���� �����
    for p:=i to n-1 do//�� ��������� �� ��������� �� ���������
    a[p,t]:=a[p+1,t];//��������� �� 1 �����
    n:=n-1;//��������� ���������� �����
    for t:=j to m-1 do//�������� ���� �����
    for p:=1 to n do//�� ��������� �� ��������� �� ���������
    a[p,t]:=a[p,t+1];//��������� �� 1 �����
    m:=m-1;//��������� ���������� �����
   end
  else i:=i+1;
 end;
if f=0 then write('� ������� ��� �����!')
else if n=0 then write('��� ������ �������!')
else
 begin
  writeln('������ � ������ �������:');
  for i:=1 to n do
   begin
    for j:=1 to m do
    write(a[i,j]:3);
    writeln
   end;
 end;
readln
end.

