program Project2;

{
  Создать программу для изменения текстового файла F1,
  изменяя слова из файла F2, сохранив изменения в файл G
}

uses
  System.SysUtils;

// Объявление типа однонаправленного списка
Type
  Adr = ^Rep;
  Rep = record
    Words: String;
    AdrCled: Adr;
  end;

var
  F1, F2, G: TextFile;
  Adr1, AdrRep: Adr;
  // F1, F2 – исходные текстовые файлы
  // G – выходной текстовый файл
  // Adr1, AdrRep – укаатели на первое и текущее звено
  // списка

// Подпрограмма для создания первого звена
// однонаправленного списка
function ListCreate (var Adrec: Adr) :Adr;

Begin
  New(Adrec);
  Result:=Adrec;
  Adrec^.AdrCled:=Nil;
End;

// Подпрограмма для удаления всех звеньев
// однонаправленного списка
procedure ListClear (var AdrStart: Adr);
var
  Adrec: Adr;
Begin
  while AdrStart^.AdrCled<>Nil  do
  Begin
    Adrec:=AdrStart^.AdrCled;
    AdrStart^.AdrCled:=Adrec^.AdrCled;
    Dispose(Adrec);
  End;
End;

// Подпрограмма для добавления звена в однонаправленный
// список
Procedure NewZveno (var Addr: Adr;
                    S: String);

Begin
  New(Addr^.AdrCled);
  Addr:=Addr^.AdrCled;
  Addr^.Words:=S;
  Addr^.AdrCled:=Nil;
End;

// Подпрограмма для связывания файловой переменной и
// полного пути, введённого пользователем
procedure GetFile (var F: TextFile);

var
  Path: String;

Begin
  //Writeln('Укажите полный путь к файлу c расширением   ''txt'': ');
  // Проверка пути файла
  Repeat
    Readln(Path);
    If FileExists(Path) = False then
      Write('Некорректный путь, введите заново: ');
  Until FileExists(Path);

  AssignFile(F, Path);
End;

// Подпрограмма для получения пары заменяемых и заменяющих
// слов
procedure GetReplace (var Adrec: Adr;
                      var File2: TextFile);
var
  I, J: Integer;
  Temp: String;

Begin
  Reset(File2);
  Readln(File2, Temp);
  I:=0;

  // Индекс запятой в строке
  J:=Pos(',',Temp);
  // Цикл для добавления слова, пока в строке есть запятая
  while J <> 0  do
  Begin
    NewZveno(Adrec, Copy(Temp,1,J-1));
    Delete(Temp,1,J);
    Inc(I);
    J:=Pos(',',Temp);
  End;

  // Проверка количества слов на чётность
  if I mod 2 = 1 then
    NewZveno(Adrec,Temp);

End;

// Подпрограмма для вывода индекса входа подстроки
Function PosAfter (S: string;
                   Per: String;
                   var After: Integer): Integer;
var
  I1, I2: Integer;
  T1: String;

Begin
  // Копируем строку, начиная с индекса After
  T1:=Copy(Per,After,Length(Per)-After+1);
  // Переводим всю строку в нижний регистр
  T1:=AnsiLowerCase(T1);
  Result:=Pos(S,T1);
End;

// Подпрограмма для замены слов с помощью подпрограммы
// PosAfter, Insert, Copy
procedure Replaces2 (var File1, File3: TextFile;
                     Adrec: Adr);
var
  J: Integer;
  Temp: String;
  K, L: Integer;
  AdrStart, Adr2: Adr;

Begin
  Reset(File1);
  ReWrite(File3);
  K:=1;
  // Сохранение адреса первого звена
  AdrStart:=Adrec;

  // Цикл для прохода по всем строкам файла
  while not Eoln (File1) do
  Begin
    Readln(File1, Temp);

    // Цикл для прохода по всем заменяемым словам
    While Adrec<>nil do
    Begin
      J:=PosAfter(Adrec^.Words,Temp,K);

      // Цикл для прохода по строке, пока есть
      // заменяемые слова
      while J <> 0  do
      Begin
        Adr2:=Adrec^.AdrCled;
        L:=Length(Adrec^.Words);
        Delete(Temp,J,L);
        Insert(Adrec^.AdrCled^.Words,Temp,J);
        J:=PosAfter(Adrec^.Words,Temp,K);
      End;

      Adrec:=Adrec^.AdrCled^.AdrCled;
    End;

    // Изменение текущего звена на первое
    Adrec:=AdrStart;
    Writeln(File3, Temp);
  End;
End;

// Основная программа
begin
  Writeln('Введите полный путь к текстовому файлу, в котором необходимо заменить слова');
  GetFile(F1);

  Writeln('Введите полный путь к файлу, который содержит пары заменяемых и заменяющих слов');
  GetFile(F2);

  Writeln('Введите папку, в которую необходимо сохранить изменения');
  GetFile(G);

  AdrRep:=ListCreate(Adr1);
  GetReplace(AdrRep, F2);
  AdrRep:=Adr1^.AdrCled;

  Replaces2(F1, G, AdrRep);
  ListClear(Adr1);

  Write('The end');
  Close(F1);
  Close(F2);
  Close(G);
  Readln;
end.

