program Alienship;

{$APPTYPE CONSOLE}

{$R *.res}

uses
  System.SysUtils;
var
floor,count: integer;
health, armor, electricity,enter, map1,map2,map3: boolean;
procedure floor1map; forward;
procedure floor2map; forward;
procedure floor3map; forward;
procedure exitroom;

var
exitenter : integer;
begin
  writeln('����� �� �������?');
  writeln('1. ��');
  writeln('2. ���');
  repeat
  readln(exitenter);
  until (exitenter <> 1) or (exitenter <> 2);
  if exitenter = 2  then
  begin
    count:=count+1;
    if count >= 5 then
    begin
      writeln('������ �������� �����������');
      readln;
      writeln('������ � ��� ��� ������ �������...');
      readln;
      writeln('�� �������� � ������ �������� �������');
      readln;
      writeln('��� �����, ��� ����� ��������� ��������������, ���� �� �� ������� ���� �������...');
      readln;
      halt;
    end
    else
    begin
    sleep(3500);
    exitroom;
    end;
  end;
end;

procedure exitship(card:boolean);
begin
  if  electricity = True then
  begin
   writeln('����� �� ��������� � ��������� ������, �� ������� �� ����� ������ ������� ���');
   readln;
   writeln('�����������, �� � ������ ����������� ���� ������ �� ������� ��������, ������� ������� �� �� � �����');
   readln;
   writeln('��� ������� �� ���');
   readln;
   writeln('� �����...');
   readln;
   writeln('�������� ������ �������������� ���� � ������� �� ���');
   readln;
   writeln('�� ������������ �������� � ��������� � �����');
   readln;
   writeln('����� �� ���� �����������, �������� �������� , ��� ��� ������� ��������, ������� ������');
   readln;
   writeln('�� � ����������� ��������� � ����������� ����');
   readln;
   if armor = True then
   begin
    writeln('� ������ ���������, �������� �� ������ ������� ������, � �� �������� ��������� ���������');
    readln;
    writeln('�� ������������� ������, ����� ������, ������ �� ��������� � ���� ���������...');
    readln;
    writeln('�� ��������� � ������� � �������� ����');
    readln;
    writeln('��� �����, ��� ����� ��������� ��������������, ���� �� �� ������� ���� �������...');
    readln;
   end
   else
    begin
    writeln('��� ���� ���� ������� ������ � �������� ����� �����');
    readln;
    writeln('�� ������� ��������� ����� � ������� ��������');
    readln;
    writeln('�� ��������� � �������, �� ������� �� ���');
    readln;
    writeln('��� �����, ��� ����� ��������� ��������������, ���� �� �� ������� ���� �������...');
    readln;
    end;
   halt;
  end
  else
  begin
  writeln('�� ��������� � �������� �����, �� ��� ����� �������� ������������ �������� �����');
  readln;
  writeln('��� �� �������� ����� �������� ����� ��������?');
  readln;
  writeln('��� ������ ����� �������:');
  readln;
  writeln('��������� ���������� ��������');
  readln;
  writeln('���������� ����� ������ ������� ��� �����');
  readln;
  floor1map;
  end;
end;
procedure medroom;
var
entermed: integer;
begin
  if health=true then
  begin
    writeln('����� ������ ��� ������ ���������');
    readln;
  end
  else
  begin
  writeln('�� ��������� � ���������� �����');
  readln;
  writeln('����� ��� ���������� ������� ����� �� 4-� ��������');
  readln;
  writeln('����������� ������?');
  writeln('1. ��');
  writeln('2. ���');
  repeat
    readln(entermed);
  until (entermed <> 1) or (entermed <> 2);
  if entermed = 1 then
  begin
     writeln('������� ���');
     readln(entermed);
     if entermed = 1375 then
     begin
        writeln('�������� �������� ����, ����� ���� ����� �����������');
        readln;
        writeln('�� �������� ������, ��� ������������� �������� ����������� ������������');
        readln;
        writeln('���� �������� ���������� ������, ������������ �������');
        readln;
        writeln('�������������� ����?');
        writeln('1. ��');
        writeln('2. ���');
        repeat
        readln(entermed);
        until (entermed <> 1) or (entermed <> 2);
        if entermed = 1 then
        begin
          writeln('������ ������ ��������� �������� ������, ����� ���� ���������');
          readln;
          writeln('�� ������ ������� ��������� ��������� ������, ������ ��� ���������������� ���� �� �������:');
          readln;
          writeln('...������: �������, ...');
          readln;
          writeln('��� ��������� ������, ������...');
          readln;
          writeln('�� ��������� �� ������ ����������� ������');
          readln;
          writeln('������ ��������');
          readln;
          writeln('������ �� ������?');
          writeln('1. ��');
          writeln('2. ���');
          repeat
          readln(entermed);
          until (entermed <> 1) or (entermed <> 2);
          if entermed = 1 then
          begin
            writeln('������ ���������� ������� ����, ������� ����������� ����������� ��� � ����');
            readln;
            writeln('�� ���������� ����� ��������� ������ ����');
            readln;
            health := True;
            writeln('����� ����� ����� ������� ����� ����������� � ������ ��� ���� ��������...');
            readln;
            writeln('����� ������...');
            readln;
            writeln('...������: ������, ...');
            readln;
            writeln('�� ����������� ����������');
            readln;
            writeln('�� �������� �� �������');
          end
          else
          begin
           writeln('�� �������� �� ������� � �������� �� �������');
           readln;
           writeln('�� ����������� ������� �������');
           readln;
          end;
        end;
     end
     else
        begin
         writeln('�������� �������� ����, ����� ���� ������������� ������:');
         readln;
         writeln('������ ��������');
         readln;
         writeln('����� ����� ������ ������ ������ ���');
         readln;
        end;
  end
  else
  begin
  writeln('�� �������� �� �����');
  readln;
  end;
  end;
  floor2map;
