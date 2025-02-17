Program Lab1_proc_vvodruch;

// Determining the Console Program Type
{$APPTYPE CONSOLE}



uses
  System.SysUtils;

{
  Create a program that calculates matrix expressions. Find
  the value of a given matrix expression using subprograms
  that do not use global parameters.
}


//   ((2*A)+B)*B-(0.5*A)
const nmax  =20;

// Determining the type for matrixes
Type
  TMatrix = Array [1..nmax,1..nmax] of Real;

// Declaring the initial matrixes used in the expression


// Variable declaration section
Var
  A,B,Temp1,Temp2,Temp3:TMatrix;
  str,st,i,j:integer;
{
  Temp1, Temp2, Temp3 - arrays that keep the value of
  intermediate calculations.
}


// Subprogram for calculating the sum of matrixes
{
  Two matrixes (X1, Y1) of the same size are given.
  The subprogram returns the matrix that is equal
  to the result of summation or subtraction of
  the given matrixes.
}
Procedure SumMat(Const X1,Y1:TMatrix;
                 Const Sign: Boolean;
                 Var Res:TMatrix);

// Variable declaration section
Var
  i,j,k:integer;

{
  i,j – counter variables;
  k – sign variable.
}

Begin
  // Determining the coefficient value
  If Sign then
    k:=1
  Else
    k:=-1;
  For i:=1 to 3 do
    For j:=1 to 3 do
      Res[i,j]:=X1[i,j]+k*Y1[i,j];
End;


// Subprogram for multiplying the matrix by a number
{
  The X1 matrix and the multiplier M1 are given. The
  subprogram returns the value of the matrix multiplied by
  a number.
}
Procedure MultiplyMatConst(Const N1:Real;
                           Const X1:TMatrix;
                           Var Res:TMatrix);

// Declaring counter variables
Var
  i,j:integer;

Begin
  For i:=1 to 3 do
    For j:=1 to 3 do
      Res[i,j]:=N1*X1[i,j];
End;


// Subprogram for multiplying the matrixes
{
  Two matrixes (X1, Y1) of the same size are given.
  The subprogram returns the matrix that is equal
  to the result of the multiplication of the matrixes.
}
Procedure MultiplyMat(Const X1,Y1:TMatrix;
                      Var Res:TMatrix);


// Declaring counter variables
Var
  i,j,l: Integer;

Begin
  For i:=1 to 3 do
    For j:=1 to 3 do
    Begin

      // Initializing the value of the matrix element
      Res[i,j]:=0;
      For l:=1 to 3 do
        Res[i,j]:=Res[i,j]+X1[i,l]*Y1[l,j];
    End;
End;


// Subprogram for outputting the matrix
{
  A matrix X1 is given. The procedure outputs the
  formatted values of the matrix elements.
}
Procedure OutputMat(Const X1:TMatrix);

// Declaring counter variables
Var
  i,j:Integer;

Begin
  For i:=1 to 3 do
  Begin
    For j:=1 to 3 do
      Write(X1[i,j]:6:1);
    Writeln
  End;
  Writeln
End;



Begin
// Outputting the initial matrixes

 repeat
 write('Количество строк Str= ');
 readln(str);
 write('Количество столбцов St= ');
 readln(st);
 until (str in [1..nmax])and(st in [1..nmax]);

  Writeln('A');
  for i:=1 to str do
  begin
   for j:=1 to st do
    begin
     write('Вводите элемент', 'A[',i,',',j,']=');
     readln(a[i,j]);

    end;
   writeln;
  end;
  OutputMat(A);
  Writeln('B');
  for i:=1 to str do
  begin
   for j:=1 to st do
    begin
     write('Вводите элемент', 'B[',i,',',j,']=');
     readln(b[i,j]);

    end;
   writeln;
  end;
  OutputMat(B);

    //   (A - B) *A + 2*B
  // Subtracting B matrix from A
  SumMat(A,B,False,Temp1);
  // Multiplying Temp1 and A matrixes
  MultiplyMat(Temp1,A,Temp2);
  // Multiplying the B matrix by 2
  MultiplyMatConst(2,B,Temp3);



  Writeln('(A + 2*B)*(3*A - B)');

  //Adding to the calculated value Temp3 matrix
  SumMat(Temp2,Temp3,True,Temp2);
  OutputMat(Temp2);
  Readln
End.

