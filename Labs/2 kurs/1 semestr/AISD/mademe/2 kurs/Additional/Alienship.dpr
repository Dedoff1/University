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
  writeln('Выйти из комнаты?');
  writeln('1. Да');
  writeln('2. Нет');
  repeat
  readln(exitenter);
  until (exitenter <> 1) or (exitenter <> 2);
  if exitenter = 2  then
  begin
    count:=count+1;
    if count >= 5 then
    begin
      writeln('Камера внезапно закрывается');
      readln;
      writeln('Похоже у вас нет шансов сбежать...');
      readln;
      writeln('Вы остались в стенах комлекса навечно');
      readln;
      writeln('Кто знает, как могли сложиться обстаятельства, если бы вы приняли иные решения...');
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
   writeln('Когда вы подходите к заветному выходу, вы слышите за своей спиной ужасный рык');
   readln;
   writeln('Обернувшись, вы в страхе устремляете свой взгляд на ужасное существо, описать которое вы не в силах');
   readln;
   writeln('Оно смотрим на вас');
   readln;
   writeln('И вдруг...');
   readln;
   writeln('Существо издает отвратительный звук и прыгает на вас');
   readln;
   writeln('Вы отталкиваете существо и выбегаете в дверь');
   readln;
   writeln('Дверь за вами закрывается, оставляя существо , как вам хочется надеется, навечно внутри');
   readln;
   writeln('Вы с облегчением вздыхаете и осматривате себя');
   readln;
   if armor = True then
   begin
    writeln('К вашему удивлению, существо не смогло порвать костюм, и вы остались полностью невредимы');
    readln;
    writeln('Вы отправляетесь вперед, чтобы узнать, почему вы оказались в этом комплексе...');
    readln;
    writeln('Вы выбрались с корабля и остались целы');
    readln;
    writeln('Кто знает, как могли сложиться обстаятельства, если бы вы приняли иные решения...');
    readln;
   end
   else
    begin
    writeln('Все ваше тело покрыто ранами и отовсюду течет кровь');
    readln;
    writeln('Вы делаете несколько шагов и теряете сознание');
    readln;
    writeln('Вы выбрались с корабля, но погибли от ран');
    readln;
    writeln('Кто знает, как могли сложиться обстаятельства, если бы вы приняли иные решения...');
    readln;
    end;
   halt;
  end
  else
  begin
  writeln('Вы подходите к странной двери, на ней видны отметины напоминающие огромные когти');
  readln;
  writeln('Что за существо могло оставить такие отметины?');
  readln;
  writeln('Над дверью горит надпись:');
  readln;
  writeln('АВАРИЙНАЯ БЛОКИРОВКА ВКЛЮЧЕНА');
  readln;
  writeln('Необходимо найти способ открыть эту дверь');
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
    writeln('Здесь больше нет ничего полезного');
    readln;
  end
  else
  begin
  writeln('Вы подходите к загадочной двери');
  readln;
  writeln('Около нее расположен кодовый замок из 4-х символов');
  readln;
  writeln('Попробовать ввести?');
  writeln('1. Да');
  writeln('2. Нет');
  repeat
    readln(entermed);
  until (entermed <> 1) or (entermed <> 2);
  if entermed = 1 then
  begin
     writeln('Введите код');
     readln(entermed);
     if entermed = 1375 then
     begin
        writeln('Издается странный звук, после чего дверь открывается');
        readln;
        writeln('Вы заходите внутрь, где обнаруживаете странное медицинское оборудование');
        readln;
        writeln('Ваше внимание привлекает прибор, напоминающий сканнер');
        readln;
        writeln('Просканировать себя?');
        writeln('1. Да');
        writeln('2. Нет');
        repeat
        readln(entermed);
        until (entermed <> 1) or (entermed <> 2);
        if entermed = 1 then
        begin
          writeln('Прибор издает множество странных звуков, после чего замолкает');
          readln;
          writeln('На экране сканера выводится множество данных, однако вас заинтересовывает одна из записей:');
          readln;
          writeln('...СТАТУС: ЗАРАЖЕН, ...');
          readln;
          writeln('Вас наполняет паника, однако...');
          readln;
          writeln('Вы замечаете на экране появившуюся кнопку');
          readln;
          writeln('ВВЕСТИ ИНЬЕКЦИЮ');
          readln;
          writeln('Нажать на кнопку?');
          writeln('1. Да');
          writeln('2. Нет');
          repeat
          readln(entermed);
          until (entermed <> 1) or (entermed <> 2);
          if entermed = 1 then
          begin
            writeln('Сверху спускается большая игла, которая молниеносно всаживается вам в руку');
            readln;
            writeln('Вы чувствуете некое изменение внутри себя');
            readln;
            health := True;
            writeln('Сразу после укола сканнер снова запускается и выдает все теже значения...');
            readln;
            writeln('Кроме одного...');
            readln;
            writeln('...СТАТУС: ОЧИЩЕН, ...');
            readln;
            writeln('Вы испытываете облегчение');
            readln;
            writeln('Вы выходите из комнаты');
          end
          else
          begin
           writeln('Вы отходите от прибора и выходите из комнаты');
           readln;
           writeln('Вы испытываете сильную тревогу');
           readln;
          end;
        end;
     end
     else
        begin
         writeln('Издается странный звук, после чего высвечивается запись:');
         readln;
         writeln('ДОСТУП ЗАПРЕЩЕН');
         readln;
         writeln('Нужно найти способ узнать верный код');
         readln;
        end;
  end
  else
  begin
  writeln('Вы отходите от двери');
  readln;
  end;
  end;
  floor2map;
