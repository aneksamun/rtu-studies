domains
    list = integer*
predicates
    first(list, integer)
    last(list, integer)
    is_ordered(list)
    fill(integer,integer,list)
    max(list,integer)
    gr_lt(list, integer, list, list)
clauses
    first([H|_], H).
    
    last([_|T], E) :- last(T,E).
    last([E],E).
    
    is_ordered([X,Y|T]) :- 
        Y > X, is_ordered([Y|T]).
    is_ordered([_|[]]).
    
    fill(E, N, [E|L]) :-
        N > 0, M = N - 1, fill(E, M, L).
    fill(_,0,[]).
    
    max([X,Y|T], E) :- X > Y, max([X|T], E).
    max([X,Y|T], E) :- X <= Y, max([Y|T], E).
    max([E],E).
    
    gr_lt([H|T], N, [H|G], L) :- 
        gr_lt(T, N, G, L), H >= N.
    gr_lt([H|T], N, G, [H|L]) :-
        gr_lt(T, N, G, L), H < N.
    gr_lt([],_,[],[]).
          