predicates
    auto(symbol)
    p1
    p2
    p3
    p4
    p5
clauses
    auto(ford).
    auto(tayota).
    auto(mazda).
    
    p1 :- auto(X), write(X, " ").           % ford, yes
    p2 :- !, auto(X), write(X, " ").        % ford, yes
    p3 :- auto(X), fail, write(X, " ").     % no
    p4 :- auto(X), write(X, " "), fail.     % ford tayota mazda no
    p5 :- auto(X), write(X, " "), !, fail.  % ford no
    