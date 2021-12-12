#include <iostream.h>
#include <conio.h>
#include <vcl.h>
#pragma hdrstop

class A
{
private:
    int a;

public:
    A()
    {
        this->a = 0;
        cout << "Parametreless constructor" << endl;
    }
    A(int v)
    {
        this->a = v;
        cout << "Initialisation constructor" << endl;
    }
    A(const A &b)
    {
        a = b.a;
        //*this = b;
        cout << "Copy constructor" << endl;
    }
    ~A()
    {
        cout << "destructor"
             << "\n";
    }
    int getA()
    {
        return a;
    }
};
//------------------------------------------------------------------------------

//void print(A& o)
void print(A o)               // parametrs ir objekts, t.i., teik padots objekts pec vertibas
{                             // secigi tiks izveidots kopijas objekts, izsaucot kopijas konstruktoram
    cout << o.getA() << endl; 
} // te tas tiks likvidets

#pragma argsused
void main(int argc, char *argv[])
{
    cout << "main() is called" << endl;
    A f(4);   // Calls initialisation constructor
    print(f); // Calls a copy constructor, prints 4 and calls destructor
    cout << "main() end";
    getch();
}
