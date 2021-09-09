.model tiny
.code
.startup
   org 100h
   mov al, 5
   mov bl, -2
   imul bl
.exit 0
end