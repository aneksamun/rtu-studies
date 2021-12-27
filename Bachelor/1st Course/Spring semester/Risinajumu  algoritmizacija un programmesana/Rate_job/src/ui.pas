unit ui;

INTERFACE
uses crt, utils;
Type
    MenuType = (Vertical);
Const
    width = 50;
    Items1 = 8;

    optText1: array [0..Items1-1] of string =
    ('.:[ apskatit datu bazes saturu ]:.',
     '.:[ ierakstit jaunu informaciju ]:.',
     '.:[ dzest ierakstu ]:.',
     '.:[ koriget informaciju ]:.',
     '.:[ sakartot informaciju faila ]:.',
     '.:[ atrast visas brivas istabas ]:.',
     '.:[ atrast informaciju par visdargako numuru ]:.',
     '.:[ exit ]:.');

    optNormal = 1;
    optSelected = white;

Const
    Max = 100;
    filename = 'hotel.txt';

type
    Data = array [1..Max] of ^Outlaw;
    Outlaw = record
        Vards     : string[12];
        Uzvards   : string[12];
        Numurs    : integer;
        Istabas   : integer;
        Stavoklis : string[12];
        Cena      : real;
    end;

  MyFile = File of Outlaw;

var
    X, Y,
    selected,
    row: integer;
    _style: menuType;
    Textfile: myfile;
    chapter: byte;
    records: data;
    code: integer;
    ch: char;

procedure content (var textfile: myfile; filename: string);
procedure addrecords(var textfile: MyFile; filename: string);
procedure discharge (var textfile: myfile; filename: string);
procedure position (var textfile : MyFile);
procedure Sort (var textfile: myfile; filename: string);
Procedure expensive (var textfile : myfile; filename : string);
procedure correct (var textfile: myfile;  filename: string);
procedure search (var textfile : myfile; filename : string);
procedure menu;

IMPLEMENTATION

procedure position (var textfile: MyFile);
var
    rec: Outlaw;
begin
    assign (textfile, filename);
    {$I-}
    reset (textfile);
    {$I+}
    Clrscr;
    if (ioresult <> 0) then
    begin
        chapter := 1; 
        exit;
    end;
    {$I-}
    read (textfile, REC);
    {$I+}
    if IOresult <> 0 then
    begin
        chapter:=2; 
        close(textfile); 
        exit;
    end;
    chapter := 0;
    close(textfile);
end;

(*-----------------------------------------------------------------------*)

procedure content (var textfile: myfile; filename: string);
var i: integer; REC: Outlaw;
    curr_pos:  integer;
    refresh: boolean;
begin
    Clrscr;
    {$I-}
    assign (textfile, filename);
    reset (textfile);
    {$I+}
    seek (textfile, 0);
    CLRSCR;
    TextColor (blue);
    Textbackground(White); Clrscr;
    writeln  ('-------------------------------------------------------------------------------');
    writeln  (' Nr    Vards       Uzvards    Numurs   Brivs numurs   Istabu skaits    cena    ');
    writeln  ('-------------------------------------------------------------------------------');
    gotoXY (5,22);
    Textcolor (white);
    Textbackground (6);
    write ('Jus varat apskatit visu sarakstu lietojot bultinas "->" un "<-"');
    gotoXY (30,24);
    write ('ESC - iziet izvelnee');
    textbackground (white);textcolor(black);
    window (1,4,80,19);
    curr_pos := 0;

    refresh := true;
    repeat
        if refresh then begin
            seek(textfile, curr_pos);
            i := 1;
            Inproc := False;
            repeat
                {$I-}
                read (textfile, REC);
                {$I+}
                with REC do begin
                    textcolor (black);
                    if curr_pos + i <= 9 then
                        writeln (' ',curr_pos + i,'   ',(Vards):7,' ',Uzvards:7,' ',Numurs:3,'   ',stavoklis:10,' ',istabas:14,' ',Cena:14:2)
                    else writeln (curr_pos + i,'   ',(Vards):6,' ',Uzvards:6,' ',Numurs:3,'  ',stavoklis:11,' ',istabas:14,' ',Cena:14:2);
                    inc (i);
                end;
            until (i > 15) or (eof (textfile));
            refresh := false;
        end;
        case ord(readkey) of
            77 : begin
                if curr_pos + 15 < filesize(textfile) then begin
                inc(curr_pos, 15); refresh := true;  end;
                end;
            75 : begin
                if curr_pos - 15 >= 0 then begin
                dec(curr_pos, 15); refresh := true; end;
                end;
            27 : begin window(1,1,80,25); Clrscr; Inproc:=True; Exit;  end;
        end;
    until false;
    window (1,22,80,23); 
    Clrscr;
    close (textfile);
    textcolor (black);
    textbackground(white);
    Window(1, 1, 80, 25);
