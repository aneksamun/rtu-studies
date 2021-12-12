#include "DLine.h"
#include "Overfl.h"
#include <iostream.h>

const unsigned int DisplayBrokenLine::DEF_MAX_SIZE = 5;

DisplayBrokenLine::~DisplayBrokenLine() {
    for(int i=0; i<Length; i++)
        delete Nodes[i];
    delete [] Nodes;
}

ostream& operator << (ostream& O, const DisplayBrokenLine& DBL) {
    O << "\nLine Color: " << DBL.LineColor << ". Nodes:" << endl;
    for (int i=0; i<DBL.Length; i++) {
        O << (i+1) << ". " << *(DBL.Nodes[i]) << endl;
    }
    return O;
}

void DisplayBrokenLine::AddNode(const DisplayPoint& Node) {
    if (Length == MaxSize)
        throw OverflowException();
    else 
        Nodes[Length++] = new DisplayPoint(
            Node.GetX(), Node.GetY(), Node.GetColor()
        );
}