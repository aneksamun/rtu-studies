#include <iostream.h>
#include <conio.h>
#include <vcl.h>
#pragma hdrstop

class MyString
{
private:
    char s[256]; // simb. 255 + '\0' -> 256
    int len;

public:
    void assign(char *);
    int length();
    void print();
};

inline void MyString::assign(char *str)
{
    strcpy(this->s, str);
    len = strlen(s);
}

inline int MyString::length()
{
    return len;
}

inline void MyString::print()
{
    std::cout << s << "\n";
}

#pragma argsused
int main(int argc, char *argv[])
{
    MyString one, two;
    one.assign("ABC");                      // Objekta one atributa s vertiba ir ABC
    two.assign("Neliels teksta fragments"); // Objekta two s vertiba ir Neliels teksta fragments

    MyString three = one;                   // Objekta three vertiba ir ABC

    one.print();
    two.print();
    three.print();

    getch();
    return 0;
}
