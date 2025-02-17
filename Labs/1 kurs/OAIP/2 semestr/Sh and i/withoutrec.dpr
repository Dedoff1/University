Program withoutrec;
{
  Программа высчитывает количество и какие именно можно
  составить последовательности из исходного количество
  крючков.
}

//Подключение модуля
uses
  SysUtils,
  Windows;

//Объявление переменных
Var
  NumCount: Integer;
  ResultCount: Integer;
  //StartHookCount - Количество крючков
  //SubsequenceCount - Количество последовательностей

//Подпрограмма для вычисления
//количества последовательностей
{
   Заданы текущее количество крючков, подпрограмма
   вычисляет количество последовательностей.
}
Function AllSequences(Const StartCount: Integer): Integer;
Var
  I: Integer;
  Num1, Num2, Num3, CurrentCount: Integer;
  //I - Переменная цикла
  //CurCount - текущее значение количеств значений
  //Count_1, Count_2, Count_3 - переменные
  //хранения прошлых количеств последовательностей

Begin
  //Обработка базового случая
  If StartCount < 4 then
    CurrentCount:= 1
  Else
  Begin
    //Присвоение начальных значений
    Num1:= 0;
    Num2:= 1;
    Num3:= 1;
    //Цикл составления количеств
    //последовательностей из
    //предыдущих значений
    For I:= 4 to StartCount do
    Begin
      //Поиск текущего количества последовательностей
      CurrentCount:= Num1 + Num2;
      //Переприсваивание значений для
      //предыдущих значений количеств
      Num1:= Num2;
      Num2:= Num3;
      Num3:= CurrentCount;
    End;
  End;

  Result:= CurrentCount;
End;

//Подпрограмма для ввода
//целочисленного значения
{
  Задана строка, для вывода пользователю. Пользователь
  вводит значение, пока не введёт корректное
}
Function InputNum(Const Text: String): Integer;

//Объявление переменных
Var
  IsCorrect: Boolean;
  Value: Integer;
  //IsCorrect - Флаг кооректности ввода
  //Value - Вводимое значение

Begin
  IsCorrect:= False;
  //Цикл ввода
  While not IsCorrect do
  Begin
    Write(Text);
    Try
      //Ввод элемнта
      Readln(Value);
      If (Value < 2) then Writeln('Не корректный ввод')
      //Если ввод корректный
      Else IsCorrect:= True;
    Except
      //Если ввод не корректный
      Writeln('Не корректный ввод');
    End;
  End;
  Result:= Value;
End;


Begin
  SetConsoleOutputCP(1251);
  SetConsoleCP(1251);
  //Ввод количества крючков
  NumCount:= InputNum('Введите количество крючков: ');

  //Посчёт количесва возможных последовательностей
  ResultCount:= AllSequences(NumCount);

  //Вывод количества последовательностей
  Writeln('Количество последовательностей: ', ResultCount);

  Readln;
End.

