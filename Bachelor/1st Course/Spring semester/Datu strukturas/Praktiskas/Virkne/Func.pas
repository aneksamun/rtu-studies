Unit Func;

Interface

uses crt;

const MaxLength = 1000;

type StringPos = 1..MaxLength;
     StringLen = 0..MaxLength;
     MyString = ^StringInstance;
     StringInstance = record
        strLen: StringLen;
        data: array[StringPos] of char;
     end;

  procedure Create(var s: MyString; var created: Boolean);
  procedure Terminate(var s: MyString; var created: Boolean);
  function  StrLength(s: MyString): StringLen;
  function  Empty(s: MyString): Boolean;
  procedure Append(var s: MyString; ch: char);
  procedure Concatenate(var s1: MyString; var s2: MyString);
  procedure Substring(s1: MyString; var s2: MyString; pos: StringPos; len: StringLen);
  procedure Delete(var S: MyString; pos: StringPos; len: StringLen);
  procedure Insert(var s1: MyString; s2: MyString; pos: StringPos);
  function  FindCons(s1,s2:mystring; pos:stringpos): StringLen;
  function  FindBM(s1, s2: MyString; pos: StringPos): StringLen;
  procedure ReadString(var s: MyString);
  procedure WriteString(s: MyString);
  function  Equal(s1, s2: MyString): Boolean;
  procedure Remove(var S: MyString; pos: StringPos; var ch: Char);
  function  Full(s: MyString): boolean;
  procedure MakeEmpty(var s: MyString);
  function  Polindrome(s: MyString): Boolean;
  procedure InFile(var s: MyString);
  procedure Reverse(var s: MyString);

var
    s: MyString;
    created: Boolean;

Implementation

function StrMatch(s1, s2: MyString; pos: StringPos): Boolean; 
forward;

procedure Create(var s: MyString; var created: Boolean);
begin
    New(s);
    s^.strLen := 0;
    created := True;
end;

function StrLength(s: MyString): StringLen;
begin
    StrLength := s^.strLen;
end;

function Full(ss: Mystring): Boolean;
begin
    Full := s^.StrLen = MaxLength;
end;

procedure Append(var s: MyString; ch: Char);
begin
    if (s^.strLen < MaxLength) then
    begin
        Inc(s^.strLen);
        s^.data[s^.strLen] := ch;
    end;
end;

function Empty(s: MyString): Boolean;
begin
    if s^.strLen=0 then 
        Empty := True
    else 
        Empty := False;
end;

procedure MakeEmpty(var s: MyString);
begin
    s^.strLen:=0
end;

procedure InFile(var s: MyString);
var ch: Char;
    i: Integer;
    lotus: Text;
begin
    Assign(lotus, 'Message.txt');
    Reset(lotus);
    if EOF(lotus) = False then
    begin
        i := 1;
        repeat
            Read(lotus, ch);
            s^.data[i] := ch;
            i := i + 1;
        until (EOF(lotus) = True) or (i = MaxLength + 1);
        s^.strLen := i - 1;
    end
    else Writeln('Faila nekas netika ievadits');
end;

function StrMatch(s1, s2: MyString; pos: StringPos): Boolean;
var i, 
    last: StringPos;
    continue: Boolean;
begin
    i := 1;
    last := StrLength(s2);
    continue := True;
    StrMatch := False;
    if (not Empty(s2)) and (StrLength(s1) >= StrLength(s2) + pos - 1) then
        while (continue) and (s1^.data[pos] = s2^.data[i]) do
            if i = last then begin
                continue:= False;
                StrMatch:= True;
            end
            else begin
                i := i + 1;
                pos := pos + 1;
            end;
end;

procedure Concatenate(var S1: MyString; var s2: MyString);
var i: StringPos;
    k: StringLen;
begin
    if (not Empty (S2)) then
    begin
        if StrLength(s1) + StrLength(s2) <= MaxLength then 
            k := MaxLength
        else 
            k := MaxLength - StrLength(s1);
        with s1^ do begin
            for i := 1 to k do 
                data[strLen + i] := s^.data[i];
            strLen := strLen + k;
        end;
    end;
end;

procedure Substring(s1: MyString; var s2: MyString; pos: StringPos; len: StringLen);
var i: StringPos;
begin
    if (len > 0) and (StrLength(S1) >= pos + len - 1) then 
        with s2^ do
        begin
            for i := 1 to len do 
                data[i] := s1^.data[pos + i - 1];
            strLen := len;
        end;
