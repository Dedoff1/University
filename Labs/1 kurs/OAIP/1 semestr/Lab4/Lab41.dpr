Program Lab41;
{
 The program finds the numbers of duplicate
 elements with the same value, outputs their
 value, the number of duplicate elements with
 the same value and the maximum value of the
 duplicate elements.
}

// Determining the type of console program.
{$APPTYPE CONSOLE}

// Setting the name of the module.
uses
  System.SysUtils;

// Assign certain data types to variables.
Var
  M, N, Max: integer;
  I, J, K: integer;
  Arr: array of integer;
  Flag, IsRepetition: boolean;
  {
   N - the number of duplicate elements with
   the same value;
   Max - maximum value of duplicate elements;
   I, J, K - variables for iterating over
   elements in an array;
   Arr - array with elements;
   Flag, IsRepetition - logical variables.
  }

Begin
  Repeat

    // Request to enter the values of the main
    // variables and check for correctness.
    Try
      write('������� ���������� ��������� ������������������: ');
      readln(M);
      while (M < 1) or (M > 1000000) do
        writeln('���������� ��������� ����� ���� � ������� �� 1 �� 1.000.000!');
      SetLength(Arr, M);
      writeln('������� �������� ������������������:');

      // Entering values of array elements.
      For I := 1 to M do
      begin
        write('������� ', I,'-� ������� ������������������: ');
        read(Arr[i]);
      end;
      readln;

      // Except for repetition.
      Flag := True;
    Except

      // When entering different characters,
      // the warning announcement.
      writeln('_______________________________________________');
      writeln;
      writeln('�� ����� ������������ ������!');
      writeln('�������� ��������� ������������������ ����� ���� ������ �����!');
      writeln('_______________________________________________');
      writeln;

      // Transition to repetition.
      Flag := False;
    End;
  Until Flag;

  writeln('________________________________________________');
  writeln;
  IsRepetition := True;

  // Cycle A1. Iterating through the array elements.
  For I := 1 to M do
  begin

    // Initialization of variables.
    Flag := True;
    N := 1;

    // Cycle A2. Checking for repetitions up
    // to a certain element.
    For J := 1 to (I-1) do

      // If there is a repetition up to a certain
      // element, assigning a false value to a
      // logical variable so that the value is
      // not compared in the future.
      If (Arr[I] = Arr[I-J]) then
        Flag := False;

    // If there is no repetition, we enter the
    // loop to search for duplicate elements
    // after this element.
    If Flag then
    begin

      // Cycle A3. Iterating through the auxiliary
      // variable to find duplicate elements.
      For K := 1  to (M-1) do
      begin

        // If there is a repeating element, the
        // branching operator is entered.
        If (Arr[I] = Arr[I+K]) and (I+K <= M) then
        begin

          // Increasing the value of the number of
          // duplicate elements with the same value.
          N:=N+1;

          // Output the number of an element with
          // a duplicate value.
          If Flag then
          begin
            write(I, '-�');
            Flag := False;
          end;
          write(', ', I+K, '-�');
        end;

       // End of cycle A3.
      end;
    end;

    // Output of required variables.
    If (N>1) then
    begin
      writeln(' �������� ����� ���������� ��������.');
      writeln(Arr[I],' - �������� ������������� ���������.');
      writeln(N, ' - ���������� ��������� � ���������� ���������.');
      writeln('________________________________________________');
      writeln;

      // Search for the maximum value from
      // duplicate elements.
      If Max < Arr[I] then
        Max := Arr[I];
      IsRepetition := False;
    end;

  // End of cycle A1.
  end;

  // If no duplicate elements are found,
  // then enter the branching operator.
  If IsRepetition then
    writeln('������������� ��������� �� �������.')


// Otherwise, an additional value of
  // the variable is output.
  Else
    writeln(Max, ' - �������� ������������� �������������� ��������.');

  readln;
End.
