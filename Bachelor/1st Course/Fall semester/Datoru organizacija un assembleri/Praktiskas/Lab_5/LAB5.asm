.model tiny
.code
.startup
			Org 100h
			Jmp Short Start
	N		Equ 2
	M 		Equ 3
	Vector	DW	M Dup (?)
	Matrix	DW	1, 2, 8
			DW	4, -6, 6
	S		Equ Type Matrix

FormVector	Proc
			Push Bp
			Mov Bp, Sp
			
			Push Cx
			Push Bx
			Push Dx
			Push Di
			Push Ax
			
			Mov Ax, S
			Mul Word Ptr [Bp + 4]
			Mov Si, Ax						;; next elem index += 6 
			
			Mov Cx, [Bp + 4]
			Mov Bx, [Bp + 8]
			Mov Di, [Bp + 10] 
			
Cols:		Push Cx
			Push Bx
			Mov Cx, [Bp + 6]
			Xor Ax, Ax
			Xor Dx, Dx

Rows:		Test Word Ptr [Bx], 0001h
			Jnz False
			Add Ax, [Bx]
			Inc Dl

False:		Add Bx, Si
			Loop Rows
		
			Cmp Ax, 0
			Je Next
			Idiv Dl
			Cbw			

Next:		Mov [Di], Ax
			Pop Bx
			Pop Cx
			Add Bx, S
			Add Di, S
			Loop Cols
			
			Pop Ax
			Pop Di
			Pop Dx
			Pop Bx
			Pop Cx
			
			Pop Bp
			Ret 2*4
FormVector	EndP

Print		Proc
			Push Bp
			Mov Bp, Sp
			Push Cx
			Push Bx
			Push Ax
			Xor Ax, Ax
			
			Mov Cx, [Bp + 4]
			Mov Bx, [Bp + 6]
Pr:			Mov Ax, [Bx]
			Add Bx, S
			Loop Pr
			
			Pop Ax
			Pop Bx
			Pop Cx
			Pop Bp
			Ret 2*2
Print 		EndP

Start:
			Lea Ax, Vector
			Push Ax
			Lea Ax, Matrix
			Push Ax
			Mov Ax, N
			Push Ax
			Mov Ax, M
			Push Ax
			Call FormVector
			
			Lea Ax, Vector
			Push Ax
			Mov Ax, M
			Push Ax
			Call Print
		        
.exit 0
end		
