with Text_IO;
use Text_IO;

procedure Out_t is
    type Speed is new Float range 0.0..300.0;
    type Weight is new Float range 0.0..6000.0;
    
    package IO_Speed is new Float_IO(Speed);
    use IO_Speed;
    
    package IO_Weight is new Float_IO(Weight);
    use IO_Weight;
    
    AutoSpeed : Speed := 60.0;
    AutoWeight : Weight := 2500.0;
    
begin
    Put("Speed: ");
    Put(AutoSpeed, 4, 1, 0);
    New_Line;
    
    Put("Weight: ");
    Put(AutoWeight, 4, 1, 0);
    New_Line;
    
    --AutoSpeed := AutoWeight; (Error!)
    --AutoWeight = 301.0; (Exception)
    
end Out_t;