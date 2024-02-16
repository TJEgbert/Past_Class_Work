% Trevor Egbert
% Homework 1
% File: first_prolog_program.pl
% This is a practive Prolog program that creates a famil tree
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

sisterof(Sis, Sib) :- siblings(Sis, Sib),
                      female(Sis).
