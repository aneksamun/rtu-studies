--------------------------------------------------------------------------------
-- File: Sq_Pack-Rec_Pack.adb
--
-- Created on 2010.9.10
--------------------------------------------------------------------------------

with Ada.Text_IO, Ada.Integer_Text_IO;
use Ada.Text_IO, Ada.Integer_Text_IO;

package body Sq_Pack.Rec_Pack is
    procedure Init(r: out Rectangle; argA, argB : in integer) is
    begin
        Sq_Pack.Init(r, argA);
        r.b := argB;
    end Init;

    procedure Print(r: in Rectangle) is
    begin
        Put_Line("Rectangle.");
        Put("   Mala a = "); Put(r.a, 1);
        Put(", mala b = "); Put(r.b, 1); Put(".");
        New_Line;
        Put("   Perimetrs: "); Put(GetPerimeter(r), 1);
        Put(", platiba: "); Put(GetArea(r), 1); Put(".");
    end Print;

    function GetPerimeter(r: in Rectangle) return integer is
    begin
        return (r.a + r.b)* 2;
    end GetPerimeter;

    function GetArea(r: in Rectangle) return integer is
    begin
        return r.a * r.b;
    end GetArea;

end Sq_Pack.Rec_Pack;