end;

(*------------------------------------------------------------------------*)

Procedure addrecords (var textfile: MyFile; filename: string);
var
    rec: Outlaw;
    str: string;
    ms: array [1..6] of boolean;
    sum: integer;
    quit: boolean;
    TypeofS: boolean;
    i: integer;

Procedure View;
var
    command: integer;
    ch : char;
    change: boolean;
    y, x, i: integer;

    procedure clean;
    var
        y1: integer;
    begin
        for y1:=7 to 17 do
        begin
            Textcolor (white); Textbackground(white);
            GotoXY (20,y1); write ('     ');
        end;
        textcolor(white);
    end;

begin
    sum := 0;
    command := 1;
    y := 7;
    x := 25;

   Textbackground(white);
   gotoXY(20,4);
   TextColor (white);Textbackground(6);
   Write (' Datus ir jaievada atbilstosos laukos');
   Textcolor (blue);Textbackground(white);
   gotoXY(25,7);
   write ('Ievadiet vardu: '); textbackground(6); write ('            ');Textbackground(white);
   gotoXY(25,9);
   write ('Ievadiet uzvardu: '); textbackground(6); write ('            ');Textbackground(white);
   gotoXY(25,11);
   write ('Ievadiet numuru: '); textbackground(6); write ('    ');Textbackground(white);
   gotoXY(25,13);
   write ('Ievadiet istabu skaitu numuraa: '); textbackground(6); write ('   ');Textbackground(white);
   gotoXY(25,15);
   write ('Vai numurs ir brivs? Ja/ne? '); textbackground(6); write ('    ');Textbackground(white);
   gotoXY(25,17);
   write ('Ievadiet cenu par diennakti: '); textbackground (6); write ('   ');Textbackground(white);
   gotoXY (20,19);
   Textbackground (6);Textcolor (white);
   Write ('Uzpiediet enter pirms un pec lauka ievadisanas');textbackground(white);
   gotoXY (30,21);
   Textbackground (6);Textcolor (white);
   Write ('Esc - iziet izvelnee');textbackground(white);

    While True do
    begin
        quit:=false;
        ch:=readkey;
        if (sum=6) then Exit;
        if ord(ch) = 27 then begin Quit:=True; Exit; end;
        if ord(ch) = 72 then
        begin
            if (command <> 1) then dec (command)
            else command:= 6;
        end
        else if ord(ch) = 80 then
        begin
            if command <> 6 then inc(command)
            else command:=1;
        end else if ord(ch) = 13 then
        begin
            case command of
            1 : begin
                    str := '';
                    ShowCursor;
                    gotoXY(41,7);textbackground(6); 
                    write ('            '); 
                    gotoXY(41,7);
                    TypeofS := True; 
                    InputCheck(str, 12, TypeofS);
                    hidecursor;
                    Rec.vards := str;
                    if InProc then begin 
                        Close(textfile); 
                        Exit; 
                    end;
                    textbackground(white);
                    ms[command] := True;
                end;

            2 : begin
                    Showcursor;
                    gotoXY(43,9);textbackground(6); 
                    write ('            ');
                    gotoXY(43,9);
                    TypeofS := True;
                    InputCheck(str, 12, TypeofS);
                    hidecursor;
                    If InProc then begin 
                        Close(textfile); 
                        Exit; 
                    end;
                    Rec.uzvards := str;
                    textbackground(white);
                    ms[command] := True;
                end;

            3 : begin
                    Showcursor;
                    TypeOfS := False; gotoXY(42,11);textbackground(6); write ('    '); gotoxy(42,11);
                    InputCheck(str, 3, TypeOfS);
                    hidecursor;
                    If InProc then begin Close(textfile); Exit; end;
                    Val (str, Rec.Numurs, Code);
                    textbackground(white);
                    ms[command] := True;
                end;

            4 : begin
                    Showcursor;
                    gotoXY(57,13); textbackground(6); write('   '); gotoXY(57, 13);
                    TypeOfS := False; InputCheck(str, 2, TypeOfS);
                    hidecursor;
                    If InProc then begin Close(textfile); Exit; end;
                    Val (str, Rec.istabas,Code);
                    textbackground (white);
                    ms[command] := True;
                end;

            5 : begin
                    Showcursor;
                    textbackground(6); gotoXY(53,15); write ('    '); gotoXY(53, 15);
                    TypeOfS := true; InputCheck(str,2,TypeOfS); hidecursor;
                    If InProc then begin Close(textfile); Exit; end;
                    If ((str <> 'Ja') and (str <> 'Ne')) then
                    begin
                        gotoxy(5, 23);
                        Textbackground(lightgreen); textcolor(31);
                        write (' Jums ir jaievada "Ja" vai "Ne", spiediet taustinu un tad spiediet enter');
                        Textbackground (white); textcolor (white);
                        readkey;
                        gotoXY(1,23); ClrEOL;
                    end
                    else begin
                        Rec.stavoklis := str;
                        textbackground(white);
                        ms[command] := True;
                    end;
                end;

            6 : begin
                    Showcursor;
                    gotoXY(54, 17); TypeOfS := False; Textbackground(6); write('   '); gotoXY(54, 17);
                    TypeOfS := False; InputCheck(str, 3, TypeOfS);
                    If InProc then begin Close(textfile); Exit; end;
                    textbackground(white);
                    Val (str, Rec.cena, Code);
                    ms[command] := True;
                    hidecursor;
                end;
            end;
     end;

    sum:=0;
    for i:=1 to 6 do begin if ms[i] = True then inc (sum); end;
    If sum = 6 then begin
        gotoXY (18,23); TextColor (31); textbackground (green);
        write ('Lai izietu un saglabatu spiediet jebkuru taustinu');
        textbackground (white); 
    end;

    case command of
        1: begin clean; gotoXY(X-5,Y); textbackground(green); textcolor(white); write ('---->'); textbackground(white); end;
        2: begin clean; gotoXY(X-5,Y + 2); textbackground (green); textcolor(white); write ('---->'); textbackground(white); end;
        3: begin clean; gotoXY(X-5,Y + 4); textbackground (green); textcolor(white); write ('---->'); textbackground(white); end;
        4: begin clean; gotoXY(X-5,Y + 6); textbackground (green); textcolor(white); write ('---->'); textbackground(white); end;
        5: begin clean; gotoXY(X-5,Y + 8); textbackground (green); textcolor(white); write ('---->'); textbackground(white); end;
        6: begin clean; gotoXY(X-5,Y + 10);textbackground (green); textcolor(white); write ('---->'); textbackground(white); end;
        end;
    end;
