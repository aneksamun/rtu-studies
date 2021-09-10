.model tiny
.code
.startup
		Org  100h
		Jmp  Short Start
Vector      	Dw   2, 7, -1, 16, 15
N           	Equ  5

Start:
           	Xor  Bx, Bx
           	Mov  Cx, N
           	Xor  Dx, Dx
S:
           	Mov  Ax, Vector[Bx]
		Test Ax, 00000001B
		Jnz  Uneven
		Inc  Dx
Uneven:
           	Add  Bx, 2
           	Loop S
		
		Mov  Ax, Dx
.exit 0
end
