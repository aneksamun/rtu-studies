//---------------------------------------------------------------------------

#include <vcl.h>
#include <conio.h>
#include <stdio.h>
#pragma hdrstop

#define CUBE(x) ((x)*(x)*(x))

//---------------------------------------------------------------------------

#pragma argsused
int cube (int x)
{
        printf ("x: %i \n", x);
        return x*x*x;
}

int main(int argc, char* argv[])
{
        int a, b;

        a = 3;
        b = cube (a++);
        printf ("a: %i", a);
        printf ("\n");
        printf ("b: %i", b);

        // call preprocessor
        printf ("\n \n");
        a = 3;
        b = CUBE(a++);

        printf ("a: %i", a);
        printf ("\n");
        printf ("b: %i", b);

        getch();
        return 0;
}
//---------------------------------------------------------------------------
