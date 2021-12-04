with Text_IO;
use Text_IO;
procedure Out_i_3 is
    type Integer_1_100 is new Integer
        range 1..100;
    i : Integer_1_100 := 1;
    
    package IO_Integer_1_100 is new 
        Integer_IO(Integer_1_100);
    use IO_Integer_1_100;
    
begin
    Put(i, 2);
end Out_i_3;