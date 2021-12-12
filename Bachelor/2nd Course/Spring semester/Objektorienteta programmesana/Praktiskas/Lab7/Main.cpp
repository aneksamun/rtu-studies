#include <conio.h>
#include <iostream.h>
#include "DLine.h"
#include "Overfl.h"

void main(void) {
    DisplayBrokenLine *DL = new DisplayBrokenLine(2, 3);

    DisplayPoint *D1 = new DisplayPoint(10, 11, 12);
    DisplayPoint  D2(13, 14, 15);

    try {
        DL->AddNode(*D1);
        cout << "\nNew Node added successfully!" << endl;
    } catch (OverflowException&) {
        cout << "Error: maximal size exceeded!" << endl;
    } catch (...) {
        cout << "Unknown Error !" << endl;
    }


    try {
        DL->AddNode(D2);
        cout << "\nNew Node added successfully!" << endl;
    } catch (OverflowException&) {
        cout << "Error: maximal size exceeded !" << endl;
    } catch (...) {
        cout << "Unknown Error !" << endl;
    }

    try {
        DL->AddNode(D2);
        cout << "\nNew Node added successfully!" << endl;
    } catch (OverflowException&) {
        cout << "Error: maximal size exceeded !" << endl;
    } catch (...) {
        cout << "Unknown Error !" << endl;
    }

    cout << "\n\nDefault maximal size (from CLASS): " << DisplayBrokenLine::GetDefaultMaxSize() << "." << endl;
    cout << "Default maximal size (from OBJECT): " << DL->GetDefaultMaxSize() << "." << endl;
    cout << "Maximal size: " << DL->GetMaxSize() << "." << endl;
    cout << "Current length: " << DL->GetLength() << "." << endl;

    cout << *DL;

    delete DL;

    while (kbhit())
        getch();
    getch();
}
