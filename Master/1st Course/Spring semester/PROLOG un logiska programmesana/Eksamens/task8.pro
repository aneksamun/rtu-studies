predicates
    p(integer,integer,integer)
clauses
    % p(1, 2, 1). Yes
    % p(0, 0, 0). Yes
    % p(1, 2, 3). No
    % p(1, 2, 2). Yes
    % p(1, X, 2). Error

    p(X,Y,X) :- X < Y, !.
    p(_, Y, Y).