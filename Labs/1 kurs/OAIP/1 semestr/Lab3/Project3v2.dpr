Program Project3v2;
{
  For a given infinite function calculate its value fox
  ranging from 0.1 to 0.9 with a step of 0.1 and with
  given precisions using the cycle "While"

}

// use app
{$APPTYPE CONSOLE}
{$R *.res}

// use SysUtils
uses
  System.SysUtils;

// declare consts
const
  acc1 = 1E-5;
  acc2 = 1E-6;
  xStart = 0.1;
  xFinish = 0.9;
  xStep = 0.1;

  // xStart - start value of X
  // xFinish - finish value of X
  // xStep - step for incrementing X
  // acc1 - the first precision for calculating
  // acc2 - the second precision for calculating

Var
  res1: array [1 .. 9] of real;
  k1: array [1 .. 9] of integer;
  res2: array [1 .. 9] of real;
  k2: array [1 .. 9] of integer;

  i, k: integer;
  x, y, up, sum: real;
  reach: boolean;

  // res1 - first array of results
  // res2 - second array of results
  // k1 - first array of ks
  // k2 - second array of ks
  // x - variable x
  // y - function value sum
  // up - numerator of the fraction
  // delta - delta for precised calculation
  // k - counter for sum
  // i - indicator for output
  // reach - needed accuracy reach tracker

Begin

  x := xStart;
  // initialise i
  i := 1;

  // Start of Cycle A (x 0.1 to 0.9 in 0.1)
  while x <= xFinish do
  begin

    // reset y, k, sum
    k := 1;
    sum := 0;

    // initialise y
    y := acc1 + 1;
    // initialize up
    up := -x;

    // initialise reach
    reach := false;

    // Start of Cycle A1
    while abs(y) > acc2 do
    begin


      // calculate the formula
      y := up / (k * (k + 1) * (k + 2));

      // upgrade the numerator
      up := up * x * (-x);

      // calculate sum
      sum := sum + y;

      // check for previous results and
      // save the current

      If not reach and (abs(y) <= acc1) then
      begin
        res1[i] := sum;
        k1[i] := k;
        reach := True;
      end;

      // increment k
      k := k + 1;

    end;
    // end of cycle A1

    // save values of second type
    res2[i] := sum;
    k2[i] := k;

    // increment x
    x := x + xStep;

    // increment i
    i := i + 1;

    // end of Cycle A
  end;

  writeln('��� �������� � 10^-5');
  for i := 1 to 9 do
    writeln('x = 0.', i, '; y = ', res1[i]:12:10, '; k = ', k1[i], ';');
  writeln;

  writeln('��� �������� � 10^-6');
  for i := 1 to 9 do
    writeln('x = 0.', i, '; y = ', res2[i]:12:10, '; k = ', k2[i], ';');

  readln;

end.

