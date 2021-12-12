#include <conio.h>
#include "cpoint.c"

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
