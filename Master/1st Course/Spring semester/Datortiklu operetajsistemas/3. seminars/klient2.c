#include <sys/types.h>
#include <sys/ipc.h>
#include <sys/msg.h>
#include "msg.h"
main()
{
    /* musu zinojuma struktura */
    Message message;
    key_t	key;
    int     msgid, length;
    /* sutama zinojuma tips, var izmantot multipleksesanai */
    message.mtype = 1L;
    /* iegusim atslegu */
    if ((key = ftok("server", 'A')) < 0) 
    {
        printf ("nevar iegut atslegu\n"); 
        exit(1); 
    }
    /* iegusim pieeju zinojumu rindai, kas jau ir izvedota ar serveri */
    if ((msgid = msgget(key, 0)) < 0) 
    {
        printf ("nevar iegu pieeju rindai\n"); 
        exit(1); 
    }
    /* ievietosim rindinu zinojuma */
    if ((length = sprintf(message.buff, "Sveiks, sveiks!!\n")) < 0) 
    {
        printf ("kopesanas buferi kluda\n"); 
        exit(1); 
    }
    /* sutisim zinojumu */
    if (msgsnd(msgid, (void *) &message, lenght, 0 ) != 0) 
    {
        printf ("zinojuma ierakstisanas rinda kluda\n");
        exit(1); 
    }
    /* likvidesim zinojumu rindu */
    if (msgctl(msgid, IPC_RMID, 0) < 0) 
    {
        printf("rindas likvidacijas kluda\n");  
        exit(1); 
    }
    exit(0);
}
