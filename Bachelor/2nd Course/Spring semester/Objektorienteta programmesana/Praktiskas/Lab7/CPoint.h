#ifndef CPointH
#define CPointH

#include <iostream.h>
class CoordPoint {
protected:
    int X;
    int Y;

public:
    CoordPoint();
    CoordPoint(int, int);
    virtual ~CoordPoint() {
        //cout << "Message from the \"CoordPoint\" - destroyed!" << endl;
    }
    int GetX() const {
        return X;
    }
    void SetX(int X) {
        this->X = X;
    }
    int GetY() const {
        return Y;
    }
    void SetY(int Y) {
        this->Y = Y;
    }
    friend ostream &operator<<(ostream &O, const CoordPoint &CP);
};

#endif