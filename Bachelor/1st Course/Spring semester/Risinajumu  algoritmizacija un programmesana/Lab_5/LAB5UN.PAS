unit lab5un;
interface
uses LAB5IO;
type 
    MyRec = record
    name1: STR39;
    name2: STR39;
    end;

type Myfiletype = file of MyRec;

var MyFileERR: integer;

procedure Fcreate(var fff:Myfiletype; filename:string; var FileOpen: boolean);
procedure Fopenf ( var fff:Myfiletype;filename:string; var FileOpen:boolean);
procedure Fview  ( var fff:Myfiletype; FileOpen: boolean);
procedure FRwRec ( var fff:Myfiletype; Filename:string; FileOpen: boolean);
procedure FClose ( var fff:Myfiletype; var FileOpen: boolean);

implementation
uses CRT;

procedure Fcreate(var fff: Myfiletype; filename: string; var FileOpen: boolean);
var RC, n, i: integer;
    answer: string[1];
    rec: MyRec;
label BUILD;
begin
    assign(fff, filename);
    {$I-}
    RC:=13;
    reset(fff);
    {$I+}
    RC := ioresult;
    if (RC = 0) then
        if (FileRewr(filename) = FALSE) then
            begin
                close(fff);
                FileOpen := False;
                MyFileErr := 1;
                exit;
            end;

    {$I-}
    rewrite(fff);
    {$I+}
    if (IOResult <> 0) then begin
        MyFileErr := 3;
        FileOpen := False;
        exit;
        end;
        n := NumOfRec;

        Rec.Name1 := '                                              ';
        Rec.Name2 := '                                              ';
        for i := 0 to n do
        begin
            Rec.name1 := chr($61 + i);
            Rec.name2 := chr($30 + i);
            write(fff,Rec);
        end;
    close(fff);
    FileOpen:=False;
end;

(* -------------------------------------------------------------------------*)
procedure FOpenF( var fff:Myfiletype; filename:string; var FileOpen: boolean);
begin
    assign(fff, filename);
    {$I-}
    reset(fff);
    {$I+}
    if (ioresult = 0) then 
        FileOpen:=TRUE
    else begin
        FileOpen:=False;
        MyFileErr:=4;
    end;
end;

(*---------------------------------------------------------------------------*)
procedure Fview( var fff:Myfiletype; FileOpen: boolean);
var
    i: integer; rec: Myrec;
begin
    if (FileOpen = False) then
    begin
        WriteLntext(' Fails nav atverts ; Darbibu nevar izpildiit');
        exit;
    end;
    i:=0;
    seek(fff, i);
    while (eof(fff) <> TRUE) do
    begin
        read(fff,rec);
        WriteLnRec('Ieraksts #:', i,'     ',rec.name1, '  ', rec.name2);
        i := i + 1;
    end;
    seek(fff,0);
end;
(*----------------------------------------------------------------------------*)
procedure FRwRec( var fff:Myfiletype; filename:string; FileOpen: boolean);
var Rec:Myrec;
    i: integer;
    ddd:Myfiletype;
    nickname:string;

function AddNewFile(var ddd: Myfiletype; nickname: string; var FileOpen: boolean): boolean;
var RC, i: integer;
begin
    assign(ddd,n ickname);
    {$I-}
    RC := 13;
    reset(ddd);
    {$I+}
    RC := ioresult;
    if (RC=0) then
        if (FileRewr(nickname) = FALSE) then
        begin
            close(ddd);
            FileOpen:=False;
            MyFileErr:=1;
            exit;
        end;

    {$I-}
    rewrite(ddd);
    {$I+}
    if (IOResult <> 0) then begin
        MyFileErr := 3;
        FileOpen:=False;
        exit;
    end;

    close(ddd);
    AddNewFile := True;
    writeln ('izpildes fails tika izveidots');
end;

begin
    WriteLnText('Parrakstisanu veiksim pec PARA IERAKSTU POZICIJAM');
    WriteLnText('Ievadi izpildes faila vardu');
    Readln(nickname);
    AddNewFile(ddd, nickname, FileOpen);
    assign(ddd, nickname);
    reset(ddd);
    {$I-}
    i := 0;
    seek(fff, i);
    {$I+}
    if (ioresult = 0)
    then FileOpen:=TRUE
    else begin
        MyFileErr:=5;
        exit;
    end;

    while (eof(fff) <> TRUE) do
    begin
        seek(fff,i);
        read(fff,rec);
        WriteLnRec('Ieraksts #:', i,'     ',rec.name1, '  ', rec.name2);
        write(ddd,rec);
        i := i + 2;
    end;
    seek(fff,0);
    close(ddd);
end;

(*---------------------------------------------------------*)
procedure FClose( var fff:Myfiletype; var FileOpen: boolean);
begin
    if (FileOpen=False) then
    begin
        WriteLnText('Fails nav atverts; Darbibu nevar izpildiit');
        exit;
    end;
    WriteLnText(' Aizveram failu ');
    close(fff);
    FileOpen := False;
end;

begin
     MyFileErr:=0;
end.
