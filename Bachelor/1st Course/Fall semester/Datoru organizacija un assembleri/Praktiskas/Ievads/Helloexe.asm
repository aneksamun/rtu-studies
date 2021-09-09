.model small
.stack 100h
.data
Hello db "Hello, world!", '$'
.code
.startup
      lea dx, Hello
      mov sh, 9h 
      int 21h 
.exit 0
end