end;

begin
    Inproc := false;
    CLRSCR;
    {$I-}
    assign (textfile, filename);
    reset (textfile);
    {$I+}
    if (ioresult <> 0) then begin FError (1); Exit; end;
    seek (textfile, filesize (textfile));
    sum := 0;
    for i := 1 to 6 do ms[i] := False;
    View;
    If (quit = True) or (sum <> 6) then begin Exit; end;
    {$I-}
    write (textfile, REC);
    close (textfile);
    {$I+}
end;

(*----------------------------------------------*)

Procedure DataView (var textfile: myfile; filename: string);
var i: integer; REC: Outlaw;
   curr_pos: integer;
   refresh: boolean;
begin
    Clrscr;
    {$I-}
    assign (textfile, filename);
    reset (textfile);
    {$I+}
    seek (textfile, 0);
    CLRSCR;
    TextColor (blue);
    Textbackground(White); Clrscr;
    writeln  ('-------------------------------------------------------------------------------');
    writeln  (' Nr    Vards       Uzvards    Numurs   Brivs numurs   Istabu skaits    cena    ');
    writeln  ('-------------------------------------------------------------------------------');
    gotoXY (5,21);
    Textcolor (white);
    Textbackground (6);
    write ('Jus varat apskatit visu sarakstu lietojot bultinas "->" un "<-"');
    textbackground (white);textcolor(black);
    gotoxy(25,23);
    textbackground (6); textcolor (white);
    write ('beigt apskatisanu "space" taustins');
    textbackground (white);
    window(1,4,80,19);

    curr_pos := 0;
    refresh := true;
    repeat
        if refresh then begin
            seek(textfile, curr_pos);
            i := 1;
            Inproc:=False;
            repeat
                {$I-}
                read (textfile, REC);
                {$I+}
                with REC do begin
                    textcolor (black);
                    if curr_pos + i <= 9 then
                        writeln (' ',curr_pos + i,'   ',(Vards):7,' ',Uzvards:7,' ',Numurs:3,'   ',stavoklis:10,' ',istabas:14,' ',Cena:14:2)
                    else writeln (curr_pos + i,'   ',(Vards):6,' ',Uzvards:6,' ',Numurs:3,'  ',stavoklis:11,' ',istabas:14,' ',Cena:14:2);
                    inc (i);
                end;
            until (i > 15) or (eof (textfile));
            refresh := false;
        end;

        case ord(readkey) of
            77  : begin
                if curr_pos + 15 < filesize(textfile) then begin
                inc(curr_pos, 15); refresh := true;  end;
                end;
            75 : begin
                if curr_pos - 15 >= 0 then begin
                dec(curr_pos, 15); refresh := true;end;
                end;
            32 : break;
            27 : begin window(1,1,80,25); Clrscr; Inproc:=True; Exit; end;
        end;
    until false;

    window (1, 22, 80, 23); 
    Clrscr;
    textcolor(black);
    textbackground(white);
    Window(1, 1, 80, 25);
