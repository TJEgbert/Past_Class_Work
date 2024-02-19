"use strict"
/*
    Challenge: Using Dates, Arrays, Loopsm and Conditional Statements

    Author: Trevor Egbert
    Date 10/30/2022

    Filename: arrays.js
*/

// Part 1

// Creating and setting the familyNames and familyRelationship arrays
var familyNames = ["Brad", "Stacey", "Tyler", "Kylie", "Zoey", "Rowan", "Addalyne"];
var familyRelationship = ["Father", "Mother", "Brother", "Sister-in-law", "Niece", "Nephew", "Niece"];

// Creating familyTable for the table
var familyTable = "<table>";

// Loops inputing information into the table
for(var i = 0; i < familyNames.length; i++)
{
    // If its the first time through it creates the heading
    if( i === 0)
    {
        familyTable += "<tr>\
                            <th>Name</th>\
                            <th>Relationship</th>\
                        </tr>"
    }

    // Adds the information from the array and inputs into the table
    familyTable += "<tr> <td>" + familyNames[i] + "</td> <td>" + familyRelationship[i] + "</td> </tr>" ;
}

// Adds the closing tag for the table and inserts into the div with id="family"
familyTable += "</table>";
document.getElementById("family").innerHTML = familyTable;

// Part 2

// Part 2a

// Creates the colorNames array and adds colors into the array
var colorNames = [];
colorNames.push("green");
colorNames.unshift("red");
colorNames.push("purple");
colorNames.push("brown");
colorNames.push("yellow");
colorNames.push("pink");
colorNames.push("blue");
colorNames.push("orange");

// Creates the string to store the list infomation in
var colorList = "<ul>";

// loops through the array adding the <li> tags and the color
for(var i = 0; i < colorNames.length; i++)
{
    colorList += "<li>" + colorNames[i] + "</li>";
}

// Adds the closing taking for the list and inserts the ColorList into the div with id="allColors"
colorList += "</ul>";
document.getElementById("allColors").innerHTML = colorList;


// Part 2b

// Sets up the <ul> for colors that start with the letter "p"
var pColorList = "<ul>";

// Loops through the colorNames array
for(var i = 0; i < colorNames.length; ++i)
{
    /*
        Checks to see if the first letter in the color Name is a p
        if so it adds the <li> tags and the color into pColorList
    */
    if(colorNames[i][0] === "p")
    {
        pColorList += "<li>" + colorNames[i] + "</li>";
    }
}

// Adds the closing tag for the <ul> and inserts the pColorList into the div with id="pColors"
pColorList += "</ul>";
document.getElementById("pColors").innerHTML = pColorList;


// Part 2c

// Creates the string to store the list information in
var nonBColorList = "<ul>";

// Loops through the colorNames array
for(var i = 0; i < colorNames.length; i++)
{
    /*
        Checks to see if the first letter of the color is not a "b"
        if not it adds the <li> tags and the color into nonBColorList
    */ 
    if(colorNames[i][0] != "b")
    {
        nonBColorList += "<li>" + colorNames[i] + "</li>";
    }
}

// Adds the closing tag for <ul> and inserts nonBColorList into the div with id="nonBColors"
nonBColorList += "</ul>";
document.getElementById("nonBColors").innerHTML = nonBColorList;


// Part 2d

// A function that checks the color that is passed in if it contains in "n" if so returns true else false
function containsN(color)
{
    if(color.includes("n"))
    {
        return true;
    }

    return false;
}

// Uses containsN to filter the colorNames array into the filterColors array
var filterColors = colorNames.filter(containsN);

// Creates the string to store the list information in
var filterColorsList = "<ul>";

// Loops through the array adding <li> tags and the color into filiterColorsList
for(var i = 0; i < filterColors.length; i++)
{
    filterColorsList += "<li>" + filterColors[i] + "</li>";
}

// Adds the closing tag for <ul> and inserts filterColorsList into the div with id="filterColors"
filterColorsList += "</ul>";
document.getElementById("filterColors").innerHTML = filterColorsList;


// Part 3

// Part 3a

// Sets up randWords and randNumbers array if fills them
var randWords = ["Spade", "Club", "Heart", "Diamond", "Ace", "King", "Queen", "Jack"];
var randNumbers = [58, 21, -7, 99, 46, 6, -20, 47];

// Convets the arrays to strings and saves them in the randomArrays the <p> tags
var randomArrays = "<p>" + randWords.toString(); + "</p>";
randomArrays += "<p>" + randNumbers.toString(); + "</p>";

// Inserts randomArrays into the div with id="twoArrays"
document.getElementById("twoArrays").innerHTML = randomArrays;


// Part 3b

// Sorts the randWords and randNumbers arrays using the sort function
randWords.sort();
randNumbers.sort()

// Convets the arrays to strings and saves them in the randomArrays the <p> tags
var sortedArrays = "<p>" + randWords.toString() + "</p>";
sortedArrays += "<p>" + randNumbers.toString() + "</p>";

// Inserts randomArrays into the div with id="sortedArrays"
document.getElementById("sortedArrays").innerHTML = sortedArrays;


// Part 3d

// Uses a function to get the numbers in numerical order 
randNumbers.sort(function(a, b) {return a - b});

// convets the array to a string and saves them in the randomArrays the <p> tags
var sortedNumbers = "<p>" + randNumbers.toString() + "</p>";

// Inserts sortedNumbers into the div with id="sortedNumberArray"
document.getElementById("sortedNumberArray").innerHTML = sortedNumbers;

// Part 4

// Creates lastModified is set to the last JaveScript was modified
var lastModified = document.lastModified;

// Creates currentDate and stores the Date object with the current date
var currentDate = new Date();

// Creates footerDates and stores the two dates with <h4> tages
var footerDates = "<h4> Last Modified: " + lastModified + "</h4>";
footerDates += "<h4> Current Date: " + currentDate + "</h4>";

// Inserts footerdates into footer with Id="dates"
document.getElementById("dates").innerHTML = footerDates;

