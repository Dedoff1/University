program anti2;

{$APPTYPE CONSOLE}

{$R *.res}

uses
  SysUtils, StrUtils, System.Types;

type
  TStack = record
    Data: array of string;
    Top: Integer;
  end;

procedure InitStack(var S: TStack);
begin
  SetLength(S.Data, 100);
  S.Top := -1;
end;

procedure Push(var S: TStack; const Value: string);
begin
  Inc(S.Top);
  S.Data[S.Top] := Value;
end;

function Pop(var S: TStack): string;
begin
  Result := S.Data[S.Top];
  Dec(S.Top);
end;

function IsOperator(const S: string): Boolean;
begin
  Result := (S = '+') or (S = '-') or (S = '*') or (S = '/');
end;

function PolishToInfix(const PolishExpr: string): string;
var
  S: TStack;
  Tokens: TStringDynArray;
  Token: string;
begin
  InitStack(S);
  Tokens := SplitString(PolishExpr, ' ');
  for Token in Tokens do
  begin
    if IsOperator(Token) then
    begin
      // Pop two operands and push them back in infix form
      Result := '(' + Pop(S) + ' ' + Token + ' ' + Pop(S) + ')';
      Push(S, Result);
    end
    else
    begin
      // Push operand onto the stack
      Push(S, Token);
    end;
  end;
  Result := Pop(S);
end;

var
  PolishExpr, InfixExpr: string;
begin
  Write('Введите выражение в польской записи: ');
  ReadLn(PolishExpr);
  InfixExpr := PolishToInfix(PolishExpr);
  WriteLn('Выражение в стандартной записи: ', InfixExpr);
  readln(polishexpr);
end.


