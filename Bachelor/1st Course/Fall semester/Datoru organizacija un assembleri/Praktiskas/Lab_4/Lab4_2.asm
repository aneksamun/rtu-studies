.model tiny
.code
.startup
		Org 100h
		Jmp Short Start
N		Equ 2
M 		Equ 3
Vector	DW	M Dup (?)
Matrix	DW	1, 2, 8
		DW	4, 5, 6
S		Equ Type Matrix

Start:
        Lea Bx, Matrix
		Mov Cx, M
        Xor Di, Di
		
Rows:	Push Cx
		Mov Cx, N
		Xor Si, Si
		Xor Ax, Ax
		Xor Dx, Dx

Cols:	Test [Bx][Si], Word Ptr 00000001B
		Jnz False
		Add Ax, [Bx][Si]
		Inc Dl
		
False:
		Add Si, S*M
		Loop Cols
		
		Cmp Ax, 0
		Jz Next
		Idiv Dl
		Cbw
		
Next:	
		Mov Vector[Di], Ax
		Add Bx, S
		Add Di, S
        Pop Cx
		Loop Rows   

		Xor Bx, Bx
		Xor Ax, Ax
		Mov Cx, M
		
Print:	Mov Ax, Vector[Bx]
		Add Bx, S
		Loop Print
        
.exit 0
end		
