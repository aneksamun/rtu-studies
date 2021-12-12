#include "DPoint.h"
#include <iostream.h>

DisplayPoint::DisplayPoint(int Px, int Py, unsigned int PColor) : CoordPoint(Px, Py) {
    Color = PColor;
}

ostream& operator << (ostream& O, const DisplayPoint& DP) {
    O << (CoordPoint&) DP << ", Color = " << DP.Color;
    return O;
}