domains
    db_selector = rectangles ; squares
    r = rectangle(symbol, integer, integer, integer, integer)
    s = square(symbol, integer, integer, integer, integer)
    xy = x_y(integer, integer, integer, integer)
database
    rect(symbol, xy)
predicates
    create_bin_rects.
    put_rects.
    get_rects.
    process_bin_squares.
    check_square(integer, integer, integer, integer).
    get_squares.
clauses
    create_bin_rects :-
        retractall(_),
        consult("rects.txt"),
        db_create(rectangles, "rects.bin", in_file),
        db_create(squares, "squares.bin", in_file),
        put_rects,
        write("RECTANGLES:"), nl,
        get_rects, nl,
        process_bin_squares,
        db_close(rectangles),
        db_close(squares),
        write("SQUARES: "), nl,
        get_squares.
        
    put_rects :- 
        rect(Name, x_y(X1, Y1, X2, Y2)),
        chain_insertz(rectangles, chain, r, rectangle(Name, X1, Y1, X2, Y2),_),
        fail.
    put_rects :- true.
    
    get_rects :-
        chain_terms(rectangles, chain, r, rectangle(Name, X1, Y1, X2, Y2), _),
        write(Name, ": ", X1, " ", Y1, " ", X2, " ", Y2),
        nl, fail.
    get_rects :- true.
    
    process_bin_squares :-
         chain_terms(rectangles, chain, r, rectangle(Name, X1, Y1, X2, Y2), _),
         check_square(X1, Y1, X2, Y2),
         chain_insertz(squares, chain, s, square(Name, X1, Y1, X2, Y2), _),
         fail.
    process_bin_squares :- true.
    
    check_square(X1, Y1, X2, Y2) :-
        A = X2 - X1,
        B = Y2 - Y1,
        A = B.
    
    get_squares :-
        db_open(squares, "squares.bin", in_file),
        chain_terms(squares, chain, s, square(Name, X1, Y1, X2, Y2), _),
        write("Name: ", Name),
        nl, fail.
    get_squares :- db_close(squares), true.