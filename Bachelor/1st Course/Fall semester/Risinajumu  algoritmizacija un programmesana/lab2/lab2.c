/*
 ============================================================================
 Name        : lab2.c
 Author      : aneksamun
 Description : Math in C, Ansi-style
 ============================================================================
 */

#include <stdio.h>
#include <stdlib.h>
#include <math.h>

int main(void) {

    puts(".:Basic math operations in C language:.\n");
    printf("Please enter circle area: ");

    float area;

    if (scanf("%f", &area) != 1) {
        printf("Value must be entered as decimal number.\n");
        exit(-1);
    }

    double radius = sqrt(area/M_PI);

    printf("Circle radius = %5.2f.\n", radius);
    printf("Square second side = %5.2f.", area / radius);

    return EXIT_SUCCESS;
}
