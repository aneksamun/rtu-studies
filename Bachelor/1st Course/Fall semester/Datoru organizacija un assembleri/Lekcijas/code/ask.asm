;	Prasa ievadit vardu un to parbauda
cseg	segment
	assume	cs:cseg, ds:cseg
	org	100h
start:	jmp	go
msg1	db	"Ievadi vardu:$"
etalon	db	'Uldis'
len	db	5
msgOK	db	13, 10,'Pareizi! $'
msgBad	db	13, 10, 7,'Nepareizi! $'
inbuf	db	16, 0, 17 dup (0)
go:
	mov     ah,9
        mov     dx, offset msg1
        int     21h
	mov	ah, 0Ah
	mov	dx, offset inbuf
	int	21h

	xor	cx, cx
	mov	cl, inbuf+1
	cmp	cl, 0
	je	finish	
	cmp	cl, len
	jne	bad

	xor	si, si
	mov	cl, len
t:	mov	al, inbuf+2[si]
	cmp	al, etalon[si]
	jne	bad
	inc	si
	loop	t

good:   mov     dx, offset msgOK
	jmp	output
bad:  	mov     dx, offset msgBad
output:	mov     ah,9
        int     21h
	jmp	go

finish:	int	20h
cseg	ends
	end	start