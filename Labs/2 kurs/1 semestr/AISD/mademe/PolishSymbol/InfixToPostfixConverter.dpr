﻿program InfixToPostfixConverter;

{$APPTYPE CONSOLE}

uses
  System.SysUtils,
  System.Generics.Collections;

type
  TExpressionWithRank = record
    ExpressionRank: integer;
    Expression: string;
  end;

var
  ExpressionWithRank: TExpressionWithRank;
  InputExpression: string;

function GetPrecedence(ASymbol: char): Integer;
begin
  case ASymbol of
    'A'..'Z', 'a'..'z', '0'..'9':
      Result := 7;
    '+', '-':
      Result := 1;
    '*', '/':
      Result := 3;
    '^':
      Result := 6;
    '(':
      Result := 9;
    ')':
      Result := 0;
    else
      Result := -1;
  end;
end;

function GetStackPrecedence(ASymbol: char): Integer;
begin
  case ASymbol of
    'A'..'Z', 'a'..'z', '0'..'9':
      Result := 8;
    '+', '-':
      Result := 2;
    '*', '/':
      Result := 4;
    '^':
      Result := 5;
    '(':
      Result := 0;
    else
      Result := -1;
  end;
end;

function GetSymbolRank(ASymbol: char): Integer;
begin
  case ASymbol of
    '+', '-', '*', '/', '^':
      Result := -1;
    'A'..'Z', 'a'..'z', '0'..'9':
      Result := 1;
    else
      Result := 0;
  end;
end;

function ConverInfixToPostfix(const AExpression: string): TExpressionWithRank;
var
  Stack: TStack<Char>;
  I, Precedence: Integer;
begin
  Result.Expression:= '';
  Stack:= TStack<Char>.Create;
  Result.ExpressionRank:= 0;

  for I := 1 to High(AExpression) do
  begin
    Precedence:= GetPrecedence(AExpression[i]);

    // If the scanned character is an open bracket, push it to the stack
    if Precedence = 9 then
    begin
      Stack.Push(AExpression[i]);
      Result.Expression := Result.Expression + '(';
    end
    // If the character is an operand, add it to output
    else if Precedence = 7 then
    begin
  		Result.Expression := Result.Expression + AExpression[i];
      Inc(Result.ExpressionRank, GetSymbolRank(AExpression[i]));
    end

    // If the scanned character is an
    // close bracket, pop and add to output from the stack
    // until an open bracket is encountered
    else if Precedence = 0 then
    begin
      while (Stack.Count <> 0) and (GetStackPrecedence(Stack.Peek) <> 0) do
      begin
        Result.Expression := Result.Expression + Stack.Peek;
        Result.ExpressionRank := Result.ExpressionRank + GetSymbolRank(Stack.Peek);
        Stack.Pop;
      end;
      Result.Expression := Result.Expression + ')';
      // Remove open bracket from the stack
      Stack.Pop;
    end

    else
    begin
      while ((Stack.Count <> 0) and (GetPrecedence(AExpression[i]) <= GetStackPrecedence(Stack.Peek))) do
      begin
        Result.ExpressionRank := Result.ExpressionRank + GetSymbolRank(Stack.Peek);
        Result.Expression := Result.Expression + Stack.Peek;
        Stack.Pop;
      end;
      Stack.Push(AExpression[i]);
    end;
  end;

  while not (Stack.Count = 0) do
  begin
    Result.ExpressionRank := Result.ExpressionRank + GetSymbolRank(Stack.Peek);
    Result.Expression := Result.Expression + Stack.Peek;
    Stack.Pop;
  end;

  Stack.Destroy;
end;


begin
  Writeln('Input an expression to convert it from infix form to postfix form (reversed polish notation) and count its rank:');
  Readln(InputExpression);

  ExpressionWithRank:= ConverInfixToPostfix(InputExpression);

  Writeln('Postfix form: ', ExpressionWithRank.Expression);
  Writeln('Expression rank: ', ExpressionWithRank.ExpressionRank);
  if ExpressionWithRank.ExpressionRank = 1 then
    Writeln('Expression is accurate')
  else
    Writeln('Expression is inaccurate');

  Readln;
end.
