include even_avg.asm
include print.asm

.model tiny
.code
.startup
            Org  100h
            Jmp  Short Start
   pN       Equ 2
   pM       Equ 3
   pMatrix  Dw  1, 2, 8
            Dw  4, -6, 6
   pVector  DW  pN Dup (?)
   pMin     Equ 2
   pS       Equ Type pMatrix

Start:
            FormVector  pN, pM, pMatrix, pVector, pS
            Print pM, pVector, pS

.exit 0
end
