cseg	segment
	assume	cs:cseg, ds:cseg
	org	100h
start:	jmp	go
wrd	dw	0f3h
buf	db	'00000$'

;	procedure 'ones' counts bits containing ones in n leftmost bits
; 	in:  ax - source, cx - number of leftmost bits
; 	out: bx - result
ones	proc	near
	push	ax
	push	cx
	xor	bx,bx
  tst:	test	ax,0001h
	jz	next
	inc	bx
  next:	shr	ax,1	; shift right
	loop 	tst	
	pop	cx
	pop	ax
	ret
ones	endp

go:
	mov	ax,wrd
	mov	cx,16
	call 	ones
;
; parveido bx saturu no binara koda uz ASCII virkni un izvada uz ekrana
	mov	ax,bx
        mov     si,4
        mov     bl,10
    d:  div     bl              ; ax/bl =  ah - atlikums
        add     ah,30h          ; make ASCII digit
        mov     buf[si],ah      ;
        cmp     al,0            ; dalijums = 0?
        je      put
        mov     ah,0
	dec	si
        jmp     d
put:
        mov     ah,9
        mov     dx, offset      buf
        int     21h
	int	20h
cseg	ends
	end	start