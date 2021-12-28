domains
predicates
    lsubstr(string, integer, string)
    rsubstr(string, integer, string)
    substr(string, integer, integer, string)
    delete(string, integer, integer, string)
    repstring(string, integer, string)
    repchars(string, integer, string)
clauses
    % Gets left side string characters.
    lsubstr(Str, Pos, SubStr) :- frontstr(Pos, Str, SubStr, _).
    
    % Gets right side string characters.
    rsubstr(Str, Pos, SubStr) :- str_len(Str, Len), Num = Len - Pos, frontstr(Num, Str, _, SubStr).
    
    % Gets substring between start and end position.
    substr(Str, StartPos, EndPos, SubStr) :- Pos = StartPos - 1, frontstr(Pos, Str, _, TempStr), frontstr(EndPos, TempStr, SubStr, _).

    % Deletes substring between start and end position.
    delete(Str, StartPos, EndPos, SubStr) :- Pos = StartPos - 1, frontstr(Pos, Str, StartStr, EndS), frontstr(EndPos, EndS, _, EndStr), Concat(StartStr, EndStr, SubStr).
    
    % Repeats string 'n' times by concating it.
    repstring(Str, Times, S) :- 
        Times > 1, Prev = Times - 1, 
        repstring(Str, Prev, StartStr), 
        concat(Str, StartStr, S). % concats 'n' times tracking back 'str' from stack.
        
    repstring(Str, 1, Str).
    
    repchars(Str, Times, S) :- frontstr(1, Str, ) 