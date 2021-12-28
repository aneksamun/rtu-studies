domains
    xy = x_y(integer, integer, integer, integer)
database - r
    rect(symbol, xy)
database - s
    square(symbol, integer, integer, integer, integer)
predicates
    pr_rect.
    chk_square.
clauses
    pr_rect :- 
        retractall(_, r),
        consult("rects.txt", r),
        write("RECTANGLES:"), nl,
        rect(X, x_y(X1, Y1, X2, Y2)),
        write(X, ": ", X1, " ", Y1, " ", X2, " ", Y2),
        nl, fail.
    pr_rect :- true.
   