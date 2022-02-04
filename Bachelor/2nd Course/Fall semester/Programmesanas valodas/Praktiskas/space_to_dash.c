# include <stdio.h>
# include <conio.h>

void space_to_dash(const char *str);

int main()
{
   space_to_dash("text example");

   getch();
   return(0);
}

void space_to_dash(const char *str)
{
   while (*str)
   {
      if (*str == ' ') printf(" %c ", '-');
      else printf(" %c ", *str);
      str++;
   }
}