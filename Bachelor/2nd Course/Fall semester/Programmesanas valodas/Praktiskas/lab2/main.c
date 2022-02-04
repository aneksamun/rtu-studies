//---------------------------------------------------------------------------
#include <stdlib.h>
#include <stdio.h>
#include <conio.h>
#include <math.h>
#pragma hdrstop

#define rows 3
#define columns 3
#define rows1 5
#define columns1 5
//---------------------------------------------------------------------------

#pragma argsused
void main(int argc, char *argv[])
{
    int i, j, choise = 0;
    int array[rows][columns];
    int newarray[rows1 * columns1];
    void fun1(int array[rows][columns]);
    void fun2(int *);

    printf("\"Funkciju izmantosana masivu apstrade\"\n");

    while (choise != 1 && choise != 2)
    {
        printf("\n 1 - aizpildit massivu ar gadijuma sk,\n 2 - massiva ievade ar roku\n\n");
        scanf("%d", &choise);
    }

    switch (choise)
    {
    case 1:
        clrscr();
        randomize();

        for (i = 0; i < rows; i++)
            for (j = 0; j < columns; j++)
                array[i][j] = random(2000) - 1000;

        printf("Apstrades masivs(Index):\n\n");

        for (i = 0; i < rows; i++)
        {
            for (j = 0; j < columns; j++)
                printf(" %4d", array[i][j]);

            printf(" //%d rinda\n", i + 1);
        }
        break;
    case 2:
        printf("\nIevadiet matricas elementus: 10x6\n");

        for (i = 0; i < rows; i++)
            for (j = 0; j < columns; j++)
                scanf(" %d ", &array[i][j]);

        clrscr();
        printf("Apstrades masivs(Index):\n\n");

        for (i = 0; i < rows; i++)
        {
            for (j = 0; j < columns; j++)
                printf(" %4d", array[i][j]);

            printf("//%d rinda\n", i + 1);
        }
        break;
    }

    fun1(array);
    printf("\nNospiediet jebkuru taustinu uz nakamo masivu!\n");
    getch();

    clrscr();

    for (i = 0; i < rows1; i++)
        for (j = 0; j < columns1; j++)
            newarray[i * columns1 + j] = random(2000) - 1000;

    printf("Apstrades masivs(Pointer):\n\n");

    for (i = 0; i < rows; i++)
    {
        for (j = 0; j < columns1; j++)
            printf(" %4d", newarray[i * columns1 + j]);

        printf(" //%d rinda\n", i + 1);
    }
    fun2(newarray);
    getch();
}
//---------------------------------------------------------------------------

void fun1(int array[rows][columns])
{
    int i, j;
    int row = 0;
    int col = 0;
    int max = abs(array[row][col]);

    for (i = 0; i < rows; i++)
        for (j = 0; j < columns; j++)
            if (max < abs(array[i][j]))
            {
                max = abs(array[i][j]);
                row = i;
                col = j;
            }

    printf("\n--------------------------------\n");
    printf("\n Max by abs (Index) -> %d\n", max);
    printf("\n Max row -> %d\n", row + 1);
    printf("\n Max col -> %d\n\n", col + 1);
}

//---------------------------------------------------------------------------

void fun2(int *m)
{
    int i, j;
    int row = 0;
    int col = 0;
    int max = abs(*(m + row * columns1 + col));

    for (i = 0; i < rows1; i++)
        for (j = 0; j < columns1; j++)
            if (max < abs(*(m + i * columns1 + j)))
            {
                max = abs(*(m + i * columns1 + j));
                row = i;
                col = j;
            }

    printf("\n--------------------------------\n");
    printf("\n Max by abs(Pointer) -> %d\n", max);
    printf("\n Max row -> %d\n", row + 1);
    printf("\n Max col -> %d\n", col + 1);
}
