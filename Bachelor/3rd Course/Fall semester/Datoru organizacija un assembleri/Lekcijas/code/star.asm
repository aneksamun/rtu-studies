code	segment
	assume	cs:code, ds:code
	org	100h

start:  jmp     go

string  db      '01234567891*ABC', 0
buf     db      '000000$'

go:	mov	si,0
	mov	ah,'*'
check:	cmp	string[si],0
	je	notfound
	cmp	ah,string[si]
	je	found
	inc	si
	jmp	check

found:	
	mov	ax,si
	inc	ax
	
	mov     si,5
        mov     bl,10
d:	idiv     bl             ; ax/bl =  ah - atlikums, al -dalîjums
        add     ah,30h          ; make ASCII digit
        mov     buf[si],ah      ;
        cmp     al,0            ; dalîjums = 0?
        je      put
        mov     ah,0
	dec	si
        jmp     d
put:
        mov     ah,9
        mov 	dx,offset buf
        int     21h
	jmp	done
notfound:
	mov	dl,'?'
	mov	ah,6
	int	21h
done:	
	int     20h

code	ends
        end     start