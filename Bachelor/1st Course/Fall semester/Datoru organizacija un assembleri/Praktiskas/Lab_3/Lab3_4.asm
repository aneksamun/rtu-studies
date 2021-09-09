.model tiny
.code
.startup
			Org 100h
			Jmp Short Start
Vector     	Dw  2, 7, -1, 16, 15
N          	Equ 5
Start:
			Xor  Bx, Bx
			Xor  Si, Si
			Mov  Cx, N
			Xor  Dx, Dx
S:
			Mov  Ax, Vector[Bx][Si]
			Test Ax, 00000001B
			Jnz  Uneven
			Inc  Dx
Uneven:
			Inc Bx
			Inc Si 
			Loop S

			Mov Ax, Dx
.exit 0
end