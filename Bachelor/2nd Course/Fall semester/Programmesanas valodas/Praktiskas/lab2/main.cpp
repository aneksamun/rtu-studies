#include <stdio.h>
#include <stdlib.h>
#include <math.h>
#include <conio.h>

#define number 7

void main()
{
    int i, choise;
    int array[number]; //= {1220,1,171,7,773,8,97};
    int newarray[number];
    void fun1(int array[], int newarray[], int), fun2(int *, int);

    printf("'funkciju izmantosana masivu apstrade'\n");
    printf("\n");
    printf("'autors: Sergejs Terentjevs',\n'grupa:IIDB - 9'\n");
    printf("\n");

    printf(" 1 - aizpildit massivu ar gadijuma sk,\n 2 - massiva ievadie ar roku\n");
    printf("\n");
    scanf("%d", &choise);

    switch (choise)
    {
    case 1:
        clrscr();
        randomize();
        for (i = 0; i < number; ++i)
            array[i] = random(1000); //veidojam sakummasivu

        printf("Sakummasivs:\n");
        for (i = 0; i < number; ++i)
            printf(" %d ", array[i]); //paradam sakummasivu
        break;

    case 2:
        clrscr();
        printf("Ievadiet matricas elementus:\n");
        for (i = 0; i < number; ++i)
        {
            scanf("%d", &array[i]);
            printf("\n");
        }

        clrscr();
        printf("Sakummasivs:\n");
        for (i = 0; i < number; ++i)
            printf(" %d ", array[i]); //paradam sakummasivu
        break;
    }

    fun1(array, newarray, number); //izsaucam funkcijas
    fun2(array, number);
    printf("\n");
}

void fun1(int mas[], int newmas[], int n)
{
    register i, x, k, s;

    for (i = 0; i < n; ++i) // iesim cauri visiem elementiem
    {
        if (mas[i] > 10) // ja masiva elements ir lielaks par 10
        {
            k = mas[i]; // k vertibai tiek pieskirta massiva elementa vertiba
            x = 0;
            while (k > 10) // kamer elements lielaks par 10
            {
                s = k % 10; // s iegust elementa vertibu pec komata
                k = k / 10; // k iegust elementa vertibu pirms komata
                x += s;     // skaitam kopa elementu vertibas pec komata
            }
            newmas[i] = x + k; // massivs iegust galeja elementa k u x summu vertibu
        }
        else
            newmas[i] = mas[i]; // elements < 10, jauns masivs iegust masiva vertibu
    }
    printf("\n");
    printf("\nJauns massivs ar indeksiem:\n");

    for (i = 0; i < n; ++i)
    {
        printf(" %d ", newmas[i]);
    }
} //end fun1

void fun2(int *m, int n)
{
    register i, x, k, s;
    int h[number];

    for (i = 0; i < n; ++i)
    {
        if (*(m + i) > 10)
        {
            k = *(m + i);
            x = 0;
            while (k > 10)
            {
                s = k % 10;
                k = k / 10;
                x += s;
            }
            h[i] = x + k;
        }
        else
            h[i] = *(m + i);
    }

    printf("\n");
    printf("\nJaunais masivs ar raditajiem:\n");

    for (i = 0; i < n; ++i)
    {
        printf(" %d ", h[i]);
    }
    getch();
}
