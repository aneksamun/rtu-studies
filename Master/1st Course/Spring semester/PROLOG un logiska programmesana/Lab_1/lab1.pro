predicates
    human(symbol, symbol, integer)
    parent(symbol, symbol)
    mother(symbol, symbol)
    sister(symbol, symbol)
    ancestor(symbol, symbol).
    anc_females(symbol, symbol).
    anc_age(symbol, symbol, integer).
    husband_wife(symbol, symbol).
    gender_error(symbol).
    parent_error(symbol, symbol).
clauses
    human(male, sergejs, 1750).
    human(female, linda, 1790).
    human(male, janis, 1820).
    human(male, peteris, 1850).
    human(female, inga, 1860).
    human(female, vizma, 1890).
    human(male, uldis, 1900).
    human(male, juris, 1925). 
    human(male, dainis, 1940).
    human(female, dainis, 1940).
    human(female, lida, 1980). 

    parent(sergejs, linda).
    parent(linda, janis).
    parent(janis, inga).
    parent(inga, vizma).
    parent(inga, uldis).
    parent(lida, uldis).
    parent(peteris, uldis).
    parent(vizma, juris).
    parent(uldis, dainis).
  
    mother(X, Y) :- parent(X, Y), human(female,X,_).
    
    sister(X, Y) :- 
    	parent(Z, X), 
    	parent(Z, Y), X <> Y,
    	human(female, X, _).
    	
    ancestor(X, Z) :- parent(X, Z).	
    ancestor(X, Z) :- parent(X, Y), ancestor(Y, Z).
    
    anc_females(X, Z) :- ancestor(X, Z), human(female, X, _).
    
    anc_age(X, Z, Y) :- 
    	ancestor(X, Z), 
    	human(_, X, E),
    	Y <= E.
    	
    husband_wife(X, Y) :- 
    	parent(X, Z),
    	parent(Y, Z),
    	X <> Y,
    	human(M, X, _),
    	human(F, Y, _),
    	M <> F.
    
    gender_error(X) :- 
    	human(female, X, _),
    	human(male, X, _),
    	write(X, " gender error!").
    
    parent_error(X, Y) :-
    	human(O, X, _),
    	human(O, Y, _),
    	parent(X, Z),
    	parent(Y, Z),
    	X <> Y.