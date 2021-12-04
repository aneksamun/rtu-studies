-- 
-- To change this template, choose Tools | Templates
-- and open the template in the editor.
-- 

--------------------------------------------------------------------------------
-- File: Lab3.adb
--
-- Created on 2010.9.10
--------------------------------------------------------------------------------

with Ada.Text_IO, Ada.Integer_Text_IO;
use Ada.Text_IO, Ada.Integer_Text_IO;

--
-- Description of Lab3
--
-- @author neo
--

procedure Task2 is
    N, M: constant integer := 5;
    type MType is array(integer range <>, integer range <>) of integer;

    task type BaseTask(startIndex, op1, op2 : Integer);

    matr: MType(1..N, 1..M) := (
        ( 1,  2,  3,  4,  5),
        ( 6,  7,  8,  9, 10),
        (11, 12, 13, 14, 15),
        (16, 17, 18, 19, 20),
        (21, 22, 23, 24, 25));

    task body BaseTask is
        sum: integer := 0;
        i: integer := startIndex;
    begin
        while (i <= Matr'Last) loop
            delay Duration(op1)/Duration(op2);

            for j in matr'range(2) loop
                sum := sum + matr(i, j);
            end loop;

            Put("Sum of elements ir row "); Put(i, 1);
            Put(": "); Put(sum, 1); Put(".");
            New_Line;

            sum := 0;
            i := i + 2;
        end loop;
    end BaseTask;

    TaskOdd : BaseTask(matr'First, 1, 1);
    TaskEven : BaseTask(matr'First + 1, 5, 4);
begin
    null;
end Task2;