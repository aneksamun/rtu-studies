/* Programma mainiga y aprekinam pec dotas formulas(19.var) */
#include <stdio.h>
#include <math.h>
#include <conio.h>

void main()
{
    float a, b, x, y, z;
    printf("Sazarotu procesu programmesana\n\nIevadiet x: \n");
    scanf("%f", &x);

    a = pow(4.2013 * sqrt(0.1) + 2 - 1 / x * cosh(2), 1. / 3);
    b = log10(2) * exp(-4 * (atan(3 + 2 * sqrt(x)) - atan(sqrt(2) / x)));
    z = fabs(a) + fabs(b);

    if (fabs(a) + fabs(b) > 1)
    {
        y = exp(-((fabs(a) + fabs(b)) / (pow(a, 2) + pow(b, 2))));
        printf("\nmodulu a,b summa ir %3.3f, tiek izpildita pirma funkcija\n", z);
    }
    else
    {
        y = sin(5 * a + 3 * b * log(3));
        printf("\nmodulu a,b summa ir %3.3f, tiek izpildita otra funkcija\n", z);
    }

    printf("\n'x' = %3.2f\n", x);
    printf("\n'a' = %6.3f\n", a);
    printf("\n'b' = %6.3f\n", b);
    printf("\n'y' = %6.3f\n", y);

    printf("\nnospiediet jebkuru taustinu, lai beigtu programmu...");
    getch();
}
