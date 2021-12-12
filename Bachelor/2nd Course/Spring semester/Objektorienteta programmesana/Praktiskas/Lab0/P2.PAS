Program P2;
Uses CRT, CPoint;

Var
    CP : CoordPoint;
Begin
    ClrScr;

    InitCoordPoint(CP, 1, 3);
    PrintCoordPoint(CP);
    SetX(CP, 2);
    PrintCoordPoint(CP);
    CP.X := 4;
    PrintCoordPoint(CP);


    While KeyPressed Do
        ReadKey;
    ReadKey;
End.