dosseg
.model tiny
.code
.startup
        Jmp Short Start
Space   Equ ' '
Star    Equ '*'
Buffer  Db  'This is the test string!', 13, 10, '$'
Buf_Len Equ $ - Buffer - 3

Start: 
        Push  Es

        Push  Ds
        Pop   Es

        ClD        
        Mov   Cx, Buf_Len
        Mov   Al, Space
        Lea   Di, Buffer

        RepNe Scasb
        Jne   _Not
        Mov   ES:[Di - 1], Byte Ptr Star

_Not:
        Lea   Dx, Buffer
        Mov   Ah, 9
        Int   21h

        Pop Es
.exit 0
end