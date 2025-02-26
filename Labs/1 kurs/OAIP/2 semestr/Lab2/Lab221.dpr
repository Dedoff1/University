program Lab221;

{$APPTYPE CONSOLE}

{$R *.res}

uses
  System.SysUtils;

{
  Conduct a comparative analysis of pyramidal sorting
  and sorting by inserts according to the number
  of comparisons.
  The dimension of the array and its type are entered by
  the user.
  Develop a data structure for storing calculation
  results.
}

// Determining the Console Program Type
{$APPTYPE CONSOLE}



type
  Mas=array of integer;
  Table = Record
    FillingMethod: byte;
    CompareCount, NExpBuble, NExpQuick : Integer;
    NTeorBuble, NTeorQuick: real;
  end;
  Res = Array[1..18] of Table;

var
  Flag: byte;
  Arr: Mas;
  Info: Res;
  j: integer;
{
  Flag - a variable for the user to select the output of
         the array
  Arr1 - array for pyramid sorting
  Arr2 - array for sorting by inserts
  Info - information about sorting
}


// Procedure for swapping two elements using the third
procedure swap(var x, y:integer);
var
  tmp: integer;
// tmp - saving the value
begin
  tmp := x;
  x := y;
  y := tmp;
end;

// Procedure for creating an array
procedure GenerateArray(var x: array of integer; const
                        i: integer; const Method: byte);
var
  j: integer;
// j - counter for the loop

begin
  // Depending on the user's choice, the array is filled
  // with the necessary elements
  for j := 0 to i-1 do
    case Method of
    1:
      x[j] := random(10000);
    2:
      x[j] := j;
    3:
      x[j] := i-1-j;
    end;

end;

// Output of array values
procedure outputArray(const x: array of integer;
                      const i: integer);
var
  j: integer;
// j - counter for output of values

begin
  for j := 0 to i-1 do
    write(x[j], ' ');
end;

// Procedure for sifting

 procedure BubleSort(const a:Mas;
                     const i :integer;var CompareCount:integer) ;
var j,k,x:integer;
begin
CompareCount:=0;
for k:=0 to i-2 do
for j:=0 to i-2 do
if a[j]>a[j+1] then
 begin
  inc(CompareCount);
  swap(a[j],a[j+1]);
 end;
for j:=0 to i-1 do
end;


procedure QuickSort(const a: Mas; left, right: integer; var CompareCount:integer) ;
var
  newLeft, newRight : integer; //������� �������
  temp, pivot : integer;
begin
  newLeft := left;
  newRight := right;
  CompareCount:=0;
  {������� ������� �������}
  pivot := A[(left + right) div 2];

  repeat
    while a[newLeft] < pivot do
      newLeft := newLeft + 1;

    while a[newRight] > pivot do
      newRight := newRight - 1;

    if newLeft <= newRight then
    begin
      {����� ��������}
      swap(newLeft,newRight);
      inc(CompareCount);
      newLeft := newLeft + 1;
      newRight := newRight - 1;
    end;
  until newLeft > newRight;

  {����������� ����� ���������� ��� "�������" ���������}
  if left < newRight then
    QuickSort(a,left, newRight,CompareCount);

  {���������� - ��� "�������" ���������}
  if newLeft < right then
    QuickSort(a,newLeft, right,CompareCount);
end;

begin
  for j := 1 to 18 do
  begin
    Arr := 0;

    case j mod 3 of
    0:
      info[j].FillingMethod := 3;
    1:
      info[j].FillingMethod := 1;
    2:
      info[j].FillingMethod := 2;
    end;

    case j div 3 of
    0:
      info[j].CompareCount := 100;
    1:
      info[j].CompareCount := 250;
    2:
      info[j].CompareCount := 500;
    3:
      info[j].CompareCount := 1000;
    4:
      info[j].CompareCount := 2000;
    5:
      info[j].CompareCount := 3000;
    6:
      info[j].CompareCount := 3000;
    end;
  // Setting the array length and generating it
    SetLength(Arr, Info[j].CompareCount);
    GenerateArray(Arr, Info[j].CompareCount,
                  Info[j].FillingMethod);

    // Calculation of theoretical values of compari-sons
    case Info[j].FillingMethod of
      1:
      begin
        Info[j].NTeorQuick := 3*(Info[j].CompareCount
                             *Info[j].CompareCount - Info[j].CompareCount)/2;
        Info[j].NTeorBuble := 3*(Info[j].CompareCount
                             *Info[j].CompareCount - Info[j].CompareCount)/2;
      end;
      2:
      begin
        Info[j].NTeorQuick := 0;
        Info[j].NTeorBuble := 0;
      end;
      3:
      begin
        Info[j].NTeorQuick := 3*(Info[j].CompareCount
                             *Info[j].CompareCount - Info[j].CompareCount)/4;
        Info[j].NTeorBuble := Info[j].CompareCount * (Info[j].CompareCount - 1)/2;
      end;
    end;

    // Implementation of sorting
    QuickSort(Arr, Info[j].CompareCount, 1, info[j].NExpQuick);
    BubleSort(Arr, Info[j].Comparecount, Info[j].NExpBuble);
    WriteLn('N = ', Info[j].CompareCount,' ����� ����: ', Info[j].NExpQuick,' ����� ����: ', Info[j].NTeorQuick:5:2, ' ������� ����: '  , Info[j].NExpBuble, ' ������� ����: ', Info[j].NTeorBuble:5:2);
  end;
  Readln;
end.

