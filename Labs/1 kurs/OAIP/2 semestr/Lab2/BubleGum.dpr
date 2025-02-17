program BubleGum;

{$APPTYPE CONSOLE}

{$R *.res}

uses
  System.SysUtils;

const
  arrayLength = 100;
var
  inputArray : array [1..arrayLength] of integer;
  i, j, tempValue, Timer: integer;
begin
  Timer:=0;
  randomize;
  writeln ('Исходный массив: ');
  {заполнение массива случайными числами}
  for i := 1 to arrayLength do
  begin
    inputArray[i] := random(100);
    write (inputArray[i]:4);
  end;
  writeln;

  {пузырьковая сортировка}
  for i := 1 to arrayLength-1 do
    for j := 1 to arrayLength-i do
      if inputArray[j] > inputArray[j+1] then
        begin
          {обмен элементов}
          tempValue := inputArray[j];
          inputArray[j] := inputArray[j+1];
          inputArray[j+1] := tempValue;
          Timer:=Timer + 1;
        end;

  writeln ('Отсортированный массив: ');
  for i := 1 to arrayLength do
    write (inputArray[i]:4);
    writeln;
    writeln('Количество перестановок ', Timer);
  readln;
end.
