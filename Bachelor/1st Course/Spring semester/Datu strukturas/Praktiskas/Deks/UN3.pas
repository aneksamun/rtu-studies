UNIT UN3;

INTERFACE

uses crt;
const MaxSize = 500;
type Count=0 .. MaxSize;
     DataType = string;
     KeyType = integer;
     No = 1..2;
     StdElement = record
        data: DataType;
        key: KeyType;
     End;
     NodePointer = ^Node;
     Node = record
        el: StdElement;
        next: NodePointer;
        prior: NodePointer;
     End;
     Deque = ^DequeInstance;
     DequeInstance = record
        head: NodePointer;
        tail: NodePointer;
        n: Count;
     End;

Procedure Create (var D: Deque; var created: boolean);
Procedure Terminate (var D: Deque; var created: boolean);
Procedure Enqueue (var D: Deque; e: StdElement; DNo: No);
Procedure Serve (var D: Deque; var e: StdElement; DNo: No);
Procedure View (D: Deque; e: StdElement; DNo:No);
Function Size (var D: Deque): Count;
Function Full (D: Deque): boolean;
Function Empty (D: Deque): boolean;
Function FindKey (D: Deque; e: StdElement): boolean;
Procedure FwRec (e: StdElement);
procedure FCreate;
Procedure FRwRecbeg (e: StdElement);
Procedure WriteLnRec (Str1: string; Key: KeyType; Str2: string; Data: Datatype);
Procedure FView (e: StdElement);
procedure FErase;
Procedure FRwRecEnd (e: StdElement);
Procedure FDel;
Procedure FEndDel;
Procedure FBegDel (e: stdElement);

type
    MyFileType = File of StdElement;

var
   created: boolean;
   name: string;
   fff: MyFileType;

IMPLEMENTATION

Procedure Create (var D: Deque; var created: boolean);
Begin
    New (D);
    With D^ Do
        Begin
            head := Nil;
            tail := Nil;
            n := 0;
        End;
    created := True;
End;

{Nosaka elementu skaitu dekaa}
Function Size (var D: Deque): Count;
Begin
    Size := D^.n;
End;

{Parbauda vai deks D^ ir pilns}
Function Full (D: Deque): Boolean;
Begin
    Full := D^.n = MaxSize;
End;

{Parbauda vai rinda ir tuksa}
Function Empty (D:Deque): Boolean;
Begin
    Empty := D^.n = 0;
End

Procedure Terminate (var D: Deque; var created: Boolean);
var p: NodePointer;
Begin
    If created Then
    Begin
        If Not Empty(D) Then With D^ Do
            While head <> Nil Do
            Begin
                p := head; head := head^.next;
                Dispose (p);
            End;
        Dispose (D);
        created := False;
    End;
End;

{Dekaa izvieto jaunu elementu e}
Procedure Enqueue (var D: Deque; e: StdElement; DNo: No);
var p: NodePointer;
Begin
    If Not Full (D) Then With D^ Do
    Begin
        New (P); P^.el := e;
        If Empty(D) Then
        Begin
            p^.next := Nil;
            p^.prior := Nil;
            head := p;
            tail := p;
            n := n + 1;
            FwRec(e);
        End
        Else
        Begin
            Case DNo of
            1:Begin  {elementu izvieto deka sakuma}
                p^.prior := Nil;
                p^.next := head;
                head^.prior := p;
                head := p;
                FRwRecbeg (e);
            End;
            2:Begin  {elementu izvieto deka galaa}
                p^.next := nil;
                p^.prior := tail;
                tail^.next := p;
                tail := p;
                FRwRecEnd (e);
            End
        End;
        n := n+1;
    End
End;

{No deka nolasa elementu e}
Procedure Serve (var D: Deque; var e: StdElement; DNo: No);
var p: NodePointer;
Begin
    If Not Empty(D) Then With D^ Do
    Begin
        If n = 1 Then
        Begin
            p := head;
            head := Nil;
            tail := Nil;
            FDel;
        End
        Else case DNo of
        1:Begin {elements tiks nolasits deka sakuma}
           p := head;
           head^.next^.prior := Nil;
           head := head^.next;
           FbegDel(e);
        End;
        2:Begin {elements tiks nolasits deka gala}
           p := tail;
           tail^.prior^.next := Nil;
           tail := tail^.prior;
           FEndDel;
        End;
    End;
    e := p^.el;        {nolasa elementu}
    Dispose(p);        {nolasitu elementu dzes}
    n := n - 1;
    End;
