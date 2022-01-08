Program Banker;
uses crt;

type process = 
    record
        l: Integer;
        m: Integer;
    end;

var n, t, choose, i, r: Integer;
    p: array [1..20] of process;

{------------------------------------------------
           Reserve
-------------------------------------------------}
procedure Reserve;
var k: Integer;
begin
    r := t;
    for k := 1 to i do
    begin
        r := r - p[k].l;
    end;
end;

{------------------------------------------------
           AddL
-------------------------------------------------}
procedure AddL;
var l: Integer;
begin
    WriteLn;
    WriteLn ('Procesam izdalitu resursu skaits l(i): ');
    ReadLn (l);
    if l <= t then
        p[i].l := l
    else
    begin
        WriteLn('Nevar iedalit vairak resursu neka sistemai ir!');
        AddL;
    end;
end;

{------------------------------------------------
           InputResource
-------------------------------------------------}
procedure InputResource;
begin
    WriteLn('Resursu sk, ko nodrosina sistema (t):');
    ReadLn(t);
    if t < 0 then
    begin
        WriteLn('Resursu sk nevar but mazaks par 0!');
        WritLn;
        InputResource;
    end;
end;

{------------------------------------------------
           InputProcess
-------------------------------------------------}
procedure InputProcess; 
begin
    WriteLn('Procesu sk, kas sistema izpildas vienlaicigi (n):');
    ReadLn(n);
    if n < 0 then
    begin
        WriteLn('Procesu sk nevar but mazaks 0!');
        WriteLn;
        InputProcess;
    end;
end;

{------------------------------------------------
           Menu
-------------------------------------------------}
procedure Menu;
var k: Integer;
begin
    ClrScr;
    WriteLn ('-------------------------');
    WriteLn ('    N    l(i)    m(i)    ');
    WriteLn ('-------------------------');
    for k := 1 to i do
        WriteLn('    ', k, '      ', p[k].l, '      ', p[k].m);
    WriteLn;
    Reserve;
    WriteLn ('-------------------------');
    WriteLn ('    n      t    Rezerve  ');
    WriteLn ('-------------------------');
    WriteLn ('    ', n,'      ', t, '     ', r);
    WriteLn;
    WriteLn (' [1] Noradit procesa pieprasijumu ');
    WriteLn (' [2] Konstatet sistemas stavokli   ');
    WriteLn (' [3] Dzest procesu        ');
    WriteLn (' [4] Iziet no programmas  ');
    WriteLn;
    Write ('Izvele-> ');
    ReadLn (choose);
end;

{------------------------------------------------
           DeleteProcess
-------------------------------------------------}
procedure DeleteProcess;
var k: Integer;
begin
    WriteLn;
    WriteLn ('Procesa numurs pec kartas (N) :');
    ReadLn(k);
    if (k < 1) or (K > i) then
    begin
        WriteLn('Ievaditais kartas numurs ir nekorekts!');
        ReadKey;
    end
    else begin
        while k <> i do
        begin
            p[k].l := p[k + 1].l;
            p[k].m := p[k + 1].m;
            k := k + 1;
        end;
        i := i - 1;
    end;
end;

{------------------------------------------------
           State
-------------------------------------------------}
function State: Boolean;
var
   k, min, e, j: Integer;
   isStable: Boolean;
   a: array [1..20] of process;
begin
    Reserve;
    if r < 0 then
        isStable := False
    else
    begin
	    for k := 1 to i do
        begin
            a[k].l := p[k].l;
            a[k].m := p[k].m;
        end;
        j := i;
        while j <> 0 do
        begin
            min := 0;
            e := 0;
            for k := 1 to j do
                min := min + a[k].m;

            for k := 1 to j do
                if a[k].m - a[k].l < min then
                begin
                    min := a[k].m - a[k].l;
                    e := k;
                end;

                if min <= r then
                begin
                    r := r + a[e].l;
                    for k := e to j do
                    begin
                        a[k].l := a[k + 1].l;
                        a[k].m := a[k + 1].m;
                    end;
                    j := j - 1;
                    isStable := True;
                    {WriteLn;
                     WriteLn ('min ',min);
                     WriteLn ('rezerve ',r);
                     ReadKey;}
                end
                else
                begin
                    isStable := False;
                    break;
                end;
        end;
    end;
    State := isStable;
 end;


{------------------------------------------------
           Rollback
-------------------------------------------------}
procedure Rollback (var i: Integer);
begin
    p[i].l := p[i + 1].l;
    p[i].m := p[i + 1].m;
    i := i - 1;
end;

{------------------------------------------------
           AddRequest
-------------------------------------------------}
Procedure AddRequest;
begin
    if i < n then
    begin
        i:=i+1;
        AddL;
        WriteLn ('Procesa vajadziba pec resursa m(i):');
        ReadLn (p[i].m);
        if not State then
        begin
            WriteLn;
            WriteLn ('Nevar apmierinat pieprasijumu');
            ReadKey;
            Rollback (i);
        end;
    end
    else
    begin
        WriteLn;
        WriteLn ('Procesu pieprasijums nevar parsniegt procesu skaitu!');
        ReadKey;
    end;
end;

{------------------------------------------------}

begin
    TextBackground(15);
    ClrScr;
    TextColor(0);
    ClrScr;
    WriteLn ('------------------------------------------------------');
    WriteLn ('                .:[ Banker algorithm ]:.              ');
    WriteLn ('------------------------------------------------------');
    WriteLn;
    InputProcess;
    InputResource;

    i := 0;
    while choose <> 4 do
    begin
        Menu;
        case choose of
        1: begin
            AddRequest;
        end;
        2: begin
            State;
            if not State then
            begin
                WriteLn;
                WriteLn ('Nevar apmierinat pieprasijumus');
                ReadKey;
            end
            else
            begin
                WriteLn;
                WriteLn ('Sistemas stavoklis ir dross');
                ReadKey;
            end;
        end;
        3: begin
            DeleteProcess;
        end;
        4: begin
            exit;
        end;
    end;
end;
end.