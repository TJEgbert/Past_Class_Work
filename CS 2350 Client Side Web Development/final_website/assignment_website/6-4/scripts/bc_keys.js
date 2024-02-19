"use strict";

/*
   New Perspectives on HTML5, CSS3 and JavaScript 6th Edition
   Tutorial 12
   Review Assignment

   Author: Trevor Egbert
   Date: 11/8/2022  

   Filename: bc_keys.js

   Functions
   =========
   
   findKeyWords()
      Locate the keywords in the article indicated by the <dfn> tag
      and add those keywords in alphabetical order to a keyword box.
      
   makeKeyStyles()
      Create an embedded style sheet for the keyword box.

      
   replaceWS(textStr)
      Replaces occurences of one or more consecutive white space
      characters with the _ character.

*/

// Eventlisterners on load to run the functions findKeyWords, makeKeyStyles
window.addEventListener("load", findKeyWords);
window.addEventListener("load", makeKeyStyles);


function findKeyWords()
{
   // Create source variable for <article> with id of doc
   var source = document.getElementById("doc");

   // Creates the new element for <aside> that will store all the other elements
   var asideElem = document.createElement("aside");

   // Sets the asideElem id to keywords
   asideElem.setAttribute("id", "keywords");

   // Creates variable and a new <h1> element
   var mainHeading = document.createElement("h1");

   // creates a variable store a text node
   var headingText = document.createTextNode("Keyword List");
   
   // appending headingText to mainHeading
   mainHeading.appendChild(headingText);

   // appending mainHeading to asideElem creating a heading for the aside
   asideElem.appendChild(mainHeading);

   // creates a variable to store a new <ol> element
   var orderedList = document.createElement("ol");

   // it also gets appends to the asideElem
   asideElem.appendChild(orderedList);

   // creates an array of all the <dfn>
   var keyWordsElems = document.querySelectorAll("dfn")

   // an array that will store the keywordsElems textContent
   var keyWords = Array(keyWordsElems.length);

   for(var i = 0; i < keyWordsElems.length; i++)
   {
      //Loops through getting the textContent from keyWordElems Nodes
      keyWords[i] = keyWordsElems[i].textContent;

      // Stores those key words in linkId using replaceWS to rid of spaces and add _
      var linkID = replaceWS(keyWords[i]);

      //Sets the id for <dfn> to the linkID
      keyWordsElems[i].setAttribute("id", linkID);
   }

   // In the aside the keywords will be in alphabetical order
   keyWords.sort();

   // loops through keyWords
   for(var i = 0; i < keyWords.length; i++)
   {
      // creates variable to store a new <li>
      var keyWordListItem = document.createElement("li");

      //creates a variable to store a new <a>
      var keyWordLink = document.createElement("a");

      // inputs the data from keywords into into keyWordLink 
      keyWordLink.innerHTML = keyWords[i];

      // Stores key words in linkId using replaceWS to rid of spaces and add _
      var linkID = replaceWS(keyWords[i]);

      // sets the href attribute to #linkID
      keyWordLink.setAttribute("href", "#" + linkID);

      // appending everything together to make a functional link list
      keyWordListItem.appendChild(keyWordLink);
      orderedList.appendChild(keyWordListItem);
   }

   // adding everything to webpage make a new aside at the top of the article
   source.prepend(asideElem);
}


function makeKeyStyles()
{
   // creates an embedded style sheet
   var asideStyle = document.createElement("style");

   //addes the style sheet to the end of the <head>
   document.head.appendChild(asideStyle);

   // Adding rules to the style sheet
   document.styleSheets[document.styleSheets.length - 1].insertRule(
      "aside#keywords {\
         border: 3px solid rgb(101,101,101);\
         float: right;\
         margin: 20px 0px 20px 20px;\
         padding: 10px;\
         width: 320px;\
      }", 0);

   document.styleSheets[document.styleSheets.length - 1].insertRule(
      "aside#keywords h1 {\
         font-size: 2em;\
         margin: 5px;\
         text-align: center;\
      }", 1);

   document.styleSheets[document.styleSheets.length - 1].insertRule(
      "aside#keywords ol {\
         margin-left: 20px;\
         font-size: 1.2em;\
      }", 2);

   document.styleSheets[document.styleSheets.length - 1].insertRule(
      "aside#keywords ol li {\
         line-height: 1.5em;\
      }", 3);

   document.styleSheets[document.styleSheets.length - 1].insertRule(
      "aside#keywords ol li a {\
         color: rgb(101,101,101);\
         text-decoration: none;\
      }", 4);
}


/* Supplied Functions */

function replaceWS(textStr) {
   var revText = textStr.replace(/\s+/g,"_");
   return revText;
}
