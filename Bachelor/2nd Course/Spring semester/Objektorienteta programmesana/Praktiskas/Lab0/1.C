#include <stdio.h>
#include <conio.h>

struct CoordPoint {
    int X;
    int Y;
};

void InitCoordPoint(struct CoordPoint* ParmCoordPoint, int ParmX, int ParmY) {
    ParmCoordPoint->X = ParmX;
    ParmCoordPoint->Y = ParmY;
}

int GetX(struct CoordPoint ParmCoordPoint) {
    return ParmCoordPoint.X;
}

int GetY(struct CoordPoint ParmCoordPoint) {
    return ParmCoordPoint.Y;
}

void SetX(struct CoordPoint* ParmCoordPoint, int ParmX) {
    ParmCoordPoint->X = ParmX;
}

void SetY(struct CoordPoint* ParmCoordPoint, int ParmY) {
    (*ParmCoordPoint).Y = ParmY;
}

void PrintCoordPoint(struct CoordPoint ParmCoordPoint) {
    printf("X = %d,  Y = %d.\n", ParmCoordPoint.X, ParmCoordPoint.Y);
}

void main(void) {
    struct CoordPoint CP;

    clrscr();

    InitCoordPoint(&CP, 1, 3);
    PrintCoordPoint(CP);
    SetX(&CP, 2);
    PrintCoordPoint(CP);
    CP.X = 4;
    PrintCoordPoint(CP);

    while (kbhit())
        getch();
    getch();
}
