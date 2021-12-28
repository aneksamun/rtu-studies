%========================================================
% Calculates f(x) = x^2 + x + 1 for the range of numbers.
%========================================================

f(Start, Finish) :- 
    Finish >= Start,
    Prev = Finish - 1, 
    f(Start, Prev),
    Y = Finish * Finish + Finish + 1,
    write(Finish), write(' '), write(Y), write(' '), nl.
    
f(Start, Finish) :- 
    Start > Finish, write('X'), write(' '), write('Y'), nl.

%========================================================
% Prints matrix dimensions.
%========================================================
    
print_matrix([H|T]) :- print_row(H), nl, print_matrix(T).
print_matrix([]).

print_row([H|T]) :- write(H), write(' '), print_row(T).
print_row([]).

%========================================================
% Finds element in the matrix by specified coordinates.
%========================================================

elem([_|T], Row, Col, X) :- 
    Row > 1, Col >= 1, 
    PrevRow = Row - 1, elem(T, PrevRow, Col, X).
    
elem([H|_], 1, Col, X) :- 
    Col >= 1, get_elem(H, Col, X).

get_elem([_|T], Col, X) :- 
    Col > 1, PrevCol = Col - 1, get_elem(T, PrevCol, X).
    
get_elem([H|_], 1, H).