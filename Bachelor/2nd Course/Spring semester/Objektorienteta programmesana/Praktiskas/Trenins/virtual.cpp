//---------------------------------------------------------------------------

#include <iostream.h>
#include <conio.h>
#include <vcl.h>
#pragma hdrstop

//---------------------------------------------------------------------------
class Clock
{
public:
        virtual void print() const
        {
                cout << "Clock!" << endl;
        }
};

class Alarm: public Clock
{
public:
        virtual void print() const // parladeta metode
        {
                cout << "Alarm!" << endl;
        }
};

int settime(Clock &d)
{
        d.print();
        return 0;
}

#pragma argsused
int main(int argc, char* argv[])
{
        Clock c;
        settime(c);
        Alarm a;
        settime(a);
        Clock *c1 = &c;
        c1->print();
        c1 = &a;
        ((Alarm*)c1)->print();
        getch();
        return 0;
}
//---------------------------------------------------------------------------
