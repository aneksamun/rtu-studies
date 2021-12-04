--------------------------------------------------------------------------------
-- File: Task3.adb
--
-- Created on 2010.15.11
--------------------------------------------------------------------------------

with Ada.Text_IO, Ada.Integer_Text_IO;
use Ada.Text_IO, Ada.Integer_Text_IO;

procedure Task3 is
    cols: integer := 5;
    rows: integer := 5;
    type MatrixType is
        array(integer range <>, integer range<>) of integer;
    matr: MatrixType(1..cols, 1..rows) :=
           ((1, 2, 3, 4, 5),
            (6, 7, 8, 9, 10),
            (11, 12, 13, 14, 15),
            (16, 17, 18, 19, 20),
            (21, 22, 23, 24, 25));

    task type Printing(startRow: integer);

    protected Resource is
        procedure PrintRow(row: in integer; pMatr: in MatrixType);
    end Resource;

    protected body Resource is
        procedure PrintRow(row: in integer; pMatr: in MatrixType) is
        begin
            put("Row: ");
            put(row, 1);
            put(". Elements: ");

            for i in pMatr'Range(2) loop
                put(pMatr(row, i), 3);
                put(" ");
            end loop;

            New_Line;
        end PrintRow;
     end Resource;

    task body Printing is
        i : integer := startRow;
    begin
        while(i <= matr'Last) loop
            Resource.PrintRow(i, matr);
            i := i + 2;
        end loop;
    end Printing;

    odd : Printing(matr'First);
    even : Printing(matr'First + 1);
begin
    null;
end Task3;