%======================================================
% Gets first element in the list.

first([H|_], H).

%======================================================
% Gets last element in the list.

last([_|T], E) :- last(T, E).
last([E], E).

%======================================================
% Indicates whether list is ordered.

is_ordered([X,Y|T]) :- Y > X, is_ordered([Y|T]).
is_ordered([_|[]]).

%======================================================
% Fills list with elements (-).

fill(E, N, [E|L]) :- N > 0, Q = N-1, fill(E, Q, L).
fill(_, 0, []).

%======================================================
% Gets max element in the list.

max([X,Y|T], M) :- X > Y, max([X|T], M).
max([X,Y|T], M) :- X =< Y, max([Y|T], M).
max([M], M).

%======================================================
% Divides elements in two list by threshold criteria.

gr_lt([H|T], N, [H|G], L) :- H >= N, gr_lt(T, N, G, L).
gr_lt([H|T], N, G, [H|L]) :- H < N, gr_lt(T, N, G, L).
gr_lt([],_,[],[]).
