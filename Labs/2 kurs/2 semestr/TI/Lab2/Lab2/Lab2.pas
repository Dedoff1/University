unit Lab2;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, ActnList;

type
  TArray=array [1..1000] of Boolean;
  TForm1 = class(TForm)
    lbl1: TLabel;
    lbl2: TLabel;
    mmo11: TMemo;
    lbl3: TLabel;
    edtKey: TEdit;
    lbl4: TLabel;
    mmoKey: TMemo;
    mmo12: TMemo;
    lbl5: TLabel;
    btn1: TButton;
    btn2: TButton;
    ActionList1: TActionList;
    Encryption: TAction;
    Decryption: TAction;
    StrToBits: TAction;
    BitsToStr: TAction;
    WriteBits: TAction;
    btnRead1: TButton;
    btnRead2: TButton;
    WriteBits2: TAction;
    BitToBool: TAction;
    BoolToBit: TAction;
    StrToBitStr: TAction;
    BitStrToStr: TAction;
    cbbFile: TComboBox;
    lbl6: TLabel;
    ReadFileToString: TAction;
    WriteStringToFile: TAction;
    Cheat: TAction;
    CreateInteger: TAction;
    EncString: TAction;
    WriteAdd: TAction;
    cbbTypeFile: TComboBox;
    lbl7: TLabel;
    edtFile1: TEdit;
    edtFile2: TEdit;
    dlgOpen1: TOpenDialog;
    dlgOpen2: TOpenDialog;
    Button1: TButton;
    function StrToBitsExecute(const AStr: string):TArray;
    function BitsToStrExecute(ABits:TArray;Len:Integer):string;
    function WriteBitsExecute(ABits:TArray;Len:Integer):string;
    procedure FormCreate(Sender: TObject);
    procedure btnRead1Click(Sender: TObject);
    procedure btnRead2Click(Sender: TObject);
    procedure btn1Click(Sender: TObject);
    procedure EncryptionExecute(FName1,Fname2:string;TypeUse:Integer);
    function WriteBits2Execute(ABits:TArray;Beg,Len:Integer):string;
    procedure btn2Click(Sender: TObject);
    procedure DecryptionExecute(FName1,Fname2:string);

    function BitToBoolExecute(a:Char):Boolean;
    function BoolToBitExecute(a:Boolean):char;
    function StrToBitStrExecute(a:string):string;
    function BitStrToStrExecute(ABits:string ):string;
    function ReadFileToStringExecute(const FileName: string): string;
    procedure WriteStringToFileExecute(const FileName, Content: string);
    procedure CheatExecute(InputFileName,OutputFileName:string;TypeEnc:Integer);
    function CreateIntegerExecute(Iteration:Integer):Integer;
    procedure EncStringExecute(var S: string);
    procedure WriteAddExecute(const s:string;TypeWrite:Integer);
    procedure Button1Click(Sender: TObject);

    //procedure EncryptString(var S: string);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

const
  FileArr1:array [1..5] of string=('input1.txt','music1.mp3','picture1.png','Video1.mp4','doc1.docx');
  FileArr2:array [1..5] of string=('output1.txt','music2.mp3','picture2.png','Video2.mp4','doc2.docx');

var
  Form1: TForm1;
  BegText,EndText,KeyText:TArray;
  StrBeg,StrEnd,StrKey,FinalKey:string;
  KeyLength:Integer;
  ChosenFile1,ChosenFile2:string;

implementation

{$R *.dfm}

function TForm1.StrToBitsExecute(const AStr: string):TArray;
var
  I: Integer;
begin
  //Len:= Length(AStr) * 8;
  for I := 1 to Length(AStr) do
  begin
    Result[(I - 1) * 8 + 1] := Odd(Ord(AStr[I]) shr 7);
    Result[(I - 1) * 8 + 2] := Odd(Ord(AStr[I]) shr 6);
    Result[(I - 1) * 8 + 3] := Odd(Ord(AStr[I]) shr 5);
    Result[(I - 1) * 8 + 4] := Odd(Ord(AStr[I]) shr 4);
    Result[(I - 1) * 8 + 5] := Odd(Ord(AStr[I]) shr 3);
    Result[(I - 1) * 8 + 6] := Odd(Ord(AStr[I]) shr 2);
    Result[(I - 1) * 8 + 7] := Odd(Ord(AStr[I]) shr 1);
    Result[(I - 1) * 8 + 8] := Odd(Ord(AStr[I]));
  end;
end;

function TForm1.BitsToStrExecute(ABits:TArray;Len:Integer):string;
var
  I, J: Integer;
  CharCode: Byte;
