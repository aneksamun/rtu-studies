/*
 ============================================================================
 Name        : lab1.c
 Author      : aneksamun
 Description : File processing in C, Ansi-style
 ============================================================================
 */

#include <stdio.h>
#include <stdlib.h>

#include "file_handler.h"

int main(int argc, char *argv[]) {

    if (argc > 3 || argc < 2) {
        puts("Incorrect program launch!");
        puts("Syntax: lab1 [source file] [result file]\nor");
        puts("Syntax: lab1 [source file]");
        exit(EXIT_FAILURE);
    }

    FILE *infile = NULL;
    FILE *outfile = NULL;

    char *outfilename = (argc == 3) ? argv[2] : "out.txt";

    puts("Lab1: File processing\n");

    if ((infile = open_file(argv[1])) == NULL) {
        printf("Failed to open %s file.\n", argv[1]);
        exit(EXIT_FAILURE);
    }

    if ((outfile = create_file(outfilename)) == NULL) {
        printf("Failed to create %s file.\n", outfilename);
        exit(EXIT_FAILURE);
    }

    printf("Source file '%s' content (length & text):\n", argv[1]);
    puts("-------------------------------------------------------");

    if (print_file(infile) == FALSE) {
        perror("Failed to print file content.");
        exit(EXIT_FAILURE);
    }

    if (proceed_file(infile, outfile) == FALSE) {
        perror("Failed to proceed file.");
        exit(EXIT_FAILURE);
    }

    printf("\n\nOutput file '%s' content:\n", outfilename);
    puts("-------------------------------------------------------");

    if (print_file(outfile) == FALSE) {
        perror("Failed to print file content.");
        exit(EXIT_FAILURE);
    }

    close_file(infile);
    close_file(outfile);

    return EXIT_SUCCESS;
}
