program Fin;

{$APPTYPE CONSOLE}

{$R *.res}

uses
  System.SysUtils;

{$APPTYPE CONSOLE}


type  PStack=^St;
  St=record
    Next:PStack;
    Prew:PStack;
    Elem:record
      Mean:Char;
      Pri:Integer;
    end;
  end;

const
  Priotity:array [1..7] of Char =('(',')','+','-','*','/','^');
  NumPrioruty:array [1..7] of Integer =(9,0,1,1,3,3,6);

 var
  vyrazh:string;
  p,y:PStack;
  s:string;
  i,j,iRes,elNum,sum:Integer;
  el:Char;
  res:array [1..1000] of Char;


begin
  New(p);
  p^.Elem.Pri:=-1;
  p^.Elem.Mean:='0';
  p^.Next:=nil;
  p^.Prew:=nil;
  write('Enter your expression:');
  Readln(s);
  iRes:=1;

  for i:=1 to Length(s) do
  begin
    j:=1;
    while (s[i]<>Priotity[j]) and (j<=7) do
      inc(j);
    if s[i]=Priotity[j] then
      elNum:=NumPrioruty[j]
    else
      elNum:=7;
    el:=s[i];
    if elNum>p^.Elem.Pri then
    begin
      New(p^.next);
      y:=p;
      p:=p^.Next;
      p^.Next:=nil;
      p^.Prew:=y;
      p^.Elem.Mean:=el;
      p^.Elem.Pri:=elNum+1;
      if (elNum=6) or (elNum=9) then
        if elNum=6 then
          p^.Elem.Pri:=5
        else
          p^.Elem.Pri:=0;
    end
    else
    begin
      while elNum<p^.Elem.Pri do
      begin
        res[iRes]:= p^.Elem.Mean;
        p:=p^.Prew;
        p^.Next:=nil;
        inc(iRes);
      end;
      if el<>')' then
      begin
        New(p^.next);
        y:=p;
        p:=p^.Next;
        p^.Next:=nil;
        p^.Prew:=y;
        p^.Elem.Mean:=el;
        p^.Elem.Pri:=elNum+1;
        if (elNum=6) or (elNum=9) then
          if elNum=6 then
            p^.Elem.Pri:=5
          else
            p^.Elem.Pri:=0;
      end
      else
      begin
        p:=p^.Prew;
        p^.Next:=nil;
      end;
    end;
  end;
  While p^.prew<>nil do
  begin
    res[iRes]:=p^.Elem.Mean;
    p:=p^.Prew;
    p^.Next:=nil;
    inc(iRes);
  end;
  Dec(iRes);
  for i:=1 to iRes do
    vyrazh:=vyrazh +' '+ Res[i];
  //Writeln;
  sum:=0;
  for i:=1 to iRes do
  begin
    j:=3;
    while (res[i]<>Priotity[j]) and (j<=7) do
      inc(j);

    if j<>8 then
      dec(sum)


    else

      inc(sum);


  end;

  if sum=1 then
      write('������� ���������� ���������')

  else
      writeln('������� ������������ ���������');
      writeln(vyrazh);



  Readln;
end.
