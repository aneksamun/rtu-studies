with Text_IO, Ada.Float_Text_IO;
use Text_IO, Ada.Float_Text_IO;

procedure Out_subt is
    subtype Speed is Float range 0.0..300.0;
    subtype Weight is Float range 0.0..6000.0;
    
    AutoSpeed : Speed := 60.0;
    AutoWeight : Weight := 2500.0;
    
begin
    Put("Speed: ");
    Put(AutoSpeed, 4, 1, 0);
    New_Line;
    
    Put("Weight: ");
    Put(AutoWeight, 4, 1, 0);
    New_Line;
    
    AutoWeight := AutoSpeed;
    
    Put("Weight after assignment: ");
    Put(AutoWeight, 4, 1, 0);
    New_Line;
    
end Out_subt;