end;
procedure cell1;
begin
  writeln('������� �����');
  readln;
  writeln('������ ����� ��������� ����-��...');
  readln;
  writeln('��� ���-��');
  readln;
  floor1map;
end;
procedure cell2;
begin
  writeln('������� �����');
  readln;
  writeln('������ ����� ��������� ����-��...');
  readln;
  writeln('��� ���-��');
  readln;
  floor2map;
end;
procedure cell3;
begin
  writeln('������� �����');
  readln;
  writeln('������ ����� ��������� ����-��...');
  readln;
  writeln('��� ���-��');
  readln;
  floor3map;
end;
procedure room;
begin
  writeln('����� ����������� ����� ����');
  readln;
  writeln('�� ��� ��������� �������, ����������� �������������� ������');
  readln;
  writeln('������ ����� ������� �� ��������� ����� � ����������� ��������');
  readln;
  writeln('������������, ��� �� ������ ������, ��� ��� ����� � ����� �����...');
  readln;
  writeln('1375');
  readln;
  writeln('���������, ��� ��� ����� �������?');
  readln;
  floor1map;
end;
procedure floor1;
begin
 if enter = false then
 begin
 exitroom;
 enter := true;
 end
 else
 begin
   writeln('��������� �������� �� ��������� �� 1 ����');
   readln;
 end;
 if map1 = false then
 begin
  writeln('�� ���������� � ������ ��������. �������, �� ����� �������� ��� ���-�� ����...');
  readln;
  writeln('��� ����� 1 �����');
  readln;
  map1 := True;
 end;
 floor1map;
end;
procedure floor3;
begin
   if enter = false then
   begin
    exitroom;
    enter := true;
   end
   else
   begin
    writeln('��������� �������� �� ��������� �� 3 ����');
    readln;
   end;
   if map3 = false then
   begin
    writeln('�� ���������� � ������ ��������. �������, �� ����� �������� ��� ���-�� ����...');
    readln;
    writeln('��� ����� 3 �����');
    readln;
    map3 := True;
   end;
   floor3map;
end;
procedure floor2;
begin
   if enter = false then
   begin
    exitroom;
    enter := true;
   end
   else
   begin
    writeln('��������� �������� �� ��������� �� 2 ����');
    readln;
   end;
   if map2 = false then
   begin
    writeln('�� ���������� � ������ ��������. �������, �� ����� �������� ��� ���-�� ����...');
    readln;
    writeln('��� ����� 2 �����');
    readln;
    map2 := True;
   end;
   floor2map;

