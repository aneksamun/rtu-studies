Comment &
   FUNKCIJA f(X, Y):
   (X^3 - 1)/(-XY - 4),  ja (X^3 - 1) > 0
   (X^3 - 1)/(2*Y + 1),  ja (X^3 - 1) < 0
&

dosseg
.model small
.stack 100
.data
ZDiv       Dw  0
.const
X          Db  -2
Y          Db  -1
Zero       Equ 0
.code
.startup
.386
_Start:
           Mov   Al, X
           Imul  X
           MovSx Bx, X	
           Imul  Bx, Ax       
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

           Jmp   Short Result

Branch_C:  MovSx Ax, Y
           Imul  Ax, Ax, 2
           Inc   Ax
Result:
           Cmp   Ax, Zero
           Jne   _Div

           Mov   ZDiv, 1 
           Jmp   Short _Exit

_Div:
           Xchg  Ax, Bx
           MovSx EBx, Bx
           Cwde
           Cdq
           IDiv EBx
_Exit:

.exit 0
end
