include macr.asm

.model tiny
.code
.startup
            Org  100h
            Jmp  Short Start
    N       Equ 2
    M       Equ 3
    Matrix  Dw  1, 2, 3
            Dw  4, 5, 6
    Vector  DW  N Dup (?)
    Min     Equ 2
    Max     Equ 6
    S       Equ Type Matrix

Start:
            FormVector  N, M, Matrix, Vector, Min, Max, S
            Print N, Vector
.exit 0
end