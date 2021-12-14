#include <string.h>
#include <iostream.h>
#include <sstream.h>
#include <conio.h>
#include <vcl.h>
#pragma hdrstop

#pragma argsused
int main(int argc, char* argv[])
{
    int list[] = {2, -3, 4, -4, 2, 0, 2, -3};
    string s1, s2;
    stringstream out1, out2;

    for (int i = 0; i < 8; i++)
    {
        if (list[i] < 0)
        {
            out1 << list[i];
            s1 = out1.str();
        }
        else
        {
            out2 << list[i];
            s2 = out2.str();
        }
    }

    cout << "str: " << s1 + s2 << "\n";

    while (kbhit())
        getch();
	getch();

    return 0;
}
