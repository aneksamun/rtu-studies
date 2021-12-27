/*
 ============================================================================
 Name        : lab7.c
 Author      : aneksamun
 Description : Mathematical series calculation in C, Ansi-style
 ============================================================================
 */

#include <stdio.h>
#include <stdlib.h>
#include <math.h>

int main(void) {
    
    puts("\t.:Lab7: Mathematical series calculation:.\n");

    int i;
    float n, a, sum, result;

    printf("Step\t\tSum\t\tResult\t\tAccuracy\n");
    printf("--------------------------------------------------------\n");

    for (n = -2.0; n < 2.2; n += 0.2) {
        i = 1;
        sum = a = n / 9;

        while (fabs(a) > 0.0000001) {
            a *= -1 * (n * n / 9);
            sum += a;
            i++;
        }

        result = n / (9 + pow(n, 2.0f));

        printf("%f %15f %15f %9d\n", n, sum, result, i);
    }

    return EXIT_SUCCESS;
}
