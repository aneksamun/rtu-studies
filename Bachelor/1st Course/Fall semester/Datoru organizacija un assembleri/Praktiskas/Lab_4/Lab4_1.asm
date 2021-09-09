.model tiny
.code
.startup
		Org 100h
		Jmp Short Start
N		Equ 2
M 		Equ	3
Vector	DW	M Dup (?)		;; 3 avarage even elements in columns 
Matrix	DW	1, -2, 8
		DW	3,  9, 6
S		Equ	Type Matrix		;; const 2 => 2bytes

Start:
		Xor	Bx, Bx
		Mov	Cx, M			;;  3 colums
		Lea	Di, Vector
		
Rows:	Push Cx
		Mov	Cx, N			;; 2 elements in each column
		Xor	Si, Si
		Xor	Ax, Ax
		Xor Dx, Dx

Cols:	Test Matrix[Bx][Si], 00000001B
		Jnz False
		Add	Ax, Matrix[Bx][Si]
		Inc	Dl
		
False:
		Add	Si, S*M			;; Go to this column next element in matrix
		Loop Cols
		
		Cmp Ax, 0
		Je	Next
		Idiv Dl
		Cbw
		
Next:	
		Mov	[Di], Ax
		Add	Bx, S			;; Go to next column first element 
		Add	Di, S 			;; plus 2 bytes for next element in one dimensional array
        Pop Cx
		Loop Rows   

		Xor	Bx, Bx
		Xor Ax, Ax
		Mov	Cx, M			;; Show all 3 elements
		
Print:	Mov	Ax, Vector[Bx]
		Add	Bx, S
		Loop Print
        
.exit 0
end		
