Program Lab3;
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
  Acc1 = 1E-5;
  Acc2 = 1E-6;
  XStart = 0.1;
  XFinish = 0.9;
  XStep = 0.1;
  // XStart - start value of X
  // XFinish - finish value of X
  // XStep - step for incrementing X
  // Acc1 - the first accuracy for calculating
  // Acc2 - the second accuracy for calculating

Var
  Res1: array [1 .. 9] of real;
  Counter1: array [1 .. 9] of integer;
  Res2: array [1 .. 9] of real;
  Counter2: array [1 .. 9] of integer;

  i, k: integer;
  X, sum, Prevsum, Up, Delta: real;
  Reach: boolean;

  // Res1 - First Accuracy results
  // Res2 - Second Accuracy results
  // Counter1 - first array of ks
  // Counter2 - second array of ks
  // X - variable X
  // Prevsum - previous function value
  // Sum - function value sum
  // Up - numerator of the fraction
  // Delta - delta for precised calculation
  // k - counter for sum
  // I - indicator for output
  // Reach - needed accuracy reach tracker

Begin

  // initialise x
  X := XStart;

  // initialise i
  I := 1;

  // Start of Cycle A (x 0.1 to 0.9 in 0.1)
  While X <= XFinish do
  begin

    // reset y, y0, k
    sum := 0;
    prevsum := 0;
    k := 1;

    // initialise delta
    delta := acc1 + 1;
    // initialize up
    up := -X ;

    //initialise reach
    reach := false;

    // start of Cycle A1 (up to the specified accura-cy)
    repeat

      // save the previous value of y
      Prevsum := Sum;

      // calculate the formula
      Sum := Prevsum + Up / (K* (K + 1) * (K + 2));
      // upgrade the numerator
      Up := Up * X * (-X);

      // calculate delta
      Delta := Sum - Prevsum;

      // check for previous results and
      // save the current

      If not Reach and (abs(Delta) <= Acc1) then
      begin
        Res1[i] := Sum;
        Counter1[i] := K;
        Reach := True;
      end;

      // increment k
      K := K + 1;

    until abs(Delta) <= Acc2;
    // end of cycle A1

    //save values of second type
    Res2[i] := Sum;
    Counter2[i] := K;
    Reach := True;

    X := X + XStep;
    I := I + 1;

    // end of Cycle A
  end;

  writeln('��� �������� � 10^-5');
  for I := 1 to 9 do
    writeln('X = 0.', i, '; Y = ', Res1[i]:12:10, '; K = ', Counter1[i], ';');
  writeln;

  writeln('��� �������� � 10^-6');
  for i := 1 to 9 do
    writeln('X = 0.', i, '; Y = ', Res2[i]:12:10, '; K = ', Counter2[i], ';');

  readln;

End.

