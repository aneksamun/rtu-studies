Comment &
   FUNKCIJA f(X, Y):
   (X^3 - 1)/(-XY - 4),  ja (X^3 - 1) > 0
   (X^3 - 1)/(2*Y + 1),  ja (X^3 - 1) < 0
&

.model tiny
.code
.startup
.386
           Org 100h
           Jmp Short _Start  
X          Db  -2
Y          Db  -1
Zero       Equ 0
ZDiv       Dw  0
_Start:
           Mov   Al, X
           Imul  X
           MovSx Bx, X     ;386
           Imul  Bx, Ax    ;386
           Dec   Bx
           Jne   Not_Zero

           Mov   Dx, Zero
           Jmp   Short _Exit

Not_Zero:
           Jl  Branch_C

           Mov   Al, X
           Imul  Y
           Neg   Ax 
           Sub   Ax, 4

           Jmp   Short Rezult

Branch_C:  MovSx  Ax, Y
           Imul   Ax, Ax, 2
           Inc    Ax
Rezult:
           Cmp    Ax, Zero
           Jne    _Div

           Mov    ZDiv, 1 
           Jmp    Short _Exit

_Div:
           Xchg   Ax, Bx
           MovSx  EBx, Bx
           Cwde
           Cdq
           IDiv   EBx
_Exit:

.exit 0
end
