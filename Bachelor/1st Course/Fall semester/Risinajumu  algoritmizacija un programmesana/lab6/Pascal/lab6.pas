{ Laboratijas darbs #6 }

{ Macibu programma - aprekini divdimensiju masivaa }
{ Ciklu operatoru un masivu pielietojumu piemers}

program massiv2;
const num = 10;                             { Masiva izmers }
var
    oper,                                   { oper=3333 beigt }
    i,j,k: integer;                         { Darba indeksi }
    wrk: integer ;
    ms: array[1..num, 1..num] of integer;   { Masivs, kuru apstrada }
label MENU, BEIGAS;
begin
    MENU:
        writeln;
        writeln( 'Programma domata ciklu operatoru un masivu apgusanai');
        writeln( ' 3333 - beigt');
        writeln( ' jebkurs cits skaitlis aizpildit masiva prasito dalu');
        writeln( ' ar vertibam 1 2 3 ... pa horizontali');
        read(oper);
        
        if oper = 3333 then 
            goto BEIGAS;
        
        for i := 1 to num do
            for j := 1 to num do
                ms[i,j] := 0;
        
        wrk := 1;
        for i := 3 to 8 do 
            begin
                j := 8 - i; 
                k := i + 3;
            
                if i >= 6 then 
                    begin 
                        j := i - 3; 
                        k := 14 - i;
                    end;
                    
                while(j <= k) do
                    begin
                        ms[i, j] := wrk;
                        wrk := wrk + 1;

                        if (wrk = 9) or (wrk = 13) then
                            j := j + 3
                        else
                            j := j + 1;
                    end;
            end;
            
        for i := 1 to num do
            begin 
                writeln;
                
                for j := 1 to num do
                    write(ms[i, j]:7)
            end;
            
        writeln;
        writeln(' Lai turpinatu ievadi jebkuru skaitli ');
        read(j);
        
        goto MENU;
    BEIGAS:
end.
