-- Ar Ada95 standartā iespējām vairs nav 
-- nepieciešamības veidot pakotni vesela 
-- skaitļa izvadei:

-- with Ada.Integer_Text_IO;
-- use Ada.Integer_Text_IO;

with Text_IO;
use Text_IO;
procedure Out_i_1 is
    i : integer := 1;

    package IO_Integer is new Integer_IO(Integer);
    use IO_Integer;
begin
    Put(i, 2);
end Out_i_1;