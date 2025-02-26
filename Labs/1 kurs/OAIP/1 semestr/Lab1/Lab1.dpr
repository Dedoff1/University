program Lab1;
// Use app
{$APPTYPE CONSOLE}

{$R *.res}

uses
  System.SysUtils;

{For a given function f, calculate its value
 for n = 10, 11..15 and x = 0.6, 0.7..1.1}



// Constant declaration section
Const
  NStart=10;
  NFinish=15;
  XFinish=1.1;

// Declare vars
Var
  N : integer;
  F, Sum, Num, Den, XStart : real;
  {N � argument of function;
  F � function value;
  Sum � the sum of a series of numbers for n;
  Num � numerator value;
  Den � denominator value}

Begin
   XStart :=0.6;
  // Start of cycle A1 (XStart to XFinish in step
  // 0.1)
  While XStart <= XFinish do
  Begin

    // Initialization start value of Sum
    Sum := 0;

    // Start of cycle A2 (N to NFinish in step 1)
    For N := 1 to NFinish do
    Begin

      // Find Num, Den & Sum for N (1 - NFinish)
      Num := cos(sqrt(N*XStart));
      Den := exp(ln(sqr(N)-1/3)/3);
      Sum := Sum + (Num/Den);

      // Find value of F for N (NStart - NFinish)
      If N >= NStart then
      Begin
        F := Sum + N*exp(XStart);

        // Displaying values XStart, N, F
        Write('X = ',XStart:4:1,'   N = ',N);
        Writeln('   F = ',F:9:5);
      End;

    // End of cycle A2
    End;
    Writeln('');

    // Increment XStart
    XStart := XStart + 0.1;

  // End of cycle A1
  End;
  Readln;
End.

