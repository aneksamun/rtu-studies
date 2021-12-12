//---------------------------------------------------------------------------

#include <iostream.h>
#include <conio.h>
#include <vcl.h>
#pragma hdrstop

//---------------------------------------------------------------------------

int fun(int k)
{
        cout << "k: " << k << endl;
        return k;
}

//----------------------------------------------------------------------------

#pragma argsused
int main(int argc, char* argv[])
{
        int i = 4;
        int k, alpha;
        k = 5;
        i = i >> 1;
        cout << "i: " << i << endl;

        alpha = ++k + fun(k);
        cout << "alpha: " << alpha;
        getch();
        return 0;
}
//---------------------------------------------------------------------------
