Print	Macro C, V, S
        Local Pr

	Push Ax
        Push Bx
        Push Cx

        Mov Cx, C
        Lea Bx, V
Pr:     Mov Ax, [Bx]
        Add Bx, S
        Loop Pr

	Pop Cx
        Pop Bx
        Pop Ax

        EndM
