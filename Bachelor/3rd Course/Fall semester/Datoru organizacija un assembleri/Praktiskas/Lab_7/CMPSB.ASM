dosseg
.model tiny
.code
.startup
        	Org 100h
        	Jmp Short Start
Buffer1  	Db  'Text', '$'
Buf_Len  	Equ $ - Buffer1 - 1
Buffer2  	Db  'Text', '$'

OK       	Db  'Strings are equals !', '$'
NOT_OK   	Db  'Strings are NOT Equals !', '$'

Start: 
        	Push  Es
        	Push  Ds
        	Pop   Es

        	ClD        
        	Mov   Cx, Buf_Len
        	Lea   Si, Buffer1
        	Lea   Di, Buffer2
        	Repe  Cmpsb

        	Jne Not_Equals
        	Lea Dx, OK
        	Jmp Short Print
Not_Equals:
        	Lea Dx, Not_OK

Print:
        	Mov Ah, 9
        	Int 21h

        Pop Es
.exit 0
end