begin
  //SetLength(Result, Length(ABits) div 8);
  Result:='';
  for I := 0 to Len - 1 do
  begin
    CharCode := 0;
    for J := 1 to 8 do
    begin
      CharCode := CharCode shl 1;
      if ABits[I * 8 + J] then
        Inc(CharCode);
    end;
    Result:=Result+Char(CharCode);
  end;

end;

function TForm1.WriteBitsExecute(ABits:TArray;Len:Integer):string;
var
  i:Integer;
  MyChar:Char;
begin
  Result:='';
  for i:=1 to Len do
  begin
    if ABits[i] then
      MyChar:='1'
    else
      MyChar:='0';
    Result:=Result+MyChar;
  end;
end;

procedure TForm1.FormCreate(Sender: TObject);
var
  F:TextFile;
  TempStr:string;
  TempArr:TArray;
begin
  //SetLength(BegText,2000);
  //SetLength(EndText,2000);
  //SetLength(KeyText,2000);
  //EndText,KeyText
  ChosenFile1:='';
  ChosenFile2:='';

  AssignFile(F,'input1.txt');
  Reset(F);
  while not Eoln(F) do
  begin
    Readln(F, TempStr);
    if TempStr='' then
      mmo11.Lines.Add(' ')
    else
    begin
      TempArr:=StrToBitsExecute(TempStr);
      TempStr:=WriteBitsExecute(TempArr,Length(TempStr)*8);
      mmo11.Lines.Add(TempStr);
    end;
  end;
  CloseFile(F);

  AssignFile(F,'output1.txt');
  Reset(F);
  while not Eoln(F) do
  begin
    Readln(F, TempStr);
    if TempStr='' then
      mmo12.Lines.Add(' ')
    else
    begin
      TempArr:=StrToBitsExecute(TempStr);
      TempStr:=WriteBitsExecute(TempArr,Length(TempStr)*8);
      mmo12.Lines.Add(TempStr);
    end;

  end;
  CloseFile(F);
end;

////////////////////////////////////////////////////////

procedure TForm1.btnRead1Click(Sender: TObject);

begin
  if dlgOpen1.Execute then
  begin
    ChosenFile1:=dlgOpen1.FileName;
    edtFile1.Text:=ChosenFile1;
  end;
end;

procedure TForm1.btnRead2Click(Sender: TObject);

begin
  if dlgOpen2.Execute then
  begin
    ChosenFile2:=dlgOpen2.FileName;
    edtFile2.Text:=ChosenFile2;
  end;

end;





//////////////////////////////////////////////////

procedure TForm1.btn1Click(Sender: TObject);
var
  i,j,Temp,Num:Integer;
  Correct:Boolean;
  TempStr:string;
begin
  mmoKey.Lines.Clear;
  Correct:=True;
  StrKey:='';
  i:=1;
  j:=1;
  //StrKey:='';
  while (j<=27) and (i<=Length(edtKey.Text)) do
  begin
    if edtKey.Text[i]='1' then
    begin
      StrKey:= StrKey+'1';
      KeyText[j]:=True;
      inc(j);
    end;
    if edtKey.Text[i]='0' then
    begin
      StrKey:= StrKey+'0';
      KeyText[j]:=False;
      inc(j);
    end;
    inc(i);
  end;
  if j<27 then
  begin
    ShowMessage('��� ���������� ������ ���� �� 27 ��� ���������� �����');
    Correct:=False;
  end;

  if Correct then
  begin
    KeyLength:=27;
    Num:=2;
    if cbbTypeFile.ItemIndex=0 then
      if Num=1 then
        EncryptionExecute(FileArr1[Num],FileArr2[Num],1)
      else
        CheatExecute(FileArr1[Num],FileArr2[Num],1)
    else
      if (ChosenFile1<>'') and (ChosenFile2<>'') then
         CheatExecute(ChosenFile1,ChosenFile2,1)
      else
        ShowMessage('�������� ����');


    if Num=1 then
      if KeyLength>80 then
        for i:=1 to (KeyLength div 80)+1 do
        begin
          if 80*i>KeyLength then
            Temp:=KeyLength
          else
            Temp:=80*i;
          TempStr:=WriteBits2Execute(KeyText,80*(i-1)+1,Temp);

          mmoKey.Lines.Add(TempStr);
        end
      else
        mmoKey.Lines.Add(WriteBitsExecute(KeyText,KeyLength)) ;
    {else
    begin
      mmo11.Lines.Clear;
      mmo12.Lines.Clear;

    end; }

  end;


end;

