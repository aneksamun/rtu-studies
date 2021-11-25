/*
 ============================================================================
 Name        : lab3.c
 Author      : aneksamun
 Description : Strings in C, Ansi-style
 ============================================================================
 */

#include <stdio.h>
#include <stdlib.h>

#include "reversion.h"

#define SIZE 50

int main(void) {
    char s1[SIZE], s2[SIZE];

    printf("Enter input string: ");

    if (!scanf("%49s", s1)) {
        perror("\nEnable to read input string.\nProgram will exit.");
        exit(1);
    }

    printf("Enter string to compare: ");

    if (!scanf("%49s", s2)) {
        perror("\nEnable to read comparing string.\nProgram will exit.");
        exit(1);
    }

    printf("%s", is_reversible(s1, s2) ?
            "Strings are reversible!" : "Strings are not reversible same!");

    return EXIT_SUCCESS;
}
