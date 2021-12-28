
% checks for odd numbers.
odd(N) :- Y is N mod 2, Y =\= 0.

% checks for even numbers.
even(N) :- odd(N), !, false.
even(_) :- true.

% Theorem prooving.
human(socrat).
mortal(X) :- human(X).

% Prints even numbers in the ascending order.
print_num(0).
print_num(N) :- Y is N-1, print_num(Y), print_even(N).

print_even(N) :- Y is N mod 2, Y is 0, write(N), write(' ').
print_even(_).

frw([H|T]) :- write(H), write(', '), frw(T).
frw([]).

back([H|T]) :- back(T), write(H), write(', ').
back([]).

member(X, [X|_]).
member(X, [_|T]) :- member(X,T).

append(X, L, [X|L]).

%delete(X, [X|T], T).
%delete(X, [Y|T], [Y|T1]) :- delete(X, T, T1).
%delete(X, [X|T], T1) :- delete(X, T, T1).

fact(N, X) :- N =< 0, X is 1, !.
fact(N, X) :- Y is N - 1, fact(Y, E), X is E * N.
pow(_, P, R) :- P =:= 0, R is 1, !.
pow(N, P, R) :- Y is P - 1, pow(N, Y, E), R = E * N. 

first([H|_], H).

last([X], X).
last([_|T], X) :- last(T, X).

isordered([X, Y|T]) :- X < Y, isordered([Y|T]), !.
isordered([_|[]]).

max([X, Y|T], M) :- X > Y, max([X|T], M), !.
max([_, Y|T], M) :- max([Y|T], M), !.
max([M], M).

gr_lt([H|T], N, [H|G], L) :- H >= N, gr_lt(T, N, G, L), !.
gr_lt([H|T], N, G, [H|L]) :- gr_lt(T, N, G, L), !.
gr_lt([], _, [], []). 

elem([H|_], 1, H).
elem([_|T], I, X) :- Y is I - 1, elem(T, Y, X).

pos1([H|T], E, X) :- H =\= E, pos1(T, E, Y), !, X is Y + 1.
pos1(_, _, 1). 

difer(X, Y) :- X == Y, !, fail; true.

f(S, F) :- S >= F, Y is F - 1, f(S, Y), A is F * F + F + 1, 
    write(F), write(' '), write(A), nl.
    
f(S, F) :- S > F, write('X'), write(' '), write('Y'), nl.


