unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls;

type
  TForm1 = class(TForm)
    Button1: TButton;
    Button2: TButton;
    Edit1: TEdit;
    Label1: TLabel;
    Label2: TLabel;
    Label3: TLabel;
    Label4: TLabel;
    Label5: TLabel;
    Button5: TButton;
    Edit3: TEdit;
    Edit4: TEdit;
    Button7: TButton;
    Stolb: TRadioButton;
    Viz: TRadioButton;
    procedure Button1Click(Sender: TObject);
    procedure Button5Click(Sender: TObject);
    procedure FormCreate(Sender: TObject);
    procedure Button7Click(Sender: TObject);
    procedure Button2Click(Sender: TObject);
    procedure Button6Click(Sender: TObject);
    procedure Button8Click(Sender: TObject);
    procedure Button3Click(Sender: TObject);
    procedure Button4Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;
  Arr1:array of array of Integer;

implementation

{$R *.dfm}

procedure CodeColomns(sss,FilePath2,key:string);
var
  i,j,k,m,n,p,MinInd,MinSymb:Integer;
  arr:array of array of char;
  cor:Boolean;
  F:TextFile;
  keyTemp,resultStr:string;
begin
  {
    AssignFile(F,FilePath1);
    Reset(F);
    Readln(F,sss);
    CloseFile(F);
  }
  key:=UpperCase(key);
  m:=Length(key);
  keyTemp:=key;
  n:=1;
  SetLength(arr,n);
  for i:=0 to n-1 do
    SetLength(arr[i],m);
  k:=1;
  while (k<=Length(sss)) do
  begin
    i:=0;
    while (i<n) and (k<=Length(sss)) do
    begin
      MinSymb:=Ord('{');
      for p:=1 to Length(key) do
          if (Ord(key[p])<MinSymb) and (key[p]<>' ')  then
          begin
            MinSymb:=Ord(key[p]);
            MinInd:=p;
          end;

      key[MinInd]:=' ';
      j:=0;
      while (j<MinInd) and (k<=Length(sss)) do
      begin
        arr[i,j]:=sss[k];
        j:=j+1;
        k:=k+1;
      end;
      i:=i+1;
      n:=n+1;
      SetLength(arr,n);
       for p:=0 to n-1 do
        SetLength(arr[p],m);
    end;
  end;
  cor:=True;
  for j:=0 to m-1 do
    if arr[n-1,j]='' then
      cor:=False;
  if cor=False then
  begin
    SetLength(arr,n-1);
    n:=n-1;
  end;

  ///strFsd:=sss;
    key:=keyTemp;
    j:=0;
    while j<m  do
    begin
      MinSymb:=Ord('{');
      for p:=1 to Length(key) do
      if (Ord(key[p])<MinSymb) and (key[p]<>' ')  then
      begin
        MinSymb:=Ord(key[p]);
        MinInd:=p;
      end;
      key[MinInd]:=' ';
      i:=0;
      while i<n do
      begin
        resultStr:=resultStr+arr[i,MinInd-1];
        //write(arr[i,MinInd-1]);
        i:=i+1;
      end;
      j:=j+1;
    end;
  AssignFile(F,FilePath2);
  Rewrite(F);
  Writeln(F,resultStr);
  CloseFile(F);
  //Writeln(resultStr);
  //Writeln;
end;

procedure DecodeColomns(sss,FilePath2,key:string);
var
  i,j,k,m,n,p,MinInd,MinSymb:Integer;
  arr:array of array of char;
  cor:Boolean;
  F:TextFile;
  keyTemp,resultStr:string;
