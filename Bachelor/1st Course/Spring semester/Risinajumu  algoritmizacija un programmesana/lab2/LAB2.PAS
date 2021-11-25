program Lab2;
uses crt;
const 
    num=20; 
    InpFileName='array.txt';
Type
    mymas=array[1..num] of integer;
var
    ms: mymas;
    InpFile, OutFile: TEXT;
    i, sumof2: integer;
    ch: char;
    OutfileName: string;
    label TESTING, ENDING;

    procedure Buble2(var a: mymas) ;forward;

    procedure main(var a: mymas; var s2: integer);
    var i: integer;
        function sum2(a: mymas): integer;
        var 
            i, sum: integer;
            procedure Buble(var a: mymas);
            var i, j, temp: integer;
            begin
                for i := 1 to num - 1 do
                    for j := i + 1 to num do
                        if a[i] > a[j] then
                        begin temp := a[i];
                            a[i] := a[j];
                            a[j] := temp;
                        end;
            end;
        { Sakartojam masivu augosa seciba }
        begin
            Buble(a);
            {writeln;
            writeln('Sakartotais masivs peec BUBLE');
            for i := 1 to num do
                write('         "', i:2,'" ', a[i]:4, '  ');}
            sum := 0;
            for i := 1 to 2 do
                sum := sum + a[i];
                Sum2 := sum;
        end;
    begin
        s2 := sum2(a);
        if (s2 > 10) then
            Buble2(a);
        { kartosim masivu dilstosa seciba}
        { writeln;
        writeln( 'reducing array');
        for i := 1 to num do
            write('         "', i:2,'" ', a[i]:4, '  '); }
    end;

    procedure Buble2(var a: mymas);
    var i, j, temp: integer;
    begin
        for i := 1 to num - 1 do
        for j := i + 1 to num do
            if a[i] < a[j] then
            begin 
                temp:= a[i];
                a[i]:=a[j];
                a[j]:=temp;
            end;
     end;

begin
    clrscr;
    assign(InpFile, InpFileName);
    reset(InpFile);
    writeln('ievadi rezultata faila vardu');
    readln(OutFileName);
    assign(OutFile, OutFilename);
    rewrite(OutFile);
TESTING:
    for i := 1 to num do
        Read(InpFile, ms[i]);
    if EOF(InpFile) then goto ENDING;
    writeln( 'Ievaditie dati');
    for i := 1 to num do
    begin
        write('         "', i:2,'" ', ms[i]:4, '  ');
        write(Outfile, ms[i]:3);
    end;
    main(ms, sumof2);
    writeln(Outfile);
    writeln('Divu mazako masiva elementu summa ir ', sumof2);
    writeln(Outfile, 'Divu mazako masiva elementu summa ir ', sumof2);
    writeln('Rezultata massivs');
    for i := 1 to num do
    begin
        write('         "', i:2,'" ', ms[i]:4, '  ');
        write(Outfile, ms[i]:3);
    end;
    writeln(' press key y to continue....');
    readln(Ch);
    if (ch = 'y') then goto TESTING;
 ENDING: 
    close(InpFile); close(OutFile);
end.