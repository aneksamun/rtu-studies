domains
    xy = x_y(integer, integer, integer, integer)
database - r
    rect(symbol, xy)
database - s
    square(symbol, integer, integer, integer, integer)
predicates
    show_rec.
    pr_rect.
    pr_square.
    chk_square.
clauses
    show_rec :-
        retractall(_, r),
        retractall(_, s),
        consult("rects.txt", r),
        write("RECTANGLES:"), nl,
        pr_rect, nl,
        chk_square,
        write("SQUARES: "), nl,
        pr_square.
        
    pr_rect :- 
        rect(X, x_y(X1, Y1, X2, Y2)),
        write(X, ": ", X1, " ", Y1, " ", X2, " ", Y2),
        nl, fail.
    pr_rect :- true.
    
    pr_square :-
        square(X, _, _, _, _),
        write("Name: ", X), nl, fail.
    pr_square :- true.
    
    chk_square :- 
        rect(X, x_y(X1, Y1, X2, Y2)),
        A = X1 - X2,
        B = Y1 - Y2,
        A = B,
        assert(square( X, X1, Y1, X2, Y2)), 
        fail.
    chk_square :- true.
