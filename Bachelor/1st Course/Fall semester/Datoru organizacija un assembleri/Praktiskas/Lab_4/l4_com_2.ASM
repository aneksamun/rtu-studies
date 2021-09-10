.model tiny
.code
.startup
        Org     100h
        Jmp 	Short Start
N	Equ 	2
M 	Equ	3
Matrix	DW	1, 2, 3
	DW	4, 5, 6
Vector	DW	N Dup (?)
Min	Equ	2
Max	Equ	6
S	Equ	Type Matrix

Start:
	Lea	Bx, Matrix
	Mov	Cx, N
	Xor	Di, Di

Rows:	Push    Cx
	Mov	Cx, M
	Xor	Si, Si
	Xor	Ax, Ax

Cols:	Cmp	[Bx][Si], Word Ptr Min
	Jl	False
	Cmp	[Bx][Si], Word Ptr Max
	Jg	False
	Inc	Ax
False:
	Add	Si, S
	Loop	Cols

	Mov	Vector[Di], Ax
	Add	Bx, S*M
	Add	Di, S  
        Pop     Cx
	Loop	Rows   

	Xor	Bx, Bx
	Mov	Cx, N
Print:	Mov	Ax, Vector[Bx]
	Add	Bx, S
	Loop	Print
        
.exit 0
end
