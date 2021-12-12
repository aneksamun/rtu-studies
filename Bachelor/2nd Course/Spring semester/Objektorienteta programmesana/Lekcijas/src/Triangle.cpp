//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop
#include <iostream.h>
#include <math.h>
#include <conio.h>

//---------------------------------------------------------------------------

#pragma argsused
class Triangle
{
private:
    int a, b, c;

public:
    double area();
    int perimeter();
    void setA(int alfa)
    {
        this->a = alfa;
    }
    void setB(int beta);
    void setC(int sigma);
};

inline void Triangle::setB(int beta)
{
    this->b = beta;
}
inline void Triangle::setC(int sigma)
{
    this->c = sigma;
}

double Triangle::area()
{
    double p;
    p = (a + b + c) / 2.0;
    return (sqrt(p * (p - a) * (p - b) * (p - c)));
}

int Triangle::perimeter()
{
    return (a + b + c);
}

void main(int argc, char *argv[])
{
    Triangle t;
    double ta;

    t.setA(50);
    t.setB(60);
    t.setC(35);

    ta = t.area();
    cout << "Area of triangle is " << ta << '\n';
    cout << "Perimetr is " << t.perimeter() << '\n';

    getch();
}
//---------------------------------------------------------------------------
