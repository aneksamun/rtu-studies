.model tiny
.code
.startup
			Org 100h
			Jmp Short Start
Vector     	Dw  2, 7, -1, 16, 15
N          	Equ 5
Start:
			Lea  Bx, Vector
			Mov  Cx, N
			Xor  Dx, Dx
S:
			Mov  Ax, [Bx] 
			Test Ax, 00000001B
			Jnz  Uneven				;; Jz Even -> even integers
			Inc  Dx
Uneven:
			Add  Bx, 2
			Loop S

			Mov Ax, Dx
.exit 0
end