procedure TForm1.EncryptionExecute(FName1,Fname2:string;TypeUse:Integer);
var
  i,j:Integer;
  F1,F2:TextFile;
  TempStr,TempStr2:string;
  TempArr:TArray;
  Before:Boolean;
begin
  mmo11.Lines.Clear;
  mmo12.Lines.Clear;
  AssignFile(F1,FName1);
  AssignFile(F2,FName2);
  Reset(F1);
  Rewrite(F2);
  i:=1;
  Before:=True;
  while not Eoln(F1) do
  begin
    j:=1;
    Readln(F1, TempStr);
    if TempStr='' then
    begin
      Writeln(F2,' ');
      Continue;
    end;

    TempArr:=StrToBitsExecute(TempStr);
    TempStr:=WriteBitsExecute(TempArr,Length(TempStr)*8);


    if Before then
      while Before and (j<=Length(TempStr)) do
      begin
        EndText[j]:=TempArr[j] xor KeyText[j];
        inc(j);
        inc(i);
        if i=28 then
          Before:=False;
      end;


    if not Before then
      while j<=Length(TempStr) do
      begin
        KeyText[KeyLength+1]:=KeyText[KeyLength-27] xor KeyText[KeyLength-2];
        Inc(KeyLength);
        EndText[j]:=TempArr[j] xor KeyText[KeyLength];
        inc(j);
      end;

    TempStr2:=WriteBitsExecute(EndText,Length(TempStr));
    if TypeUse=1 then
    begin
      mmo11.Lines.Add(TempStr);
      mmo12.Lines.Add(TempStr2);
    end
    else
    begin
      mmo12.Lines.Add(TempStr);
      mmo11.Lines.Add(TempStr2);
    end;
    TempStr2:=BitsToStrExecute(EndText,Length(TempStr) div 8);
    Writeln(F2,TempStr2);
  end;
  if Before then
    KeyLength:=i-1;
  CloseFile(F1);
  CloseFile(F2);

end;

function TForm1.WriteBits2Execute(ABits:TArray;Beg,Len:Integer):string;
var
  i:Integer;
  MyChar:Char;
begin
  Result:='';
  for i:=Beg to Len do
  begin
    if ABits[i] then
      MyChar:='1'
    else
      MyChar:='0';
    Result:=Result+MyChar;
  end;
end;

procedure TForm1.btn2Click(Sender: TObject);
var
  i,j,Temp,Num:Integer;
  Correct:Boolean;
  TempStr:string;
begin
  mmoKey.Lines.Clear;
  Correct:=True;
  StrKey:='';
  i:=1;
  j:=1;
  while (j<=27) and (i<=Length(edtKey.Text)) do
  begin
    if edtKey.Text[i]='1' then
    begin
      StrKey:= StrKey+'1';
      KeyText[j]:=True;
      inc(j);
    end;
    if edtKey.Text[i]='0' then
    begin
      StrKey:= StrKey+'0';
      KeyText[j]:=False;
      inc(j);
    end;
    inc(i);
  end;
  if j<27 then
  begin
    ShowMessage('��� ���������� ������ ���� �� 27 ��� ���������� �����');
    Correct:=False;
  end;

  if Correct then
  begin
    KeyLength:=27;
    Num:=cbbFile.ItemIndex+1;

    if cbbTypeFile.ItemIndex=0 then
      if Num=1 then
        EncryptionExecute(FileArr2[Num],FileArr1[Num],2)
      else
        CheatExecute(FileArr2[Num],FileArr1[Num],2)
    else
      if (ChosenFile1<>'') and (ChosenFile2<>'') then
         CheatExecute(ChosenFile2,ChosenFile1,2)
      else
        ShowMessage('�������� ����');


  if Num=1 then
    if KeyLength>80 then
      for i:=1 to (KeyLength div 80)+1 do
      begin
        if 80*i>KeyLength then
          Temp:=KeyLength
        else
          Temp:=80*i;
        TempStr:=WriteBits2Execute(KeyText,80*(i-1)+1,Temp);

        mmoKey.Lines.Add(TempStr);
      end
    else
      mmoKey.Lines.Add(WriteBitsExecute(KeyText,KeyLength));
  {else
  begin
    mmo11.Lines.Clear;
    mmo12.Lines.Clear;
  end;}

  end;

end;

procedure TForm1.DecryptionExecute(FName1,Fname2:string);
var
  i,j:Integer;
  F1,F2:TextFile;
  TempStr,TempStr2:string;
  TempArr:TArray;
  Before:Boolean;
