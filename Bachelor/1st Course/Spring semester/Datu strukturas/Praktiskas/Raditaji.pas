Program Random;
uses crt;
var a,b,c,
    d,f,g: ^integer;
begin
    Clrscr;
    Writeln('Operacijas ar vertibam');
    New (a); 
    New (d); 
    New (f);
    d^ := 2 * 3 - 1;            
    Writeln ('4 d^ ',d^);
    f^ :=( d^ * d^) * 2;        
    Writeln ('5 f^ ',f^);
    a^ := (f^ - d^ * 2) div 2;  
    Writeln ('6 a^ ',a^);
    c := d;
    g := f;
    New (b);
    b^ := g^ - (c^ * d^) + a^;    
    Writeln ('10 b^ ',b^);
    g := a;
    c := g;
    if c = a then b^ := f^ - b^
    else b^ := f^ + b^;       
    Writeln ('13, 14 after verification b^ ',b^);
    if b^ = d^ then
    begin
        Dispose (b);
        b := d;
    end;
    c^ := (b^ * -d^ * 2 + f^) Div 10;         
    Writeln ('18 c^ ',c^);
    c := f;
    f^ := g^ + c^;                        
    Writeln ('20 f^ ',f^);
    Dispose (b);
    if c^ <> (a^ Div 2) then c^ := c^ * 2
    else begin
        b := g;
        d := a;
    end;
    Dispose (g);
    Writeln;
    Writeln ('press any key to continue..');
    Readln;
end.
