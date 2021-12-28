domains
    row = integer*
    matrix = row*
predicates
    f(integer, integer)
    PrintRow(row)
    PrintMatrix(matrix)
    Elem(matrix, integer, integer, integer)
    Get_Elem(row, integer, integer)
clauses
    f(Start, Finish) :- 
        Start <= Finish,
        F = Finish - 1,
        f(Start, F), 
        Write(Finish, " "),
        Result = Finish * Finish + Finish + 1,
        Write(Result, " "), nl. 
    f(Start, Finish) :- Start > Finish, Write("X Y"), nl.

    PrintMatrix([H|T]) :- PrintRow(H), nl, PrintMatrix(T).
    PrintMatrix([]).
    
    PrintRow([H|T]) :- Write(H, " "), PrintRow(T).
    PrintRow([]). 
    
    Elem([_|T], Row, Col, X) :-
        Row > 1, Col >= 1,
        CurrRow = Row - 1, 
        Elem(T, CurrRow, Col, X).
        
    Elem([H|_], 1, Col, X) :-
        Col >= 1, Get_Elem(H, Col, X).
        
    Get_Elem([_|T], Col, X) :-
        Col > 1, 
        C = Col - 1, 
        Get_Elem(T,C, X).
    
    Get_Elem([H|_], 1, H). 