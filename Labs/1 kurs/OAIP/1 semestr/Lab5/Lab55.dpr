program Lab55;

{$APPTYPE CONSOLE}

{$R *.res}

uses
  System.SysUtils;

const nmax=20;
var X:array [1..nmax,1..nmax] of integer;
    St:array[1..20] of integer;
    n,m,i,j,k,p,t,e,y,w:byte;
    f: boolean;
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
    X[i,j]:=random(10);
    write(X[i,j]:3);
   end;
  writeln;
 end;
 writeln;
{Udalenie strok s 0}
 i:=1;
 w:=1;
 f:=False;
 while i<=n do
 begin
  k:=0;
  for j:=1 to m do
   if X[i,j]=0 then
   begin
   St[w]:=j; 
   k:=1;
   w:=w+1;
   end;
  if k=1 then//���� � ������ ���� ����
  begin
   f:=True;//���������
   for t:=1 to m do//�������� ���� �����
   for p:=i to n-1 do//�� ��������� �� ��������� �� ���������
    X[p,t]:=X[p+1,t];//��������� �� 1 �����
   n:=n-1;//��������� ���������� �����
  end
  else i:=i+1;
 end;
 if f= true then
 begin
   for y := 1 to w do
    for p:=1 to n do//�������� ���� �����
     for t:=st[y] to n-1 do//�� ��������� �� ��������� �� ���������
         X[p,t]:=X[p,t+1];//��������� �� 1 �����
       m:=m-1;//��������� ���������� �����
 end;
  {while i<=n do
  begin
   k:=0;
   for i:=1 to n do
    if X[i,j]=0 then k:=1;
    if k=1 then//���� � ������ ���� ����
      begin
       for t:=1 to m do//�������� ���� �����
        for p:=j to n-1 do//�� ��������� �� ��������� �� ���������
         x[p,t]:=x[p,t+1];//��������� �� 1 �����
       m:=m-1;//��������� ���������� �����
      end
    else j:=j+1;
  end;
 end;}
 

 
 
  {j:=1;
  while i<=n do
  begin
   k:=0;
   for i:=1 to n do
    if a[i,j]=0 then k:=1;
    if k=1 then//���� � ������ ���� ����
      begin
       for t:=1 to m do//�������� ���� �����
        for p:=j to n-1 do//�� ��������� �� ��������� �� ���������
         a[p,t]:=a[p,t+1];//��������� �� 1 �����
       m:=m-1;//��������� ���������� �����
      end
    else j:=j+1;
  end; }

 if f=False then write('� ������� ��� �����!')
 else
  if n=0 then write('��� ������ �������!')
  else
  begin
   writeln('������ � ������ �������:');
   for i:=1 to n do
   begin
    for j:=1 to m do
    write(X[i,j]:3);
    writeln
   end;
  end;
 readln
end.

