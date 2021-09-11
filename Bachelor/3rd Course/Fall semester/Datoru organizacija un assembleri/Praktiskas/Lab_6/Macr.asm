FormVector  Macro    R, C, Matr, Vect, _Min, _Max, _S
            Local Rows, Cols, False

            Push Ax
            Push Bx
            Push Cx
            Push Dx
            Push Di

            Mov  Cx, R
            Lea  Bx, Matr
            Lea  Di, Vect
Rows:       Mov  Dx, Cx
            Mov  Cx, C
            Xor  Ax, Ax
Cols:       Cmp  [Bx], Word Ptr _Min
            Jl   False
            Cmp  [Bx], Word Ptr _Max
            Jg   False 
            Inc  Ax
False:
            Add  Bx, _S
            Loop Cols

            Mov  [Di], Ax
            Mov  Cx, Dx
            Add  Di, S  
            Loop Rows   

            Pop  Di
            Pop  Dx
            Pop  Cx
            Pop  Bx
            Pop  Ax

            EndM

Print       Macro     R, V
            Local    Pr

            Push Ax
            Push Bx
            Push Cx

            Mov  Cx, R
            Lea  Bx, V
Pr:         Mov  Ax, [Bx]
            Add  Bx, S
            Loop Pr

            Pop  Cx
            Pop  Bx
            Pop  Ax

            EndM