end;

(*------------------------------------------------------------*)

procedure discharge (var textfile: myfile; filename: string);
var
    REC: Outlaw;
    n, i: integer;
    TypeOfS: boolean;
    str: string;
    code: integer;

begin
    dataview (textfile, filename);
    if InProc then Exit;
    InProc := false;
    assign (textfile, filename);
    reset (textfile);
    gotoxy(10,23); textbackground (6); textcolor (white);
    writeln ('Kuru Ierakstu velieties dzest?');
    textbackground (white); showcursor;
    gotoXY (42,23); Textbackground (green); write ('   ');
    gotoXY (42,23); textcolor (white);
    TypeOfS:=False;
    InputCheck (str,2,TypeOfS);
    If InProc then begin Close(textfile); Exit; end;
    val (str,n,Code);
    Textbackground(White);
    hidecursor;
    if (ioresult <> 0) or ((n < 1) or ( n > filesize (textfile))) then
    begin FError (3); exit; end;

    n:=n-1; {-1 jo sakam ar 0}
    for i := n+1 to pred(filesize(textfile)) do
    begin
        seek(textfile, i); read(textfile, Rec);
        seek(textfile, i-1); write(textfile, Rec);
    end;
    seek(textfile, filesize(textfile) - 1);
    truncate(textfile);
    Close (textfile);
    FError (4);
    Content (textfile,filename);
    If Inproc then Exit;
    assign (textfile, filename);
    {$I-}
    reset (textfile);
    {$I+}
    for i:=1 to filesize(textfile) - 1 do
    begin
        seek (textfile, i - 1);
        read (textfile, rec);
        records[i] ^:= rec;
    end;

    Close (textfile);
    readkey;
end;

(*------------------------------------------------------------------------------*)

procedure correct (var textfile: myfile;  filename: string);
var
    REC, law: Outlaw;
    nos: string;
    i: integer;
    str: string;
    code, size: integer;
    TypeOfS: boolean;
    ch: string[1];

