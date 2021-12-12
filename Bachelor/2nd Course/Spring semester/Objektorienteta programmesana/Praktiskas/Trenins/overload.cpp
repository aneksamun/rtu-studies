//---------------------------------------------------------------------------

#include <iostream.h>
#include <conio.h>
#include <stdlib.h>
#include <vcl.h>
#pragma hdrstop

//---------------------------------------------------------------------------
// * class Vect * //

class Vect
{
private:
        int *p;
        int size;
public:
        Vect() {
                size = 16;
                p = new int[size]; // pateicoties operacijas parladesanai
        }
        Vect(int);
        Vect(const Vect&);
        Vect(const int a[], int n);
        ~Vect()
        {
                delete p;
        }
        int& operator[](int i);
        Vect& operator =(const Vect& v);

        int sizeOf() {
                return size;
        }
        void print(int n);
        void print();
};

class Ex {};

//--------------- CONSTRUCTORS ----------------------------------------------
Vect::Vect(int n)
{
        if (n <= 0)
                throw Ex();
        size = n;
        p = new int[size];
}

Vect::Vect(const Vect &v)
{
        size = v.size;
        p = new int[size];
        for (int i = 0; i < size; ++i)
        {
                p[i] = v.p[i];
        }
}

Vect::Vect(const int a[], int n)
{
        if (n <= 0)
                throw Ex();
        size = n;
        p = new int[size];
        for (int i; i < size; ++i)
        {
                p[i] = a[i];
        }
}
//------------- OVERLOADING -------------------------------------------------

int& Vect::operator[](int i)
{
        if (i < 0 || i > size - 1)
        {
                cout << "Illegal Vector index: " << i << endl;
                exit(2);
        }
        return (p[i]);
}

Vect& Vect::operator=(const Vect& v)
{
        int s = (size < v.size)? size:v.size;
        for (int i = 0; i < s; ++i) p[i] = v.p[i];
        return (*this);
}

void Vect::print(int n)
{
        int s = (n < size)?n:size;
        for(int i = 0; i < s; ++i)
                cout << p[i] << ' ';
        cout << endl;
        getch();
}

void Vect::print()
{
        print(size);
}

//---------------------------------------------------------------------------
#pragma argsused
int main(int argc, char* argv[])
{
	try{
        Vect v1;
        Vect v2;

        int i;
        for (i = 0; i < v1.sizeOf(); ++i)
                v1[i] = i+100;
        v1.print(v1.sizeOf());

        for (i = 0; i < v2.sizeOf(); ++i)
                v2[i] = i+100;
        v2.print();

        int a[] = {11, 12, 13, 14, 15, 16, 17, 18, 19};
        Vect v3(a, 5);
        v3 = v1; // overloading
        v3.print();
        for (i = 0; i < 10; ++i) v3[i] = i;
        v3.print();

        getch();
	}
	catch(Ex&)
	{
		cout << "Illegal vector size" << endl;
		getch();
	}
    return 0;
}
//---------------------------------------------------------------------------
