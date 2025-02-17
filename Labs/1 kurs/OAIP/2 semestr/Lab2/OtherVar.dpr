program OtherVar;

{$APPTYPE CONSOLE}

{$R *.res}

uses
  System.SysUtils;

{
  Conduct a comparative analysis of quick sorting
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
  Table = Record
    FillingMethod: byte;
    count, NExpBuble, NExpQuick: Integer;
    NTeorBuble, NTeorQuick: real;
  end;

  Res = Array [0 .. 17] of Table;

var
  Flag: byte;
  Arr: array of Integer;
  Info: Res;
  j: Integer;
  {
    Flag - a variable for the user to select the output of
    the array
    Arr - array for  sorting
    Info - information about sorting
  }

  // Procedure for swapping two elements using the third
procedure swap(var x, y: Integer);
var
  tmp: Integer;
  // tmp - saving the value
begin
  tmp := x;
  x := y;
  y := tmp;
end;

// Procedure for creating an array
procedure GenerateArray(var x: array of Integer; const i: Integer;
  const Method: byte);
var
  j: Integer;
  // j - counter for the loop

begin
  // Depending on the user's choice, the array is filled
  // with the necessary elements
  for j := 0 to i - 1 do
    case Method of
      1:
        x[j] := random(10000);
      2:
        x[j] := j;
      3:
        x[j] := i - 1 - j;
    end;

end;

// Output of array values
procedure outputArray(const x: array of Integer; const i: Integer);
var
  j: Integer;
  // j - counter for output of values

begin
  for j := 0 to i - 1 do
    write(x[j], ' ');
end;


procedure BubleSort(Arr: array of Integer;
                     const i :integer;var ChangeCount:integer) ;
var j,k:integer;
begin
ChangeCount:=0;
for k:=0 to i-2 do
for j:=0 to i-2 do
if Arr[j]>Arr[j+1] then
 begin
  inc(ChangeCount);
  swap(Arr[j],Arr[j+1]);
 end;
//for j:=0 to i-1 do
end;
// Procedure for performing quick sorting
procedure QuickSort(Arr: array of Integer; high: Integer; const Flag: byte;
  var changeCount: Integer);
var
  Pivot, i, j, stlast, low: Integer;
  Stack: Array [1 .. 13, 1 .. 2] of Integer;
  // define the stack for storing subarray indices
begin
  low := 1;
  changeCount := 0;
  stlast := 2;

  Stack[1, 1] := low;
  // initialize the stack with the indices of the initial subarray
  Stack[1, 2] := high;

  // loop until the stack is empty
  while stlast <> 1 do
  begin
    low := Stack[stlast - 1, 1];
    // get the indices of the subarray at the top of the stack
    high := Stack[stlast - 1, 2];

    stlast := stlast - 1; // pop the top element off the stack

    if Low < High then
    // if the subarray has more than one element, partition it
    begin
      Pivot := (Low + High) div 2; // choose a pivot ele-ment

      i := Low;
      j := High;

      // loop until the indices cross
      while i < j do
      begin
        while (Arr[i] <= Arr[Pivot]) and (i <= High) do
        // move the left pointer until it points to an ele-ment greater than the pivot
          Inc(i);

        while Arr[j] > Arr[Pivot] do
        // move the right pointer until it points to an el-ement smaller than or equal to the pivot
          Dec(j);

        if i < j then
        // if the pointers have not crossed, swap the ele-ments they point to
        begin
          swap(Arr[i], Arr[j]); // swap the elements
          Inc(changeCount); // increment the comparison counter
        end;
      end;

      // swap the pivot element with the element at the right pointer
      swap(Arr[Pivot], Arr[j]);

      // push the indices of the left and right subarrays onto the stack
      Stack[stlast][1] := Low;
      Stack[stlast, 2] := j - 1;
      stlast := stlast + 1;

      Stack[stlast][1] := j + 1;
      Stack[stlast, 2] := high;
      stlast := stlast + 1;
    end;
  end;

  // output the resulting array if the user wants it
  if Flag = 1 then
    outputArray(Arr, high);
end;

begin
  for j := 0 to 17 do
  begin
    Arr := 0;
    case j mod 3 of
      0:
        Info[j].FillingMethod := 3;
      1:
        Info[j].FillingMethod := 1;
      2:
        Info[j].FillingMethod := 2;
    end;

    case j div 3 of
      0:
        Info[j].count := 100;
      1:
        Info[j].count := 250;
      2:
        Info[j].count := 500;
      3:
        Info[j].count := 1000;
      4:
        Info[j].count := 2000;
      5:
        Info[j].count := 3000;
    end;
    // Setting the array length and generating it
    SetLength(Arr, Info[j].count);
    GenerateArray(Arr, Info[j].count, Info[j].FillingMethod);

    // Calculation of theoretical values of comparisons
    case Info[j].FillingMethod of
      1:
        begin
          Info[j].NTeorQuick := (Info[j].count - 1) * ln(Info[j].count)
            / ln(2);
          Info[j].NTeorBuble := Info[j].count * (Info[j].count) / 4;
        end;
      2:
        begin
          Info[j].NTeorQuick := 0;
          Info[j].NTeorBuble := 0;
        end;
      3:
        begin
          Info[j].NTeorQuick := (Info[j].count - 1) * ln(Info[j].count)
            / ln(2);
          Info[j].NTeorBuble := Info[j].count * (Info[j].count - 1) / 2;

        end;
    end;

    // Implementation of sorting
    writeln('|          |                |                      |                   |                        |');
    QuickSort(Arr, Info[j].count, Flag, Info[j].NExpQuick);
    BubleSort(Arr, Info[j].count, Info[j].NExpBuble);
    writeln('| N = ', Info[j].count:4, ' | QSort Exp: ', Info[j].NExpQuick:4,
      '| QSort Theor: ', Info[j].NTeorQuick:8:2, '| BubleSort Exp: ',
      Info[j].NExpBuble:7, '| BubleSort Theor: ', Info[j].NTeorBuble:10:2, '|');
    writeln('|__________|________________|______________________|___________________|________________________|');
    // writeln('| N = 3000 | QSort Exp:    0| QSort Theor:     0.00| BubleSort Exp:       0| BubleSort Theor:       0.00|');
  end;
  Readln;

end.


