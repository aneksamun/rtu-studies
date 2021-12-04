-- { 1, 2, 3 }
-- { 4, 5, 6 }

with Text_IO, Ada.Integer_Text_IO;
use Text_IO, Ada.Integer_Text_IO;

procedure out_a is
    N : constant Integer := 2;
    M : constant Integer := 3;
    
    type MatrixType is array (Integer range <>, Integer range <>) of Integer;
        
    Matr : MatrixType(1..N, 1..M) := ((1, 2, 3), (4, 5, 6));
    
begin
    for i in Matr'First..Matr'Last loop
        for j in Matr'Range(2) loop
            Put(Matr(i, j), 3);
        end loop;
        New_Line;
    end loop;
end out_a;