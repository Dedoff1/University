program StringReplace;

{
  ������� ��������� ��� ��������� ���������� ����� F1,
  ������� ����� �� ����� F2, �������� ��������� � ���� G
}

uses
  System.SysUtils,
  StrUtils;

// ���������� ���� ����������������� ������
Type
  Adr = ^Rep;
  Rep = record
    Words: String;
    AdrCled: Adr;
  end;

var
  F1, F2, G: TextFile;
  Adr1, AdrRep: Adr;
  // F1, F2 � �������� ��������� �����
  // G � �������� ��������� ����
  // Adr1, AdrRep � �������� �� ������ � ������� �����
  // ������

// ������������ ��� �������� ������� �����
// ����������������� ������
function ListCreate (var Adrec: Adr) :Adr;

Begin
  New(Adrec);
  Result:=Adrec;
  Adrec^.AdrCled:=Nil;
End;

// ������������ ��� �������� ���� �������
// ����������������� ������
procedure ListClear (var AdrStart: Adr);
var
  Adrec: Adr;
Begin
  while AdrStart^.AdrCled<>Nil  do
  Begin
    Adrec:=AdrStart^.AdrCled;
    AdrStart^.AdrCled:=Adrec^.AdrCled;
    Dispose(Adrec);
  End;
End;

// ������������ ��� ���������� ����� � ����������������
// ������
Procedure NewZveno (var Addr: Adr;
                    S: String);

Begin
  New(Addr^.AdrCled);
  Addr:=Addr^.AdrCled;
  Addr^.Words:=S;
  Addr^.AdrCled:=Nil;
End;

// ������������ ��� ���������� �������� ���������� �
// ������� ����, ��������� �������������
procedure GetFile (var F: TextFile);

var
  Path: String;

Begin
  //Writeln('������� ������ ���� � ����� c ����������� ''txt'': ');
  // �������� ���� �����
  Repeat
    Readln(Path);
    If FileExists(Path) = False then
      Write('������������ ����, ������� ������: ');
  Until FileExists(Path);

  AssignFile(F, Path);
End;

// ������������ ��� ��������� ���� ���������� � ����������
// ����
procedure GetReplace (var Adrec: Adr;
                      var File2: TextFile);
var
  I, J: Integer;
  Temp: String;

Begin
  Reset(File2);
  Readln(File2, Temp);
  I:=0;

  // ������ ������� � ������
  J:=Pos(',',Temp);
  // ���� ��� ���������� �����, ���� � ������ ���� �������
  while J <> 0  do
  Begin
    NewZveno(Adrec, Copy(Temp,1,J-1));
    Delete(Temp,1,J);
    Inc(I);
    J:=Pos(',',Temp);
  End;

  // �������� ���������� ���� �� ��������
  if I mod 2 = 1 then
    NewZveno(Adrec,Temp);

End;

// ������������ ��� ������ ���� � ������� ������������
// StringReplace
procedure Replaces1 (var File1, File3: TextFile;
                     Adrec: Adr);
var
  AdrStart: Adr;
  Temp: String;

begin
  // ���������� ������ ������� �����
  AdrStart:=Adrec;
  Reset(File1);
  ReWrite(File3);

  // ���� ��� ������� �� ���� ������� �����
  while not Eoln (File1) do
  Begin
    Readln(File1, Temp);

    // ���� ��� ������� �� ���� ���������� ������
    While Adrec<>nil do
    Begin
      Temp:=StringReplace(Temp,Adrec^.Word,Adrec^.AdrCled^.Words, [rfReplaceAll, rfIgnoreCase]);
      Adrec:=Adrec^.AdrCled^.AdrCled;
    End;

    Writeln(File3, Temp);
    // ����������� � ��������� ����� ������� �����
    Adrec:=AdrStart;
  End;
end;

// �������� ���������
begin
  Writeln('������� ������ ���� � ���������� �����, � ������� ���������� �������� �����');
  GetFile(F1);

  Writeln('������� ������ ���� � �����, ������� �������� ���� ���������� � ���������� ����');
  GetFile(F2);

  Writeln('������� �����, � ������� ���������� ��������� ���������');
  GetFile(G);

  AdrRep:=ListCreate(Adr1);
  GetReplace(AdrRep, F2);
  AdrRep:=Adr1^.AdrCled;

  Replaces1(F1, G, AdrRep);
  ListClear(Adr1);

  Write('The end');
  Close(F1);
  Close(F2);
  Close(G);
  Readln;
end.


