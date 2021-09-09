;	procedure 'ones' counts bits containing ones in n leftmost bits 

CSEG SEGMENT 
	PUBLIC ones
	ASSUME CS:CSEG

; parameters: source, number of leftmost bits, result

ones	proc	far	
	push	bp
	mov	bp,sp
	push	cx
	push	ax
	mov	word ptr [bp+10],0	; count=0
	mov	cx,[bp+8]
	mov	ax,[bp+6]
  tst:  test	ax,0001h
	jz	next
	inc	word ptr [bp+10]	; count=count+1
  next: shr	ax,1
	loop 	tst
	pop	ax
	pop	cx
	pop	bp
	ret     4
ones	endp

CSEG ENDS

        END     