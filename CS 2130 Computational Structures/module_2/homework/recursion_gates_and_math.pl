% Trevor Egbert
% Homework 2
% File: recursion_gate_math.pl
% This is pratice for recursion, gates and math in Prolog
%
%

% biologically female family members
female(ann).
female(beth).
female(liz).
female(sue).
female(jill).
female(mary).
female(carol).

% biologically male family members
male(bob).
male(ted).
male(bill).
male(sam).
male(harry).
male(john).
male(matt).

% parental relationship
parentof(beth,bill).
parentof(bill,jill).
parentof(bill,liz).
parentof(ann,jill).
parentof(ann,liz).
parentof(ann,ted).
parentof(liz,matt).
parentof(matt,john).
parentof(bob,carol).
parentof(harry,sue).
parentof(harry,sam).
parentof(carol,sue).
parentof(carol,sam).
parentof(sue,mary).
parentof(mary,john).

% Our rules come next
childof(Child, Parent) :- parentof(Parent, Child).
siblings(Sib1, Sib2) :- parentof(Parent, Sib1),
                        parentof(Parent, Sib2),
                        Sib1 \== Sib2.

sisterof(Sis,Sib) :- siblings(Sis,Sib),
                      female(Sis).

% Added the following for homework 2
%
ancestor_of(A,B) :- parentof(A,B).
ancestor_of(A,B) :- parentof(A,C), ancestor_of(C,B).

%and for counting the generations
%
ancestor_gen(A,B,G) :- parentof(A,B), G is 1.
ancestor_gen(A,B,G):- parentof(A,C),ancestor_gen(C,B,F), G is F + 1.

% Gates in Prolog
%
mygate(0,0,0,1).
mygate(0,0,1,1).
mygate(0,1,0,0).
mygate(0,1,1,0).
mygate(1,0,0,1).
mygate(1,1,0,1).
mygate(1,1,1,1).

% XOR gates
%
myxor(0,0,0).
myxor(0,1,1).
myxor(1,0,1).
myxor(1,1,0).

% NAND gates
%
mynand(0,0,1).
mynand(0,1,1).
mynand(1,0,1).
mynand(1,1,0).

mycircuit(X,Y,Z,F):- myxor(X,Y,T1), myxor(T1,Z,T2), mynand(T1,T2,F),
    write(X),write(' '),write(Y),write(' '),write(Z),write(' '),write(F),write('\n').
