program ProjectTI1Console;

{$APPTYPE CONSOLE}

uses
  SysUtils,
  Windows;

var
  str1,str2:string;

procedure CodeColomns(FilePath1,FilePath2,key:string;var strFsd:string);
var
  i,j,k,m,n,p,MinInd,MinSymb:Integer;
  arr:array of array of char;
  cor:Boolean;
  F:TextFile;
  sss,keyTemp,resultStr:string;
begin
  AssignFile(F,FilePath1);
  Reset(F);
  Readln(F,sss);
  CloseFile(F);
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

  strFsd:=sss;
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
  Writeln(resultStr);
  //Writeln;
end;

procedure DecodeColomns(FilePath1,key:string;var strFsd:string);
var
  i,j,k,m,n,p,MinInd,MinSymb:Integer;
  arr:array of array of char;
  cor:Boolean;
  F:TextFile;
  sss,keyTemp,resultStr:string;
begin
  AssignFile(F,FilePath1);
  Reset(F);
  Readln(F,sss);
  CloseFile(F);
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
    if (Ord(arr[i,j])>=Ord('A')) and (Ord(arr[i,j])<=Ord('Z')) then
      resultStr:=resultStr+arr[i,j];
  Writeln(resultStr);
end;

procedure CodeVijener(FilePath1,FilePath2,key:string);
const
  alphlit='ÀÁÂÃÄÅ¨ÆÇÈÉÊËÌÍÎÏÐÑÒÓÔÕÖ×ØÙÚÛÜÝÞß';
  alphbig='àáâãäå¸æçèéêëìíîïðñòóôõö÷øùúûüýþÿ';
var
  i,j,k,m,n,p,MinInd1,MinInd2,index,MinSymb:Integer;
  arr:array of array of char;
  cor:Boolean;
  F:TextFile;
  symbol,symbol2:char;
  sss,keyTemp,resultStr:string;
begin
  AssignFile(F,FilePath1);
  Reset(F);
  while(not Eof(F)) do
  begin
    read(F,symbol2);
    if ((symbol2>='À') and (symbol2<='ß')) or ((symbol2>='à') and (symbol2<='ÿ')) or (symbol2='¨') or (symbol2='¸') or (symbol2=' ') then
      sss:=sss+symbol2;
  end;
  //Readln(F,sss);
  CloseFile(F);
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
   Writeln(resultStr);

end;

procedure DecodeVijener(FilePath1,FilePath2,key:string);
const
  alphlit='ÀÁÂÃÄÅ¨ÆÇÈÉÊËÌÍÎÏÐÑÒÓÔÕÖ×ØÙÚÛÜÝÞß';
  alphbig='àáâãäå¸æçèéêëìíîïðñòóôõö÷øùúûüýþÿ';
var
  i,j,k,m,n,p,MinInd1,MinInd2,index,index1,MinSymb:Integer;
  arr:array of array of char;
  cor:Boolean;
  F:TextFile;
  symbol,symbol2:char;
  sss,keyTemp,resultStr:string;
begin
  AssignFile(F,FilePath1);
  Reset(F);
  while(not Eof(F)) do
  begin
    read(F,symbol2);
    if ((symbol2>='À') and (symbol2<='ß')) or ((symbol2>='à') and (symbol2<='ÿ')) or (symbol2='¨') or (symbol2='¸') or (symbol2=' ') then
      sss:=sss+symbol2;
  end;
  //Readln(F,sss);
  CloseFile(F);
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
      writeln(resultStr);
end;

begin
  SetConsoleCP(1251);
  SetConsoleOutputCP(1251);

  Readln(str1);
  DecodeVijener('C:\merc.txt','C:\bmw.txt',str1);
  //DecodeColomns('C:\merc.txt',str1,str2);
  Writeln(str1);
  { TODO -oUser -cConsole Main : Insert code here }
  Readln;
end.
