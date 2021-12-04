--------------------------------------------------------------------------------
-- File: Sq_Pack-Rec_Pack.ads
--
-- Created on 2010.9.10
--------------------------------------------------------------------------------

package Sq_Pack.Rec_Pack is
    type Rectangle is new Sq_Pack.Square
        with private;

    procedure Init(r: out Rectangle; argA, argB : in integer);
    procedure Print(r: in Rectangle);
    function GetPerimeter(r: in Rectangle) return integer;
    function GetArea(r: in Rectangle) return integer;

private
    type Rectangle is new Sq_Pack.Square
        with record
            b: integer;
    end record;
end Sq_Pack.Rec_Pack;
