.model tiny
.code
.startup
      org 100h
      jmp short start
      Hello DB "Hello, world!", '$'
start:
      lea Dx, Hello
      mov Ah, 9h 
      int 21h 
.exit 0
end