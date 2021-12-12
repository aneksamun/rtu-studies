#include <stdio.h>
#include <conio.h>

struct CoordPoint
{
private:
    int X;
    int Y;

public:
    void InitCoordPoint(int ParmX, int ParmY)
    {
        X = ParmX;
        Y = ParmY;
    }
    int GetX()
    {
        return X;
    }
    int GetY()
    {
        return Y;
    }
    void SetX(int ParmX)
    {
        X = ParmX;
    }
    void SetY(int ParmY)
    {
        Y = ParmY;
    }
    void PrintCoordPoint()
    {
        printf("X = %d,  Y = %d.\n", X, Y);
    }
};

void main(void)
{
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
