/*
 * interface.h
 *
 *  Created on: Jul 18, 2011
 *      Author: neo
 */

#ifndef INTERFACE_H_
#define INTERFACE_H_

/*
 * Menu options.
 */
enum operations { FIND_GREAT = 1, FIND_SMALL, FIND_GREATNEG, FIND_SMALLPOS, EXIT };
extern enum operations options;

/*
 * Displays menu.
 */
void display_menu();

void display_menu() {
    printf("%d. - Find greatest digit.\n", FIND_GREAT);
    printf("%d. - Find smallest digit.\n", FIND_SMALL);
    printf("%d. - Find greatest negative digit.\n", FIND_GREATNEG);
    printf("%d. - Find smallest positive digit.\n", FIND_SMALLPOS);
    printf("%d. - Exit application.\n", EXIT);
    printf("\nOption-> ");
}

#endif /* INTERFACE_H_ */
