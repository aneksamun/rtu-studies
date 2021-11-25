{ Laboratijas darbs #5  }
{ Macibu programma - aprekini viendimensiju masivaa }
{ Ciklu operatoru un masivu pielietojumu piemers}

program massiv1;
uses crt;
const num=20;   						{ Masiva izmers }
var
    oper,         						{ Izpildama programmas operacija }
                                        { oper=3333 beigt }
    i,j:integer;    					{ Darba indeksi }
    ms: array[1..num] of real;			{ Masivs, kuru apstrada }
    x, dx:real;
    idet:integer; 						{ Indeksi rezultatam }
    lielneg:real;           			{ Rezultats }
    label  MENU, SOLVE, BEIGAS;
 begin
    clrscr;
    MENU:
        x:=0.27; dx:=0.345;
        writeln;
        writeln( 'Programma domata ciklu operatoru un masivu apgusanai ');
        writeln( ' 3333 - beigt');
        writeln( ' 1111 - rekinat ar standarta sakumvertibam ');
        writeln( ' jebkurs cits skaitlis rekinat ar pasa uzdotam sakumvertibam');
        read(oper);
        if oper=3333 then goto BEIGAS;
        if oper=1111 then goto SOLVE;
        {masiva aizpildisana un aprekini }
        writeln( 'ievadi divus realus skaitlus,tie noteiks masiva elem. vertibas');
        read(x, dx);
        
    SOLVE:
        for i:=1 to num do
            begin
                ms[i]:=10*sin(x);
                x:=x+dx;
            end;          
        writeln;
            
        for i:=1 to num do  {Uzgenereta masiva izvads}
            begin
                write( '      "',i:2, '"', ms[i]:10:5)
            end;
            
        writeln;   
        writeln(' Lai turpinatu ievadi jebkuru skaitli ');
        read(j);
        
        { Meklejam lielako negativa elementu vertibu un indeksu pa para indeksiem }
        i := 2; lielneg := - MaxLongInt;
        while i < num do 
            begin
                if (ms[i] < 0) and (ms[i] > lielneg) then 
                    begin
                        lielneg := ms[i];
                        idet := i;
                    end;
                i:=i+2;
            end;
            
        writeln(' Lielaka negativa elementa vertiba ir :', lielneg:10:5);
        writeln(' Lielaka negativa elementa indeks ir :', idet:5);
        goto MENU;
        
        BEIGAS:
end.
