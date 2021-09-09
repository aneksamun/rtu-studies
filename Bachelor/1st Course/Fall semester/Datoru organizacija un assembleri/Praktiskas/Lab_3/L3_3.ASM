.model tiny
.code
.startup
           Org 100h
           Jmp Short Start
Vector     Label  Word
Array      Label  Word
           Dw  2, 7, -1, 16, 15
N          Equ 5
Step       Equ 2
.386
Start:
           Xor  EBx, EBx  
           Mov  Cx, N
S: 
           Mov  Ax, Array[EBx*Step]   
           Inc  EBx
           Loop S
.exit 0
end