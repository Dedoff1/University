program Sor;
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

uses
  System.SysUtils;

type
  Table = Record
    FillingMethod: byte;
    count, NExpIns, NExpHeap : Integer;
    NTeorIns, NTeorHeap: real;
  end;
  Res = Array[1..18] of Table;

var
  Flag: byte;
  Arr: array of Integer;
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
procedure siftDown(var Tree: array of integer;
                   const nodeStart, nodeLast:integer;
                   var compareCount: integer);
var
  isSifted: boolean;
  child, node: integer;
{
  isSifted - a logical variable for completing the
             algorithm
  child - index of the considered "child"
  node - index of the considered "parent"
}

begin
  isSifted := false;
  node := nodeStart;

  // Cycle for moving an element to its place in the tree
  while (not isSifted) and (2*node <= nodeLast) do
  begin

    // Getting the index of one child for a parent
    child := 2*node;

    // Checking the existence of a second child
    if (child + 1 <= nodeLast) then
    begin

      // Increasing the comparison operation counter
      Inc(compareCount);

      // Selecting the index of the child with the
      // highest values
      if (Tree[child + 1] > Tree[child]) then
        child := child + 1;
    end;
    Inc(compareCount);

    // Permutation of two elements if they do not satisfy
    // Max Heap
    if Tree[child] > Tree[node] then
    begin
      swap(Tree[node], Tree[child]);
      node := child;
    end
    else
      isSifted := true;
  end;
end;

// Procedure for sorting inserts
procedure insertionSort (arr: array of integer; const n:
                         integer; const flag: byte; var
                         compareCount: integer);
var
  i, j, tmp: integer;
{
  i, j - cycle counters
  tmp - saving the rearranged element
}

begin

  // Initializing the initial values
  i := 1;
  compareCount := 0;

  // Loop to pass through all elements of the array
  while i <= n-1 do
  begin

    // Initializing variables for the internal loop
    tmp := arr[i];
    j := i - 1;

    // Loop to select the location of the current element
    while (j >= 0) and (arr[j] > tmp) do
    begin
      arr[j+1] := arr[j];
      Dec(j);
      Inc(compareCount);
    end;

    // Inserting an element to the desired position
    arr[j+1] := tmp;
    Inc(i);

    // Increase the value of the comparison operations
    // counter if the element does not come first
    // (when the element comes first, j is equal to -1
    // and the comparison of elements does not occur
    if j >= 0 then
      Inc(compareCount);
  end;

  // Output the resulting array if the user wants it
  if Flag = 1 then
    outputArray(arr, n);
end;

// Procedure for performing pyramid sorting
Procedure heapSort(arr: array of integer; const
                   count: integer; const flag:byte;
                   var compareCount: integer);
var
  nodeCurr, nodeLast:integer;
{
  nodeCurr is the current element in the tree
  nodeLast - the last element of the tree
}

begin

  // Initializing initial values
  compareCount := 0;
  nodeCurr := count div 2;

  // Loop for the initial bringing of the tree to the
  // Max Heap state
  while nodeCurr >= 0 do
  begin
    siftDown(arr, nodeCurr, count, compareCount);
    dec(nodeCurr);
  end;
  nodeLast := count;

  // Cycle for for final sorting
  // 1. We put the largest element in the last place
  // 2. Reduce the number of unsorted elements
  // 3. Sift the resulting tree by the zero element
  while nodeLast > 0 do
  begin
    swap(arr[0], arr[nodeLast]);
    dec(nodeLast);
    siftDown(arr, 0, nodeLast, compareCount);
  end;

  // Output the resulting array if the user wants it
  if Flag = 1 then
    outputArray(arr, count);
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
      info[j].count := 100;
    1:
      info[j].count := 250;
    2:
      info[j].count := 500;
    3:
      info[j].count := 1000;
    4:
      info[j].count := 2000;
    5:
      info[j].count := 3000;
    6:
      info[j].count := 3000;
    end;
  // Setting the array length and generating it
    SetLength(Arr, Info[j].count);
    GenerateArray(Arr, Info[j].count,
                  Info[j].FillingMethod);

    // Calculation of theoretical values of comparisons
    case Info[j].FillingMethod of
      1:
      begin
        Info[j].NTeorHeap := 2*Info[j].count
                             *ln(Info[j].count)/ln(2);
        Info[j].NTeorIns := sqr(Info[j].count)/4;
      end;
      2:
      begin
        Info[j].NTeorHeap := Info[j].count
                             *ln(Info[j].count)/ln(2);
        Info[j].NTeorIns := Info[j].count - 1;
      end;
      3:
      begin
        Info[j].NTeorHeap := 3*Info[j].count
                             *ln(Info[j].count)/ln(2);
        Info[j].NTeorIns := sqr(Info[j].count)/4;
      end;
    end;

    // Implementation of sorting
    heapSort(Arr, Info[j].count, Flag,
             info[j].NExpHeap);
    insertionSort(Arr, Info[j].count, Flag,
                  Info[j].NExpIns);
WriteLn('N = ', Info[j].count,' Пир эксп: ',
         Info[j].NExpHeap,' Пир вст: ',
         Info[j].NTeorHeap:5:2,
        ' Вст эксп: '  , Info[j].NExpIns, ' Вст теор: ',
         Info[j].NTeorIns:5:2);
  end;
  Readln;
end.

