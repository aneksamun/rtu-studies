/*
 ============================================================================
 Name        : lab6.c
 Author      : aneksamun
 Description : Two-dimensional array processing in C, Ansi-style
 ============================================================================
 */

#include <stdio.h>
#include <stdlib.h>

#include "array_handler.h"

/*
 *  __0__1__2__3__4__5__6__7__8__9
 * |
 *0|  0  0  0  0  0  0  0  0  0  0
 *1|  0  0  0  0  0  0  0  0  0  0
 *2|  0  0  0  0  1  2  0  0  0  0
 *3|  0  0  0  3  4  5  6  0  0  0
 *4|  0  0  7  8  0  0  9 10  0  0
 *5|  0  0 11 12  0  0 13 14  0  0
 *6|  0  0  0 15 16 17 18  0  0  0
 *7|  0  0  0  0 19 20  0  0  0  0
 *8|  0  0  0  0  0  0  0  0  0  0
 *9|  0  0  0  0  0  0  0  0  0  0
 */

int main(void) {

    puts("\t\t.:Lab6: Two-dimensional array processing:.\n");

    init_array();
    draw_figure();
    print_array();

    return EXIT_SUCCESS;
}
