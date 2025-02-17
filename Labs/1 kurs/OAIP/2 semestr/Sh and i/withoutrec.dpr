Program withoutrec;
{
  ��������� ����������� ���������� � ����� ������ �����
  ��������� ������������������ �� ��������� ����������
  �������.
}

//����������� ������
uses
  SysUtils,
  Windows;

//���������� ����������
Var
  NumCount: Integer;
  ResultCount: Integer;
  //StartHookCount - ���������� �������
  //SubsequenceCount - ���������� �������������������

//������������ ��� ����������
//���������� �������������������
{
   ������ ������� ���������� �������, ������������
   ��������� ���������� �������������������.
}
Function AllSequences(Const StartCount: Integer): Integer;
Var
  I: Integer;
  Num1, Num2, Num3, CurrentCount: Integer;
  //I - ���������� �����
  //CurCount - ������� �������� ��������� ��������
  //Count_1, Count_2, Count_3 - ����������
  //�������� ������� ��������� �������������������

Begin
  //��������� �������� ������
  If StartCount < 4 then
    CurrentCount:= 1
  Else
  Begin
    //���������� ��������� ��������
    Num1:= 0;
    Num2:= 1;
    Num3:= 1;
    //���� ����������� ���������
    //������������������� ��
    //���������� ��������
    For I:= 4 to StartCount do
    Begin
      //����� �������� ���������� �������������������
      CurrentCount:= Num1 + Num2;
      //���������������� �������� ���
      //���������� �������� ���������
      Num1:= Num2;
      Num2:= Num3;
      Num3:= CurrentCount;
    End;
  End;

  Result:= CurrentCount;
End;

//������������ ��� �����
//�������������� ��������
{
  ������ ������, ��� ������ ������������. ������������
  ������ ��������, ���� �� ����� ����������
}
Function InputNum(Const Text: String): Integer;

//���������� ����������
Var
  IsCorrect: Boolean;
  Value: Integer;
  //IsCorrect - ���� ������������ �����
  //Value - �������� ��������

Begin
  IsCorrect:= False;
  //���� �����
  While not IsCorrect do
  Begin
    Write(Text);
    Try
      //���� �������
      Readln(Value);
      If (Value < 2) then Writeln('�� ���������� ����')
      //���� ���� ����������
      Else IsCorrect:= True;
    Except
      //���� ���� �� ����������
      Writeln('�� ���������� ����');
    End;
  End;
  Result:= Value;
End;


Begin
  SetConsoleOutputCP(1251);
  SetConsoleCP(1251);
  //���� ���������� �������
  NumCount:= InputNum('������� ���������� �������: ');

  //������ ��������� ��������� �������������������
  ResultCount:= AllSequences(NumCount);

  //����� ���������� �������������������
  Writeln('���������� �������������������: ', ResultCount);

  Readln;
End.

