dosseg
.model tiny
.code
.startup
        Jmp Short Start
Message  Db  'Hello, user !'
Mes_Len  Equ $ - Message
Start: 
        Push Es

        Mov Ah, 0         ; Ekraana attiiriissanas funkcija
        Mov Al, 2         ; 80*25, melnbaltais rezziims
        Int 10h

        Mov Dh, 3         ; displeja rinda
        Mov Dl, 10        ; displeja kolona

        Push Ds
        Pop  Es

        Lea Bp, Message   ; teksta rinda reggistros ES:BP
        Mov Cx, Mes_Len   ; simbolu daudzums teksta rindaa
        Mov Ah, 13h       ; funkcija teksta rindas izvadei
        Mov Al, 1         ; teksta rindaa ir tikai simboli bez atribuutiem
        Mov Bl, 8 + 4     ; kraasa (Intensity + Red)
        Int 10h

        Add Dl, 25        ; jauna displeja kolona
        Int 10h

        Pop Es  
.exit 0
end