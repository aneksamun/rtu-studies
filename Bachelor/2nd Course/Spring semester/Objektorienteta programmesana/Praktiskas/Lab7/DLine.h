#ifndef DLineH
#define DLineH

#include "DPoint.h"
#include <iostream.h>

class DisplayBrokenLine
{
private:
    typedef DisplayPoint *DPPointer;
    DPPointer *Nodes;

    static const unsigned int DEF_MAX_SIZE;
    unsigned int MaxSize;
    unsigned int Length;
    unsigned int LineColor;

public:
    DisplayBrokenLine() : MaxSize(DEF_MAX_SIZE), Length(0), LineColor(0) {
        Nodes = new DPPointer[MaxSize];
    }
    DisplayBrokenLine(unsigned int MaxSize, unsigned int LineColor) : MaxSize(MaxSize), Length(0) {
        this->LineColor = LineColor;
        Nodes = new DPPointer[MaxSize];
    }
    ~DisplayBrokenLine();
    static unsigned int GetDefaultMaxSize() {
        return DEF_MAX_SIZE;
    }
    int GetMaxSize() const {
        return MaxSize;
    }
    int GetLength() const {
        return Length;
    }
    void AddNode(const DisplayPoint &);
    friend ostream &operator<<(ostream &O, const DisplayBrokenLine &DBL);
};
#endif