begin
    InProc:=False;
    Dataview (textfile, filename);
    if InProc then begin Close(textfile); Exit; end;
    assign (textfile, filename);
    reset (textfile);
    size:=filesize(textfile);
    gotoxy(10,23); textbackground (6); textcolor (white);
    writeln ('ievadiet labojama ieraksta numuru');
    textbackground (white); showcursor;
    gotoXY (45,23); Textbackground (green); write ('   ');
    gotoXY (45,23); textcolor (white);
    TypeOfS:=False;
    InputCheck (str,2,TypeOfS);
    If InProc then begin Close(textfile); Exit; end;
    val (str,i,Code);
    Textbackground(White);
    hidecursor;
    seek(textfile,i-1);
    {$I+}
    if (ioresult <> 0) or ((i < 1) or (i > filesize (textfile))) then
    begin FError(5); exit; end;
    read (textfile,REC);
    seek (textfile,i-1);
    with REC do
    begin
        Clrscr;
        gotoXY(7,23);textbackground (6); textcolor (white);
        write ('"J" vai "j" - piekrist, jebkurs taustins - atcelt, "enter" - turpinat');
        textbackground (white);
        gotoXY(20,11); textbackground (6);
        write ('Jus gribat mainit vardu? ja:"j"');textbackground (white);
        gotoXY(53,11);Textbackground(lightgreen); write ('  ');showcursor;
        gotoXY(53,11); TypeOfS:=True; InputCheck  (str,1,TypeOfS); ch:=Str;
        If (Ch = 'J') or (Ch = 'j') then
            begin
                Textbackground(white);
                gotoXY(20, 13); 
                textbackground(6); 
                textcolor(white);
  	            write ' Ievadi vardu: ');
                textbackground (white); 
                gotoXY(37,13);
                textbackground(lightgreen);   
                write ('            ');
                gotoXY(37,13); TypeOfS:=True; InputCheck(str,12,TypeOfS); vards := str;
                if InProc then begin Close(textfile); Exit; end;
                textbackground(white);
                ClrEOL;
            end
        else if inproc then begin close (textfile); exit; end;

        textbackground(white);
        gotoXY(1,11); ClrEOL;
        gotoXY(1,13); ClrEOL;
        gotoXY(20,11);textbackground (6);
        write ('Jus gribat mainit uzvardu? Ja:"j"'); Textbackground(white);
        gotoXY (54,11);Textbackground (lightgreen); write ('  ');
        gotoXY(54,11); TypeOfS:=True; InputCheck  (str,1,TypeOfS); ch:=Str;
        If (Ch = 'J') or (Ch = 'j') then
        begin
            textbackground(white);
            gotoXY(20,13); 
            textbackground(6);
            textcolor (white); write(' Ievadi uzvardu: '); textbackground(white);
            gotoXY (40,13);textbackground (lightgreen); write ('            ');
            gotoXY(40,13);InputCheck(str,12,TypeOfS); 
            uzvards := str;
            if InProc then begin 
                Close(textfile); 
                exit; 
            end;
            textbackground (white);
        end
        else if inproc then begin close (textfile); exit; end;

        textbackground(white);
        gotoXY(1, 11); ClrEOL;
        gotoXY(1, 13); ClrEOL;
        gotoXY(20, 11); textbackground(6);
        write ('Jus gribat mainit numuru?Ja:"j"'); textbackground(white);
        gotoXY (54, 11); textbackground(lightgreen); write ('  '); gotoXY (54,11);
        TypeOfS:=true; Inputcheck (str,1,TypeOfS);  ch:=Str;
        if (Ch = 'J') or (Ch = 'j') then
        begin
            Textbackground(white); gotoXY(20,13); textbackground (6);
            textcolor (white); write (' Ievadi numuru: '); textbackground(white);
            gotoXY (40,13); textbackground (lightgreen); write ('  ');
 	        gotoxy(40,13); TypeOfS:=false; InputCheck(str,2,TypeOfS);
            If InProc then begin Close (textfile); Exit; end;
            val (str, numurs, code);
            textbackground(white);
        end
        else if inproc then begin close (textfile); exit; end;

        textbackground(white);
        gotoXY(1,11); ClrEOL;
        gotoXY(1,13); ClrEOL;
        gotoXY(20,11); textbackground(6);
        write ('Jus gribat istabu sk. numuraa? Ja:"j"'); Textbackground(white);
        gotoXY(60,11); textbackground (lightgreen);  write ('  ');
        gotoXY(60,11); TypeOfS:=True; InputCheck  (str,1,TypeOfS); ch:=Str;
        if (Ch = 'J') or (Ch = 'j') then
        begin
            textbackground(white);gotoXY(20,13); textbackground (6);
	        write (' Ievadi skaitu: '); textbackground(white);
            gotoXY(40,13); textbackground (lightgreen); write ('  ');
	        gotoXY(40,13); typeOfS:=false; InputCheck(str,2,TypeOfS);
            If InProc then begin Close(textfile); Exit; end;
            val (str,istabas, code);
            textbackground(white);
        end
        else if inproc then begin close (textfile); exit; end;

        textbackground(white);
        gotoXY(1,11); ClrEOL;
        gotoXY(1,13); ClrEOL;
        gotoXY(20,11); textbackground (6);
        write ('Jus gribat mainit numura stavokli? Ja:"j"'); Textbackground(white);
        gotoXY (62,11); textbackground (lightgreen); write ('  ');
        gotoXY(62,11); TypeOfS:=True; InputCheck  (str,1,TypeOfS); ch:=Str;
        if (Ch = 'J') or (Ch = 'j') then
        begin
            textbackground(white); gotoXY(20,13); textbackground (6);
            write ('Numurs brivs?Ja/Ne?:'); textbackground(white);
            gotoXY(42,13); textbackground (lightgreen); write ('  ');
            gotoXY(42,13); TypeOfS:=true; InputCheck(str, 2, TypeOfS); 
            stavoklis := str;
            If InProc then begin Close(textfile); exit; end;
            Textbackground(white);
        end
        else if inproc then begin close(textfile); exit; end;

        textbackground(white);
        gotoXY(1,11); ClrEOL;
        gotoXY(1,13); ClrEOL;
        gotoXY(20,11); textbackground (6);
        write ('Jus gribat mainit cenu? Ja:"j"'); Textbackground(white);
        gotoXY(54,11); textbackground (lightgreen); write ('  ');
        gotoXY(54,11); TypeOfS := True; InputCheck(str, 1, TypeOfS); ch := Str;
        if (Ch = 'J') or (Ch = 'j') then
        begin
            textbackground(white);gotoXY(20,13); textbackground(6);
	        write (' Ievadi cenu: '); textbackground(white);
            gotoXY(40,13); textbackground (lightgreen); write ('   ');
            gotoXY(40,13); TypeOfS:=false; InputCheck(str,3,TypeOfS);
            val (str, cena, code);
            if InProc then begin Close(textfile); Exit; end;
            textbackground (white);
        end
        else if inproc then begin close (textfile); exit; end;

        textbackground (white);
        write (textfile, REC);
        writeln;
        close (textfile);
        hidecursor;
        FError (6);
        Content (textfile, filename);
        if Inproc then exit;
        assign (textfile, filename);
        {$I-}
        reset (textfile);
        {$I+}
        for i := 1 to filesize(textfile) - 1 do
        begin
            seek (textfile, i - 1);
            read (textfile, rec);
            records[i]^:=rec;
        end;
        Close (textfile);
        readkey;
    end;
