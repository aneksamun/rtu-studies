Comment &
   FUNKCIJA f(X, Y):
   (-2x^3y-z)/(xy^2-2z), ja (-2x^3y-z) > 0
   (-2x^3y-z)/(x^2y+z+1), ja (-2x^3y-z) < 0
&

.model tiny
.code
.startup
            Org 100h
            Jmp short _Start
x           db -2
y           db -1
z           db 2
; z         db 26
Zero        equ 0
ZDiv        dw  0
Two         db  2
; MyDWord   dd  ?

_Start:
            Mov  Al, x
            Imul Al
            Mov  Bx, Ax
            Mov  Al,x
            Cbw
            Imul Bx         ; Ax = x^3 = FFF8h = -8 dec

            Mov  Bx, Ax     ; Bx = Ax
            Mov  Ax, -2
            Imul Bx         ; Ax = Ax * Bx = FFFE * FFF8 = 0010h = 16dec
            
            Mov Bx, Ax
            Mov Al, y
            Cbw
            Imul Bx         ; Ax = Ax * Bx = FFFF * 0010 = FFF0h = -16dec
            
            Mov Bx, Ax
            Mov Al, z
            Cbw
            Sub Bx, Ax      ; Bx = Bx - Ax = FFF0 - 0002h= FFEEh = -18dec
                            ; Bx = Bx - Ax = FFF0 - FFE6 = Ah = 10dec
            Jne Not_Zero    ; ZF ? 1:0
            
            Mov Dx, Zero
            Jmp Short _Exit
            
Not_Zero:
            Cmp Bx, Zero
            Jl Branch_C
            
            Mov Al, y
            Imul y
            Mov Cx, Ax      ; Imul x here isn't correct
            Mov Al, x       ; because we Imul byte with word  
            Cbw             ; so we do that Mov Cx, Ax and so on
            Imul Cx         ; Ax = 0001 * FFFE = FFFEh = -2dec
            
            Push Ax
            
            Mov  Cl, Two    ; byte * byte = word
            Mov  Al, z      ; what's why we needn't Cbw
            Imul Cl         ; Ax = Cx * Ax = 0002 * FFE6 = FFCCh = -52dec
            
            Pop Cx
            
            Sub Cx, Ax      ; Cx = FFFE - FFCC = 32h = 50dec
            Mov Ax, Cx
            
            Jmp Short Rezult
            
Branch_C:
            Mov  Al, x
            Imul x
            Mov  Cx, Ax
            Mov  Al, y
            Cbw
            Imul  Cx        ; Ax = 0004 * FFFF = FFFCh = -4dec
            
            Mov Cx, Ax
            Mov Al, z
            Cbw
            Add Ax, Cx      ; Ax = 0002 + FFFC = FFFEh = -2dec
            
            Inc Ax          ; Ax = FFFE + 0001 = FFFFh = -1dec

Rezult:
            Cmp Ax, Zero
            Jne  _Div
            
            Mov  ZDiv, 1 
            Jmp  Short _Exit

_Div:
            Xchg Ax, Bx     ; Ax = FFEE, Bx = FFFF or Ax = A, Bx = 0032
            Cwd
            iDiv Bx         ; Ax = 0012h = 18dec or Ax = 0
_Exit:

.exit 0
end
