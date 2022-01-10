#include <sys/types.h>
#include <sys/stat.h>
/* FIFO varda saskanosana */
#define FIFO "fifo.1"
main()
{
    int writefd, n;
    /* iegusim pieeju pie FIFO */
    if ((readfd = open(FIFO,  O_WRONLY)) < 0) 
    {
        printf ("nevar atvert FIFO\n"); exit(1); 
    }
    /* sutam  zinojumu serverim FIFO */
    if (write(writefd, "Sveiks, sveiks!!\n", 18) != 18)
    {
        printf("rakstisanas kluda\n"); 
        exit(1); 
    }
    /* aizveram FIFO */
    close (writefd);
    /* likvidesim FIFO */
    if (unlink(FIFO) < 0) 
    {
        printf  ("nevar likvidet FIFO\n");  exit(1); 
    }
    exit(0);
}
