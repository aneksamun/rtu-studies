Comment &
   FUNKCIJA f(X, Y):
   (-2x^3y-z)/(xy^2-2z), ja (-2x^3y-z) > 0
   (-2x^3y-z)/(x^2y+z+1), ja (-2x^3y-z) < 0
&

.model tiny
.code
.startup
.386
           Org 100h
           Jmp Short _Start  
x          db  -2
y          db  -1
;z          db	2
z          db  -26
Zero       Equ  0
ZDiv       dw   0

_Start:
           Mov   Al, x		 ; Ax = ??FE 
           Imul  x		 ; Ax = 0004h = 4dec
           MovSx Bx, x           ; Bx = FFFE -> Add FF or 00 sign to Byte		
           Imul  Bx, Ax          ; Bx = FFF8h = -8dec

           Imul  Bx, -2          ; Bx = FFF8 * FFFE = 0010h = 16dec
    

           MovSx Ax, y		 ; Ax = FFFF
           Imul  Bx, Ax          ; Bx = FFF0h = -16dec

           MovSx Ax, z		 ; Ax = 0002 (Not FF02 ???) or Ax = FFE6 h = -26dec 
           Sub   Bx, Ax          ; Bx = FFEEh = -18dec or Ax = 000Ah = 10dec

           Jne   Not_Zero	 ; ZF ? 1:0 

           Mov   Dx, Zero
           Jmp   Short _Exit


Not_Zero:
           Cmp    Bx, Zero
           Jl     Branch_C

           Mov    Al, y		 ; Ax = ??FF 
           Imul   y              ; Ax = 0001
           MovSx  Cx, x		 ; Cx = FFFE
           Imul   Cx, Ax	 ; Cx = FFFEh = -2dec

           Push   Cx
           
           MovSx  Ax, z		 ; Ax = FFE6  
           Imul   Cx, Ax, 2	 ; Cx = FFE6 * 0002 = FFCCh = -52dec 

           Pop    Ax

           Sub    Ax, Cx	 ; Ax = FFEh - FFCC = 0032h = 50dec
           
           Jmp   Short Rezult    

Branch_C:  
            Mov   Al, x		 ; Ax = ??FE 	
            Imul  x		 ; Ax = 0004
            MovSx Cx, y		 ; Cx = FFFFh = -1dec
            Imul  Cx, Ax	 ; Cx = FFFCh = -4dec

            MovSx Ax, z		 ; Ax = 0002
            Add Ax, Cx           ; Ax = FFFEh = -2dec 

            Inc Ax  		 ; Ax = FFFFh = -1dec
            
Rezult:
           Cmp    Ax, Zero
           Jne    _Div

           Mov    ZDiv, 1 
           Jmp    Short _Exit

_Div:
           Xchg   Ax, Bx	; Ax = FFEE, Bx = FFFF or Ax = 000A, Bx = 0032
           MovSx  EBx, Bx      	; EBx = FFFF FFFF or EBx = 0000 0032
           Cwde		        ; EAx = FFFF FFEE or EAx = 0000 000A 
           Cdq 		        ; EDx : EAx = FFFF FFFF : FFFF FFEE or EDx:EAx = 0000 0000 : 0000 000A
           IDiv   EBx	        ; Ax = 0012h = 18dec or Ax = 0h = 0dec

_Exit:

.exit 0
end
