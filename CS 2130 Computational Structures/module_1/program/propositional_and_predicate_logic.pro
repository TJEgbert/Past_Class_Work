% Trevor Egbert
% CS 2130 - 7:00 am
% Assigment: Program - Propositional and Predicate Logic Using Prolog
% Dr. Hunson
% Due: 5/14/2023
% Filename: propositional_and_predicate_logic.pro
% Version: 1.0
% Student discussions: None
% The program is used to determine if therr are airline flights schedule
% between a list of cities

% Flight facts
%
flight(dgz,qyy).
flight(dgz,azi).
flight(qyy,csi).
flight(azi,tva).
flight(csi,ppg).
flight(tva,brw).
flight(brw,csi).

% Rules

% Base Case: This checks using flight() see if the Scity is a direct
% flight to Dcity. Since there are no additinoal stops Stops is set to
% zero
%
route(Scity,Dcity,Stops):- flight(Scity,Dcity), Stops is 0.

% Recursive Call: This checks using flight() to get the Ncity.
% Then it calls route() using NCity as Scity.
% It adds C + 1 to Stops and writes out the Ncity with a line break.
%
route(Scity,Dcity,Stops):- flight(Scity,Ncity), route(Ncity,Dcity,C), Stops is C + 1,write(Ncity),write('\n').
