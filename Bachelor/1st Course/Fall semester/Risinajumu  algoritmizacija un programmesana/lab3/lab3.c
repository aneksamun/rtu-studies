/*
 ============================================================================
 Name        : lab3.c
 Author      : aneksamun
 Description : Math in C, Ansi-style
 ============================================================================
 */

#include <stdio.h>
#include <stdlib.h>

#define SIZE 4086

int main(void) {

    puts(".:Closest factorial boundary calculation:.\n");
    printf("Please enter boundary of the factorial: ");

    int boundary;
    char buf[SIZE];

    // Checking input for non-characters value.
    while (1) {
        fgets(buf, SIZE, stdin);

        if (sscanf(buf, "%d", &boundary) && boundary > 0)
            break;

        puts("Unexpected boundary value!");
        printf("Please reenter boundary as decimal number which's greater when zero: ");
    }


    int factorial = 1;
    int i;

    // Calculating boundary specific factorial limits.
    for (i = 1; factorial <= boundary; i++) {
        factorial *= i;
    }

    puts("\nFactorial boundaries:");
    printf("Boundary: %d;\n", boundary);
    printf("Major factorial: %d;\n", factorial);
    printf("Closest factorial: %d.", (factorial / --i));

    return EXIT_SUCCESS;
}
