program FirstLaba;

{$APPTYPE CONSOLE}

uses
  SysUtils;

type
  TElement = record
  name:string;
  leftdist:byte;
  rightdist:Byte;
  end;

  TFloor = record
  number:string;
  color:string;
  MasElem:array[1..6] of TElement;
  end;

  TBuild = record
  Name:string;
  Floors:array[1..4] of TFloor;
  end;

procedure Mahf;
begin

end;

begin

end.