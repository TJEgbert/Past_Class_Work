"use strict";
/*
    6-5 Challenge: Manipulating the DOM

    Author: Trevor Egbert
    Date: 11/9/2022

    file: myCollection.js
*/

/*
    An array of video games whith properties for...
    title:
    developer:
    beaten:
*/
var videoGames = [
    {
        title: 'The Legend of Zelda: Majoras Mask',
        developer: 'Nintendo',
        beaten: true
    },
    {
        title: 'The World Ends With You',
        developer: 'Square Enix',
        beaten: true
    },
    {
        title: 'Final Fantasy 8',
        developer: 'Square',
        beaten: false
    },
    {
        title: 'Xenogears',
        developer: 'Square',
        beaten: false
    },
    {
        title: 'Legend of Legaia',
        developer: 'Contrail',
        beaten: true
    },
    {
        title: 'Hades',
        developer: 'Supergiant Games',
        beaten: false
    },
    {
        title: 'Persona 5 Royal',
        developer: 'Atlus',
        beaten: true
    },
    {
        title: 'The Messenger',
        developer: 'Sabotage Studio',
        beaten: true
    },
    {
        title: 'Shovel Knight',
        developer: 'Yacht Club Games',
        beaten: true
    },
]

// Var to story to <body> to add to
var body = document.body;

// Creates the a new <table>
var collectionTable = document.createElement("table");

// Creates a new <thead>
var tableHeader = document.createElement("thead");

// Creates a new <tr>
var trElement = document.createElement("tr");

// Creates a new <th> elements one for each property for an item in the videoGames array
var title = document.createElement("th");
var developer = document.createElement("th");
var beaten = document.createElement("th");

// Inserts the Text for each property in corresponding <th>
title.innerText = "Title";
developer.innerText = "Developer";
beaten.innerText = "Beaten?"

// Appends the <th> element to trElement
trElement.appendChild(title);
trElement.appendChild(developer);
trElement.appendChild(beaten);

// Appends the trElement to the tableHeader Element
tableHeader.appendChild(trElement);

// Appends the tableHeader to the collectionTable element
collectionTable.appendChild(tableHeader);

// Appending the collectionTable to the <body>
body.insertBefore(collectionTable, body.firstChild.nextSibling.nextSibling);

// Setting up strings <img> strings for the check.png and x.png
var checkImg = "<img src='images/check.png' alt='Check Mark'>";
var xImg = "<img src='images/x.png' alt='X Mark'>";

// Creates a new <tbody>
var tbody = document.createElement("tbody");

// Loops through the videoGames Array
for(var i = 0; i < videoGames.length; i++)
{
    // Creates a new <tr>
    var tempTr = document.createElement("tr");

    // Creates a <td> for each property for an item in the videoGames array
    var tempTitle = document.createElement("td");
    var tempDev = document.createElement("td");
    var tempBeaten = document.createElement("td");

    // Inserts title and developer for each item in the array
    tempTitle.innerText = videoGames[i].title;
    tempDev.innerText = videoGames[i].developer;

    // Checks to see if beaten property is true
    if(videoGames[i].beaten === true)
    {
        // If true sets the innerHTML to check.png
        tempBeaten.innerHTML = checkImg;
    }
    else
    {
        // If false set the inner HTML to x.png
        tempBeaten.innerHTML = xImg;
    }

    // Appends all <td> elements to the tempTr
    tempTr.appendChild(tempTitle);
    tempTr.appendChild(tempDev);
    tempTr.appendChild(tempBeaten);

    // Appends the update tempTr to the tbody
    tbody.appendChild(tempTr);
}

// Appends the fully update tbody element to collectionTable
collectionTable.appendChild(tbody);

//Creates a style element
var style = document.createElement("style");

// Appends the new embedded style sheet to <head>
document.head.appendChild(style);

// Adds rules to the embedded style sheet
document.styleSheets[0].insertRule("\
    table {\
        width:50%;\
        border: 5px outset black;\
        border-collapse: collapse;\
        font-family: Verdana, Geneva, Tahoma, sans-serif;\
        font-size: 18px;\
    }", 0)

document.styleSheets[0].insertRule("\
th{\
    font-size: 1.5em\
}", 1)

document.styleSheets[0].insertRule("\
th, td{\
    border: 1px solid black;\
    padding: 5px\
}", 2)