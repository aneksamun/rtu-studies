#include <iostream.h>
#include <conio.h>
#include <vcl.h>
#pragma hdrstop

class DemoStat
{
public:
    static int n;
    DemoStat()
    {
        n++;
    }
    ~DemoStat()
    {
        n--;
    }
};

int DemoStat::n = 0;

#pragma argsused
int main(int argc, char *argv[])
{
    DemoStat a, b[5];
    DemoStat *p = new DemoStat();
    std::cout << a.n << "\n";
    std::cout << b[4].n << endl;
    delete p;
    cout << DemoStat::n << endl;
    getch();
    return 0;
}