End;

Procedure View (D: Deque; e: StdElement; DNo: No);
var p: NodePointer;
Begin
    If Not Empty(D) Then With D^ Do
    Begin
        If n = 1 Then
        Begin
            p := head;
            e := p^.el;
            Writeln ('"atsleega:" ',e.key,' "data:" ',e.data);
        End
        Else case DNo of
        1:Begin
            p := head;
            e := p^.el;
            Writeln ('"atsleega:" ',e.key,' "data:" ',e.data);
        End;
        2:Begin
            p := tail;
            e := p^.el;
            Writeln ('"atsleega:" ',e.key,' "data:" ',e.data);
        End;
    End;
End;

Function FindKey (D: Deque; e: StdElement): Boolean;
var p: NodePointer;
    a: StdElement;
Begin
    If Not Empty(D) Then With D^ Do
    Begin
        If n = 1 Then
        Begin
            p := head;
            a := p^.el;
            If e.key = a.key Then
                FindKey := True
            Else
                FindKey := False;
        End
    End
    Else
    Begin
       findkey:=false;
         p:=head;
          while (p^.next <> nil) and (p^.el.key = e.key) do
          begin
             p:=p^.next;
          end;
         if p^.el.key = a.key then
         findkey:=true;
        End;
    End;
End;

Procedure FCreate;
var n: Integer;
Begin
    name := 'result';
    Assign(fff, name);
    {$I-}
    Reset(fff);
    {$I+}
    n := IOResult;
    if n <> 0 then 
    Begin
        {$I-}
        ReWrite(fff);
        {$I+}
        n := IOResult;
        If n <> 0 Then
        Begin
            Writeln('Error creating file !'); halt;
        End;
    End
    Else
    Begin
        n := FileSize(fff);    { Calculate total record }
        Seek(fff, n);          { Move file pointer PAST the last record }
    End;
    Close(fff);
End;

Procedure FwRec (e: StdElement);
var i: Integer;
Begin
    Reset (fff);
    i := 1;
    Seek (fff,i);
    Write (fff,e);
End;

Procedure FRwRecbeg (e: StdElement);
var
   i: Integer;
Begin
    i := 0;
    Reset (fff);
    Seek (fff,i);
    Write (fff,e);
End;

Procedure FRwRecEnd (e: StdElement);
var i: Integer;
begin
    i := FileSize (fff);
    Reset (fff);
    Seek (fff,i);
    Write (fff,e);
end;

Procedure FDel;
var
   i: Integer;
Begin
    i := 0;
    Reset (fff);
    Seek (fff,i);
    Truncate (fff);
End;

Procedure FEndDel;
var i: Integer;
Begin
    i := FileSize(fff) - 1;
    Reset(fff);
    Seek(fff,i);
    Truncate (fff);
End;

Procedure FBegDel (e: stdElement);
var i, total: Integer;
Begin
    total := FileSize(fff);
    For i := 0 To total-1 Do
        If i = 0 Then 
        Begin
            Seek (fff, i);
            Read (fff, e);
            Seek (fff, total);
            Write (fff, e);
        End
        Else
        Begin
            Seek (fff, i);
            Read (fff, e);
            Seek (fff, i-1);
            Write (fff, e);
        End;
    Seek (fff, total-1);
    Truncate (fff);
    Dec (total);
End;

Procedure WriteLnRec (str1: string; key: KeyType ; str2: string; data: datatype);
Begin
    Writeln(str1, key:3, str2, data);
End;

Procedure FView (e: StdElement);
var i: Count;
Begin
    i := 0;
    Seek (fff,i);
    While (EOF (fff) <> TRUE) Do
    Begin
        Read (fff, e);
        WriteLnRec ('"atslega:" ', e.key ,' "dati:" ', e.data);
        i := i + 1;
    End;
End;

Procedure FErase;
Begin
    Assign (fff, 'result');
    Erase (fff);
End;

End.