begin
  {
  AssignFile(F,FilePath1);
  Reset(F);
  Readln(F,sss);
  CloseFile(F);
  }
  m:=Length(key);
  key:=UpperCase(key);
  keyTemp:=key;
  n:=Length(sss) div m;
  SetLength(arr,n);
  for i:=0 to n-1 do
    SetLength(arr[i],m);
  k:=1;
  while (k<=Length(sss)) do
  begin
    j:=0;
    while (j<m) and (k<=Length(sss)) do
    begin
      MinSymb:=Ord('{');
      for p:=1 to Length(key) do
          if (Ord(key[p])<MinSymb) and (key[p]<>' ')  then
          begin
            MinSymb:=Ord(key[p]);
            MinInd:=p;
          end;
      key[MinInd]:=' ';
      i:=0;
      while (i<n) and (k<=Length(sss)) do
      begin
        arr[i,MinInd-1]:=sss[k];
        i:=i+1;
        k:=k+1;
      end;
      j:=j+1;
    end;
  end;

  for i:=0 to n-1 do
    for j:=0 to m-1 do
    if ((Ord(arr[i,j])>=Ord('A')) and (Ord(arr[i,j])<=Ord('Z'))) or ((Ord(arr[i,j])>=Ord('a')) and (Ord(arr[i,j])<=Ord('z')))  then
      resultStr:=resultStr+arr[i,j];
  AssignFile(F,FilePath2);
  Rewrite(F);
  Writeln(F,resultStr);
  CloseFile(F);
end;

procedure CodeVijener(sss,FilePath2,key:string);
const
  alphlit='ÀÁÂÃÄÅ¨ÆÇÈÉÊËÌÍÎÏÐÑÒÓÔÕÖ×ØÙÚÛÜÝÞß';
  alphbig='àáâãäå¸æçèéêëìíîïðñòóôõö÷øùúûüýþÿ';
var
  i,j,k,m,n,p,MinInd1,MinInd2,index,MinSymb:Integer;
  arr:array of array of char;
  cor:Boolean;
  F:TextFile;
  symbol,symbol2:char;
  keyTemp,resultStr:string;
begin
  {AssignFile(F,FilePath1);
  Reset(F);
  while(not Eof(F)) do
  begin
    read(F,symbol2);
    if ((symbol2>='À') and (symbol2<='ß')) or ((symbol2>='à') and (symbol2<='ÿ')) or (symbol2='¨') or (symbol2='¸') or (symbol2=' ') then
      sss:=sss+symbol2;
  end;
  //Readln(F,sss);
  CloseFile(F);}
  i:=1;
  j:=1;
  k:=1;
  while(i<=Length(sss)) do
  begin
    if (sss[i]<>' ') and (j<=Length(key)) then
      begin
        keyTemp:=keyTemp+key[j];
        j:=j+1;
      end
      else
        if sss[i]<>' ' then
          begin
             while sss[k]=' ' do
              k:=k+1;
             keyTemp:=keyTemp+sss[k];
             k:=k+1;
          end

        else
          keyTemp:=keyTemp+' ';
    i:=i+1;
  end;

  i:=1;
  while i<=Length(sss) do
  begin
    if sss[i]<>' ' then
    begin
      j:=1;
      while j<=Length(alphlit) do
      begin
        if  (sss[i]=alphlit[j]) or (sss[i]=alphbig[j])  then
          MinInd1:=j;

        if  (keyTemp[i]=alphlit[j]) or (keyTemp[i]=alphbig[j])  then
          MinInd2:=j;
        j:=j+1;
      end;

      MinInd1:=MinInd1-1;
      MinInd2:=MinInd2-1;
      index:=(MinInd1+MinInd2) mod Length(alphlit);
      index:=index+1;
      if sss[i]=alphlit[MinInd1+1] then
        resultStr:=resultStr+alphlit[index]
      else
        resultStr:=resultStr+alphbig[index];
    end
    else
      resultStr:=resultStr+' ';
    i:=i+1;
  end;
  AssignFile(F,FilePath2);
  Rewrite(F);
  Writeln(F,resultStr);
  CloseFile(F);

end;

