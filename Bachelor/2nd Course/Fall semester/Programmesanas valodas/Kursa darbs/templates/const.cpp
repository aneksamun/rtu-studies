#include <stdio.h> #include <conio.h> int main();void sp_to_dash (const char *str); int main() { int a;sp_to_dash ( "text examp*e" );
if( a == 1 ){ return 1;} getch ();return (0); } void sp_to_dash (const char *str){ while(*str) { if ( *str == ' ') 
printf ("%c",'-');
else printf ("%c", *str); str++; } }