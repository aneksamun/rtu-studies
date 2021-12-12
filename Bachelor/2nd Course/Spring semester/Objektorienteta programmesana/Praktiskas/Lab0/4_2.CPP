#include <stdio.h>
#include <conio.h>

struct CoordPoint
{
private:
    int X;
    int Y;

public:
    void InitCoordPoint(int ParmX, int ParmY);
    int GetX();
    int GetY();
    void SetX(int ParmX);
    void SetY(int ParmY);
    void PrintCoordPoint();
};

void CoordPoint::InitCoordPoint(int ParmX, int ParmY) {
    X = ParmX;
    Y = ParmY;
}

int CoordPoint::GetX() {
    return X;
}

int CoordPoint::GetY() {
    return Y;
}

void CoordPoint::SetX(int ParmX) {
    X = ParmX;
}

void CoordPoint::SetY(int ParmY) {
    Y = ParmY;
}

void CoordPoint::PrintCoordPoint() {
    printf("X = %d,  Y = %d.\n", X, Y);
}

void main(void) {
    CoordPoint CP;

    clrscr();

    CP.InitCoordPoint(1, 3);
    CP.PrintCoordPoint();
    CP.SetX(2);
    CP.PrintCoordPoint();

    //	CP.X = 4; aizliegts !!!

    CP.PrintCoordPoint();

    while (kbhit())
        getch();
    getch();
}
