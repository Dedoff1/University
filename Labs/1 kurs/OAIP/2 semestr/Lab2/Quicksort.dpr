program Quicksort;

{$APPTYPE CONSOLE}

{$R *.res}

uses
  System.SysUtils;

const
  arrayLength = 50;
var
  inputArray : array [1..arrayLength] of integer;
  i, timer : integer;

procedure QuickSort(left, right: integer);
var
  newLeft, newRight : integer; //границы массива
  temp, pivot : integer;
begin
  newLeft := left;
  newRight := right;

  {опорный элемент массива}
  pivot := inputArray[(left + right) div 2];

  repeat
    while inputArray[newLeft] < pivot do
      newLeft := newLeft + 1;

    while inputArray[newRight] > pivot do
      newRight := newRight - 1;

    if newLeft <= newRight then
    begin
      {обмен значений}
      temp := inputArray[newLeft];
      inputArray[newLeft] := inputArray[newRight];
      inputArray[newRight] := temp;
      Timer:=Timer + 1;
      newLeft := newLeft + 1;
      newRight := newRight - 1;
    end;
  until newLeft > newRight;

  {рекурсивный вызов сортировки для "меньших" элементов}
  if left < newRight then
    QuickSort(left, newRight);

  {сортировка - для "больших" элементов}
  if newLeft < right then
    QuickSort(newLeft, right);
end;

begin
  randomize;
  writeln ('Исходный массив: ');
  {заполнение массива случайными числами}
  for i := 1 to arrayLength do
  begin
    inputArray[i] := random(100);
    write (inputArray[i]:4);
  end;
  writeln;

  QuickSort(1, arrayLength);

  writeln ('Отсортированный массив: ');
  for i := 1 to arrayLength do
    write (inputArray[i]:4);
  writeln;
  writeln('Количество перестановок ', Timer);
  readln;
end.
