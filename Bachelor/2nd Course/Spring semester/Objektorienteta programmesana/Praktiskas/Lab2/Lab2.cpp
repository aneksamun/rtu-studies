#include <iostream>
#include <conio.h>
#pragma hdrstop

using namespace std;

class Settlement {
protected:
    char *title;
    long int numOfCitizens;
    short int zipCode;
public:
    Settlement();
    
    Settlement(char*, long int, short int);
    
    virtual ~Settlement() {
        cout<<endl<<"Message from the\"Settlement\" - destroyed!"<<endl;
    }
    
    virtual void Print()const;
                
    char* GetTitle() const {
        return title;
    }

    void SetName(char *title) {
        this->title = title;
    }

    long GetNumOfCitizens() const {
        return numOfCitizens;
    }
    
    void SetNumOfCitizens(long int number) {
        this->numOfCitizens = number;
    }

    short GetZipCode() const;
    void SetZipCode(short int zipCode);
};

class City: public Settlement {
private:
    short int quantity;
public:
    City(): Settlement(), quantity(0) {}

    City(char* title, long number, short code, 
        short num): Settlement(title, number, code) {
            this->quantity = num;
    }
    
    virtual ~City(){
        cout << "Message from the\"City\" - destroyed!";
    }

    short GetQuantity() const {
        return this->quantity;
    }

    void SetQuantity(short int quantity) {
        this->quantity = quantity;
    }
    
    virtual void Print() const;
};

inline short Settlement::GetZipCode() const{
    return zipCode;
}

inline void Settlement::SetZipCode(short int zipCode) {
    this->zipCode = zipCode;
}

Settlement::Settlement() : title("---"), numOfCitizens(-1), zipCode(-1) {}

Settlement::Settlement(char *title, long number, short code) {
    this->title = title;
    this->numOfCitizens = number;
    this->zipCode = code;
}

void Settlement::Print() const {
    cout << "Title = " << this->title << ", number of citizens = " << this->numOfCitizens
        << ", code = " << this->zipCode;
}

inline void City::Print() const {
   Settlement::Print();
   cout << ", Quantity = " << quantity;
}

int main(int argc, char* argv[]) {

    const int N = 3;
    City *city = new City("Riga", 3446786, 17090, 1790);
    Settlement *settlement = new City();

    Settlement *settlements[N] = {
        new Settlement("Varkava", 300, 7790),
        new City(),
        new City("Daugavpils",576667, 9090, 1189)
    };

    cout << "Array of points: " << endl;
    
    for (int i = 0; i < N; i++) {
        cout << (i + 1) << ". ";
        settlements[i]->Print();
        cout << endl;
    }

    cout << endl << "*******************************" << endl;

    cout << endl << "City:" << endl;
    city->Print();
    cout << endl;

    cout << endl << "Title = " << city->GetTitle() << ".";
    cout << endl << "Quantity = " << city->GetQuantity() << "." << endl;

    cout << endl << "*******************************" << endl;

    for(int k = 0; k < N; k++) {
        delete settlements[k];
    }

    delete city;
    delete settlement;

    while (kbhit())
        getch();
    getch();

    return 0;
}
