TEXT    SEGMENT
	ASSUME  cs:TEXT, ds:TEXT
	ORG     100h
start:  jmp	go

m	dw	-1,2,3,-4,5
	dw	1,-2,3,4,5
	dw	1,2,-3,4,-5
rez	dw	3 dup(0)

go:	
	xor	si,si
	xor	di,di

	mov	cx, 3		;rindu skaits
rows:	push	cx

	xor	ax, ax		;summa = 0
	mov	cx, 5		;kolonnu skaits
cols:	push	cx
	cmp	m[si],0		;vai elements negativs?
	jge	next		;jnl
	add	ax, m[si]	
next:	add	si,2		;indekss masiva
	pop	cx
	loop	cols

	mov	rez[di], ax	;summa -> rezultats
	add	di,2		;indekss rezultata
	pop	cx
	loop	rows

	int     20h
TEXT    ENDS
	END     start