end;

(*---------------------------------------------------------------------------------*)

procedure Sort (var textfile: myfile; filename: string);
var
    save, rec: Outlaw;
    nos: string;
    TypeOfS: boolean;
    str: string;
    FindTrue: boolean;
    i,j: integer;

begin
    InProc:=false;
    assign (textfile, filename);
    reset (textfile);
    Clrscr;
    gotoXY(35,17);
    textbackground (6);
    Textcolor (white);
    Write ('ESC - iziet');
    textbackground (white);
    FindTrue := false;
    repeat
        gotoXY(17,13); textbackground (6);
        write ('Kartosim pec istabu skaita vai uzvardiem?I/U?');
        textbackground (white);gotoXY(65,13); textbackground (lightgreen); write ('  ');
        showcursor; gotoXY(65,13); TypeOfS:=True; InputCheck (str,1,TypeOfS);
        Textbackground(white); ch:=str[1];
        if Inproc then Exit;

        FindTrue := false;

        if (ch = 'I') then
        begin
            FindTrue := true;
            for i:= 0 to (filesize(textfile) - 1) do
            for j:= 0 to (filesize (textfile)-1) do
            begin
                seek (textfile, i);
                read (textfile, rec);
                save := rec;
                seek (textfile, j);
                read (textfile, rec);
                if save.istabas < rec.istabas then
                begin
                    seek (textfile, i);
                    write (textfile, rec);
                    seek (textfile, j);
                    write (textfile, save);
                end;
            end;
        end else if (ch = 'U') then
        begin
            FindTrue := true;
            for i := 0 to (filesize (textfile) - 1) do
            for j := 0 to (filesize (textfile) - 1) do
            begin
                seek(textfile, i);
                read(textfile, rec);
                save := rec;
                seek (textfile, j);
                read (textfile, rec);
                if save.uzvards < rec.uzvards then
                begin
                    seek (textfile, i);
                    write (textfile, rec);
                    seek (textfile, j);
                    write (textfile, save);
                end;
            end;
        end else if ord(ch) = 27 then Exit
        else if ((ch <> 'U') and (ch <> 'A')) then
        begin
            gotoxy(WhereX - 1, WhereY);
            TextColor (green); Write (' ');
            gotoxy(WhereX - 1, WhereY);
            Textcolor(white);
        end;
    until FindTrue;

    Close (textfile);
    hidecursor;
    FError (6);
    Content (textfile,filename);
    if Inproc then Exit;

    assign (textfile, filename);
    {$I-}
    reset (textfile);
    {$I+}
    for i := 1 to filesize(textfile) - 1 do
    begin
        seek (textfile, i - 1);
        read (textfile,rec);
        records[i] ^:= rec;
    end;
    Close (textfile);
    readkey;
