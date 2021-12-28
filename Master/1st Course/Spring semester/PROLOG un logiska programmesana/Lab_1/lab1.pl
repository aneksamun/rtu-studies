human(male, sergejs, 1750).
human(female, linda, 1790).
human(male, janis, 1820).
human(male, peteris, 1850).
human(female, inga, 1860).
human(female, vizma, 1890).
human(male, uldis, 1900).
human(male, juris, 1925). 
human(male, dainis, 1940).
% for testing.
human(female, dainis, 1940).
human(female, dace, 1860).

parent(sergejs, linda).
parent(linda, janis).
parent(janis, inga).
parent(inga, vizma).
parent(inga, uldis).
parent(peteris, uldis).
parent(vizma, juris).
parent(uldis, dainis).
% for testing.
parent(dace, uldis).

%========================================
% Gets father for the specified children.
father(A, B) :- parent(A, B), human(male, A, _).

%========================================
% Gets sister for the specified children.
sister(A, B):-parent(Z, B),parent(Z, A),human(female, A, _).

%========================================
% Gets all ancestors for specified child.
ancestor(A, B) :- parent(A, B).
ancestor(A, B) :- parent(A, C), ancestor(C, B).

%=================================================
% Gets all feminine ancestors for specified child.
anc_females(A, B) :- ancestor(A, B), human(female, A, _).

%============================================================
% Gets all ancestors from the specified year of birth.
% anc_age(X,linda,1700) :- X = sergejs (year of birth: 1750).
anc_age(Parent, Child, Year) :- 
    ancestor(Parent, Child), 
    human(_, Parent, ParentYear), Year =< ParentYear.

%====================================================================
% Gets families whose has at least one children.
husband_wife(A, B) :- 
    parent(A, C), % Getting children (C) for parent A.
    parent(B, C), A \= B, % Getting same children for parent B. true?
    human(S1, A, _), % Getting sex for parent A.
    human(S2, B, _), S1 \= S2. % Getting sex for parent B.

%===========================================================================
% Verifies whether a person at the same time not indicated as woman and man.
gender_error(A) :- 
    human(female, A, _), human(male, A, _), 
    write(A), write(' has many genders!').

%==========================================
% Verifies whether parents has same gender.
parent_error(A, B) :-
    parent(A, C), parent(B, C), A \= B,
    human(S1, A, _), human(S2, B, _), S1 = S2.
    
