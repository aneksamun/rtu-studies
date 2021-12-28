% Gets module for the number.
rabs(X, Y) :- X < 0, Y = -X.
rabs(X, Y) :- X > 0, Y = X.

% Gets factorial for the number.
fact(X, Y) :- X < 0, Y = -1. % num < 0? = gag (-1)
fact(X, Y) :- X > 0, N = X - 1, fact(N, R), Y = X * R.
fact(X, Y) :- X =:= 0, Y = 1. % zero? = one

% Calculates pow for the number.
pow(N, P, R) :- P > 0, A = P - 1, pow(N, A, B), R = N * B.
pow(_, P, R) :- P =< 0, R = 1. % at start 'b' becomes '1'.

% Gets sum of the entered numbers.
sum(S) :- write("Enter loop number: \n"), read(N), read_num(S, N).
read_num(S, N) :- 
    N > 0, A = N - 1, 
    write("Enter number to sum: \n"), read(Y), 
    read_num(B, A), S = B + Y. % at start 'b' becomes to '0'.
read_num(0, 0).