end;
procedure dockroom;
var
enterdock: integer;
begin
  if electricity=true then
  begin
    writeln('����� ������ ��� ������ ���������');
    readln;
  end
  else
  begin
  writeln('�� ��������� � �������� ����� ������� �����, ��� ������� �� ���������, �������� �� ������� �� ������...');
  readln;
  writeln('����� � ������ ��������� ��������� �������');
  readln;
  writeln('������������ ���?');
  writeln('1. ��');
  writeln('2. ���');
  repeat
   readln(enterdock);
  until (enterdock <> 1) or (enterdock <> 2);
  if enterdock = 1 then
  begin
   writeln('�� ��������� � ���� ����...');
   if health = true then
   begin
    writeln('������: ������');
    readln;
    writeln('������ ��������');
    readln;
    writeln('����� ����������� � �� ������� ������');
    readln;
    writeln('�� ����������� ���� ������ �� ������� ������');
    readln;
    writeln('����� ������ ������ ������ ����� ���������');
    readln;
    writeln('��� ����� ������� ��� ��������, ����� ����...');
    readln;
    writeln('����� �� ���������: ��������� ����������');
    writeln('���������: ��������� ����������');
    writeln('������� ����������: ��������� ����������');
    readln;
    writeln('����� �������: ������ ����������');
    readln;
    writeln('������ �� ������?');
    writeln('1. ��');
    writeln('2. ���');
    repeat
     readln(enterdock);
    until (enterdock <> 1) or (enterdock <> 2);
    if enterdock = 1 then
    begin
     writeln('������ ������ �������� �����');
     readln;
     electricity:= true;
     writeln('���������� �����');
     readln;
     writeln('����� �� �������, ��� ������� �������� ������� ���');
     readln;
     writeln('��� ���������� �� �� ����...');
     readln;
     writeln('�� �������� �� �������');
     readln;
    end
    else
    begin
     writeln('�� �������� �� ������ � �������� �� �������');
     readln;
    end;
   end
   else
   begin
    writeln('������: �������');
    readln;
    writeln('������ ��������');
    readln;
    writeln('��� ��������� �����');
    readln;
    writeln('���������� ����� ������ ���������� � ������� ��� �����');
    readln;
   end;
  end
  else
  begin
   writeln('�� �������� �� �����');
   readln;
  end;
  end;
  floor3map;
end;
procedure weaponroom;
var
enterweapon: integer;
begin
  if armor=true then
  begin
    writeln('����� ������ ��� ������ ���������');
    readln;
  end
  else
  begin
  writeln('�� ��������� � �����, ���������� ��������� �������');
  readln;
  if electricity = True then
  begin
    writeln('����� ����������� � �� �������� ������');
    readln;
    writeln('������� ��������� ��������� ����������');
    readln;
    writeln('�� ����������� ���� ���� �� �������� ������ ���������� �������');
    readln;
    writeln('����� ���?');
    writeln('1. ��');
    writeln('2. ���');
    repeat
     readln(enterweapon);
    until (enterweapon <> 1) or (enterweapon <> 2);
    if enterweapon = 1 then
    begin
      writeln('�� �������� ������ �� ����...');
      readln;
      writeln('� ��� �� ���������� ���� �����������');
      readln;
      writeln('�� �������� �� �������');
      armor:=True;
    end
    else
    begin
      writeln('�� �������� �� �������');
      readln;
      writeln('��� �� �������� ����� � ������������ �������');
      readln;
    end;
  end
  else
  begin
  writeln('��� ������ ����� �������:');
  readln;
  writeln('��������� ���������� ��������');
  readln;
  writeln('���������� ����� ������ ������� ��� �����');
  readln;
  end;
  end;
  floor3map;
end;
procedure floor3map;
var
enter1: integer;
begin
 writeln('1. �������� �� 2 ����');
 writeln('2. ���������');
 writeln('3. �������������');
 writeln('4. ������ ����������');
 writeln('���� ����?');
  repeat
  readln(enter1);
  until (enter1 >= 1) and (enter1 <= 4);
  case enter1 of
  1: floor2;
  2: weaponroom;
  3: dockroom;
  4: cell3;
  end;
end;
procedure floor2map;
var
enter1: integer;
begin
 writeln('1. �������� �� 1 ����');
 writeln('2. ��������');
 writeln('3. �������� �� 3 ����');
 writeln('4. ������ ����������');
 writeln('���� ����?');
  repeat
  readln(enter1);
  until (enter1 >= 1) and (enter1 <= 4);
  case enter1 of
  1: floor1;
  2: medroom;
  3: floor3;
  4: cell2;
  end;
end;


procedure floor1map;
var
enter1: integer;
begin
 writeln('1. �����');
 writeln('2. �����');
 writeln('3. �������� �� 2 ����');
 writeln('4. ������ ����������');
 writeln('���� ����?');
  repeat
  readln(enter1);
  until (enter1 >= 1) and (enter1 <= 4);
  case enter1 of
  1: exitship(True);
  2: room;
  3: floor2;
  4: cell1;
  end;
end;


begin
 count:=0;
 health :=false;
 armor := false;
 electricity := false;
 enter := false;
 map1 := false;
 map2 := false;
 map3 := false;
 writeln('�� ������������ � ������ ������, ���� ������� ���� �� ������������ ���� �������� ���������');
 readln;
 writeln('������ ����� ���� ����?');
 writeln('1. �������');
 writeln('2. ������� ');
 writeln('3. ������');
 repeat
  readln(floor);
  until (floor >= 1) and (floor <= 3);
 writeln('����� ��� ������ �������� �������, � ����� ����� ���� �����������');
 readln;
 writeln('�������� ����');
 readln;
 case floor of
 1: floor1;
 2: floor2;
 3: floor3;
 end;
end.
