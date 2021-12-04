--------------------------------------------------------------------------------
-- File: Sq_Pack.ads
--
-- Created on 2010.9.10
--------------------------------------------------------------------------------

package Sq_Pack is
    type Square is tagged private;

    procedure Init(s: out Square'Class; argA : in integer);
    procedure Print(s: in Square);
    function GetPerimeter(s: in Square) return integer;
    function GetArea(s: in Square) return integer;

private
    type Square is tagged record
        a: integer;
    end record;
end Sq_Pack;
