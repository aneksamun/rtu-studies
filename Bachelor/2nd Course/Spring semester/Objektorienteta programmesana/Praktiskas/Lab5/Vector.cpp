#include <iostream>
#include <conio>
#include <vector>
#include <string>

using namespace std;

class Plane
{
private:
    string Type;

public:
    Plane() {}
    Plane(const string &pType) : Type(pType) {}
    void PrintInfo()
    {
        cout << Type;
    }
};

void main(void)
{
    const N = 3;

    int I[N] = {1, -2, 3};

    vector<int> IntVector;
    vector<Plane> PlaneVector;

    for (int i = 0; i < N; i++)
        IntVector.push_back(I[i]);

    PlaneVector.push_back(Plane("Boeing-747"));
    PlaneVector.push_back(Plane("Il-96"));

    cout << "Integer vector:" << endl;

    for (int i = 0; i < IntVector.size(); i++)
        cout << IntVector.at(i) << " ";

    cout << endl;

    cout << endl
         << "Plane vector:" << endl;

    for (int i = 0; i < PlaneVector.size(); i++)
    {
        PlaneVector.at(i).PrintInfo();
        cout << " ";
    }

    cout << endl;

    while (kbhit())
        getch();
    getch();
}
