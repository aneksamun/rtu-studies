#include <stdio.h>
#include <stdlib.h>
#include <math.h>
#include <conio.h>
# define number 7
void main () 
{
  int i, choise;
  int array[number];
  int newarray[number];
  void fun1 ( int array[], int newarray[], int ), fun2 ( int*, int );
  printf(" funkciju izmantosana masivu apstrade'\n");
  printf("\n");
  printf(" autors: Sergejs Terentjevs, \n grupa:IIDB - 9 \n");
  printf("\n");
  printf(" 1 / 2 \n");
  printf("\n");
  scanf("%d", &choise);
  switch(choise)
  {
case 1:
clrscr();
randomize();
for (i=0;i<number;++i)
array[i] = random (1000);
printf ("Sakummasivs:\n"); 
for (i=0;i<number;++i) printf(" %d ",array[i]);
break;
case 2:
clrscr();
printf("Ievadiet matricas elementus:\n");
for(i=0; i<number; ++i){
scanf("%d",&array[i]);
printf("\n");}
clrscr();
printf("Sakummasivs:\n");
for (i=0;i<number;++i)
printf(" %d ",array[i]);
break;
  }
  fun1(array,newarray,number);
  fun2(array,number);
  printf("\n");
}
void fun1 (int mas[],int newmas[],int n){
register i,x,k,s;
for(i=0;i<n; ++i)
{ 
 if (mas[i] > 10)
 {
 k = mas[i];x = 0;
 while (k > 10){
 s = k%10;
 k = k/10;
 x += s;
}newmas[i] = x + k;}  
else
newmas[i]=mas[i];}
printf("\n");
printf("\nJauns massivs ar indeksiem:\n");
//Siet ir jau komentars 
for (i=0; i<n; ++i)
{
printf(" %d ", newmas[i]);
}
}
/*  Siet ir jau komentars  */
void fun2 (int* m, int n)
{
register i,x,k,s;
int h[number];

for(i=0 ; i<n; ++i)
{
	if ((*m+i)>10)
	{
	k = *(m+i);
	x = 0;
	while (k > 10)
	    {s = k%10;
	       k = k/10;
	       x += s;
	    }h[i] = x + k;
	}
	else { h[i] = *(m+i);}printf("\n");}
    printf("\nJaunais masivs ar raditajiem:\n");

for (i=0 ; i<n; ++i){
printf(" %d ", h[i]);}getch();}