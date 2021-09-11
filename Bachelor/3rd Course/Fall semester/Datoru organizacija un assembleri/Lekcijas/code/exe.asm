ASSUME	cs:CSEG, ds:DSEG, ss:SSEG

CSEG	SEGMENT			; Code segment
begin:mov	ax, DSEG	; Set data segment
	mov	ds, ax
	mov	ah, 9h		; Function 9
	lea	dx, msg		; Load DX with offset of string
	int	21h		; Display string
	mov 	ah, 4ch		; Function 4ch
	mov	al, 0		; Return code
	int     21h		; Return to operating system
CSEG	ENDS

DSEG	SEGMENT			; Data segment
msg	db	"Sveiks!", 7, 13, 10, "$"
DSEG	ENDS

SSEG	SEGMENT STACK 		; Stack segment
	dw	64 dup(0)
SSEG	ENDS
	
	END	begin