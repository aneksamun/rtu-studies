.model tiny
.code
.startup
			Org 100h
			Jmp Short Start
Vector     		Label  Word
Array      		Label  Word
			Dw  2, 7, -1, 16, 15
N          		Equ 5
Step       		Equ 2
.386
Start:
			Xor  EBx, EBx  
			Mov  Cx, N
			Xor  Dx, Dx
S: 
			Mov  Ax, Array[EBx*Step]
			Test Ax, 00000001B
			Jnz  Nepara
			Inc  Dx
Nepara:      
			Inc  EBx
			Loop S

			Mov  Ax, Dx	
.exit 0
end
