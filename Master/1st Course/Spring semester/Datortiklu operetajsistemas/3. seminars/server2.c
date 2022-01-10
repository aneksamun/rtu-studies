#include <sys/types.h>
#include <sys/ipc.h>
#include <sys/msg.h>
#include "msg.h"
main()
{
    /* musu zinojuma struktura */
    Message message;
    key_t	key;
    int     msgid, length,  n;
    /* iegusim atslegu */
    if ((key = ftok("server", 'A')) < 0) 
    {
        printf ("nevar iegut atslegu\n"); 
        exit(1); 
    }
    /* sanemamo zinojumu tips */
    message.mtype = 1L;
    /* izveidosim zinojumu rindu */
    if ((msgid = msgget(key, PERM | IPC_CREATE)) < 0) 
    {
        printf ("nevar izveidot rindu\n"); 
        exit(1); 
    }
    /* izlasisim zinojumu */
    n = msgrcv(msgid, &message, sizeof(message), message.mtype, 0);
    /* ja zinojums ir, izvadisim to uz terminalu */
    if (n > 0)  
    {
        if (write(1, message.buff, n) != n) 
        {
            printf("izvades kluda\n");  
            exit(1); 
        }
    }
    else 
    { 
        printf("zinojuma lasisanas kluda\n"); 
        exit(1); 
    }
    /* rindas likvidesanu uzticesim klientam */
    exit(0);
}
