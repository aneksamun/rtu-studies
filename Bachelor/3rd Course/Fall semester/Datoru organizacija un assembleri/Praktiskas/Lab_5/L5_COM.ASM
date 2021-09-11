.model tiny
.code
.startup
            Org 100h
            Jmp Short Start
    N       Equ 2
    M       Equ 3
    Matrix  Dw  1, 2, 3
            Dw  4, 5, 6
    Vector  DW  N Dup (?)
    S       Equ Type Matrix
    Min     Equ 2
    Max     Equ 6

FormVector  Proc
            Push Bp
            Mov  Bp, Sp

            Push Cx
            Push Bx
            Push Dx
            Push Di
            Push Ax 

            Mov  Cx, [Bp + 4]
            Mov  Bx, [Bp + 8]
            Mov  Di, [Bp + 10]
Rows:       Push Cx
            Mov  Cx, [Bp + 6]
            Xor  Ax, Ax
Cols:       Cmp  [Bx], Word Ptr Min
            Jl   False
            Cmp  [Bx], Word Ptr Max
            Jg   False 
            Inc  Ax
False:
            Add  Bx, S
            Loop Cols

            Mov  [Di], Ax
            Pop  Cx
            Add  Di, S  
            Loop Rows   

            Pop Ax 
            Pop Di
            Pop Dx
            Pop Bx
            Pop Cx

            Pop  Bp
            Ret  2*4
FormVector  EndP

Print       Proc
            Push Bp
            Mov  Bp, Sp
            Push Cx
            Push Bx
            Push Ax

            Mov  Cx, [Bp + 4]
            Mov  Bx, [Bp + 6]
Pr:         Mov  Ax, [Bx]
            Add  Bx, S
            Loop Pr

            Pop  Ax
            Pop  Bx
            Pop  Cx
            Pop  Bp
            Ret  2*2
Print       EndP

Start:
            Lea  Ax, Vector
            Push Ax
            Lea  Ax, Matrix
            Push Ax
            Mov  Ax, M
            Push Ax 
            Mov  Ax, N
            Push Ax 
            Call FormVector            

            Lea  Ax, Vector
            Push Ax
            Mov  Ax, N
            Push Ax
            Call Print
.exit 0
end