end;
procedure cell1;
begin
  writeln('Комната пуста');
  readln;
  writeln('Похоже здесь содержали кого-то...');
  readln;
  writeln('или что-то');
  readln;
  floor1map;
end;
procedure cell2;
begin
  writeln('Комната пуста');
  readln;
  writeln('Похоже здесь содержали кого-то...');
  readln;
  writeln('или что-то');
  readln;
  floor2map;
end;
procedure cell3;
begin
  writeln('Комната пуста');
  readln;
  writeln('Похоже здесь содержали кого-то...');
  readln;
  writeln('или что-то');
  readln;
  floor3map;
end;
procedure room;
begin
  writeln('Дверь открывается перед вами');
  readln;
  writeln('За ней находится комната, наполненная разнообразными вещами');
  readln;
  writeln('Помимо всего прочего вы замечаете стэнд с непонятными записями');
  readln;
  writeln('Единственное, что вы можете понять, это три цифры в самом конце...');
  readln;
  writeln('1375');
  readln;
  writeln('Интересно, что они могут значить?');
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
   writeln('Используя лестницу вы попадаете на 1 этаж');
   readln;
 end;
 if map1 = false then
 begin
  writeln('Вы находитесь в темном коридоре. Кажется, на стене напротив вас что-то есть...');
  readln;
  writeln('Это карта 1 этажа');
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
    writeln('Используя лестницу вы попадаете на 3 этаж');
    readln;
   end;
   if map3 = false then
   begin
    writeln('Вы находитесь в темном коридоре. Кажется, на стене напротив вас что-то есть...');
    readln;
    writeln('Это карта 3 этажа');
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
    writeln('Используя лестницу вы попадаете на 2 этаж');
    readln;
   end;
   if map2 = false then
   begin
    writeln('Вы находитесь в темном коридоре. Кажется, на стене напротив вас что-то есть...');
    readln;
    writeln('Это карта 2 этажа');
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
    writeln('Здесь больше нет ничего полезного');
    readln;
  end
  else
  begin
  writeln('Вы подходите к странной двери черного цвета, она сделана из материала, которого вы никогда не видели...');
  readln;
  writeln('Рядом с дверью находится небольшой сканнер');
  readln;
  writeln('Использовать его?');
  writeln('1. Да');
  writeln('2. Нет');
  repeat
   readln(enterdock);
  until (enterdock <> 1) or (enterdock <> 2);
  if enterdock = 1 then
  begin
   writeln('Вы подносите к нему руку...');
   if health = true then
   begin
    writeln('СТАТУС: ОЧИЩЕН');
    readln;
    writeln('ДОСТУП РАЗРЕШЕН');
    readln;
    writeln('Дверь открывается и вы входите внутрь');
    readln;
    writeln('Вы устремляете свой взгляд на главную панель');
    readln;
    writeln('Здесь указан список дверей всего комплекса');
    readln;
    writeln('Все двери указаны как открытые, кроме трех...');
    readln;
    writeln('ВЫХОД ИЗ КОМПЛЕКСА: АВАРИЙНАЯ БЛОКИРОВКА');
    writeln('ОРУЖЕЙНАЯ: АВАРИЙНАЯ БЛОКИРОВКА');
    writeln('КОМНАТА СОДЕРЖАНИЯ: АВАРИЙНАЯ БЛОКИРОВКА');
    readln;
    writeln('Внизу подпись: СНЯТИЕ БЛОКИРОВКИ');
    readln;
    writeln('Нажать на кнопку?');
    writeln('1. Да');
    writeln('2. Нет');
    repeat
     readln(enterdock);
    until (enterdock <> 1) or (enterdock <> 2);
    if enterdock = 1 then
    begin
     writeln('Панель издает странные звуки');
     readln;
     electricity:= true;
     writeln('БЛОКИРОВКА СНЯТА');
     readln;
     writeln('Вдруг вы слишите, как вдалеке издается громкий рык');
     readln;
     writeln('Вам становится не по себе...');
     readln;
     writeln('Вы выходите из комнаты');
     readln;
    end
    else
    begin
     writeln('Вы отходите от панели и выходите из комнаты');
     readln;
    end;
   end
   else
   begin
    writeln('СТАТУС: ЗАРАЖЕН');
    readln;
    writeln('ДОСТУП ЗАПРЕЩЕН');
    readln;
    writeln('Вас наполняет страх');
    readln;
    writeln('Необходимо найти способ вылечиться и открыть эту дверь');
    readln;
   end;
  end
  else
  begin
   writeln('Вы отходите от двери');
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
    writeln('Здесь больше нет ничего полезного');
    readln;
  end
  else
  begin
  writeln('Вы подходите к двери, украшенной странными узорами');
  readln;
  if electricity = True then
  begin
    writeln('Дверь открывается и вы заходите внутрь');
    readln;
    writeln('Комната наполнена различным снаржением');
    readln;
    writeln('Вы устремляете свой взор на странный костюм посередине комнаты');
    readln;
    writeln('Одеть его?');
    writeln('1. Да');
    writeln('2. Нет');
    repeat
     readln(enterweapon);
    until (enterweapon <> 1) or (enterweapon <> 2);
    if enterweapon = 1 then
    begin
      writeln('Вы одеваете костюм на себя...');
      readln;
      writeln('В нем вы чувствуете себя безопастнее');
      readln;
      writeln('Вы выходите из комнаты');
      armor:=True;
    end
    else
    begin
      writeln('Вы выходите из комнаты');
      readln;
      writeln('Вас не покидают мысли о таинственном костюме');
      readln;
    end;
  end
  else
  begin
  writeln('Над дверью горит надпись:');
  readln;
  writeln('АВАРИЙНАЯ БЛОКИРОВКА ВКЛЮЧЕНА');
  readln;
  writeln('Необходимо найти способ открыть эту дверь');
  readln;
  end;
  end;
  floor3map;
end;
procedure floor3map;
var
enter1: integer;
begin
 writeln('1. Лестница на 2 этаж');
 writeln('2. Оружейная');
 writeln('3. Диспетчерская');
 writeln('4. Камера заключения');
 writeln('Куда идти?');
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
 writeln('1. Лестница на 1 этаж');
 writeln('2. Медпункт');
 writeln('3. Лестница на 3 этаж');
 writeln('4. Камера заключения');
 writeln('Куда идти?');
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
 writeln('1. Выход');
 writeln('2. Каюты');
 writeln('3. Лестница на 2 этаж');
 writeln('4. Камера заключения');
 writeln('Куда идти?');
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
 writeln('Вы просыпаетесь в темной камере, лишь тусклый свет из иллюминатора чуть освещает помещение');
 readln;
 writeln('Какого цвета этот свет?');
 writeln('1. Зеленый');
 writeln('2. Красный ');
 writeln('3. Желтый');
 repeat
  readln(floor);
  until (floor >= 1) and (floor <= 3);
 writeln('Вдруг вся камера начинает дрожать, и дверь перед вами открывается');
 readln;
 writeln('Приятной игры');
 readln;
 case floor of
 1: floor1;
 2: floor2;
 3: floor3;
 end;
end.