procedure DecodeVijener(sss,FilePath2,key:string);
const
  alphlit='ÀÁÂÃÄÅ¨ÆÇÈÉÊËÌÍÎÏÐÑÒÓÔÕÖ×ØÙÚÛÜÝÞß';
  alphbig='àáâãäå¸æçèéêëìíîïðñòóôõö÷øùúûüýþÿ';
var
  i,j,k,m,n,p,MinInd1,MinInd2,index,index1,MinSymb:Integer;
  arr:array of array of char;
  cor:Boolean;
  F:TextFile;
  symbol,symbol2:char;
  keyTemp,resultStr:string;
begin
  {AssignFile(F,FilePath1);
  Reset(F);
  while(not Eof(F)) do
  begin
    read(F,symbol2);
    if ((symbol2>='À') and (symbol2<='ß')) or ((symbol2>='à') and (symbol2<='ÿ')) or (symbol2='¨') or (symbol2='¸') or (symbol2=' ') then
      sss:=sss+symbol2;
  end;
  //Readln(F,sss);
  CloseFile(F); }
  i:=1;
  j:=1;
  k:=1;
  while i<=Length(sss) do
  begin
    keyTemp:=keyTemp+' ';
    i:=i+1;
  end;


  i:=1;
  index:=1;
  index1:=1;
  while j<=Length(key) do
  begin
    if sss[i]<>' ' then
    begin
      keyTemp[i]:=key[j];
      j:=j+1;
    end;
    i:=i+1;
    index1:=index1+1;
  end;


      i:=1;
      while i<=Length(sss) do
      begin
          if sss[i]<>' ' then
          begin
              j:=1;
            while j<=Length(alphlit) do
            begin
              if  (sss[i]=alphlit[j]) or (sss[i]=alphbig[j])  then
                MinInd1:=j;

              if  (keyTemp[i]=alphlit[j]) or (keyTemp[i]=alphbig[j])  then
                MinInd2:=j;
              j:=j+1;
            end;

            MinInd1:=MinInd1-1;
            MinInd2:=MinInd2-1;
            index:=(MinInd1-MinInd2+length(alphlit)) mod Length(alphlit);
            index:=index+1;
            if sss[i]=alphlit[MinInd1+1] then
              resultStr:=resultStr+alphlit[index]
            else
              resultStr:=resultStr+alphbig[index];

            if index1<=Length(sss) then
            begin
              while sss[index1]=' ' do
              begin
                index1:=index1+1;
              end;
              keyTemp[index1]:=resultStr[i];
              index1:=index1+1;
            end;

          end
          else
          begin
            resultStr:=resultStr+' ';
          end;

        i:=i+1;
      end;
  AssignFile(F,FilePath2);
  Rewrite(F);
  Writeln(F,resultStr);
  CloseFile(F);
end;

procedure TForm1.Button1Click(Sender: TObject);
var
  i:Integer;
  F:TextFile;
  str1,s1,source:string;
  symbol:Char;
