--------------------------------------------------------------------------------
-- File: Lab4.adb
--
-- Created on 2010.18.10
--------------------------------------------------------------------------------

with Ada.Text_IO, Ada.Integer_Text_IO;
use Ada.Text_IO, Ada.Integer_Text_IO;

procedure Lab4 is
    task MaxElementInRow is
        entry TotalRows(n : in integer); -- indeksu daudzums
        entry Row(i : in integer);       -- rindiņas indekss
    end MaxElementInRow;

    task ListOfRows is
        entry Result(max : in integer);  -- aprēķinātais maksimums
    end ListOfRows;

    -- ** Calculation task **
    task body MaxElementInRow is
        n: constant integer := 5;
        length, rowIndex, max: integer;
        -- Matricas tips
        type Matrix is array
            (integer range <>, integer range <>) of integer;
        -- Matricas eksemplārs
        matr: Matrix(1..n, 1..n) :=
            ((2, 3, 6, 1, 5),
             (1, 4, 5, 6, 7),
             (3, 4, 5, 6, 8),
             (3, 5, 5, 5, 7),
             (1, 2, 5, 6, 6));
    begin
        -- Iegūstam matricas rindiņu garumu
        accept TotalRows(n: in integer) do
            length := n;
        end TotalRows;

        -- Apskatam visas rindas
        for row in 1..length loop
            accept Row(i : in integer) do
                rowIndex := i;
            end Row;
            -- Noradītas rindas pirma elementa
            -- vērtība kļūst par maksimālo
            max := matr(rowIndex, matr'First(2));

            -- Apskatām izvēlētas rindas kolonas elementus
            for col in matr'Range(2) loop
                if matr(rowIndex, col) > max then
                    max := matr(rowIndex, col);
                end if;
            end loop;

            -- Rezultāta nodošana
            ListOfRows.Result(max);
        end loop;
    end MaxElementInRow;

    -- Control task
    task body ListOfRows is
        maxElem: integer;
        -- Rindu vektors
        type Vector is array(integer range <>) of integer;
        -- Rindu indeksi :)
        vect: Vector(1..5) := (1, 2, 3, 4, 5);
    begin
        MaxElementInRow.TotalRows(vect'Length);

        -- Padodām kartējas rindas indeksu
        for i in vect'First..vect'Last loop
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
end Lab4;