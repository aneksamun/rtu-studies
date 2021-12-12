#include <iostream.h>
#include <conio.h>

class CoordPoint
{
private:
    int X;
    int Y;

public:
    CoordPoint();
    CoordPoint(int ParmX, int ParmY);
    ~CoordPoint() {
        cout << "Object destroyed !" << endl;
    }
    int GetX();
    int GetY();
    void SetX(int ParmX);
    void SetY(int ParmY);
    void PrintCoordPoint();
};

CoordPoint::CoordPoint() {
    X = 1;
    Y = 3;
}

CoordPoint::CoordPoint(int ParmX, int ParmY) {
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
    cout << "X = " << X << ",  Y = " << Y << "." << endl;
}

void main(void)
{
    CoordPoint CP1, *CP2;

    clrscr();

    CP1.PrintCoordPoint();

    CP1.CoordPoint::SetX(2);
    CP1.PrintCoordPoint();
    CP1.CoordPoint::PrintCoordPoint();

    CP2 = new CoordPoint(5, 4);
    (*CP2).PrintCoordPoint();
    delete CP2;

    while (kbhit())
        getch();
    getch();
}
