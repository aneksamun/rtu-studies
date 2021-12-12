Program P5;
Uses CRT;

Type
    CoordPoint = object
        private
            X : Integer;
            Y : Integer;
        public
            Constructor InitDefCoordPoint;
            Constructor InitCoordPoint(ParmX, ParmY : Integer);
            Destructor Done;
            Function GetX:Integer;
            Function GetY:Integer;
            Procedure SetX(ParmX : Integer);
            Procedure SetY(ParmY : Integer);
            Procedure PrintCoordPoint;
    End;

    Constructor CoordPoint.InitDefCoordPoint;
    Begin
        X := 1;
        Y := 3;
    End;

    Constructor CoordPoint.InitCoordPoint(ParmX, ParmY : Integer);
    Begin
        X := ParmX;
        Y := ParmY;
    End;

    Destructor CoordPoint.Done;
    Begin
        WriteLn('Object destroyed  !');
    End;

    Function CoordPoint.GetX:Integer;
    Begin
        GetX := X;
    End;

    Function CoordPoint.GetY:Integer;
    Begin
        GetY := Y;
    End;

    Procedure CoordPoint.SetX(ParmX : Integer);
    Begin
        X := ParmX;
    End;

    Procedure CoordPoint.SetY(ParmY : Integer);
    Begin
        Y := ParmY;
    End;

    Procedure CoordPoint.PrintCoordPoint;
    Begin
        Writeln('X = ', X, ',  Y = ', Y, '.');
    End;

Var
    CP1 : CoordPoint;
    CP2 : ^CoordPoint;
Begin
    ClrScr;

    CP1.InitDefCoordPoint;
    CP1.PrintCoordPoint;

    CP1.SetX(2);
    CP1.PrintCoordPoint;

    New(CP2, InitCoordPoint(5, 4));
    CP2^.PrintCoordPoint;

    CP2^.Done;
    While KeyPressed Do
        ReadKey;
    ReadKey;
End.