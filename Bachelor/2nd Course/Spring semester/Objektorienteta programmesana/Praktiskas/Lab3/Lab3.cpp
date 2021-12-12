#include <iostream>
#include <conio.h>
#pragma hdrstop

using namespace std;

class OverflowException {
    public:
        OverflowException(){
            cout << endl << "Exception created!" << endl;
        }
        OverflowException(OverflowException&){
            cout << "Exception copied!" << endl;
        }
        ~OverflowException(){
            cout << "Exception finished!" << endl;
        }
};

class Settlement {
protected:
    char *title;
    long numOfCitizens;
    short zipCode;
public:
    Settlement();
    Settlement(char*, long, short);
    virtual ~Settlement() { }

    virtual void Print()const;

    char* GetTitle() const {
        return title;
    }

    void SetTitle(char *title) {
        this->title = title;
    }
    
    long GetNumOfCitizens() const {
        return numOfCitizens;
    }

    void SetNumOfCitizens(long number) {
        this->numOfCitizens = number;
    }

    short GetZipCode() const;
    void SetZipCode(short zipCode);
};

class City : public Settlement {
private:
    short quantity;
public:
    City(): Settlement(), quantity(-1) {}
    City(char*, long, short, short);
      
    virtual ~City() {}

    short GetQuantity() const {
        return this->quantity;
    }

    void SetQuantity(short quantity) {
        this->quantity = quantity;
    }

    virtual void Print() const;
};

class State {
    private:
        typedef City* cityPtr;
        cityPtr *cities;

        static const unsigned int DEF_MAX_SIZE;
        unsigned int MaxSize;
        unsigned int Length;

   public:
        State(): MaxSize(DEF_MAX_SIZE), Length(0) {
            cities = new cityPtr[MaxSize];
        }

        State(unsigned int MaxSize) : MaxSize(MaxSize), Length(0) {
            cities = new cityPtr[MaxSize];
        }

        ~State();

        static unsigned int GetDefaultMaxSize() {
            return DEF_MAX_SIZE;
        }

        int GetMaxSize() const {
            return MaxSize;
        }

        int GetLength() const {
            return Length;
        }

        void AddNode(const City&);
        void Print() const;
        long GetMincities();
};

const unsigned int State::DEF_MAX_SIZE = 5;

inline short Settlement::GetZipCode() const {
    return zipCode;
}

inline void Settlement::SetZipCode(short int zipCode) {
    this->zipCode = zipCode;
}

Settlement::Settlement() : title("---"), numOfCitizens(-1), zipCode(-1) {}

Settlement::Settlement(char *title, long num, short int code) {
    this->title = title;
    this->numOfCitizens = num;
    this->zipCode = code;
}

City::City(char* title, long num, short code, short quantity): Settlement(title, num, code) {
    this->quantity = quantity;
}

void Settlement::Print() const {
    cout << "Title = " << this->title << ", cities = "<< this->numOfCitizens
        <<", code = " << this->zipCode;
}

inline void City::Print() const {
   Settlement::Print();
   cout << ", quantity = " << quantity;
}

State::~State() {
    for(int i = 0; i < Length; i++)
        delete cities[i];
    delete [] cities;
}

void State::Print() const {
    for (int i = 0; i < Length; i++) {
        cout << (i + 1) << ". ";
        cities[i]->Print();
        cout << endl;
    }
}

void State::AddNode(const City& city) {
    if (Length == MaxSize)
        throw OverflowException();
    else
        cities[Length++] = new City(
            city.GetTitle(),
            city.GetNumOfCitizens(), 
            city.GetZipCode(),
            city.GetQuantity()
        );
}

long State::GetMincities() {
    short minQuantity;
    minQuantity = cities[0]->GetQuantity();
  
    for(int i = 0; i < Length; i++) {
        if (cities[i]->GetQuantity() < minQuantity)
            minQuantity = cities[i]->GetQuantity();
    }
  
    return minQuantity;
}

int main() {

    State *cities = new State(2);
    City *c1 = new City("Mexica", 10110001, 10019, 220099);
    City  c2("Praga", 56666,1005,4455);

    try {
        cities->AddNode(*c1);
        cout << "\nNew Node added successfully!" << endl;
    } catch (OverflowException&) {
        cout << "Error: maximal size exceeded!" << endl;
    } catch (...) {
        cout << "Unknown Error !" << endl;
    }

    delete c1;

    try {
        cities->AddNode(c2);
        cout << "\nNew Node added successfully!" << endl;
    }
    catch (OverflowException&) {
        cout << "Error: maximal size exceeded !" << endl;
    }
    catch (...) {
        cout << "Unknown Error !" << endl;
    }

    try {
        cities->AddNode(c2);
        cout << "\nNew Node added successfully!" << endl;
    }
    catch (OverflowException&) {
        cout << "Error: maximal size exceeded !" << endl;
    } catch (...) {
        cout << "Unknown Error !" << endl;
    }

    cout << "\n\nDefault maximal size (from CLASS): " << State::GetDefaultMaxSize() << "." << endl;
    cout << "Default maximal size (from OBJECT): " << cities->GetDefaultMaxSize() << "." << endl;
    cout << "Maximal size: " << cities->GetMaxSize() << "." << endl;
    cout << "Current length: " << cities->GetLength() << "." << endl;

    cities->Print();

    cout << "\nMinimal cities Quantity: " << cities->GetMincities() << "." << endl << endl;

    delete cities;
    while (kbhit())
        getch();
    getch();

    return 0;
}
