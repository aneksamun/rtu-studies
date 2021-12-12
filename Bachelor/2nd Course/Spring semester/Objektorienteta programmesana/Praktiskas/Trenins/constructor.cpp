//---------------------------------------------------------------------------

#include <iostream.h>
#include <conio.h>
#include <vcl.h>
#pragma hdrstop

//---------------------------------------------------------------------------

class A {
private:
        int a;
public:
        A()
        {
           this->a = 0;
           cout << "without parametres constructor" << endl;
        }
        A(int v)
        {
           this->a = v;
           cout << "initialisation constructor" << endl;
        }
        A(const A& b){
           a = b.a;
           //*this = b;
           cout << "copy constructor" << endl;
        }
        ~A()
        {
           cout << "destructor" << "\n";
        }
        int getA(){
           return a;
        }
};
//------------------------------------------------------------------------------

//void print(A& o)
void print(A o) // parametrs ir objekts, t.i., teik padots obkjekts
{               // pec vertibas, tatad tiks izveidots kopijas objekts->
        cout << o.getA() << endl; // nostradas kopijas konstruktors
}               // te tas tiks likvidets

#pragma argsused
void main(int argc, char* argv[])
{
        cout << "main() is called" << endl;
        A f(4);         // initialisation constructor
        print(f);       // Copy constructor, 4, destructor
        cout << "main() end";
        getch();
}                       // destructor
//---------------------------------------------------------------------------
