#include <sys/types.h>
#include <sys/ipc.h>
#include <sys/sem.h>
#include <sys/shm.h>
#include "shmem.h"
main()
{
    /* musu zinojuma struktura */
    Message *msgptr;
    key_t	key;
    int     shgid, semid;
    /* iegusim atslegu, ko var izmantot gan semaforam gan dalamai atminai */
    if ((key = ftok ("server", 'A' )) < 0) 
    {
        printf ("nevar iegut atslegu\n"); 
        exit(1); 
    }
    /* izveidosim dalamas atminas apgabalu */
    if ((shmid = shmget(key, sizeof(Message), PERM | IPC_CREAT)) < 0)
    {
        printf ("nevar izveidot atminas apgabalu\n"); 
        exit(1); 
    }
    /* pievienosim apgabalu */
    if ((msgptr = (Message *) shmat (shmid, 0, 0) 0 < 0) 
    {
        printf ("pievienosanas kluda\n"); 
        exit(1); 
    }
    /* izveidosim grupu no diviem semaforiem - darbam ar atminu sinhronizesanai un 
    un procesu izpildes sinhronizesanai */
    if ((semid = semget(key, 2, PERM | IPC_CREAT)) < 0)
    {
        printf("nevar izveidot semaforu\n");  
        exit(1); 
    }
    /* gaidam, kamer klients saks darbu un noblokes atminu  */
    if (semop(semid, &proc_wait[0], 1) < 0) 
    {
        printf("nevar izpildit operaciju\n"); 
        exit(1); 
    }
    /* gaidam, kamer klients pabeigs ierakstisanu atmina un atbrivos to. pec tam noblokesim atminu  */
    if (semop(semid, &mem_lock[0] , 2) < 0) 
    {
        printf("nevar izpildit operaciju\n");  
        exit(1);
    }
    /* izvadisim zinojumu uz terminalu */
    printf ("%s", msgptr->buff);
    /* atbrivosim atminu */
    if  (semop(semid, &mem_unlock[0] , 1) < 0) 
    {
        printf("nevar izpildit operaciju\n");  
        exit(1);
    }
    /* atsledzamies no atminas */
    if (shmdt(msgptr) < 0) 
    {
        printf("atslegsanas kluda\n"); 
        exit(1); 
    }
    /* visu parejo darbu ar objektu likvidaciju izpilda klients */
    exit(0);
}
