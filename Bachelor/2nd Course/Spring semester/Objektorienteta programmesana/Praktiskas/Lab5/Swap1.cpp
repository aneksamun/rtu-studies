#include <iostream.h>
#include <cstring.h>
#include <conio.h>

template <class T>
void Swap(T &A, T &B)
{
    T C;

    C = A;
    A = B;
    B = C;
}

class Plane
{
private:
    string Type;

public:
    Plane() : Type("") {}
    Plane(const string &pType) : Type(pType) {}
    void PrintInfo()
    {
        cout << "Type: " << Type;
    }
};

void main(void)
{
    int iX = 2, iY = 3;
    float fX = 2.5, fY = 3.5;
    Plane P1("Boeing - 747"), P2("Il - 96");

    cout << "X: " << iX << ", Y: " << iY << "." << endl;
    Swap(iX, iY);
    cout << "X: " << iX << ", Y: " << iY << "." << endl;

    cout << "------------------------" << endl;

    cout << "X: " << fX << ", Y: " << fY << "." << endl;
    Swap(fX, fY);
    cout << "X: " << fX << ", Y: " << fY << "." << endl;

    cout << "------------------------" << endl;

    P1.PrintInfo();
    cout << ", ";
    P2.PrintInfo();
    cout << "." << endl;
    Swap(P1, P2);
    P1.PrintInfo();
    cout << ", ";
    P2.PrintInfo();
    cout << "." << endl;

    getch();
}