end;

function FindCons(s1, s2: MyString; pos: StringPos): StringLen;
var kBegin, kEnd: StringPos;
    found: Boolean;
begin
    kBegin := pos;
    kEnd := s1^.strLen - s2^.strLen + 1;
    found := False;
    while (kBegin <= kEnd) and (found = False) do
        if StrMatch(s1, s2, kBegin) = true then
            found := True
        else
            kBegin := kBegin + 1;

    if found then 
        FindCons := kBegin
    else
        FindCons := 0;
end;

function FindBM(s1, s2: MyString; pos: StringPos): StringLen;
var len1, len2, kBegin: StringLen;
    d: array[' '..'}'] of StringPos;
    found: Boolean;

    procedure PreProcess(s2: MyString; len: StringLen);
    var ch: Char; 
        i: StringPos;
    begin
        for ch:=' ' to '}' do
            d[ch] := len;
        for i := 1 to len - 1 do
            d[s2^.data[i]] := len - i;
    end;
begin
    found := False;
    len2 := StrLength(s2);
    len1 := StrLength(s1);
    PreProcess(s2,len2);
    kBegin := pos + len2 - 1;

    while (kBegin <= len1) and (found = false) do
        if StrMatch(s1, s2, kBegin - len2 + 1) = True then
            found := True
        else kBegin := kBegin + d[s1^.data[kBegin]];

    if found = True then
        FindBM := kBegin - len2 + 1
    else FindBM := 0;
end;

procedure Insert(var s1: MyString; s2: MyString; pos: StringPos);
var len, len1, len2, i, k: StringLen;
begin
    len1 := StrLength(s1);
    len2 := StrLength(s2);
    len := len1 + len2;
    k := len1 - pos + 1;
    if (len2 > 0) and (len <= MaxLength) and (len >= pos + len2 - 1) then
    begin
        for i := k downto 1 do
            s1^.data[len2 + pos + i - 1] := s1^.data[pos + i - 1];
        for i := 0 to len2 - 1 do
            s1^.data[pos + i + 1] := s2^.data[i + 1];
        s1^.strLen := len;
    end;
end;

procedure Delete(var s: MyString; pos: StringPos; len: StringLen);
var i: StringLen;
begin
    if (len > 0) and (StrLength(s) >= pos + len - 1) then with s^ do
    begin
        for i := pos + len to s^.strLen do
            s^.data[i - len] := data[i];
        s^.strLen := s^.strLen - len;
    end
    else 
        s^.strLen := pos - 1;
end;

procedure ReadString(var s: MyString);
var ch: Char;
begin
    while EOLN = False do
    begin
        if not Full(s) then
        begin
            Read(ch);
            Append(s, ch);
        end;
    end;
end;

function Polindrome (S: MyString): Boolean;
var p: MyString;
begin
    Polindrome := True;
    if StrLength(S) > 1 then
    begin
        New(p);
        p^.data := s^.data;
        p^.strLen := s^.strlen;
        Reverse(p);
        Polindrome := Equal(s,p);
    end;
end;

procedure WriteString(s: MyString);
var i: StringPos;
begin
    if not Empty(s) then 
        with s^ do
            for i := 1 to strLen do 
                Write(data[i]);
end;

function Equal(s1, s2: MyString): Boolean;
var len1, len2: StringLen;
begin
    len1 := StrLength(s1);
    len2 := StrLength(s2);
    if (len1 = 0) and (len2 = 0) then 
        Equal := True
    else if len1 = len2 then 
        Equal := StrMatch(s1, s2, 1)
    else Equal := False;
end;

procedure Reverse(var s: MyString);
var i: StringPos;
    ch: Char;
begin
    i := 1;
    while (i <= (s^.strLen div 2)) do
    begin
        ch := s^.data[i];
        s^.data[i] := s^.data[s^.strLen - i + 1];
        s^.data[s^.strLen - i + 1] := ch;
        i := i + 1;
    end;
end;

procedure Remove(var s: MyString; pos: StringPos; var ch: Char);
var i: StringPos;
begin
    if not Empty(s) then with s^ do
    begin
        ch := data[pos];
        for i := pos + 1 to strLen do 
            data[i - 1] := data[i];
        strLen:= strLen-1;
    end;
end;

procedure Terminate(var s: Mystring; var created: Boolean);
begin
    Dispose(s);
    created := False;
end;

end.