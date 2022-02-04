#include<conio.h>
#include<stdio.h>

#pragma argsused
int main(int argc, char* argv[])
{
    int a = 1;
    int b = 2;
    void exchange(int*, int*);

    printf("Before Xchg\na: %d\n", a);
    printf("b: %d\n", b);

    swap(&a, &b);

    printf("After Xchg\na: %d\n", a);
    printf("b: %d", b);

    getch();

    return 0;
}

void swap(int* a, int* b)
{
    int c = *a;
    *a = *b;
    *b = c;
}
