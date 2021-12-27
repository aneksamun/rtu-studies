unit utils;

INTERFACE

uses crt, dos;
var
    InProc : Boolean;

procedure FError (number: integer);
procedure InputCheck(var buf: string; max_len: integer; param: boolean);
procedure ShowCursor;
procedure HideCursor;

implementation

procedure FError (number: integer);
var
    str: string;
begin
    case number of
        1: begin
            Clrscr;
            gotoXY(10,21); Textbackground (6); TextColor(31);
            write ('Kluda, fails netika atverts, spiediet jebkuru pogu');
            Textbackground (white); Textcolor(black);
            readkey;
            exit;
        end;

        2: begin
            Clrscr;
            gotoXY (10,21); Textbackground (6); Textcolor(31);
            write ('Datu fails nesatur neviena ieraksta, spiediet jebkuru pogu');
            Textbackground (White); Textcolor(black);
            readkey;
            exit;
        end;

        3:  begin
            Clrscr;
            gotoXY(15,22); TextColor(31); Textbackground (6);
            writeln ('Sads ieraksts neeksiste. Spiediet jebkuru taustinu.');
            Textbackground (white); Textcolor(black);
            readkey;
            Exit;
        end;

        4:  begin
            Clrscr;
            gotoXY(15,22); TextColor(31); Textbackground (6);
            writeln ('Ieraksts tika izdzest, nospiediet taustinu');
            Textbackground (white); Textcolor(black);
            readkey;
            Exit;
        end;

        5: begin
            Clrscr;
            gotoXY(15,22); TextColor(31); Textbackground (6);
            writeln ('Jus noradijat nepariezo informaciju, nospiediet taustinu');
            Textbackground (white); Textcolor(black);
            readkey;
            Exit;
        end;

        6: begin
            Clrscr;
            gotoXY(15,22); TextColor(31); Textbackground (6);
            writeln ('Operacija vieksmigi izpildita, nospiediet taustinu');
            Textbackground (white); Textcolor(black);
            readkey;
            exit;
        end;
    end;
end;

procedure HideCursor;
var
    regs: registers;
begin
    regs.ax := $0100;
    regs.cx := $2607;
    intr($10, regs);
end;

procedure ShowCursor;
var
    regs : registers;
begin
    regs.ax := $0100;
    regs.cx := $0506;
    intr($10, regs);
end;

procedure InputCheck(var buf: string; max_len: integer; param: boolean);
var
    Active: Integer;
    str: string;
    ch: char;
    start_pos, i: integer;
type 
    tset = set of char;
const
    char_set: array[boolean] of tset = (
        ['0' .. '9', ':', '.'],
        ['a' .. 'z', 'A' .. 'Z', '_', #32]
    );

begin
    str := '';
    start_pos:= WhereX;
    Active := 1;
    repeat
        gotoxy(start_pos, WhereY);
        for i := (start_pos) to (start_pos + max_len - 1) do
        begin
            write (' ');
        end;
        gotoxy(start_pos, WhereY);
        write(str);
        gotoxy(start_pos + Active - 1, WhereY);

        ch := readkey;
        case ch of
        #0:
        case readkey of
            #75:
            if Active > 1 then begin { LEFT }
                dec(Active);
                gotoXY(start_pos + Active - 1, WhereY);
            end;

            #77:
            if WhereX <= (start_pos + Length(str) - 1) then begin { RIGHT }
                inc(Active);
                gotoXY(start_pos + Active - 1, Wherey);
            end;

            #83:
            if Active <= Length(str) then
                Delete(str, Active, 1); { DELETE }
            end;

            #8:
            if length(str) <> 0 then begin { BS }
                dec(Active);
                gotoXY(start_pos + Active - 1, Wherey);
                Delete(str, Active, length(str));
            end;

            #13: If Length(str) > 0 then break else continue;

            #27: 
                Begin Inproc := True; 
                Exit; 
            end;

            else begin
                if (length(str) < max_len) and (ch in char_set[param]) then begin
                    if (Active = 1) and (param) then ch:=Upcase(ch)
                    else if (param) and (ch In ['A'..'Z']) then ch:=chr(ord(ch) + 32);
                
                    if Active <= Length(str) then Insert(ch, str, active)
                    else str := str + ch;
                    inc(Active);
                end;
            end;
        end;
    until false;

    if (Length(str) < Max_Len) and param then for i:= (Length(str) + 1) to (Max_Len) do str:= str +' ';
    buf := str;
end;
end.
