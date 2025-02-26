Program Lab31;
{
For a given infinite function calculate its value for x ranging from 0.1 to 0.9 with a step of 0.1 and with
  given precisions using the cycle "Repeat...Until"
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
  x, y, y0, delta: real;
  reach: boolean;

  // res1 - first array of results
  // res2 - second array of results
  // k1 - first array of ks
  // k2 - second array of ks
  // x - variable x
  // y0 - previous function value
  // y - function value sum
  // up - numerator of the fraction
  // delta - delta for precised calculation
  // k - counter for sum
  // i - indicator for output
  // reach - needed accuracy reach tracker

Begin

  // initialise x
  x := xStart;

  // initialise i
  i := 1;

  // Start of Cycle A (x 0.1 to 0.9 in 0.1)
  while x <= xFinish do
  begin

    // reset y, y0, k
    y := 0;
    y0 := 0;
    k := 1;

    // initialise delta
    delta := acc1 + 1;

    // initialize up

    //initialise reach
    reach := false;

    // start of Cycle A1 (up to the specified accura-cy)
    repeat

      // save the previous value of y
      y0 := y;

      // calculate the formula
      y := y + ((exp(ln(x)*2 * k+1) * exp(ln(-1) * k)) / (k * ( k + 1) * (k + 2)));

      // upgrade the numerator

      // calculate delta
      delta := y - y0;

      // check for previous results and
      // save the current

      If not reach and (delta <= acc1) then
      begin
        res1[i] := y;
        k1[i] := k;
        reach := True;
      end;

      // increment k
      k := k + 1;

    until abs(delta) <= acc2;
    // end of cycle A1

    //save values of second type
    res2[i] := y;
    k2[i] := k;
    reach := True;

    x := x + xStep;
    i := i + 1;

    // end of Cycle A
  end;

  writeln('��� �������� � 10^-7');
  for i := 1 to 9 do
    writeln('x = 0.', i, '; y = ', res1[i]:12:10, '; k				    = ', k1[i], ';');
  writeln;

  writeln('��� �������� � 10^-12');
  for i := 1 to 9 do
    writeln('x = 0.', i, '; y = ', res2[i]:12:10, '; k = ', k2[i], ';');

  readln;

End.

