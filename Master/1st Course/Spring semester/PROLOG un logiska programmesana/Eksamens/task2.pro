predicates
    s(symbol)
    p
clauses
    s(a).
    s(b).
    s(c).
    
    % aa ac ba bc ca cc Yes
    
    p :- S(A), S(B), write(A, B, " "), fail.
    p.