/*
 * file_handler.c
 *
 *  Created on: Jul 24, 2011
 *      Author: aneksamun
 */

#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#include "file_handler.h"

#define MAX 49

FILE* open_file(char *filename) {
    return fopen(filename, "r");
}

FILE* create_file(char *filename) {
    return fopen(filename, "w+");
}

bool print_file(FILE* file) {
    if (file == NULL)
        return FALSE;

    char buf[BUFSIZ];

    while (fgets(buf, BUFSIZ, file) != NULL)
        printf("%3d %s", strlen(buf), buf);

    rewind(file);

    return TRUE;
}

bool proceed_file(FILE *in, FILE* out) {
    if (in == NULL)
        return FALSE;

    if (out == NULL)
        return FALSE;

    char input[BUFSIZ], output[MAX];

    while (fgets(input, BUFSIZ, in) != NULL) {

        while (strlen(input) > MAX) {
            strncpy(output, input, MAX);

            fputs(output, out);
            fputs("\n", out);

            memmove(input, input + MAX, strlen(input));
        }

        fputs(input, out);
    }

    rewind(in);
    rewind(out);

    return TRUE;
}

void close_file(FILE* file) {
    if (file != NULL)
        fclose(file);
}
