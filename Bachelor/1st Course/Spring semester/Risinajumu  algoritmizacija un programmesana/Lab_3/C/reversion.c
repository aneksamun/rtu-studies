/*
 * reversion.c
 *
 *  Created on: Apr 27, 2012
 *      Author: aneksamun
 */
#include <string.h>

#include "reversion.h"

int is_reversible(char *s1, char *s2) {

    if (strlen(s1) != strlen(s2))
        return 0;

    int i, j;

    for (i = 0, j = strlen(s2) - 1; i < strlen(s1) && j >= 0; i++, j--) {
        if (s1[i] != s2[j])
            return 0;
    }

    return 1;
}

int is_reversible_2(char *s1, char *s2) {

    if (strlen(s1) != strlen(s2))
        return 0;

    char *s3 = ((strlen(s2) - 1) + s2);

    while (*s1 && *s3) {
        if (*s1 != *s3)
            return 0;
        s1++;
        s3--;
    }

    return 1;
}
