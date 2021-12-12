#include <iostream.h>
#include "CPoint.h"

CoordPoint::CoordPoint() : X(0), Y(0) {
}

CoordPoint::CoordPoint(int Px, int Py) : X(Px) {
    Y = Py;
}

ostream& operator << (ostream& O, const CoordPoint& CP) {
    O << "X = " << CP.X << ", Y = " << CP.Y;
    return O;
}