Program hotel;

uses crt, St01, St02;

Label Login;
var i,x,sk,k:byte;
    simb: byte;
    pass: string;

begin
    Login:
        TextBackground (White);
        Clrscr;
        TextColor(Black);
        writeln('            ____                    ');
        writeln('           /  _)))                  ');
        writeln('          (___|" -                  ');
        writeln('            ; _=                    ');
        writeln('         ___//_   /_    _________   ');
        writeln('        /)  \/ )  ))   |.        |_ ');
        writeln('       //| - -/\\/;    |.        |:|');
        writeln('      |/ |   /  \/     |.        |/ ');
        writeln('      ;  :::::         |_________|  ');
        writeln('    _(/ //////\\\\\     __|___|__   ');
        writeln(' ___/|_//////// / /____[_________]_ ');
        writeln('              |/|/                  ');
        writeln('              | |                   ');
        writeln('             (|(|                   ');
        writeln('            ,||||                   ');
        writeln('             ;=;=                   ');
        gotoXY(21,15);
        showcursor;
        TextColor (White);
        Textbackground(6);
        writeln ('.:[ Numuru uzskaites sistema veisnicai ]:.');
        Textbackground (White);
        gotoXY(30,19);
        TextColor (white);
        writeln ('Ievadiet Jusu paroli');
        gotoXY(30,20);
        TextColor(white);
        Writeln ('password:');
        gotoXY (40,20);
        TextBackground (6); Write ('          '); ;
        GotoXY (40,20);
        TextColor (Black);
        Textbackground(white);

    pass := '';

    x := 24;
    sk := 0;
    K := 9;

    repeat
        simb:=ord(readkey);
        if not (ord(simb) = 13) and (ord(simb) <> 10) then
        begin
            if ord(simb) = 27 then Exit;
            if (simb <> 8) and (Length(pass) <= 9) then 
            begin 
                pass:=pass + chr(simb); 
                inc(sk); 
            end;
            if (simb = 8) and (Length(pass) > 0) then
            begin
                dec(sk);
                delete(pass, Length(pass), 1);
            end;

            Clrscr;
            TextBackground (White);
            Clrscr;
            TextColor(Black);
            writeln('            ____                    ');
            writeln('           /  _)))                  ');
            writeln('          (___|" -                  ');
            writeln('            ; _=                    ');
            writeln('         ___//_   /_    _________   ');
            writeln('        /)  \/ )  ))   |.        |_ ');
            writeln('       //| - -/\\/;    |.        |:|');
            writeln('      |/ |   /  \/     |.        |/ ');
            writeln('      ;  :::::         |_________|  ');
            writeln('    _(/ //////\\\\\     __|___|__   ');
            writeln(' ___/|_//////// / /____[_________]_ ');
            writeln('              |/|/                  ');
            writeln('              | |                   ');
            writeln('             (|(|                   ');
            writeln('            ,||||                   ');
            writeln('             ;=;=                   ');
            gotoXY(21,15);
            TextColor (White);
            Textbackground (6);
            writeln ('.:[ Numuru uzskaites sistema veisnicai ]:.');
            Textbackground (white);
            gotoXY(30,19);
            TextColor (white);
            writeln ('Ievadiet Jusu paroli');
            gotoXY(30,20);
            TextColor(white);
            Writeln ('password:');
            gotoXY (40,20);
            TextBackground (6); Write ('          '); ;
            GotoXY (40,20);
            Textcolor (white);

            if sk <= 9 then for i := 1 to Sk do write ('*') 
            else if sk > 9 then
                if simb = 8 then
                begin
                    k:=K-1;
                    for i:=1 to K do write ('*');
                end 
            else for i:=1 to K do write ('*');
            Textbackground(white);
        end;
    until simb = 13;

    if (pass <> '111') then
    begin
        TextBackground(White);
        Clrscr;
        TextColor(Black);
        writeln('            ____                    ');
        writeln('           /  _)))                  ');
        writeln('          (___|" -                  ');
        writeln('            ; _=                    ');
        writeln('         ___//_   /_    _________   ');
        writeln('        /)  \/ )  ))   |.        |_ ');
        writeln('       //| - -/\\/;    |.        |:|');
        writeln('      |/ |   /  \/     |.        |/ ');
        writeln('      ;  :::::         |_________|  ');
        writeln('    _(/ //////\\\\\     __|___|__   ');
        writeln(' ___/|_//////// / /____[_________]_ ');
        writeln('              |/|/                  ');
        writeln('              | |                   ');
        writeln('             (|(|                   ');
        writeln('            ,||||                   ');
        writeln('             ;=;=                   ');
        gotoXY(21,15);
        TextColor (white);
        Textbackground (6);
        writeln ('.:[ Numuru uzskaites sistema veisnicai ]:.');
        Textbackground (white);
        gotoXY(30,19);
        TextColor (white);
        writeln ('Ievadiet Jusu paroli');
        gotoXY(30,20);
        TextColor(white);
        Writeln ('password:');
        gotoXY (40,20);
        TextBackground (6); Write ('          '); ;
        GotoXY (15,22);
        TextBackground(white);
        hidecursor;
        Textcolor(31); writeln ('Parole ir nepareiza, spiediet jebkuru taustinu... ');
        Readkey;
        goto Login;
    end
    else 
    begin
        hidecursor;
        menu;
    end;
end.