begin
  mmo11.Lines.Clear;
  mmo12.Lines.Clear;
  TempStr:=ReadFileToStringExecute(FName1);
  StrKey:='';
  StrBeg:='';
  for i:=1 to KeyLength do
    StrKey:=StrKey+BoolToBitExecute(KeyText[i]);
  StrBeg:=StrToBitStrExecute(TempStr);
  i:=1;
  j:=1;
  Before:=True;


    //TempArr:=StrToBitsExecute(TempStr);
    //TempStr:=WriteBitsExecute(TempArr,Length(TempStr)*8);
    //mmo12.Lines.Add(TempStr);
      StrEnd:='';
      while (i<>28) and (j<=Length(StrBeg)) do
      begin
        StrEnd:=StrEnd + BoolToBitExecute(BitToBoolExecute(StrBeg[j]) xor BitToBoolExecute(StrKey[j]));
        inc(j);
        inc(i);
        if i=28 then
          Before:=False;
      end;

    if not Before then
      while j<=Length(TempStr) do
      begin
        StrKey:=StrKey + BoolToBitExecute(BitToBoolExecute(StrKey[KeyLength-27]) xor BitToBoolExecute(StrKey[KeyLength-2]));
        Inc(KeyLength);
        StrEnd:=StrEnd + BoolToBitExecute(BitToBoolExecute(StrBeg[j]) xor BitToBoolExecute(StrKey[KeyLength]));
        inc(j)
      end;

    TempStr:=BitStrToStrExecute(StrEnd);
    WriteStringToFileExecute(FName2,TempStr);

    {TempStr2:=WriteBitsExecute(EndText,Length(TempStr));
    mmo11.Lines.Add(TempStr2);
    TempStr2:=BitsToStrExecute(EndText,Length(TempStr) div 8);
    Writeln(F2,TempStr2);}

  if Before then
    KeyLength:=i-1;
  //CloseFile(F1);
  //CloseFile(F2);

end;

function TForm1.BitToBoolExecute(a:Char):Boolean;
begin
  if a='1' then
    Result:=True
  else
    Result:=False;
end;

function TForm1.BoolToBitExecute(a:Boolean):char;
begin
   if a then
     Result:='1'
   else
     Result:='0';
end;

function TForm1.StrToBitStrExecute(a:string ):string;
var
  i,j:Integer;
begin
  Result:='';
  //SetLength(Result,Length(a));
  for I := 1 to Length(a) do
  begin
    for j:=7 downto 0 do
      if Odd(Ord(a[I]) shr j) then
        Result:=Result+'1'
      else
        Result:=Result+'0';
    {Result[(I - 1) * 8 + 1] := Odd(Ord(AStr[I]) shr 7);
    Result[(I - 1) * 8 + 2] := Odd(Ord(AStr[I]) shr 6);
    Result[(I - 1) * 8 + 3] := Odd(Ord(AStr[I]) shr 5);
    Result[(I - 1) * 8 + 4] := Odd(Ord(AStr[I]) shr 4);
    Result[(I - 1) * 8 + 5] := Odd(Ord(AStr[I]) shr 3);
    Result[(I - 1) * 8 + 6] := Odd(Ord(AStr[I]) shr 2);
    Result[(I - 1) * 8 + 7] := Odd(Ord(AStr[I]) shr 1);
    Result[(I - 1) * 8 + 8] := Odd(Ord(AStr[I])); }
  end;
end;

function TForm1.BitStrToStrExecute(ABits:string):string;
var
  I, J: Integer;
  CharCode: Byte;
begin
  //SetLength(Result, Length(ABits) div 8);
  Result:='';
  for I := 0 to Length(ABits) - 1 do
  begin
    CharCode := 0;
    for J := 1 to 8 do
    begin
      CharCode := CharCode shl 1;
      if ABits[I * 8 + J]='1' then
        Inc(CharCode);
    end;
    Result:=Result+Char(CharCode);
  end;

end;

function TForm1.ReadFileToStringExecute(const FileName: string): string;
var
  FileStream: TFileStream;
  Buffer: array of Byte;
begin
  FileStream := TFileStream.Create(FileName, fmOpenRead);
  try
    SetLength(Buffer, FileStream.Size);
    FileStream.Read(Buffer[0], FileStream.Size);
    Result := string(PAnsiChar(Buffer));
  finally
    FileStream.Free;
  end;
end;

procedure TForm1.WriteStringToFileExecute(const FileName, Content: string);
var
  FileStream: TFileStream;
begin
  FileStream := TFileStream.Create(FileName, fmCreate);
  try
    FileStream.WriteBuffer(PAnsiChar(Content)^, Length(Content) * SizeOf(Char));
  finally
    FileStream.Free;
  end;
