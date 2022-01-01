Program Deque;

uses crt, UN3;

type MenuType = (Vertical, Horizontal);

const
    width = 9;             { Maksimaals izvelnes elementu (burtu) garums }

    items1 = 8;            { Izvelnes1 elementu skaits }
    optText1: array [0..items1 - 1] of string =
        ('Create',
         'Size',
         'Full',
         'Empty',
         'Enqueue (pievieno el)',
         'Serve (nolasa el)',
         'Terminate',
         'Exit');

    items2 = 4;            { Izvelnes2 elementu skaits  }
    optText2: array [0..items2 - 1] of string = 
        ('back',
         'aplukot deku',
         'aplukot deku failu',
         'exit');

    optNormal = LightBlue; { neizveleeto elementu krasa }
    optSelected = White;   { izveleeto elementu krasa   }

 var
    x, y,
    selected,  { elementaa indekss, kurs tiks izgaismots programmas
                darbiibas saakuma }
    row: integer;
    _style: MenuType;  { Noraada uz izvelnes tipu: vertikaala (Vertical)
                         vai horizantaala (Horizontal) }
    D: Deque;
    fileOpen, created: boolean;
    DNo: No;
    e, el: StdElement;
    i: Count;

Label CasePoint;
Label CaseOption;

{ So proceduru izmanto procedura MenuOption, lai izveidotu izvelni }
procedure MakeMenu (optText: array of string; maxItems: integer);
var
    i, _x: byte;
begin
    y := row;
    _x := x;
    for i := 0 to maxItems - 1 do
    begin
        GoToXY (_X, Y);
        if i = selected then
            TextColor (optSelected)
        else
            TextColor (optNormal);

        Write (optText[i]);

        if _style = Horizontal then
            Inc(_x, width + 1)
        else
            Inc(y, 2);
    end;
end;

{ Izvelaamies vajadziigo funkciju }
function MenuOption (ptText: array of string; maxItems: integer): byte;
var
    ch: char;
begin
    selected := 0;

    if _style = Vertical then 
    begin
        x := (80 - width) div 2;
        row := (25 - maxItems) div 2;
    end
    else begin
        x := (80 - maxItems * width) div 2;
        row := 2;
        GoToXY(1, row); 
        ClrEol;
    end;

    repeat
        MakeMenu (optText, MaxItems);

        ch := readkey;
        if ch = #0 then
            ch := readkey;

        case ch of
        #80, #77: {Down/Right}
        begin
            Inc(selected);
            if selected = maxItems then
                selected := 0;
            MakeMenu (optText, MaxItems);
        end;

        #72, #75: {Up/Left}
        begin
            Dec(selected);
            if selected < 0 then
                selected := maxItems-1;
                MakeMenu (optText, MaxItems);
        end;
    end;
    until ch = #13; {Enter}

    MenuOption := Selected + 1;

    TextColor (optNormal);
    if _style = Vertical then
        Clrscr;
end;

var option: byte; { izveleeta punkta numurs }

begin
    TextBackground(White);
    Clrscr;
CasePoint:
    _style := Vertical;
    option := MenuOption (optText1, Items1);

    case option of
    1: begin
        Clrscr;
        Create (D, created);
        if Created then
            Writeln ('"Deks" izveidots');
            FCreate;
    end;
    2: begin
        Clrscr;
        if Created then
            Writeln('"Deks" satur ',Size (D) ,' elementus')
        else
            Writeln('Vispirms jaaizveido "deks"');
    end;
    3: begin
        Clrscr;
        if Created then begin
            if Full (D) then 
                Writeln ('"Deks" ir saniedzis MAX atVeLeeto elementu skaitu')
            else
                Writeln ('"Deks" nav sasniedzis MAX atVeLeeto elementu skaitu')
        end
        else Writeln ('Vispirms jaaizveido "deks"');
    end;
    4: begin
        Clrscr;
        if Created then begin
            if Empty (D) then 
                Writeln('Sobrid "deks" ir tukss')
            else
                Writeln('Sobrid "deks" nav tukss');
        end
        else Writeln ('Vispirms jaaizveido "deks" ');
    end;
    5: begin
        Clrscr;
        if Created then
        begin
            Writeln ('Ievadiet elementa atsleegu');
            Readln (e.key);
            Clrscr;
            Writeln ('Ievadiet elementa datu lauku');
            Readln (e.Data);
            Clrscr;
            Writeln ('Ievadiet poziiciju:');
            Writeln ('1 - elements tiks izveitots "deka" saakumaa');
            Writeln ('2 - elements tiks izveitots "deka" galaa');
            Readln (DNo);
            if ( DNo<> 1) and (DNO <> 2) then
            begin
                Clrscr;
                Writeln ('Ludzu ievadiet vai nu " 1 ", vai nu " 2 "');
                GoTo CaseOption;
            end
            else begin
                FindKey(D,e);
                if FindKey(D,e) = true then
                begin
                    Clrscr;
                    Writeln ('Tada  atslega ir jau ievadita, ludzu meginiet velreiz!');
                    GoTo CaseOption;
                end
                else begin
                    Enqueue ( D, e, DNo );
                end
            end
        end
        else Writeln ('Vispirms jaaizveido "deks" ');
    end;
    6: begin
        Clrscr;
        if Created then
        begin
            Clrscr;
            Writeln ('Ievadiet poziciju no kuras elements tiks nolasiits: ');
            Writeln ('1 - elements tiks nolasiits "deka" saakumaa');
            Writeln ('2 - elements tiks nolasiits "deka" galaa');
            Readln (DNo);
            Clrscr;
            if (DNo<> 1) and (DNO <> 2) then
            begin
                Clrscr;
                Writeln ('Ludzu ievadiet vai nu " 1 ", vai nu " 2 "');
                GoTo CaseOption;
            end
            else begin
                Serve ( D, e, DNo );
                Clrscr;
                Writeln ('elements (atslega: ',e.key,' datu lauks: ',e.data, ') tika izdzests');
            end
        end
        else Writeln ('Vispirms jaaizveido "deks" ');
    end;
    7: begin
        Clrscr;
        if Created then begin
            Terminate (D, Created);
            Writeln ('"Deks" vairs nepastaaV ');
            FErase;
        end
        else Writeln ('Vispirms jaaizveido "deks" ');
    end;
    8: begin
        FDel;
        exit;
    end;
end;

CaseOption:
    _style := Vertical;
    option := MenuOption (optText2, Items2);

    case option of
    1: begin
        Clrscr;
        GoTo CasePoint;
    end;
    2: begin
        Clrscr;
        if Created and not Empty (D) then
        begin
            Writeln ('1 - elements tiks izvadits no "deka" saakumaa');
            Writeln ('2 - elements tiks izvadits no "deka" galaa');
            Readln (DNo);
            Clrscr;
            View (D,e,DNo);
            Goto CaseOption;
        end else Writeln ('"Deks" nesatur elementus ');
        Goto CaseOption;
        exit;
    end;
    3: begin
        Clrscr;
        if Empty (D) then
        begin
            Writeln ('"Deks" nesatur elementus ');
            GoTo CaseOption;
        end
        else begin
            Clrscr;
            FView (e);
            GoTo CaseOption;
        end
    end;
    4: begin
        FDel;
        exit;
    end;
end;
End.
