;	programm calls procedure 'ones' to
;       count bits containing ones in n leftmost bits 

CSEG    SEGMENT 
	EXTRN  ones:far
	ASSUME	cs:CSEG
	ORG	100h

start:  jmp     go

wrd     dw      0059h
n	dw	8
count	dw	0

buf     db      '00000$'

go:
	push    count   ;
	push    n	;
        push    wrd	;
	call 	ones
	pop	count

	mov	ax,count
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
        int     20h

CSEG    ENDS
        END     start