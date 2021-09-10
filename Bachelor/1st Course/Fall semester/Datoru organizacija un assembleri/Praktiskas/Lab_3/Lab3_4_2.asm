.model tiny
.code
.startup
			Org 100h
			Jmp Short Start
Vector     		Dw  2, 7, -1, 16, 15
N          		Equ 5
Max			Dw	6

Start:
			Xor  Bx, Bx
			Xor  Si, Si
			Mov  Cx, N
			Mov  Dx, Max
S:
			Mov  Ax, Vector[Bx][Si]
			Test Ax, 00000001B
			Jnz  Next
			Cmp	 Ax, Dx
			Jng	 Next
			Mov	 Dx, Ax
Next:
			Inc Bx
			Inc Si 
			Loop S

			Mov Ax, Dx
.exit 0
end