end;

///////////////////
procedure EncryptString(var S: string);
var
  i,Key: Integer;
begin
  Key:=42;
  for i := 1 to Length(S) do
    S[i] := Char(Byte(S[i]) xor Key{CreateIntegerExecute(i)});
end;

procedure TForm1.CheatExecute(InputFileName,OutputFileName:string;TypeEnc:Integer);
var
  InputFile, OutputFile: TFileStream;
  PNGContent: string;
  i:Integer;
begin
  try
    mmo11.Lines.Clear;
    mmo12.Lines.Clear;
    mmoKey.Lines.Clear;
    for i:=1 to 5 do
    begin
      StrKey:=StrKey + BoolToBitExecute(BitToBoolExecute(StrKey[KeyLength-26]) xor BitToBoolExecute(StrKey[KeyLength]) xor BitToBoolExecute(StrKey[KeyLength-7]) xor BitToBoolExecute(StrKey[KeyLength-6]));
      Inc(KeyLength);
    end;
    //i:=CreateIntegerExecute(i);
    FinalKey:='';
    InputFile := TFileStream.Create(InputFileName, fmOpenRead);
    SetLength(PNGContent, InputFile.Size);
    InputFile.ReadBuffer(Pointer(PNGContent)^, InputFile.Size);
    InputFile.Free;
   ///////////////////////////////
    if TypeEnc=1 then
      WriteAddExecute(PNGContent,1)
    else
      WriteAddExecute(PNGContent,3);

    EncStringExecute(PNGContent);
    WriteAddExecute(FinalKey,2);

    OutputFile := TFileStream.Create(OutputFileName, fmCreate);
    OutputFile.WriteBuffer(Pointer(PNGContent)^, Length(PNGContent));
    OutputFile.Free;

    if TypeEnc=1 then
      WriteAddExecute(PNGContent,3)
    else
      WriteAddExecute(PNGContent,1);

    OutputFile := TFileStream.Create('output.txt', fmCreate);
    OutputFile.WriteBuffer(Pointer(PNGContent)^, Length(PNGContent));
    OutputFile.Free;

    //Writeln('File encrypted successfully.');
  except
    on E: Exception do
      ShowMessage( E.Message);
  end;

end;



function TForm1.CreateIntegerExecute(Iteration:Integer):Integer;
var
  j: Integer;
  CharCode: Integer;
begin
  //SetLength(Result, Length(ABits) div 8);
    if Iteration>=5 then
    begin
      Result:= 0;
      for j := 1 to 8 do
      begin
        Result := Result shl 1;
        StrKey:=StrKey + BoolToBitExecute(BitToBoolExecute(StrKey[KeyLength-26]) xor BitToBoolExecute(StrKey[KeyLength]) xor BitToBoolExecute(StrKey[KeyLength-7]) xor BitToBoolExecute(StrKey[KeyLength-6]));
        Inc(KeyLength);
        if BitToBoolExecute(StrKey[KeyLength]) then
          Inc(Result);
      end;
      FinalKey:=FinalKey+Char(Result);
    end
    else
    begin
      Result:= 0;
      for j := 8*(Iteration-1)+1 to 8*Iteration do
      begin
        Result := Result shl 1;
        if BitToBoolExecute(StrKey[j]) then
          Inc(Result);
      end;
      FinalKey:=FinalKey+Char(Result);
    end;

    //Result:=Result+Char(CharCode);
end;

procedure TForm1.EncStringExecute(var S: string);
var
  i,Key: Integer;
begin
  //Key:=42;
  for i := 1 to Length(S) do
  begin
    Key:= CreateIntegerExecute(i);
    S[i] := Char(Byte(S[i]) xor Byte(Key));
  end;

end;

procedure TForm1.WriteAddExecute(const s:string;TypeWrite:Integer);
var
  i,Iter8:Integer;
  StrRes:string;
begin
  StrRes:='';
  Iter8:=1;
  for i:=1 to Length(s) do
  begin
    StrRes:=StrRes+StrToBitStrExecute(s[i]);
    if Iter8=10 then
    begin
      if TypeWrite=1 then
        mmo11.Lines.Add(StrRes);
      if TypeWrite=2 then
        mmoKey.Lines.Add(StrRes);
      if TypeWrite=3 then
        mmo12.Lines.Add(StrRes);
      StrRes:='';
      Iter8:=1;
    end
    else
      inc(Iter8);
  end;
end;

procedure TForm1.Button1Click(Sender: TObject);
begin
mmo11.Text:='';
mmo12.Text:='';
mmoKey.Text:='';
end;

end.
