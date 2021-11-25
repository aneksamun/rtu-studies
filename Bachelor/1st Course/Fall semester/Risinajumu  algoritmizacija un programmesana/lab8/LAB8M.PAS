{$B+,D+,E+,I+,N+,Q+,R+,X-}
{ Laboratijas darbs #8 }

Program RINDA;
uses crt;
var X, S: Real;
    k: Integer;

Procedure RindasAprekins(y: Real; var z: Real; var i: Integer);
var r:real;
Begin
    Z := y / 9;
    R := y / 9;
    I := 1;
    While ABS(R) > 0.0000001 Do
    Begin
        R := R * -1 * (y * y / 9);
        Z := Z + R;
        I := I + 1
    End;
End;

Function FunkcijasApreikins(x:real): Real;
Begin
    FunkcijasApreikins := x / (9 + x * x);
End;

Begin
    Clrscr;
    Writeln('  x            Rinda      Standartfunkcija    Loc. skaits rindaa');
    X := -2;
  
    While x < 2.2 Do
    Begin
        RindasAprekins(x, s, k);
        writeln(x:6:2, S:18:6, funkcijasApreikins(x):18:6, k:12);
        x := x + 0.2;
    End;
    
    Writeln('press any key to continue...');
    Readln;
End.
