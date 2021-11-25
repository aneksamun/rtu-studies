/*
 ============================================================================
 Name        : lab5.c
 Author      : aneksamun
 Description : One-dimensional array in C, Ansi-style
 ============================================================================
 */

#include <stdio.h>
#include <ctype.h>
#include <stdlib.h>

#include "array_handler.h"
#include "interface.h"

float range = 0.27, subrange = 0.345;
enum operations options;

int main(int argc, char *argv[]) {

    float result;
    char buf[BUFSIZ];
    int option;

    puts(".:One-dimensional array processing:.\n");

    switch(argc) {
    case 1:
        puts("Default range will be used for an array generation.");
        puts("If you would like to determine your own range,\nyou should use following command running program:");
        puts("Syntax: Program [range] [subrange]");

        break;
    case 3:

        if ((result = strtof(argv[1], NULL)) == 0)
            puts("Range value should be provided as decimal number.\nDefault value'll be used.");
        else
            range = result;

        if ((result = strtof(argv[2], NULL)) == 0)
            puts("Subrange value should be provided as decimal number.\nDefault value'll be used.");
        else
            subrange = result;
        break;
    default:
        puts("Unexpected range of the arguments.");
        puts("Syntax: Program [range] [subrange]\nor");
        puts("Syntax: Program");
        exit(-1);
    }

    printf("\n");

    apply_range();
    display_array();
    printf("\n");

    while (1) {
        display_menu();

        fgets(buf, BUFSIZ, stdin);

        if (sscanf(buf, "%d", &option) == 0) {
            puts("You must enter a valid option.\n");
            continue;
        }

        switch(option) {
        case FIND_GREAT:
            find_greatest();
            break;
        case FIND_SMALL:
            find_smallest();
            break;
        case FIND_GREATNEG:
            find_greatnegative();
            break;
        case FIND_SMALLPOS:
            find_smallpositive();
            break;
        }

        if (option == EXIT)
            break;

        printf("\n");
    }

    return EXIT_SUCCESS;
}
