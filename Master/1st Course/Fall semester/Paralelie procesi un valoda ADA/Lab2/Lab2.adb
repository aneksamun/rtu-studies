-- 
-- To change this template, choose Tools | Templates
-- and open the template in the editor.
-- 

--------------------------------------------------------------------------------
-- File: Lab2.adb
--
-- Created on 2010.9.10
--------------------------------------------------------------------------------

with Sq_Pack, Sq_Pack.Rec_Pack, Text_IO;
use Sq_Pack, Sq_Pack.Rec_Pack, Text_IO;

procedure Lab2 is
    s: Square;
    r: Rectangle;
begin
    Init(s, 2);
    Print(s);
    Init(r, 2, 4);
    New_Line(2);
    Print(r);
end Lab2;