FormVector  	Macro R, C, Matr, Vect, _S
        	Local Rows, Cols, False, Next

        	Push Ax
        	Push Bx
        	Push Cx
        	Push Dx
        	Push Di

        	Mov Cx, C
		Lea Bx, Matr
		Lea Di, Vect
            
Rows:		Push Cx
		Mov Cx, R
		Xor Si, Si
		Xor Ax, Ax
		Xor Dx, Dx
            
Cols:		Test [Bx][Si], Word Ptr 00000001B
		Jnz False
		Add Ax, [Bx][Si]
		Inc Dl
            
False:		Add Si, _S*C
		Loop Cols
		
		Cmp Ax, 0
		Jz Next
		Idiv Dl
		Cbw
	
Next:		Mov [Di], Ax
		Add Bx, _S
		Add Di, _S
		Pop Cx
		Loop Rows          

        	Pop  Di
        	Pop  Dx
        	Pop  Cx
        	Pop  Bx
        	Pop  Ax

EndM
			
