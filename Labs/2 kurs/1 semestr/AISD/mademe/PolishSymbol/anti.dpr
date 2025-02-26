program anti;

{$APPTYPE CONSOLE}

{$R *.res}

uses
  System.SysUtils,System.Generics.Collections;

function ConvertPostfixToInfix(const APostfixExpression: string): string;
var
  Stack: TStack<string>;
  i: Integer;
  Token, LeftOperand, RightOperand: string;
begin
  Stack := TStack<string>.Create;
  try
    for i := 1 to Length(APostfixExpression) do
    begin
      Token := APostfixExpression[i];
      if Token = ' ' then
        Continue;
      if (Token >= 'A') and (Token <= 'z') then
      begin
        Stack.Push(Token);
      end
      else
      begin
        RightOperand := Stack.Pop();
        LeftOperand := Stack.Pop();

        Stack.Push('(' + LeftOperand + Token + RightOperand + ')');
      end;
    end;

    Result := Stack.Pop();
  finally
    Stack.Free;
  end;
end;

var
  PostfixExpression, InfixExpression: string;
begin
  readln(postfixexpression);
  InfixExpression := ConvertPostfixToInfix(PostfixExpression);
  Writeln(InfixExpression); // (3+4)*2
  readln(postfixexpression);
end.
```
