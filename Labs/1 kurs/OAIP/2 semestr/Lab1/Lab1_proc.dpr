Program Lab_1_proc_inter;
{
  Create a program that calculates matrix expressions. Find
  the value of a given matrix expression using subprograms
  that do not use global parameters.
}

// Determining the Console Program Type
{$APPTYPE CONSOLE}


// Determining the type for matrixes
Type
  TMatrix = Array [1..3,1..3] of Real;

// Declaring the initial matrixes used in the expression
Const
  A:TMatrix=((1,2,3),(4,-2,1),(0,1,-1));
  B:TMatrix=((2,3,-1),(-2,0,-1),(1,0,1));

// Variable declaration section
Var
  Temp1,Temp2,Temp3,Temp4,Temp5:TMatrix;
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
  g:integer;
  i:integer ;
  j:integer ;
  k: integer absolute g;
{
  i,j � counter variables;
  k � sign variable.
}

Begin
  // Determining the coefficient value
  If Sign then
    k:=1
  Else
    g:=-1;
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
                           Var Res:TMAtrix);

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
  Writeln('Matrix A');
  OutputMat(A);
  Writeln('Matrix B');
  OutputMat(B);





















// Multiplying the � matrix by 3



  Writeln('3*A');
MultiplyMatConst(3,A,Temp1);


  OutputMat(Temp1);

// Subtracting B matrix from Temp1

  Writeln('(3*A - B)');
  SumMat(Temp1,B,False,Temp1);
  OutputMat(Temp1);

  // Multiplying the B matrix by 2
  Writeln('2*B');
  MultiplyMatConst(2,B,Temp2);
  OutputMat(Temp2);

  // Adding the Temp2 matrix to A matrix
   Writeln('A + 2*B');
  SumMat(A,Temp2,True,Temp2);
  OutputMat(Temp2);

// Multiplying Temp1 and Temp2 matrixes

  Writeln('(A + 2*B)*(3*A - B)');
  MultiplyMat(Temp2,Temp1,Temp3);


  OutputMat(Temp3);
  Readln
End.

