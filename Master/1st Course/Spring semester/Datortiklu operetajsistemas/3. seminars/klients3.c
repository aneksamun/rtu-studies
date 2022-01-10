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
    if ((key = ftok("server", 'A' )) < 0) 
    {
        printf("nevar iegut atslegu\n"); 
        exit(1); 
    }
    /* iegusim pieeju dalamai atminai */
    if ((shmid = shmget(key, sizeof(Message), 0)) < 0)	
    {
        printf ("pieejas kluda\n"); 
        exit(1); 
    }
    /* pievienosim apgabalu */
    if ((msgptr = (Message *) shmat (shmid, 0, 0)  < 0) 
    {
        printf("pievienosanas kluda\n"); 
        exit(1); 
    }
    /* iegusi pieeju semaforam */
    if ((semid = semget(key, 2, PERM)) < 0) 
    {
        printf  ("pieejas kluda\n");  exit(1); 
    }
    /* noblokesim atminu  */
    if (semop(semid, &mem_lock[0], 21) < 0) 
    {
        printf("nevar izpildit operaciju\n");  
        exit(1); 
    }
    /* pazinosim serverim par darba sakumu  */
    if (semop(semid, &proc_start[0], 1) < 0)
    {
        printf("nevar izpildit operaciju\n");  
        exit(1);
    }
    /* ierakstisim zinojumu atmina */
    sprintf (msgptr->buff, "Sveiks, sveiks!!\n");
    /* atbrivosim atminu */
    if (semop(semid, &mem_unlock[0], 1) < 0) 
    {
        printf("nevar izpildit operaciju\n");  
        exit(1); 
    }
    /* gaidam, kamer serveris ari atbrivos atminu */
    if (semop(semid, &mem_lock[0], 2) < 0)
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
    /* likvidesim izveidotus IPC objektus */
    if (shmctl(shmid, IPC_RMID, 0) < 0)
    {
        printf("nevar likvidet atminu\n");  
        exit(1); 
    }
    if (shmctl(shmid, 0, IPC_RMID) < 0) 
    {
        printf("nevar likvidet semaforu\n");  
        exit(1); 
    }
    exit(0);
}
