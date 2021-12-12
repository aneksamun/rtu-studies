#include <conio.h>
#include <iostream.h>
#include <vcl.h>
#pragma hdrstop

class Square
{
protected:
    int side;

public:
    void setSide(int &x)
    {
        side = x;
    }
    int getSide();
    int area();
    int Perimeter();
    Square()
    {
        this->side = 0;
    }
    Square(const Square &);
    ~Square() {}
};

Square::Square(const Square &t)
{
    *this = t;
}

/*Square& Operator=(const Square& t)
{
        *this = t;
        return *this;
}*/

inline int Square::getSide()
{
    return this->side;
}

inline int Square::Perimeter()
{
    return 4 * this->side;
}

inline int Square::area()
{
    return side * side;
}

#pragma argsused
int main(int argc, char *argv[])
{
    Square s;
    Square d = s;
    s.setSide(20);
    std::cout << "side = " << s.getSide() << endl;
    std::cout << "area = " << s.area() << "\n";
    std::cout << "perimeter = " << s.Perimeter() << endl;
    getch();
    return 0;
}