end;

(*----------------------------------------------------*)

Procedure expensive (var textfile : myfile; filename : string);
Const
    holdname = 'holdtext.txt';
var
    save, rec: Outlaw;
    str: string;
    typeofS: boolean;
    hold: myfile;
    sum, k, i: integer;
    count: real;

begin
    InProc := false;
    assign (textfile, filename);
    reset (textfile);
    assign (hold,holdname);
    rewrite (hold);

    count:=0;
    sum:=0;

    for i:= 0 to (filesize (textfile)-1) do
    begin
        seek (textfile, i);
        read (textfile, rec);
        if rec.cena > count then
        count:=rec.cena;
    end;

    for k:= 0 to (filesize (textfile)-1) do
    begin
        seek (textfile,k);
        read (textfile,rec);
        with REC do If ((REC.cena) = count) then begin
        inc (sum); write (hold,REC); end;
    end;

    Close (textfile);
    Close (hold);

    If sum > 0 then
    begin
        gotoXY(10,22); textbackground (6); Textcolor (31);
        write ('Kopigi sameklets(ti) ',sum,' numurs(ri) , spiediet jebkuru taustinu');
        textbackground (white); 
        textcolor(white);
        readkey;
        Content (hold, holdname);
    end;
end;

(*-----------------------------------------------------------------------------------*)

procedure search (var textfile: myfile; filename: string);
Const
    roomname = 'roomdata.txt';
var
    rec: Outlaw;
    yeah: string;
    room: MyFile;
    k, i, sum: integer;

begin
    InProc := false;
    assign(textfile, filename);
    reset(textfile);
    assign(room,roomname);
    rewrite(room);

    Clrscr;
    k:=0;
    sum:=0;
    yeah:='Ja';

    for i:= 0 to (filesize (textfile) - 1) do
    begin
        seek (textfile, i);
        read (textfile, rec);
        with REC do If ((rec.stavoklis) = yeah) then begin
            sum := sum + rec.istabas; 
            write (room,rec); 
        end;
    end;

    Close (textfile);
    Close (room);

    If sum > 0 then
    begin
        gotoXY(10,22); 
        textbackground (6); 
        Textcolor (31);
        write ('Kopigi samekletas ',sum,' istabas , spiediet jebkuru taustinu');
        textbackground (white);
        textcolor(white);
        readkey;
        Content (room, roomname);
    end;
end;

(*---------------------------------------------------------------------------------------------------------*)

procedure MakeMenu (optText: array of string; MaxItems: integer);
var
   i, _X: byte;
begin
    Y := row;
    _X := X;
    for i := 0 to MaxItems - 1 do
    begin
        GoToXY (_X, Y);
        if i = selected then
            TextColor (optSelected)
        else
            TextColor (optNormal);
        write (optText[i]);
        inc (Y,1);
     end;
end;

(*---------------------------------------------------------------------------*)

function MenuOption (optText: array of string; MaxItems: integer): byte;
var
    ch: char;
begin
    selected := 0;
    X := (80 - width) div 2;
    row := (25 - MaxItems) div 2;

    repeat
        MakeMenu (optText, MaxItems);

        ch := readkey;
        if ch = #0 then
            ch := readkey;

            case ch of
            #80, #77: {Down/Right}
            begin
                inc (Selected);
                if Selected = MaxItems then
                    Selected := 0;
                MakeMenu (optText, MaxItems);
            end;

           #72, #75: {Up/Left}
           begin
                dec (Selected);
                if Selected < 0 then
                   Selected := MaxItems-1;
                MakeMenu (optText, MaxItems);
           end;
        end;
    until ch = #13; {Enter}

    MenuOption := Selected + 1;

    TextColor(optNormal);
    If _style = Vertical Then
        clrscr;
