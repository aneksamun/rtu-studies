#include <iostream.h>
#include <conio.h>
#include <vcl.h>
#pragma hdrstop
using namespace std;

#pragma argsused
int main(int argc, char *argv[])
{
    char *t[5] = {"ONE", "TWO", "THREE", "FOUR"};
    int i = 1;
    char *s;
    // t[i++] => T
    // t[i++] + 1 => W
    s = t[i++] + 1;
    cout << "Atbilde: " << *s << endl; // W;

    cout << endl;

    int *x, y[] = {1, 2, 3, 4};
    x = y;
    cout << "*(y+2): " << *(y + 2) << endl;   // 3
    cout << "x[2]: " << x[2] << endl;         // 3
    cout << "*(x + 2): " << *(x + 2) << endl; // 3
    return 0;

    cout << endl;

    int a = 1;
    ++a;
    //a++;
    cout << "Atbilde: " << a << endl; // ++a = 2; a++ = 2

    //cout << ++a /* 2 */ << endl;
    //cout << a++ /* 1 */ << endl;

    int i = 4;
    int k, alpha;
    k = 5;
    i >>= 1;                        // 4 / 2 = 2
    cout << "i: " << i << endl;

    alpha = ++k + fun(k);           // 6 + 6
    cout << "alpha: " << alpha;     // 12

    getch();
    return 0;
}
