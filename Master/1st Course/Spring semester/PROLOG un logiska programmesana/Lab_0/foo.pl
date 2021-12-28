:- ensure_loaded('foo.pl').

% takes sequentially X out of list
% takeout(X,[1,2,3,4],_), X>3.
% takeout(X,[1,2,3,4],Y). ;(next sequence)

takeout(A,[A|B],B).
takeout(A,[B|C],[B|D]) :-
     takeout(A,C,D).
     
%=========================================
% theorem proving
% mortal(socrat).
% mortal(X).

human(socrat).
mortal(X) :- human(X).

%==========================================
% outputs numbers in descending order  
% works in turbo prolog

nat(0).
nat(X) :- write(X, " "), Y=X-1, nat(Y).

% works in swi-prolog

foo(0).
foo(A) :- write(A), write(' '), 
    B is A-1, foo(B).


%===========================================
% outputs even number in descending order
% works in turbo prolog

domains
predicates
    f(integer)
    is_even(integer)
clauses
    f(0).
    f(N) :- is_even(N), Y=N-1, f(Y).
    
    is_even(_).
    is_even(I) :- Y = I mod 2, Y=0, write(I, " ").

% works in swi-prolog
% odd => Y =/= 0

loop(0).
loop(A) :- even(A), 
    B is A-1, loop(B).
    
even(X) :- Y is X mod 2, Y =:= 0,	
    write(X), write(' ').
even(_) :- loop(_).
