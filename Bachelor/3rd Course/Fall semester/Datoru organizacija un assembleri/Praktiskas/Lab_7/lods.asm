dosseg
.model tiny
.code
.startup
           Jmp   Short Start

Buffer     Db    "123", '$'
BufSize    Equ   $ - Buffer - 1   
Copy       Db    BufSize Dup (?), '$'

Start:
           Push  Es

           Push  Ds
           Pop   Es

           Mov   Cx, BufSize
           Lea   Si, Buffer
           Lea   Di, Copy
Next:
           LodsB
           StosB
           Loop Next    

           Lea   Dx, Copy
           Mov   Ah, 9
           Int   21h

           Pop   Es     
.exit 0
end