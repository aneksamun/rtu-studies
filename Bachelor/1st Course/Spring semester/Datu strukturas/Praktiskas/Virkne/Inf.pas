 Program Inf;

uses crt, func;

const maxLength=300;
type menuType = (Vertical);
const
   width = 30;
   items = 22;

   optText1: array [0..Items-1] of string =
    (' 1: Create (Izveido jaunu tuksu rakstzinju virkni)',
     ' 2: Terminate (Likvide rakstzimju virkni)',
     ' 3: StrLength (Nosaka raktzimes garumu)',
     ' 4: Empty (Parbauda vai rakstzime ir tuksa)',
     ' 5: Append (rakstzimes virknes gala pieliek raktzimi)',
     ' 6: Concatenate(apvieno divas rakstzimju virknes)',
     ' 7: Substring (No pirmas virknes izdala otru)',
     ' 8: Delete (Nodzest rakstziimi)',
     ' 9: Insert (Iestarpina virkni S)',
     ' 10: FindCons (linearas meklesana)',
     ' 11: FindBM (Mura meklesanas algoritms)',
     ' 12: ReadString (ar tastaturu ievada virkni)',
     ' 13: WriteString (izvad rakstzimes virkni)',
     ' 14: Equal(nosaka identiskumu)',
     ' 15: Remove (nodzess rakstzimi)',
     ' 16: Full (nosaka vai virkne ir pilna)',
     ' 17: MakeEmpty (padara par tukso virkni)',
     ' 18: Polindrome (vai ta ir vienadi lasama?)',
     ' 19: InFile (text tipa fails)',
     ' 20: Reverse (virkni apgriez otradi) ',
     ' 21: Inkey (ievads no klaviaturas)',
     ' 22: close (Beigt darbu)');

    optNormal = Lightgreen;
    optSelected = White;
var
    x, y, selected, row: integer;
    _style: menuType;
    ss, s, helpString: MyString;
    created: boolean;
    number: byte;
    close: boolean;
    c: string;
    simbols: char;
    pos, b: StringPos;
    ssLen: StringLen;

Label MenuGo;
Label Ending;

procedure CreateMenu (optText: array of string; maxItems: integer);
var i, x1: byte;
begin
    y := row;
    x1 := x;
    for i := 0 to maxItems-1 do
    begin
        GoToXY (X1, Y);
        if i = selected then
            TextColor (optSelected)
        else
            TextColor (optNormal);
        Write (optText[i]);
        Inc(Y, 1);
    end;
end;

function MenuOption (optText: array of string; maxItems: integer): byte;
var ch: char;
begin
    selected := 0;
    x := (35 - width) div 2;
    row := (25 - MaxItems) div 2;

    repeat
        CreateMenu (optText, MaxItems);
        ch := ReadKey;
        if ch = #0 then
            ch := ReadKey;
        case ch of
        #80, #77: {Down/Right}
        begin
            inc (selected);
            if Selected = MaxItems then
                Selected := 0;
            CreateMenu (optText, maxItems);
        end;

        #72, #75: {Up/Left}
        begin
            Dec(selected);
            if selected < 0 then
                selected := maxItems - 1;
            CreateMenu (optText, MaxItems);
        end;
    end;
    until ch = #13; {Enter}

    menuOption := selected + 1;
    TextColor (optNormal);
    Clrscr;
end;

procedure DoCalc;
begin
    ClrScr;
    WriteLn('???');
    ReadLn;
end;

procedure ShowHelp;
begin
    ClrScr;
    WriteLn('???');
    ReadLn;
end;

procedure About;
begin
    ClrScr;
    WriteLn('???');
    ReadLn;
end;

procedure InKey(var s: MyString);
var key: char;
    pos: StringPos;
    x,y: integer;
    temp: MyString;

    procedure SWrite;
        var i: StringLen;
    begin
        GoToXY(x,y);
        for i := 1 to s^.strlen do
        begin
            Write(s^.data[i]);
            if wherex > 79 then gotoxy(2, wherey + 1);
        end;
        Write(' ');
        GoToXY(x,y);
        for i := 1 to pos - 1 do
        begin
            Write(s^.data[i]);
            if wherex > 79 then gotoxy(2, wherey + 1);
        end;
    end;

