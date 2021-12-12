//---------------------------------------------------------------------------

#include <conio.h>
#include <iostream.h>
#include <math.h>
#include <vcl.h>
#pragma hdrstop

//---------------------------------------------------------------------------

class Ex
{
};

class Triangle
{
    int a, b, c;

public:
    Triangle() : a(0), b(0), c(0)
    {
    }
    Triangle(int x, int y, int z)
    {
        if (x + y <= z || x + z <= y || z + y <= x)
            throw Ex();
        a = x;
        b = y;
        c = z;
    }
    float area();
};

inline float Triangle::area()
{
    float p = (a + b + c) / 2.0;
    return (sqrt(p * (p - a) * (p - b) * (p - c)));
}

#pragma argsused
int main(int argc, char *argv[])
{
    try
    {
        Triangle t(40, 50, 30);
        cout << t.area() << endl;

        Triangle f(4, 15, 3);
        cout << f.area() << endl;
    }
    catch (Ex &)
    {
        cout << "Malu garumi ir nepariezi" << endl;
    }
    catch (...)
    {
        cout << "Unknown exception!" << endl;
    }
    getch();
    return 0;
}
//---------------------------------------------------------------------------
