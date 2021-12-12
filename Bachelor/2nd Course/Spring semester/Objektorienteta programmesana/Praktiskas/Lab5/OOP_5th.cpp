//---------------------------------------------------------------------------
#include <vcl.h>
#include <iostream.h>
#include <conio.h>
#include <cstring.h>
#pragma hdrstop
//-----------------------------------------------------------------------------
class OverflowException {
    public:
        OverflowException() {
            cout << endl << "Exception created!" << endl;
        }
        OverflowException(OverflowException&) {
            cout << "Exception copied!" << endl;
        }
        ~OverflowException() {
            cout << "Exception finished!" << endl;
        }
};
//---------------------------------------------------------------------------
template <class T>
class Settlement
{
    protected:
        char *szName;
        long int iCitizens;
        T iCode;
    public:
        Settlement();
        Settlement(char*, long int, T);
        virtual ~Settlement()
        {
           //cout<<endl<<"Message from the\"Settlement\" - destroyed!"<<endl;
        }
        virtual void Print()const;
        char* GetName() const
        {
           return szName;
        }
        void SetName(char *szName)
        {
           this->szName = szName;
        }
        long int GetCitizens() const
        {
           return iCitizens;
        }
        void SetCitizens(long int Citizens)
        {
           this->iCitizens = Citizens;
        }
        T GetCode() const;
        void SetCode(T iCode);
};
//-----------------------------------------------------------------------------
template <class T>
class City : public Settlement<T> {
    private:
        short int iQuantity;
   public:
        City(): Settlement<T>(), iQuantity(0) {}

        City(char*, long int, T, short int);

        virtual ~City()
        {
            //cout << "Message from the\"City\" - destroyed!";
        }

        short int GetQuantity() const
        {
            return this->iQuantity;
        }

        void SetQuantity(short int Quantity)
        {
            this->iQuantity = Quantity;
        }

        virtual void Print() const;
};
//---------------------------------------------------------------------------
template <class T>
class State {
    private:
        typedef City<T>* DPPointer;
        DPPointer *Inhabitants;

        static const unsigned int DEF_MAX_SIZE;
        unsigned int MaxSize;
        unsigned int Length;

    public:
        State(): MaxSize(DEF_MAX_SIZE), Length(0) {
            Inhabitants = new DPPointer[MaxSize];
        }
        State(unsigned int MaxSize): MaxSize(MaxSize), Length(0) {
            Inhabitants = new DPPointer[MaxSize];
        }
        ~State();
        static unsigned int GetDefaultMaxSize() {
            return DEF_MAX_SIZE;
        }
        unsigned int GetMaxSize() const {
            return MaxSize;
        }
        unsigned int GetLength() const {
         return Length;
        }
        void AddNode(const City<T>&);
        void Print() const;
        long GetMinInhabitants();
};
//---------------------------------------------------------------------------
template <class T>
const unsigned int State<T>::DEF_MAX_SIZE = 5;
//---------------------------------------------------------------------------
template <class T>
inline T Settlement<T>::GetCode() const {
    return iCode;
}
//---------------------------------------------------------------------------
template <class T>
inline void Settlement<T>::SetCode(T iCode) {
    this->iCode = iCode;
}
//----------------------------------------------------------------------------
template <class T>
Settlement<T>::Settlement() : szName("NULL"), iCitizens(0), iCode(0) {
}
//----------------------------------------------------------------------------
template <class T>
Settlement<T>::Settlement(char *Name, long int Citizens, T Code) {
    this->szName = Name;
    this->iCitizens = Citizens;
    this->iCode = Code;
}
//-----------------------------------------------------------------------------
template <class T>
City<T>::City(char* Name, long int Citizens, T Code, short int Quantity): Settlement<T>(Name, Citizens, Code) {
    this->iQuantity = Quantity;
}
//---------------------------------------------------------------------------
template <class T>
void Settlement<T>::Print() const {
    cout<< "Name = " << this->szName << ", CitQuantity = " << this->iCitizens <<", Code = " << this->iCode;
}
//-----------------------------------------------------------------------------
template <class T>
inline void City<T>::Print() const
{
    Settlement<T>::Print();
    cout << ", Quantity = " << iQuantity;
}
//----------------------------------------------------------------------------
template <class T>
State<T>::~State() {
    for(int i=0; i<Length; i++)
        delete Inhabitants[i];
    delete [] Inhabitants;
}
//----------------------------------------------------------------------------
template <class T>
void State<T>::Print() const {
    for (int i=0; i<Length; i++) {
        cout << (i+1) << ". ";
        Inhabitants[i]->Print();
        cout << endl;
    }
}
//----------------------------------------------------------------------------
template <class T>
void State<T>::AddNode(const City<T>& C) {
    if (Length == MaxSize)
        throw OverflowException();
    else
        Inhabitants[Length++] = new City<T>(
            C.GetName(), C.GetCitizens(), C.GetCode(),C.GetQuantity()
        );
}
//-----------------------------------------------------------------------------
template <class T>
long State<T>::GetMinInhabitants() {
    long int MinQuantity;
     MinQuantity = Inhabitants[0]->GetQuantity();

    for(int i=0; i<Length; i++) {
        if (Inhabitants[i]->GetQuantity() < MinQuantity)
            MinQuantity = Inhabitants[i]->GetQuantity();
    }
    return MinQuantity;
}
//----------------------------------------------------------------------------
#pragma argsused
int main(int argc, char* argv[]) {
    clrscr();

    State<unsigned short> *UShortState = new State<unsigned short>(5);
    State<unsigned int> *UIntState = new State<unsigned int>(4);


    City<unsigned short> *UShortC1 = new City<unsigned short>("Ivan", 5, 10, 2);
    City<unsigned int> *UIntC1 = new City<unsigned int>("Aleksandr", 6, 11, 3);

    City<unsigned short> UShortC2("Igarj", 7, 12, 4);
    City<unsigned int> UIntC2("Maksim", 8, 13, 5);

    try {
        UShortState->AddNode(*UShortC1);
        cout << "\nNew Node added successfully!" << endl;
    } catch (OverflowException&) {
        cout << "Error: maximal size exceeded!" << endl;
    } catch (...) {
        cout << "Unknown Error !" << endl;
    }

    try {
        UShortState->AddNode(UShortC2);
        cout << "\nNew Node added successfully!" << endl;
    } catch (OverflowException&) {
        cout << "Error: maximal size exceeded !" << endl;
    } catch (...) {
        cout << "Unknown Error !" << endl;
    }

    try {
        UIntState ->AddNode(*UIntC1);
        cout << "\nNew Node added successfully!" << endl;
    } catch (OverflowException&) {
        cout << "Error: maximal size exceeded !" << endl;
    } catch (...) {
        cout << "Unknown Error !" << endl;
    }

    try {
        UIntState ->AddNode(UIntC2);
        cout << "\nNew Node added successfully!" << endl;
    } catch (OverflowException&) {
        cout << "Error: maximal size exceeded !" << endl;
    } catch (...) {
        cout << "Unknown Error !" << endl;
    }

    delete UShortC1;
    delete UIntC1;

    std::cout << "\n";
    UShortState->Print();
    UIntState->Print();

    delete UShortState;
    delete UIntState;

    while (kbhit())
        getch();
    getch();

    return 0;
}
//---------------------------------------------------------------------------