begin
    if not Empty(s) then MakeEmpty (simb);
    New(temp);
    pos := 1;
    x := wherex;
    y := wherey;
    repeat
        key := ReadKey;
        if (key>=' ') and
           (key<='}') and
           (key<>'M') and  {labas bultnes kods}
           (key<>'K') and  {kreisas bultnes kods}
           (key<>'G') and  {HOME pogas kods}
           (key<>'O') and  {END pogas kods}
           (key<>'S') then {DELETE pogas kods}
        begin
            Append(temp, key);
            Insert(s, temp, pos);
            pos := pos + 1;
            SWrite;
            MakeEmpty(temp);
        end;
        if (key = #8) and (pos > 1) then
        begin
            pos := pos-1;
            Remove(s, pos, key);
            SWrite;
        end;
        if (key = #83) and (pos <= s^.strlen) then
        begin
            Remove(s, pos, key);
            SWrite;
        end;
        if (key=#75) and (pos>1) then
        begin
            pos := pos-1;
            SWrite;
        end;
        if (key=#77) and (pos<=S^.strlen) then
        begin
            pos := pos+1;
            SWrite;
        end;
        if key = #79 then {END}
        begin
            pos := S^.strlen+1;
            SWrite;
        end;
        if key=#71 then {HOME}
        begin
            pos := 1;
            SWrite;
        end;
    until key = #13;
    Dispose(temp);
end;

var option: byte;

begin
    ClrScr;
MenuGo: 
    option := MenuOption (optText1, Items);

    case option of
    1: begin
        Create(s, created);
        WriteLn('Virkne izveidota');
        if created then begin 
            WriteLn ('Virknes stavoklis : ');
            WriteString(s);
            WriteLn;
            WriteLn('Virknes garums ir:', StrLength(s));
            MakeEmpty(ss);
            WriteLn; 
        end; 
        ReadKey; 
        ClrScr; 
        GoTo MenuGo;
    end;
    2: begin
        if created then
        begin
            Terminate(s, created);
            WriteLn('Virkne vairs neeksiste');
        end 
        else WriteLn ('Vispirms jaizveido virkni');
        WriteLn ('Virknes stavoklis : '); 
        WriteString(s); 
        WriteLn;
    	WriteLn('Virknes garums ir:', StrLength(s));
        MakeEmpty(ss);
    	WriteLn;
        ReadKey; 
        ClrScr; 
        GoTo MenuGo;
        end;

    3: begin
        Clrscr;
        if created then begin
            WriteLn('Virknes garums ir:', StrLength(s));
        end 
        else WriteLn('Vispirms jaizveido virkni')
        WriteLn ('Virknes stavoklis : '); 
        WriteString(s); 
        WriteLn;
        WriteLn('Virknes garums ir:', StrLength(s));
        MakeEmpty(ss);
        WriteLn; 
        ReadKey; 
        ClrScr; 
        GoTo MenuGo;
    end;

    4: begin
        ClrScr;
        if created then begin
            if Empty(S) then 
                WriteLn('Virkne ir tuksa') 
            else WriteLn('Virkne nav tuksa');
        end else WriteLn('Virkni vispirms jaizveido');
        WriteLn ('Virknes stavoklis : '); 
        WriteString(S); 
        WriteLn;
        WriteLn('Virknes garums ir:', StrLength(s));
        MakeEmpty(ss);
        WriteLn; 
        ReadKey; 
        ClrScr; 
        GoTo MenuGo;
     end;

    5: begin
        ClrScr;
        WriteLn ('velies pievienot simbolu virknie?');
        if created then begin 
            WriteLn ('Kadu simbolu jus griba pievienot?');
            ReadLn (simbols);
            Append (s, simbols);
            WriteLn ('Virknes tekoshais stavoklis : '); 
            WriteString(S); 
            WriteLn;
            WriteLn('Virknes garums ir:', StrLength(s)); 
            MakeEmpty(ss); 
            if not created then 
                WriteLn ('Virkni vispirms ir jaizveido');
        end;
        ReadKey; 
        ClrScr; 
        GoTo MenuGo;
    end;

    6: begin
        Clrscr;
        WriteLn('virknu apvienosana...');
        Concatenate (s, ss);
        if created then 
        begin 
            WriteLn ('Virknes stavoklis : '); 
            WriteString(s); 
            Writeln;
            WriteLn('Virknes garums ir:', StrLength(S));
            MakeEmpty(helpString); 
        end; 
        if not created then Writeln ('Virkne nav izveidota');
        ReadKey;
        ClrScr; 
        GoTo MenuGo; 
    end;

    7: begin
        ClrScr;
        if created then begin 
            WriteLn('Izdala apaksvirkni'); 
            WriteLn('Ievadiet poziciju'); 
            ReadLn(pos); 
            WriteLn ('Cik simbolu?');
            ReadLn(sslen);
            substring(s,ss,pos,sslen); 
            WriteLn('Virkne kuru dabujam pec operacijas:');
            WriteString(ss) 
            WriteLn('Virknes stavoklis : '); 
            WriteString(s); 
            WriteLn;
            WriteLn('Virknes garums ir:', StrLength(s));
            MakeEmpty(ss); 
        end;
        if not created then WriteLn ('Virkne nav izveidota'); 
        ReadKey; 
        ClrScr; 
        GoTo MenuGo; 
    end;

    8: begin
        ClrScr;
        if created then begin 
            WriteLn ('Tiks nodzesta apaksvirkne');
            WriteLn ('Ievadiet poziciju'); 
            ReadLn(pos);
            WriteLn ('ievadiet garumu');
            ReadLn (sslen);
            Delete(s, pos, sslen);
            WriteLn ('Virknes stavoklis : '); 
            WriteString(s); 
            WriteLn;
            WriteLn('Virknes garums ir:', StrLength(s));
            MakeEmpty(ss); 
        end;
        if not created then WriteLn ('Virkne nav izveidota'); 
        ReadKey; 
        ClrScr; 
        GoTo MenuGo;
    end;

    9: begin
        ClrScr;
        if created then begin 
            WriteLn ('Iestarpinam virkni');
            WriteLn ('Ko iestarpinam?'); 
            InKey(ss);
            WriteLn;
            WriteLn ('No kadas pozicijas? '); 
            ReadLn(pos); 
            Insert(s, ss, pos); 
            WriteLn('Virknes stavoklis: '); 
            WriteString(s); 
            WriteLn;
            WriteLn('Virknes garums ir: ', StrLength(s));
            MakeEmpty(ss); 
        end;
        if not created then WriteLn ('Virkne nav izveidota'); 
        ReadKey; 
        ClrScr; 
        GoTo MenuGo; 
    end;

    10: begin
        Clrscr;
        If created then begin
            WriteLn('Meklejam apaksvirkni. Ievadiet kadus simbolus meklet.');
            InKey(SS);
            WriteLn;
            WriteLn('Ievadiet poziciju');
            ReadLn(pos);
            if (FindCons(s, ss, pos) = 0) then 
                WriteLn('Nav atrasts') 
            else 
                WriteLn ('Ir atrasts sakot ar ', FindCons(s, ss, pos),' poziciju');
            MakeEmpty(ss);
            WriteLn ('Virknes stavoklis : '); 
            WriteString(s); 
            WriteLn;
            WriteLn('Virknes garums ir:', StrLength(s));
            MakeEmpty(ss); 
        end;
        if not created then WriteLn('Virkne nav izveidota'); 
        ReadKey; 
        ClrScr; 
        GoTo MenuGo; 
    end;

    11: begin
        ClrScr;
        If created then begin 
            WriteLn ('Meklesim apaksvirkni'); 
            WriteLn ('Kadus simbolus meklesim ? '); 
            InKey(helpString);
            WriteLn ('No kuras pozicijas?'); 
            ReadLn (pos); 
            if FindBM(s, helpString, pos) = 0 then 
                WriteLn('Nav atrasts') 
            else
                WriteLn('Ir atrasts sakot ar ', FindBM(s, helpString, pos),' poziciju'); 
            WriteLn('Virknes stavoklis : '); 
            WriteString(s); 
            WriteLn;
            WriteLn('Virknes garums ir:', StrLength(s));
            MakeEmpty(ss);
        end;
        if not created then Writeln('Virkni vispirms ir jaizveido');
        ReadKey; 
        ClrScr; 
        GoTo MenuGo; 
    end;

    12: begin
        ClrScr;
        if (created) then begin 
            WriteLn ('Ievadiet datus no tastaaturas');
            InKey(s);
            WriteLn;
            WriteLn('Virknes stavoklis : '); 
            WriteString(s); 
            WriteLn;
            WriteLn('Virknes garums ir:', StrLength(S));
            MakeEmpty(ss); 
        end;
        if not created then WriteLn ('Virkne nav izveidota'); 
        ReadKey; 
        ClrScr; 
        GoTo MenuGo; 
    end;

    13: begin
        ClrScr;
        if created then begin
            WriteString(s);
            WriteLn;
            WriteLn('Izvade pabeigta');
            WriteLn;
        end 
        else WriteLn('Virkne nav pieiejama');
        WriteLn ('Virknes stavoklis : '); 
        WriteString(s); 
        WriteLn;
        WriteLn('Virknes garums ir:', StrLength(s));
        MakeEmpty(ss);
        WriteLn; 
        ReadKey; 
        ClrScr; 
        GoTo MenuGo;
    end;

    14: begin
        if created then begin 
            ClrScr;
            WriteLn('Salidzina virknes...');
            WriteLn('Ar ko salidzinam?'); 
            InKey(helpString);
            Equal(s, helpString);
            WriteLn; 
            if Equal(s, helpString) then 
                WriteLn('Ir vienadi') 
            else 
            WriteLn('nav vienadi');
            WriteLn('Virknes stavoklis : '); 
            WriteString(s); 
            WriteLn;
            WriteLn('Virknes garums ir:', StrLength(s));
            MakeEmpty(ss); 
        end;
        ReadKey; 
        ClrScr; 
        GoTo MenuGo; 
    end;

    15: begin
        Clrscr;
        If Created then begin writeln ('Aizvacam rakstziimi');writeln('ievadi poziciju');readln (pos);
        writeln ('Ievadiet simbolu'); readln(simbols);
        Remove(S,pos,simbols); end;
        if created then begin writeln ('Virknes stavoklis : '); writestring(S); writeln;
        writeln('Virknes garums ir:',StrLength(S));makeempty(SS); if not created then writeln ('Virkne nav izveidota'); end;
        readkey; Clrscr; goto MenuGo; 
    end;

    16: begin
        Clrscr;
        if created  then begin
        IF Full(s) then writeln ('Virkne pilna') else writeln ('Virkne nav pilna');
        end else writeln('Virkni vispirms ir jaizveido');
        if created then begin writeln ('Virknes stavoklis : '); writestring(S); writeln;
        writeln('Virknes garums ir:',StrLength(S));makeempty(SS);
        writeln; end; readkey; Clrscr; goto MenuGo;
    end;

    17: begin
        Clrscr;
        if created then begin
        MakeEmpty(s);
        writeln('Virkne padariita tukshsa');
        end else writeln('Virkni vispirms ir jaizveido');
        if created then begin writeln ('Virknes stavoklis : '); writestring(S); writeln;
        writeln('Virknes garums ir:',StrLength(s));
        writeln;makeempty(SS); end; readkey; Clrscr; goto MenuGo;
    end;

    18: begin
        ClrScr;
        If created then begin 
            WriteLn ('Parbaude uz salasisanu'); 
            if Polindrome(S) = True then
                Writeln ('Tas ir salasams no abiem galiem') 
            else
                WriteLn 'Tas nav tada veida salasama'); 
            WriteLn ('Virknes stavoklis : '); 
            WriteString(S); 
            WriteLn;
            WriteLn('Virknes garums ir:', StrLength(s));
            MakeEmpty(ss); 
        end;
        if not created then WriteLn('Virkne nav izveidota'); 
        ReadKey; 
        ClrScr; 
        GoTo MenuGo;
    end;

    19: begin
        ClrScr;
        If created then begin 
            WriteLn ('Ievadisim datus no faila');
            Infile(s); 
            WriteLn ('Virknes stavoklis : '); 
            WriteString(s); 
            WriteLn;
            WriteLn('Virknes garums ir:', StrLength(s));
            MakeEmpty(ss); 
        end;
        if not created then WriteLn('Virkne nav izveidota'); 
        ReadKey; 
        ClrScr; 
        GoTo MenuGo; 
    end;

    20: begin
        ClrScr;
        if created then begin 
            WriteLn ('virkne tiks apgriezta otradi'); 
            Reverse (s); 
            WriteLn ('virkne tika parveidota'); 
            WriteLn ('Virknes stavoklis : '); 
            WriteString(s); 
            WriteLn;
            WriteLn('Virknes garums ir:', StrLength(s));
            MakeEmpty(ss);
        end;
        if not created then WriteLn ('Virkne nav izveidota'); 
        ReadKey; 
        ClrScr; 
        GoTo MenuGo; 
    end;

    21: begin
        ClrScr;
        if created then begin 
            WriteLn('Ievadiet datus no tastaaturas'); 
            InKey(s);
            WriteLn; 
        end;
        if created then begin 
            WriteLn ('Virknes tekoshais stavoklis: '); 
            WriteString(s); 
            WriteLn;
            WriteLn('Virknes garums ir:', StrLength(s));
            MakeEmpty(ss); 
        end;
        if not created then WriteLn('Virkne nav izveidota'); 
        ReadKey; 
        ClrScr; 
        GoTo MenuGo; 
    end;

    22: begin
        ClrScr;
        Write('Y/N:');
        ReadLn(c);
        if (c = 'y') or (c = 'Y') then 
            GoTo Ending 
        else 
        begin 
            ClrScr; 
            goto MenuGO; 
        end;
    end;
end;

Ending: end.