end;

(*-----------------------------------------------------------*)

procedure menu;
var
    Option, i: byte;

begin
    TextBackground (white);
    clrscr;
    hidecursor;
    Textbackground(6);
    Textcolor(white);
    gotoxy(14,5);write (' Jusu riciba ir viesnicas datu bazes informacija ');
    Textbackground(white);
    TextColor (1);
    Gotoxy(15,7);
    for i := 1 to 48 do write ('�');
    Gotoxy(15,16);
    for i := 1 to 48 do write ('�');
    Gotoxy(14,7); write ('�');
    Gotoxy(14,16); write ('�');
    Gotoxy(63,7); write ('�');
    Gotoxy(63,8); write ('�');
    Gotoxy(63,9); write ('�');
    Gotoxy(14,8); write ('�');
    Gotoxy(14,9); write ('�');
    Gotoxy(14,10); write ('�');
    Gotoxy(14,11); write ('�');
    Gotoxy(14,12); write ('�');
    Gotoxy(14,13); write ('�');
    Gotoxy(14,14); write ('�');
    Gotoxy(14,15); write ('�');
    Gotoxy(63,10); write ('�');
    Gotoxy(63,11); write ('�');
    Gotoxy(63,12); write ('�');
    Gotoxy(63,13); write ('�');
    Gotoxy(63,14); write ('�');
    Gotoxy(63,15); write ('�');
    Gotoxy(63,16); write ('�');
    Gotoxy(9,18); Textbackground(6);
    Textcolor(white);
    write('Parvietoties pa izvelni var ar taustinu "->" un "<-" palidzibu');
    Textbackground(white);

    _style := Vertical;
    Option := MenuOption (optText1, Items1);

    case option of
        1: begin;
            Textbackground (white);
            Clrscr;
            position (Textfile);
            if (chapter = 1) then begin FError (1); menu; end 
            else if (chapter = 2) then begin FError (2); menu; end;
            if (chapter = 0) then begin
                Content (textfile, filename); 
                menu; 
            end;
        end;

        2: begin
            Textbackground (White);
            Clrscr;
            position (Textfile);
            if (chapter = 0) or (chapter = 2) then begin
            addrecords (Textfile, filename); menu; end
            else if (chapter = 1) then begin FError (1); menu; end;
        end;

        3: begin
            Textbackground (white);
            Clrscr;
            position (textfile);
            if (chapter = 1) then begin FError (1); menu; end 
            else if (chapter = 2) then begin FError (2); menu; end;
            if (chapter = 0) then 
            begin
                discharge (textfile, filename); 
                menu; 
            end;
        end;

        4: begin
            Textbackground (white);
            Clrscr;
            position (textfile);
            if (chapter = 1) then begin FError (1); menu; end 
            else if (chapter = 2) then begin FError (2); menu; end;
            if (chapter = 0) then begin
                correct (textfile, filename); 
                menu; 
            end;
        end;

        5: begin
            Textbackground (white);
            Clrscr;
            position (textfile);
            if (chapter = 1) then begin FError (1); menu; end 
            else if (chapter = 2) then begin FError (2); menu; end;
            if (chapter = 0) then begin
            sort (textfile, filename); menu; end;
        end;
        
        6: begin
            Textbackground (white);
            Clrscr;
            position (textfile);
            if (chapter = 1) then begin FError (1); menu; end 
            else if (chapter = 2) then begin FError (2); menu; end;
            if (chapter = 0) then 
            begin
                search (textfile, filename); menu; end;
            end;
        7: begin
            textbackground (white);
            Clrscr;
            position (textfile);
            if (chapter = 1) then 
            begin 
                FError (1); 
                menu; 
            end 
            else if (chapter = 2) then begin FError (2); menu; end;
            if (chapter = 0) then 
            begin
                expensive (textfile, filename); 
                menu; 
            end;
        end;

        8: begin
            exit;
        end;
    end;
end;
end.
