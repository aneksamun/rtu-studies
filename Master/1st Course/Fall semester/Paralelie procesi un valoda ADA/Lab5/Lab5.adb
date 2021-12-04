--------------------------------------------------------------------------------
-- File: Lab5.adb
--
-- Created on 2010.1.11
--------------------------------------------------------------------------------

with Ada.Text_IO, Ada.Integer_Text_IO;
use Ada.Text_IO, Ada.Integer_Text_IO;

procedure Lab5 is
    task MaxElementInRow is
        entry TotalRows(n : in integer); -- indeksu daudzums
        entry Row(i : in integer);       -- rindinas indekss
    end MaxElementInRow;

    task ListOfRows is
        entry Result(max : in integer);  -- aprekinatais maksimums
    end ListOfRows;

    -- Calculation task
    task body MaxElementInRow is
        n: constant integer := 5;
        delayed: integer := 0;
        length, rowIndex, max: integer;
        -- Matricas tips
        type Matrix is array
            (integer range <>, integer range <>) of integer;
        -- Matricas eksemplars
        matr: Matrix(1..n, 1..n) :=
            ((2, 3, 6, 1, 5),
             (1, 4, 5, 6, 7),
             (3, 4, 5, 6, 8),
             (3, 5, 5, 5, 7),
             (1, 2, 5, 6, 6));
    begin
        -- Iegustam matricas rindinu garumu
        accept TotalRows(n: in integer) do
            length := n;
        end TotalRows;

        -- Apskatam visas rindas
        for row in 1..length loop
            select
                accept Row(i : in integer) do
                    rowIndex := i;
                end Row;

                Put("Task 'MaxElemInRow': CURRENT waiting of entry 'Row' = ");
                Put(delayed, 1);
                New_Line;
                -- Noraditas rindas pirma elementa
                -- vertiba klust par maksimalo
                max := matr(rowIndex, matr'First(2));

                -- Apskatam izveletas rindas kolonas elementus
                for col in matr'Range(2) loop
                    if matr(rowIndex, col) > max then
                        max := matr(rowIndex, col);
                    end if;
                end loop;

                -- Rezultata nodosana
                ListOfRows.Result(max);
            or
                delay 0.1;
                Put("#");
                delayed := delayed + 1;
            end select;
        end loop;
    end MaxElementInRow;

    -- Control task
    task body ListOfRows is
        maxElem: integer;
        -- Rindu vektors
        type Vector is array(integer range <>) of integer;
        -- Rindu indeksi :)
        vect: Vector(1..5) := (1, 2, 3, 4, 5);
        refusals : integer := 0;
        continue : boolean := true;
    begin
        while (continue) loop
            select
                MaxElementInRow.TotalRows(vect'Length);
                continue := false;
            else
                Put("*");
                refusals := refusals + 1;
                delay 0.5;
            end select;
        end loop;

        Put("Task 'ListOfRows': TOTAL waiting of entry 'TotalRows' = ");
        Put(refusals, 1);
        New_Line;
        
        -- Padodam kartejas rindas indeksu
        for i in vect'First..vect'Last loop
            delay 0.1;
            MaxElementInRow.Row(vect(i));

            accept Result(max: in integer) do
                maxElem := max;
            end Result;

            Put("Row: "); Put(vect(i), 1);
            Put(". Maximal element: "); Put(MaxElem, 1);
            Put_Line(".");
        end loop;
    end ListOfRows;

begin
    null;
end Lab5;