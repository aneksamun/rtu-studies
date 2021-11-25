/*
 * array_handler.h
 *
 *  Created on: Jul 17, 2011
 *      Author: neo
 */

#include <math.h>
#include <limits.h>

#ifndef ARRAY_HANDLER_H_
#define ARRAY_HANDLER_H_
#define SIZE 20

extern float range, subrange;
double digits[SIZE];
int i;

/*
 * Calculates digits according with range.
 */
void apply_range();

/*
 * Outputs an array.
 */
void display_array();

/*
 * Finds greatest digit.
 */
void find_greatest();

/*
 * Finds greatest negative digit.
 */
void find_greatnegative();

/*
 * Finds smallest digit.
 */
void find_smallest();

/*
 * Finds smallest positive digit.
 */
void find_smallpositive();

void apply_range() {
    for (i = 0; i < SIZE; i++) {
        digits[i] = 10 * sin(range);
        range += subrange;
    }
}

void display_array() {
    for (i = 0; i < SIZE; i++) {
        printf("%2d. %4.5f\t", i, digits[i]);

        if (!((i + 1) % 5)) printf("\n");
    }
}

void find_greatest() {
    int index = 0;
    double greatest = digits[index];

    for (i = 1; i < SIZE; i++)
        if (digits[i] > greatest) {
            greatest = digits[i];
            index = i;
        }

    printf("\nGreatest digit: %f\n", greatest);
    printf("Greatest digit index: %d\n", index);
}

void find_smallest() {
    int index = 0;
    double smallest = digits[index];

    for (i = 1; i < SIZE; i++)
        if (digits[i] < smallest) {
            smallest = digits[i];
            index = i;
        }

    printf("\nSmallest digit: %f\n", smallest);
    printf("Smallest digit index: %d\n", index);
}

void find_greatnegative() {
    int index = 0;
    double largest_neg = INT_MIN;

    for (i = 0; i < SIZE; i++)
        if (digits[i] < 0 && digits[i] > largest_neg) {
            largest_neg = digits[i];
            index = i;
        }

    printf("\nLargest negative digit: %f\n", largest_neg);
    printf("Largest negative digit index: %d\n", index);
}

void find_smallpositive() {
    int index = 0;
    double small_positive = INT_MAX;

    for (i = 0; i < SIZE; i++)
        if (digits[i] > 0 && digits[i] < small_positive) {
            small_positive = digits[i];
            index = i;
        }

    printf("\nSmallest positive digit: %f\n", small_positive);
    printf("Smallest positive digit index: %d\n", index);
}

#endif /* ARRAY_HANDLER_H_ */
