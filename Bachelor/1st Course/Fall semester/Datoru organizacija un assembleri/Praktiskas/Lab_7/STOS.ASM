dosseg
.model tiny
.code
.startup
           Jmp   Short Start
BufSize    Equ   10   
Buffer     Db    BufSize Dup (?), '$'
Star       Equ   '*'
Start:
           Push  Es

           Push  Ds
           Pop   Es

           Mov   Cx, BufSize
           Mov   Al, Star         
           Lea   Di, Buffer
           Rep   Stosb

           Lea   Dx, Buffer
           Mov   Ah, 9
           Int   21h

           Pop   Es     
.exit 0
end