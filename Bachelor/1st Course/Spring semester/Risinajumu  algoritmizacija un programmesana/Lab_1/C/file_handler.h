/*
 * file_handler.h
 *
 *  Created on: Jul 24, 2011
 *      Author: aneksamun
 */

#ifndef FILE_HANDLER_H_
#define FILE_HANDLER_H_

enum boolean { FALSE = 0, TRUE = 1 };
typedef enum boolean bool;

/*
 * Returns opened file descriptor.
 */
FILE* open_file(char*);

/*
 * Returns created file descriptor.
 */
FILE* create_file(char*);

/*
 * Prints file content.
 */
bool print_file(FILE*);

/*
 * Proceeds source file by splitting lines.
 */
bool proceed_file(FILE*, FILE*);

/*
 * Closes file.
 */
void close_file(FILE*);

#endif /* FILE_HANDLER_H_ */
