Unit CPoint;
Interface

Type
    CoordPoint = record
        X : Integer;
        Y : Integer;
    End;
    Procedure InitCoordPoint(Var ParmCoordPoint : CoordPoint;
        ParmX, ParmY : Integer);
    Function GetX(ParmCoordPoint : CoordPoint):Integer;
    Function GetY(ParmCoordPoint : CoordPoint):Integer;
    Procedure SetX(Var ParmCoordPoint : CoordPoint; ParmX : Integer);
    Procedure SetY(Var ParmCoordPoint : CoordPoint; ParmY : Integer);
    Procedure PrintCoordPoint(ParmCoordPoint : CoordPoint);

implementation
Uses CRT;

    Procedure InitCoordPoint;
    Begin
        ParmCoordPoint.X := ParmX;
        ParmCoordPoint.Y := ParmY;
    End;

    Function GetX;
    Begin
        GetX := ParmCoordPoint.X;
    End;

    Function GetY;
    Begin
        GetY := ParmCoordPoint.Y;
    End;

    Procedure SetX;
    Begin
        ParmCoordPoint.X := ParmX;
    End;

    Procedure SetY;
    Begin
        ParmCoordPoint.Y := ParmY;
    End;

    Procedure PrintCoordPoint;
    Begin
        Writeln('X = ', ParmCoordPoint.X, ',  Y = ', ParmCoordPoint.Y, '.');
    End;
End.