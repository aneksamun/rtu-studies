#include <sys/types.h>
#include <sys/stat.h>
#define FIFO "fifo.1"
#define MAXBUFF	80
main()
{
    int readfd, n;
    char buff[MAXBUFF];  /*buferis datu nolasisanai no FIFO*/
    /* izveidosim specialu FIFO failu ar atlauju lasit un rakstit visiem */
    if (mknod (FIFO, S_IFIFO | 0666, 0) < 0) 
    {
        printf ("nevar izveidot FIFO\n"); 
        exit(1); 
    }
    /* iegusim pieeju pie FIFO */
    if ((readfd = open(FIFO, O_RDONLY)) < 0) 
    {
        printf ("nevar atvert FIFO\n"); 
        exit(1); 
    }
    /* izlasisim zinojumu ("Sveiks, sveiks!!") un izvadisim to uz ekranu */
    while ((n = read(readfd,  buff,  MAXBUFF)) > 0)
        if  (write(1, buff, n) != n) 
        {
            printf ("izvades kluda\n"); 
            exit(1); 
        }
    /* aizveram FIFO, FIFO likvidacija ir klienta lieta */
    close (readfd);
    exit(0);
}
