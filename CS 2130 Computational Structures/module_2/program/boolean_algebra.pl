% Trevor Egbert
% CS 2130 - 8:00 am
% Assigment: Program - Boolean Algebra: Prolog for logic gates
% Dr. Hunson
% Due: 5/20/2023
% Filename: boolean_algebra.pl
% Version: 1.0
% Student discussions: None
% This program is to output results of circuit containg,
% Not, Or, And logic gates.

%Not gates
%
mynot(0,1).
mynot(1,0).

% Or gates
%
myor(0,0,0).
myor(0,1,1).
myor(1,0,1).
myor(1,1,1).

% And gates
%
myand(0,0,0).
myand(0,1,0).
myand(1,0,0).
myand(1,1,1).

% Circuit: Takes in variables W,X,Y,Z and uses mynot(), myor(),myand(),
% to output the results to the variable F
%
circuit(W,X,Y,Z,F):- myand(W,X,T1),mynot(Y,T2),myor(X,T2,T3),
    myand(T1,T3,T4),myor(Y,Z,T5),mynot(T5,T6),myor(T4,T6,F).
