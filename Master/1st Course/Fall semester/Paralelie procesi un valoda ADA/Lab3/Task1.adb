--------------------------------------------------------------------------------
-- File: Lab3.adb
--
-- Created on 2010.9.10
--------------------------------------------------------------------------------

with Ada.Text_IO, Ada.Integer_Text_IO;
use Ada.Text_IO, Ada.Integer_Text_IO;

procedure Task1 is
    N, M: constant integer := 5;
    type MType is array(integer range <>, integer range <>) of integer;

    task Odd;
    task Even;

    matr: MType(1..N, 1..M) := (
        ( 1,  2,  3,  4,  5),
        ( 6,  7,  8,  9, 10),
        (11, 12, 13, 14, 15),
        (16, 17, 18, 19, 20),
        (21, 22, 23, 24, 25));

    task body Odd is
        sum: integer := 0;
        i: integer := matr'First;
    begin
        while (i <= Matr'Last) loop
            for j in matr'range(2) loop
                sum := sum + matr(i, j);
            end loop;

            Put("Sum of elements ir row "); Put(i, 1);
            Put(": "); Put(sum, 1); Put(".");
            New_Line;

            sum := 0;
            i := i + 2;
        end loop;
    end Odd;

    task body Even is
        d: constant Duration := 0.05;
        sum: integer := 0;
        i: integer := matr'First + 1;
    begin
        while (i <= Matr'Last) loop
            delay d;

            for j in matr'range(2) loop
                sum := sum + matr(i, j);
            end loop;

            Put("Sum of elements ir row "); Put(i, 1);
            Put(": "); Put(sum, 1); Put(".");
            New_Line;

            sum := 0;
            i := i + 2;
        end loop;
    end Even;
begin
    null;
end Task1s;