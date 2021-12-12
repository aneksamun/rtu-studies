#ifndef DPointH
#define DPointH

#include "CPoint.h"
class DisplayPoint : public CoordPoint {
    private:
        unsigned int Color;
   public:
        DisplayPoint():CoordPoint(), Color(0) {}
        DisplayPoint(int, int, unsigned int);
        virtual ~DisplayPoint() {
            //cout << endl << "Message from the \"DisplayPoint\" - destroyed!" << endl;
        }
        unsigned int GetColor() const {
            return Color;
        }
        void SetColor(unsigned int PColor) {
            this->Color = PColor;
        }
        friend ostream& operator << (ostream& O, const DisplayPoint& DP);
};

#endif