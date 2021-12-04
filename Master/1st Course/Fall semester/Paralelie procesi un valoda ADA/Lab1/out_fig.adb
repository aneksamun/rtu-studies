with Text_IO;
use Text_IO;

procedure Out_Fig is
    type Shapes is (Square, Rectangle, Circle);
    
    package IO_Shapes is new
        Enumeration_IO(Enum => Shapes);
    use IO_Shapes;
    
begin
    for Shape in Shapes loop
        Put(Shape);
        New_Line;
    end loop;
end Out_Fig;