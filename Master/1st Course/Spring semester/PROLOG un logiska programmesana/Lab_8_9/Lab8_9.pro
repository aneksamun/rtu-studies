domains
    file = f
    list = char*
    
database
    delim_counter(integer)
    
predicates
    start(string)
    read_file
    delimiters(list)
    ln_elem(string)
    delim_elem(list, char)
    try_X(char, char)

goal
    assert(delim_counter(0)),	
    start("data.txt"),
    delim_counter(X),
    write(X),
    retractall(_).

clauses
    start(Name):-
        openread(f, Name),
        readdevice(f),
        read_file,
        closefile(f).
        
    read_file:-
        readln(L), !,
        concat(L, "\10", N),
        ln_elem(N),
        read_file.		
        
    read_file.
    
    delimiters([' ', ',', '.', '!', '?', '\10']).
    
    
    delim_elem([H|T], X):-
        try_X(H, X),
        delim_elem(T, X).

    delim_elem([], _).
    
    
    try_X(H, H):-
        retract(delim_counter(X)),
        Y = X + 1,
        assert(delim_counter(Y)), !.
    
    try_X(_, _).
    
    
    ln_elem(L):-
        frontchar(L, H, T),
        delimiters(List),
        delim_elem(List, H),
        ln_elem(T).
        
    ln_elem("").