begin
if (Stolb.Checked) then
begin
  i:=1;
  while (i<=Length(Edit1.Text)) do
  begin
    if ((Ord(Edit1.Text[i])>=Ord('A')) and (Ord(Edit1.Text[i])<=Ord('Z'))) or ((Edit1.Text[i]>='a') and (Edit1.Text[i]<='z')) then
      s1:=s1+Edit1.Text[i];
    i:=i+1;
  end;
  if Length(s1)=0 then
  begin
    ShowMessage('Íåâåðíûé êëþ÷');
    Exit;
  end;
  i:=1;
  while (i<=Length(Edit3.Text)) do
  begin
    if ((Ord(Edit3.Text[i])>=Ord('A')) and (Ord(Edit3.Text[i])<=Ord('Z'))) or ((Edit3.Text[i]>='a') and (Edit3.Text[i]<='z'))  then
      source:=source+Edit3.Text[i];
    i:=i+1;
  end;
 
  //source:=Edit3.Text;
  CodeColomns(source,'CodeInfFirst.txt',s1);
  AssignFile(F,'CodeInfFirst.txt');
  Reset(F);
  while not Eof(F) do
  begin
    read(F,symbol);
    if ((symbol>='a') and (symbol<='z')) or ((symbol<='Z') and (symbol>='A')) or (symbol=#0) then
      str1:=str1+symbol;
  end;
  i:=1;
  while i<=Length(str1) do
  begin
    if str1[i]=#0 then
      str1[i]:=' ';
    i:=i+1;
  end;
  Edit4.Text:=str1;
  CloseFile(F);
  end
  else
  begin
  i:=1;
  while (i<=Length(Edit1.Text)) do
  begin
    if ((Edit1.Text[i]>='À') and (Edit1.Text[i]<='ß')) or ((Edit1.Text[i]<='ÿ') and (Edit1.Text[i]>='à')) or (Edit1.Text[i]='¨') or (Edit1.Text[i]='¸') then
      s1:=s1+Edit1.Text[i];
    i:=i+1;
  end;
  if Length(s1)=0 then
  begin
    ShowMessage('Íåâåðíûé êëþ÷');
    Exit;
  end;
  i:=1;
  while (i<=Length(Edit3.Text)) do
  begin
    if ((Edit3.Text[i]>='À') and (Edit3.Text[i]<='ß')) or ((Edit3.Text[i]<='ÿ') and (Edit3.Text[i]>='à')) or (Edit3.Text[i]='¨') or (Edit3.Text[i]='¸') or (Edit3.Text[i]=' ')  then
      source:=source+Edit3.Text[i];
    i:=i+1;
  end;
  if Length(source)=0 then
  begin
    ShowMessage('Ïóñòàÿ ñòðîêà');
    Exit;
  end;
  //source:=Edit3.Text;
  CodeVijener(source,'CodeInfSecond.txt',s1);
  AssignFile(F,'CodeInfSecond.txt');
  Reset(F);
  while not Eof(F) do
  begin
    read(F,symbol);
    if ((symbol>='À') and (symbol<='ß')) or ((symbol<='ÿ') and (symbol>='à')) or (symbol=' ') or (symbol='¨') or (symbol='¸') then
      str1:=str1+symbol;
  end;
  Edit4.Text:=str1;
  CloseFile(F);
  end;
  //Code('C:\bmw.txt','C:\merc.txt',s1);
  //Decode('C:\merc.txt','C:\bmw.txt',s1);
end;

procedure TForm1.Button5Click(Sender: TObject);
var
  symbol:Char;
  str1:string;
  F:TextFile;
begin
if (Stolb.Checked) then
begin
  Edit3.Clear;
  if (FileExists('CodeInfFirst.txt')) then
  begin
  AssignFile(F,'CodeInfFirst.txt');
  Reset(F);
  while not Eof(F) do
  begin
    read(F,symbol);
    if ((symbol>='a') and (symbol<='z')) or ((symbol<='Z') and (symbol>='A')) or (symbol=#0) or (symbol=' ') then
      if symbol=#0 then
        str1:=str1+' '
      else
        str1:=str1+symbol;
  end;
  CloseFile(F);
  Edit3.Text:=str1;
  end
  else
  showmessage('Ôàéë íå íàéäåí');
  end
  else
  begin
  Edit3.Clear;
  if (FileExists('CodeInfSecond.txt')) then
  begin
  AssignFile(F,'CodeInfSecond.txt');
  Reset(F);
  while not Eof(F) do
  begin
    read(F,symbol);
    if ((symbol>='À') and (symbol<='ß')) or ((symbol<='ÿ') and (symbol>='à')) or (symbol='¨') or (symbol='¸') or (symbol=' ') then
        str1:=str1+symbol;
  end;
  CloseFile(F);
  Edit3.Text:=str1;
  end
  else
  showmessage('Ôàéë íå íàéäåí');
  end;
end;

procedure TForm1.FormCreate(Sender: TObject);
begin
  Edit1.Clear;

  Edit3.Clear;
  Edit4.Clear;


end;

procedure TForm1.Button7Click(Sender: TObject);
begin
  Edit1.Clear;
  Edit3.Clear;
  Edit4.Clear;
end;

procedure TForm1.Button2Click(Sender: TObject);
var
  i:Integer;
  F:TextFile;
  str1,s1,source:string;
  symbol:Char;
begin
if (Stolb.Checked) then
begin
  i:=1;
  while (i<=Length(Edit1.Text)) do
  begin
    if ((Ord(Edit1.Text[i])>=Ord('A')) and (Ord(Edit1.Text[i])<=Ord('Z'))) or ((Edit1.Text[i]>='a') and (Edit1.Text[i]<='z'))  then
      s1:=s1+Edit1.Text[i];
    i:=i+1;
  end;
  if Length(s1)=0 then
  begin
    ShowMessage('Íåâåðíûé êëþ÷');
    Exit;
  end;
  i:=1;
  while (i<=Length(Edit3.Text)) do
  begin
    if ((Ord(Edit3.Text[i])>=Ord('A')) and (Ord(Edit3.Text[i])<=Ord('Z'))) or ((Edit3.Text[i]>='a') and (Edit3.Text[i]<='z')) or (Edit3.Text[i]=' ') then
      source:=source+Edit3.Text[i];
    i:=i+1;
  end;

  DecodeColomns(source,'CodeInfFirst.txt',s1);
  AssignFile(F,'CodeInfFirst.txt');
  Reset(F);
  while not Eof(F) do
  begin
    read(F,symbol);
    if ((symbol>='a') and (symbol<='z')) or ((symbol<='Z') and (symbol>='A')) or (symbol=' ') then
      str1:=str1+symbol;
  end;
  Edit4.Text:=str1;
  CloseFile(F);
  end
  else
  begin
  i:=1;
  while (i<=Length(Edit1.Text)) do
  begin
    if ((Edit1.Text[i]>='À') and (Edit1.Text[i]<='ß')) or ((Edit1.Text[i]<='ÿ') and (Edit1.Text[i]>='à')) or (Edit1.Text[i]='¨') or (Edit1.Text[i]='¸') then
      s1:=s1+Edit1.Text[i];
    i:=i+1;
  end;
  if Length(s1)=0 then
  begin
    ShowMessage('Íåâåðíûé êëþ÷');
    Exit;
  end;
  i:=1;
  while (i<=Length(Edit3.Text)) do
  begin
    if ((Edit3.Text[i]>='À') and (Edit3.Text[i]<='ß')) or ((Edit3.Text[i]<='ÿ') and (Edit3.Text[i]>='à')) or (Edit3.Text[i]='¨') or (Edit3.Text[i]='¸') or (Edit3.Text[i]=' ') then
      source:=source+Edit3.Text[i];
    i:=i+1;
  end;

  //source:=Edit3.Text;
  DecodeVijener(source,'CodeInfSecond.txt',s1);
  AssignFile(F,'CodeInfSecond.txt');
  Reset(F);
  while not Eof(F) do
  begin
    read(F,symbol);
    if ((symbol>='À') and (symbol<='ß')) or ((symbol<='ÿ') and (symbol>='à')) or (symbol=' ') or (symbol='¨') or (symbol='¸') then
      str1:=str1+symbol;
  end;
  Edit4.Text:=str1;
  CloseFile(F);
  end;
end;


procedure TForm1.Button6Click(Sender: TObject);
var
  symbol:Char;
  str1:string;
  F:TextFile;
begin
  Edit3.Clear;
  AssignFile(F,'CodeInfSecond.txt');
  Reset(F);
  while not Eof(F) do
  begin
    read(F,symbol);
    if ((symbol>='À') and (symbol<='ß')) or ((symbol<='ÿ') and (symbol>='à')) or (symbol='¨') or (symbol='¸') or (symbol=' ') then
        str1:=str1+symbol;
  end;
  CloseFile(F);
  Edit3.Text:=str1;
end;

procedure TForm1.Button8Click(Sender: TObject);
begin
  //Edit2.Clear;
  
  
end;

procedure TForm1.Button3Click(Sender: TObject);
var
  i:Integer;
  F:TextFile;
  str1,s1,source:string;
  symbol:Char;
begin
   i:=1;
  while (i<=Length(Edit1.Text)) do
  begin
    if ((Edit1.Text[i]>='À') and (Edit1.Text[i]<='ß')) or ((Edit1.Text[i]<='ÿ') and (Edit1.Text[i]>='à')) or (Edit1.Text[i]='¨') or (Edit1.Text[i]='¸') then
      s1:=s1+Edit1.Text[i];
    i:=i+1;
  end;
  if Length(s1)=0 then
  begin
    ShowMessage('Íåâåðíûé êëþ÷');
    Exit;
  end;
  i:=1;
  while (i<=Length(Edit3.Text)) do
  begin
    if ((Edit3.Text[i]>='À') and (Edit3.Text[i]<='ß')) or ((Edit3.Text[i]<='ÿ') and (Edit3.Text[i]>='à')) or (Edit3.Text[i]='¨') or (Edit3.Text[i]='¸') or (Edit3.Text[i]=' ')  then
      source:=source+Edit3.Text[i];
    i:=i+1;
  end;
  if Length(source)=0 then
  begin
    ShowMessage('Ïóñòàÿ ñòðîêà');
    Exit;
  end;
  //source:=Edit3.Text;
  CodeVijener(source,'CodeInfSecond.txt',s1);
  AssignFile(F,'CodeInfSecond.txt');
  Reset(F);
  while not Eof(F) do
  begin
    read(F,symbol);
    if ((symbol>='À') and (symbol<='ß')) or ((symbol<='ÿ') and (symbol>='à')) or (symbol=' ') or (symbol='¨') or (symbol='¸') then
      str1:=str1+symbol;
  end;
  Edit4.Text:=str1;
  CloseFile(F);
end;

procedure TForm1.Button4Click(Sender: TObject);
var
  i:Integer;
  F:TextFile;
  str1,s1,source:string;
  symbol:Char;
begin
   i:=1;
  while (i<=Length(Edit1.Text)) do
  begin
    if ((Edit1.Text[i]>='À') and (Edit1.Text[i]<='ß')) or ((Edit1.Text[i]<='ÿ') and (Edit1.Text[i]>='à')) or (Edit1.Text[i]='¨') or (Edit1.Text[i]='¸') then
      s1:=s1+Edit1.Text[i];
    i:=i+1;
  end;
  if Length(s1)=0 then
  begin
    ShowMessage('Íåâåðíûé êëþ÷');
    Exit;
  end;
  i:=1;
  while (i<=Length(Edit3.Text)) do
  begin
    if ((Edit3.Text[i]>='À') and (Edit3.Text[i]<='ß')) or ((Edit3.Text[i]<='ÿ') and (Edit3.Text[i]>='à')) or (Edit3.Text[i]='¨') or (Edit3.Text[i]='¸') or (Edit3.Text[i]=' ') then
      source:=source+Edit3.Text[i];
    i:=i+1;
  end;

  //source:=Edit3.Text;
  DecodeVijener(source,'CodeInfSecond.txt',s1);
  AssignFile(F,'CodeInfSecond.txt');
  Reset(F);
  while not Eof(F) do
  begin
    read(F,symbol);
    if ((symbol>='À') and (symbol<='ß')) or ((symbol<='ÿ') and (symbol>='à')) or (symbol=' ') or (symbol='¨') or (symbol='¸') then
      str1:=str1+symbol;
  end;
  Edit4.Text:=str1;
  CloseFile(F);
end;

end.
