dosseg
.model tiny
.code
.startup
   Org 100h
   Jmp Short Start
Mess1 DB "Hello,        ", '$'
Mess2 DB "World !", '$'
L_Mess2 Equ $ - Mess2 - 1
Start:
   Push Es

   Push Ds
   Pop  Es

   Lea  Si, Mess2
   Lea  Di, Mess1
   Add  Di, 7
   Mov  Cx, L_Mess2
   Rep  Movsb

   Lea  Dx, Mess1
   Mov  Ah, 9
   Int  21h
      
   Pop  Es
.exit 0
end