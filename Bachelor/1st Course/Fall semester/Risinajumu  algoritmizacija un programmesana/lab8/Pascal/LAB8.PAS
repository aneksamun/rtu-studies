{$B+,D+,E+,I+,N+,Q+,R+,X-}
{ Laboratijas darbs #8 }

Program RINDA;
uses crt;
var X, S, Y, A : real;
    k : integer;

Procedure RindasAprekins(x:real; var s,a:real; var k:integer);
begin
    S := x / 9;
    A := x / 9;
    k := 1;
    while ABS(A) > 0.0000001 do
        begin
            A := A * -1 * (x * x / 9);
            S := S + A;
            k := k + 1
        end;
end;
    
Function FunkcijasApreikins(x:real):real;
begin
    FunkcijasApreikins := x / (9 + x * x);
end;

begin
    clrscr;
    writeln('  x            Rinda      Standartfunkcija    Loc. skaits rindaa');
    
    X := -2;
    
    while x < 2.2 do
        begin
            RindasAprekins(x, s, a, k);
            writeln(x:6:2, S:18:6, FunkcijasApreikins(x):18:6, k:12);
            x := x + 0.2;
        end;
        
    writeln ('press any key to continue...');
    readln;
End.
