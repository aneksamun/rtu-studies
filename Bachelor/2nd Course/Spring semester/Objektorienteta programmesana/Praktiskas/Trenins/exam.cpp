//---------------------------------------------------------------------------

#include <iostream.h>
#include <conio.h>
#include <vcl.h>
#pragma hdrstop

//---------------------------------------------------------------------------

#pragma argsused
int main(int argc, char* argv[])
{
    /* 4 */
        char *t[5] = {"ONE", "TWO", "THREE", "FOUR"};
        int i = 1;
        char *s;
        s = t[i++] + 1;
        cout << "Atbilde: " << *s << endl; // ответ W -> TWO;
    /* 5 */
        cout << '\n';
        int *x, y[] = {1,2,3,4};
        x = y;
        cout << "*(y+2): " << *(y+2) << endl;
        cout << "x[2]: " << x[2] << endl;
        cout << "*(x + 2): " << *(x + 2) << endl;
        // указивают всё
    /*  7  */
        cout << '\n';
        int a = 1;
        ++a;
        //a++;
        cout << "Atbilde: " << a << endl; /* ++a -> 2 и a++ -> 2 */
        /* в этом случие результат отличается */
        //cout << ++a /* 2 */ << endl;
        //cout << a++ /* 1 */ << endl;
        getch();
        return 0;
}
//---------------------------------------------------------------------------
