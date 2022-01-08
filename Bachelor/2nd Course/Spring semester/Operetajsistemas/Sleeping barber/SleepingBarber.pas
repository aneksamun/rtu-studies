Program SleepingBarber;
uses Crt;

const Chairs = 3;
      Max = 100;
      M = 1;
type
    arriveArray   = array [0..MAX] of integer;
    intervalArray = array [0..MAX] of integer;
    clientNumber  = array [0..4]   of integer;
var
    quantity, num, e, visit, count, l, j: Integer;
    mutex: Integer;
    waiting: Integer;
    barbers: Integer;
    costumers: Integer;
    arriving: arriveArray;
    interval: intervalArray;
    number: clientNumber;
    isFull: boolean;
    ch: Char;

procedure Up(var this: Integer);
begin
    this := this + 1;
end;

procedure Down(var this:integer);
begin
    if this > 0 then
        this := this - 1
    else
        this := 0;
end;

procedure CutHair;
var 
    cuttingTime: Integer;
begin
    cuttingTime := random(8);

    if cuttingTime <> 0 then
    begin
        if num > 0 then
            interval[num] := interval[num - 1] + cuttingTime
        else
            interval[e] := arriving[num] + cuttingTime;
        end
    else
        CutHair;
end;

procedure GetHaircut;
begin
    if num > 0 then
        arriving[num] := visit + arriving[num - 1]
    else
        arriving[num] := visit;
end;

procedure Costumer;
begin
    Down(mutex);
    quantity := quantity + 1;
    isFull := True;

    if waiting < Chairs then
    begin
        waiting := waiting + 1;
        Up(costumers);
        Up(mutex);
        Down(barbers);
        GetHaircut;
        isFull := False;
    end
    else
    begin
        Up(mutex);
        WriteLn ('Nav brivo kreslu, apmekletajs ', quantity,' iet projam');
        WriteLn;
        ch := ReadKey;
    end;
end;

procedure Barber;
begin
    if arriving[num] >= e then
    begin
        while waiting <> 0 do
        begin
            down (costumers);
            down (mutex);
            waiting := waiting - 1;
            if barbers < M then
                Up(barbers);
            Up (mutex);

            if costumers > 0 then
            begin
                WriteLn ('Apmekletajs ', number[j],' griez matus');
                WriteLn;
                number[j] := 0;
                j := j + 1;
                l := 0;
            end;
        end;
        CutHair;
        e := interval[num];

        if (j > 0) and (number[j] <> 0) then
        begin
            WriteLn ('Apmekletajs ', number[j],' griez matus');
            number[j] := 0;
            WriteLn;
        end
        else
        begin
            WriteLn ('Apmekletajs ', quantity,' griez matus');
            WriteLn;
        end;
        num := num + 1;
        ch := readkey;
    end
    else
        begin
            if not IsFull then
            begin
                WriteLn('Apmekletajs ', quantity,' apsedas ', waiting,' kresla');
                WriteLn;
                number[l] := quantity;
                l := l + 1;
                j := 0;
                CutHair;
                num := num + 1;
                ch := ReadKey;
            end
            else
            begin
                count := count + 1;
                if count = 2 then
                begin
                    arriving[num] := e;
                    count := 0;
                end;
            end;
        end;
    end;
end;

begin
    TextBackground(White);
    ClrScr;
    TextColor(0);
    barbers := 0;
    costumers := 0;
    mutex := 1;
    waiting := 0;
    num := 0;
    e := 0;
    count := 0;
    quantity := 0;
    l := 0;
    j := 0;

    while ch < #32 do
    begin
        visit := random (8);
        if visit > 0 then
        begin
            costumer;
            barber;
        end
        else
        begin
            if (costumers = 0) {and (arriving[num] >= e)} then
            begin
                WriteLn('Frizieris gul sava kresla');
                WriteLn;
                ch := ReadKey;
            end;
        end;
    end;
end.