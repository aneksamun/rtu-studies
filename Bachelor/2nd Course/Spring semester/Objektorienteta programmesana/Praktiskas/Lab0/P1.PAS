Program P1;
Uses CRT;

Type
    CoordPoint = record
        X : Integer;
        Y : Integer;
    End;

    Procedure InitCoordPoint(Var ParmCoordPoint : CoordPoint; ParmX, ParmY : Integer);
    Begin
        ParmCoordPoint.X := ParmX;
        ParmCoordPoint.Y := ParmY;
    End;

    Function GetX(ParmCoordPoint : CoordPoint):Integer;
    Begin
        GetX := ParmCoordPoint.X;
    End;

    Function GetY(ParmCoordPoint : CoordPoint):Integer;
    Begin
        GetY := ParmCoordPoint.Y;
    End;

    Procedure SetX(Var ParmCoordPoint : CoordPoint; ParmX : Integer);
    Begin
        ParmCoordPoint.X := ParmX;
    End;

    Procedure SetY(Var ParmCoordPoint : CoordPoint; ParmY : Integer);
    Begin
        ParmCoordPoint.Y := ParmY;
    End;

    Procedure PrintCoordPoint(ParmCoordPoint : CoordPoint);
    Begin
        Writeln('X = ', ParmCoordPoint.X, ',  Y = ', ParmCoordPoint.Y, '.');
    End;

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