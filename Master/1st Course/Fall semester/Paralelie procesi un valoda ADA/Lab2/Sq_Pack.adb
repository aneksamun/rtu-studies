--------------------------------------------------------------------------------
-- File: Sq_Pack.adb
--
-- Created on 2010.9.10
--------------------------------------------------------------------------------

with Ada.Text_IO, Ada.Integer_Text_IO;
use Ada.Text_IO, Ada.Integer_Text_IO;

package body Sq_Pack is
    procedure Init(s: out Square'Class; argA : in integer) is
    begin
        s.a := argA;
    end Init;

    procedure Print(s: in Square) is
    begin
        Put_Line("Square.");
        Put("   Mala a = "); Put(s.a, 1); Put(".");
        New_Line;
        Put("   Perimetrs: "); Put(GetPerimeter(s), 1);
        Put(", platiba: "); Put(GetArea(s), 1); Put(".");
    end Print;

    function GetPerimeter(s: in Square) return integer is
    begin
        return s.a * 4;
    end GetPerimeter;

    function GetArea(s: in Square) return integer is
    begin
        return s.a * s.a;
    end GetArea;

end Sq_Pack;
