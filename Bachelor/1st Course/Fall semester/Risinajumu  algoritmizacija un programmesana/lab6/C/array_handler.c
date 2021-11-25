/*
 * array_handler.c
 *
 *  Created on: Jul 21, 2011
 *      Author: aneksamun
 */

#include <stdio.h>
#include "array_handler.h"

#define RANGE 10

int digits[RANGE][RANGE];
int i, j, n;

void init_array() {
    for (i = 0; i < RANGE; i++)
        for (j = 0; j < RANGE; j++)
            digits[i][j] = 0;
}

void draw_figure() {
    int counter = 1;

    for (i = 2; i < 8; i++) {

        if (i < 5) {
            j = 5 - i;
            n = i + 2;
        } else {
            j = i - 4;
            n = 11 - i;
        }

        while(j <= n) {

            j += (counter == 9 || counter == 13) ? 3 : 1;

            digits[i][j] = counter++;
        }
    }
}

void print_array() {
    for (i = 0; i < RANGE; i++) {
        for (j = 0; j < RANGE; j++) {
            printf("%d\t", digits[i][j]);

            if (!((j + 1) % 10)) printf("\n");
        }
    }
}
