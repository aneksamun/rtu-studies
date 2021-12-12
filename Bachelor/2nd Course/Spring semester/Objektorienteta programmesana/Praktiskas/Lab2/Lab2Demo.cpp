#include <iostream.h>
#include <conio.h>

class CoordPoint {
   protected:
      int X;
      int Y;
   public:
      CoordPoint();
      CoordPoint(int, int);
      virtual ~CoordPoint() {
         cout << "Message from the \"CoordPoint\" - destroyed!" << endl;
      }
      int GetX() const {
         return X;
      }
      void SetX(int X) {
         this->X = X;
      }
      int GetY() const;
      void SetY(int);
      virtual void Print() const;
};

class DisplayPoint : public CoordPoint {
   private:
      unsigned int Color;
   public:
      DisplayPoint():CoordPoint(), Color(0) {
      }
      DisplayPoint(int, int, unsigned int);
      virtual ~DisplayPoint() {
         cout << endl << "Message from the \"DisplayPoint\" - destroyed!" << endl;
      }
      unsigned int GetColor() const {
         return Color;
      }
      void SetColor(unsigned int Color) {
         this->Color = Color;
      }
      virtual void Print() const;
};

CoordPoint::CoordPoint() : X(0), Y(0) {
}

CoordPoint::CoordPoint(int Px, int Py) : X(Px) {
   Y = Py;
}
inline int CoordPoint::GetY() const {
   return Y;
}
inline void CoordPoint::SetY(int Y) {
   this->Y = Y;
}
inline void CoordPoint::Print() const {
   cout << "X = " << X << ", Y = " << Y;
}

DisplayPoint::DisplayPoint(int Px, int Py, unsigned int PColor) : CoordPoint(Px, Py) {
   Color = PColor;
}

inline void DisplayPoint::Print() const {
   CoordPoint::Print();
   cout << ", Color = " << Color;
}

void main(void) {
   const int N = 3;
   DisplayPoint *DP1 = new DisplayPoint(5, 6, 10);
   CoordPoint   *DP2 = new DisplayPoint();

   CoordPoint *Points[N] = {
      new CoordPoint(1, 2),
      new DisplayPoint(),
      new DisplayPoint(3, 4, 11)
   };
   clrscr();

   cout << "Array of points: " << endl;
   for(int i=0; i<N; i++) {
      cout << (i+1) << ". ";
      Points[i]->Print();
      cout << endl;
   }

   cout << endl << "Display Point:" << endl;

   DP1->Print();
   cout << endl << "X = " << DP1->GetX() << ".";
   cout << endl << "Color = " << DP1->GetColor() << "." << endl << endl;

   for(int k=0; k<N; k++) {
      delete Points[k];
   }
   delete DP1;
   delete DP2;

   while (kbhit())
      getch();
   getch();
}
