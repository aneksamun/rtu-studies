#include <iostream>
#include <conio.h>
#include <string.h>
#pragma hdrstop

using namespace std;

class Settlement {
private:
    char *title;
    long int numOfCitizens;
    short int zipCode;
public:
    Settlement();
    
    Settlement(char*, long int, short int);
    
    ~Settlement() {
        cout << endl << "Settlement obj destroyed now!" <<endl;
    }
    
    void Print() const;
    
    char GetTitle() const {
        return *title;
    }
    
    void SetTitle(char *title) {
        this->title = title;
    }
    
    long GetNumOfCitizens() const {
        return numOfCitizens;
    }
    
    void SetNumOfCitizens(long int number) {
        this->numOfCitizens = number;
    }
    
    short GetZipCode() const;
    void SetZipCode(short int code);
};

inline short Settlement::GetZipCode() const {
    return zipCode;
}

inline void Settlement::SetZipCode(short int zipCode) {
    this->zipCode = zipCode;
}

void Settlement::Print() const {
    cout << "Title = " << this->title << ", number of citizens = " << this->numOfCitizens << 
    ", Zip code = " << this->zipCode << endl;
}

Settlement::Settlement() : title("---"), numOfCitizens(-1), zipCode(-1) {}

Settlement::Settlement(char *title, long int numOfCitizens, short int code) {
    this->title = title;
    this->numOfCitizens = numOfCitizens;
    this->zipCode = code;
}

#pragma argsused
int main(int argc, char* argv[]) {

    Settlement s;
    s.Print();
    cout << endl << "*******************************" << endl << endl;
    
    Settlement *sl = new Settlement("Aluksne" , 2011, 2778);
    sl->Print();
    cout << endl << "*******************************" << endl << endl;
    
    s.SetTitle("Cesis");
    s.SetZipCode(1789);
    s.SetNumOfCitizens(3007);
    s.Print();

    delete sl;

    while (kbhit())
        getch();
    getch();

    return 0;
}
