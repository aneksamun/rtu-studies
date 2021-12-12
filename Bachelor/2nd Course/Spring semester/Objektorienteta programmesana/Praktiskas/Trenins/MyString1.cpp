//---------------------------------------------------------------------------

#include <iostream.h>
#include <conio.h>
#include <vcl.h>
#pragma hdrstop

//---------------------------------------------------------------------------

class MyString
{
private:
        char *ps; // raditajs uz virknes objektu
        int len;  // virknes garums
        int size; // virknes izmers
public:
        MyString();
        MyString(int MaxLength);
        MyString(char *ps);
        MyString(const MyString&);
        ~MyString();
        void assign(char* str);
        int length();
        void print();
        MyString& operator=(const MyString&);
};
//--------- OVERLOADING -----------------------------------------------------

MyString& MyString::operator=(const MyString& s)
{
        len = s.len;
        size = len + 1;
        if (ps) delete ps;
        ps = new char[size];
        for (int i = 0; i <= len; ++i)
        {
                ps[i] = s.ps[i];
        }
        cout << "operator = overloading" << endl;
        return *this;
}
//--------- CONSTRUCTORS ----------------------------------------------------

MyString::MyString()
{
        ps = new char[256];  // raditajs rada uz jauno inicializetu objektu
        size = 256;
        len = 0;
        //cout << "Simple constructor" << endl;
}

MyString::MyString(int MaxLength)
{
        if (MaxLength < 1)
        {
                cout << "Illegal string size :" << MaxLength;
                exit(0);
        }
        ps = new char[MaxLength+1];
        size = MaxLength + 1;
        len = 0;
        //cout << "Initalisation int constructor" << "\n";
}

MyString::MyString(char *str)
{
        len = strlen(str);
        ps = new char[len + 1];
        strcpy (ps, str);
        size = len + 1;
        //cout << "Initalisation char constructor" << endl;
}

MyString::MyString(const MyString& s) // bez kopijas konstruktora objekts a un d radis uz vienu un
{				      // to pasu atminas adresi, likvidejot objektu d, pec objekta a
        //*this = s;		      // tiks izvadita kluda, jo tada adrese ir jau atbrivota !
        len = s.len;
        size = s.size;
        ps = new char[size];
        for (int i = 0; i <= len; ++i)
        {
                ps[i] = s.ps[i];
        }
        cout << "Copy constructor" << "\n";
}
//---------- Destructor -----------------------------------------------------

MyString::~MyString()
{
        delete ps;
        //cout << "Destructor" << endl;
}
//---------- Methods --------------------------------------------------------

inline void MyString::assign(char *str)
{
        strncpy(ps, str, size);
        ps[size + 1] = '\0';
        len = strlen(str);
}

inline int MyString::length()
{
        return len;
}

inline void MyString::print()
{
        std::cout << ps << "\n";
}
//------------- MAIN --------------------------------------------------------

#pragma argsused
int main(int argc, char* argv[])
{
        char myName[] = "My name is Benjamin";
        MyString a, b(20), c("My Name is Chartles");

        a.assign("My name is Albert");
        b.assign(myName);
        a.print();
        b.print();
        c.print();

        MyString d = a;
        d.print(); 

        MyString *q;
        q = new MyString[25];
        q->assign("My name is David");
        q->print();

        getch();
        return 0;
}
//---------------------------------------------------------------------------
