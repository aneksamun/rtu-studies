%====================================================
% Gets element in the specified position.
% elem([4,5,6], 2, X) :- P = 2 & H = 4; P = 1 & H = 5 
% P - position
% X - result variable
% N - next position after count down.
%======================================================
 
elem([_|T], P, X) :- P > 1, N = P-1, elem(T, N, X).
elem([H|_], _, H).

%=============================================================
% Gets element in the specified position tracing it from stack 
% after recursion execution.
% E - element to find  
% X, Y - variables to detect position.
%=============================================================

pos1([H|_], H, X) :- X = 1. % Takes H and checks if H =:= E? 
pos1([_|T], E, Y) :- pos1(T, E, X), Y = X + 1.  

%==============================================================
% Gets element in the specified position without it's recursive 
% tracing form stack.
%=============================================================

pos2(L, E, X) :- get_pos(L, E, 1, X).

get_pos([H|T], E, P, X) :- H =\= E, I = P + 1, get_pos(T, E, I, X).
get_pos([H|_], H, P, P). 

%===================================
% Gets maximal elements in the list.
% M - keeps current maximal element. 
% X - returns maximal element.
%===================================

max([H|T], X) :- get_max(T, H, X).

get_max([H|T], M, X) :- H > M, !, get_max(T, H, X).
get_max([_|T], M, X) :- get_max(T, M, X), !.
get_max([], M, M).

%===========================================================
% Gets maximal positive elements in the list. 
% return (max_pos != null && max_pos > 0) ? max_pos : -1;
% X - returns maximal positive element.
%=========================================================== 

max_pos([], -1). % sets X = -1 when recursion ends execution.
max_pos([H|T], X) :- max_pos(T, M), H > 0, H > M, X = H, !.
max_pos([_|T], X) :- max_pos(T, M), X = M.

%===========================================================
% Gets minimal positive elements in the list.
% return (min_pos != null && min_pos < 0) ? min_pos : -1; 
% X - returns minimal positive element.
%===========================================================

min_pos([], -1).
min_pos([H|T], X) :- min_pos(T, M), H > 0, M > 0, H < M, X = H, !.
min_pos([H|T], X) :- min_pos(T, M), H > 0, M = -1, X = H, !.
min_pos([_|T], X) :- min_pos(T, X).
