#include <iostream.h>
#include <conio.h>
#pragma hdrstop

#pragma argsused
int main(int argc, char* argv[])
{
    int a, b;
    void swap(int&, int&);

    a = 1;
    b = 2;

    cout << "Before swap\n";
    cout << "a: " << a << endl;
    cout << "b: " << b << endl;

    swap(a, b);

    cout << "After swap:\n";
    cout << "a: " << a << "\n";
    cout << "b: "<< b;

    getch();

    return 0;
}

void swap(int &a, int &b)
{
    int c = a;
    a = b;
    b = c;
}