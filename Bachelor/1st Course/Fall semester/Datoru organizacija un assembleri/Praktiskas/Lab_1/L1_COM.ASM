Comment &
   FUNKCIJA f(X, Y):
   (X^3 - 1)/(-XY - 4),  ja (X^3 - 1) > 0
   (X^3 - 1)/(2*Y + 1),  ja (X^3 - 1) < 0
&

.model tiny
.code
.startup
           Org 100h
           Jmp Short _Start  
X          Db  -2
Y          Db  -1
Two        Db  2  
Zero       Equ 0
ZDiv       Dw  0

_Start:
           Mov  Al, X
           Imul Al
           Mov  Bx, Ax
           Mov  Al, X
           Cbw
           Imul Bx

           Dec  Ax
           Jne  Not_Zero

           Mov   Dx, Zero
           Jmp   Short _Exit

Not_Zero:
           Mov  Bx, Ax 
           Jl  Branch_C

           Mov  Al, X
           Imul Y
           Neg  Ax 
           Sub  Ax, 4

           Jmp  Short Rezult

Branch_C:  
           Mov  Al, Y
           Mov  Cl, Two
           Imul Cl
           Inc  Ax
Rezult:
           Cmp  Ax, Zero
           Jne  _Div

           Mov  ZDiv, 1 
           Jmp  Short _Exit

_Div:
           Xchg Ax, Bx    ; Ax = -9 (FFF7), Bx = -1 (FFFF)
           Cwd            ; Dx = -1 (FFFF)
           IDiv Bx        ; Ax = 9, Dx = 0
_Exit:

.exit 0
end
