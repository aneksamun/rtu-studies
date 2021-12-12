#ifndef OverflH
#define OverflH

#include <iostream.h>
class OverflowException {
public:
    OverflowException() {
        cout << endl << "Exception created!" << endl;
    }
    OverflowException(OverflowException &) {
        cout << "Exception copied!" << endl;
    }
    ~OverflowException() {
        cout << "Exception finished!" << endl;
    }
};

#endif