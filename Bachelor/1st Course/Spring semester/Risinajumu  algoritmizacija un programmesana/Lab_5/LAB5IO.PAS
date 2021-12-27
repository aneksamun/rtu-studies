unit lab5IO;
interface
    var MyFileErr: integer;
    type STR39= string[39];

    function FileRewr(filename:string): boolean;
    function NumOfRec: integer;
    procedure WriteLnText(OuText: string);
    procedure WriteLnRec(str1: string; i: integer; str2, str3, str4, str5: string);
    procedure FError;

implementation
uses CRT;

function FileRewr(filename:string): boolean;
var answer:string;
    begin
        writeln('Fails ',filename,' eksiste vai veidot to no jauna ?');
        writeln(' j/n ');
        read(answer);
        if( (answer='j') or (answer='J')) then
            begin
                writeln(' esoso failu paarrakstam');
                FileRewr:= TRUE;
                exit;
            end
        else
            begin
                writeln('tiek saglabaats esosais fails ');
                FileRewr:= FALSE;
            end;
    end;

    function NumOfRec: integer;
        label INPNUM;
        var n : integer;
    begin
        INPNUM:         writeln('Cik ierakstus gatavot (skaitam 0, 1, 2, 3,.. n)?');
{$I-}
        Read(n);
{$I+}
        if(IOResult<>0) then
        begin
            writeln(' Nepareizi ievadiits ierakstu skaits');
            writeln(' Ievadiit vajag no jauna');
            goto INPNUM;
        end;
        NumOfRec:=n;
    end;

    procedure WriteLnText(OuText: string);
    begin
        writeln(OuText);
    end;

    procedure WriteLnRec(str1: string; i: integer; str2, str3, str4, str5: string);
    begin
        writeln(str1, i:3,str2,str3,str4, str5);
    end;

procedure FError ;
begin
    case (MyFileErr) of
        1: writeln( ' ######01 lietotaajs neatlauj paarrakstit esoso failu ');
        2: writeln( ' ######02 Kluuda ievadotierakstu skaitu veidojamaa failaa');
        3: writeln( ' ######03 Neizdodas radiit failu');
        4: writeln( ' ######01 Nevar atveert pieprasiito failu');
        5: writeln( ' ######04 Nepielaujams labojamaa ieraksta numurs');
        else writeln(' ######55 Faila apstraades kluuda  Nr:', MyFileErr);
    end;
    MyFileErr:=0;
    writeln(' ###### nospied taustinu ');
    readkey;
end;

begin
    MyFileErr:=0;
end.
