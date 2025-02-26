Program withrec;
{
  ��������� ����������� ����������
  � ����� ������ ����� ��������� ������������������
  �� ��������� ���������� �������.
}

//����������� ������
uses
  SysUtils;

//���������� ����������
Var
  NumCount: Integer;
  ResCount: Integer;
  //NumCount - ���������� �������
  //ResCount - ���������� �������������������

//������������ ��� ���������� ���������� �������������������
{
   ������ ������� ���������� ������� � �������
   ������������������, ������������ ��������� ���������
   �������� ������������������ � ������� �������� ����������
   �������������������.
}
Procedure AllSequences(Const StartCount:integer; Const CurrentSequence: String; var ResultCount: Integer);
Begin
  //���� ������� �� ������ 4-�
  If StartCount >= 4 then
  Begin
    //��������� ������������������ �� ���
    //(���� � "�", ������ � "�", ���� ������� ������ 4)
    AllSequences(StartCount - 2, CurrentSequence + '�', ResultCount);
    if StartCount <> 4 then
      AllSequences(StartCount - 3, CurrentSequence + '�', ResultCount);
  End


  //���� �������� 3 ������ ������������������
  //������������ �� "�"
  Else if StartCount = 3 then
  Begin
    Inc(ResultCount);
    Writeln(ResultCount, '. ', CurrentSequence + '�')
  End
  //���� 2, �� �� "�"
  Else
  Begin
    Inc(ResultCount);
    Writeln(ResultCount, '. ', CurrentSequence + '�')
  End;
End;

//������������ ��� �����
//�������������� ��������
{
  ������ ������, ��� ������ ������������. ������������ ������
  ��������, ���� �� ����� ����������
}
Function InputNum(Const InputText: String): Integer;

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
    Write(InputText);
    Try
      //���� �������
      Readln(Value);
      If (Value < 2) then Writeln('�� ����� ������������ ������. ���������� �����')
      //���� ���� ����������
      Else IsCorrect:= True;
    Except
      //���� ���� �� ����������
      Writeln('�� ����� ������������ ������. ���������� �����');
    End;
  End;
  Result:= Value;
End;



Begin
  //���� ���������� �������
  NumCount:= InputNum('������� ���������� �������: ');
  //������ ��������� ��������� �������������������
  //� �� �����
  Writeln('��� ��������� ������������������ �� "�" � "�" :');
  AllSequences(NumCount, '', ResCount);
  //����� ���������� �������������������
  Writeln('���������� �������������������: ', ResCount);

  Readln;
End.


