"use strict";
/*
    6-5 Challenge: Manipulating the DOM

    Author: Trevor Egbert
    Date: 11/9/2022

    file: aboutme.js
*/

window.addEventListener("load", aboutMeFun);

function aboutMeFun()
{
    var body = document.body;
    // Sets the style for font-family in the <body>
    body.setAttribute("style", "font-family:'Arial, sans-serif'");

    // Add text to the element with id nickname
    document.getElementById("nickname").innerText = "Trev, and T-Dawg";

    // Add text to the element with id nickname
    document.getElementById("favorites").innerText = "Favorite movie: Who Framed Roger Rabbit \
        Favorite Book Series: Magic 2.0  Favorite Video Games: The Legend of Zelda: Majora's Mask, \
        Final Fantasy 4, 6 and 9, Mega Man X4, Persona 3-5";

    // Add text to the element with id hometown
    document.getElementById("hometown").innerText = "Layton Utah";

    // Loops through <li> and class = listitem
    var list = document.getElementsByTagName("li");
    for(var i = 0; i < list.length; i++)
    {
        list[i].setAttribute("class", "listitem");
    }

    // Create <style>
    var aboutMeStyle = document.createElement("style");

    // Adds embedded style sheet to <head>
    document.head.appendChild(aboutMeStyle);

    // Add a style rule to the head
    document.styleSheets[0].insertRule(
        "li.listitem {\
            color: red;\
        }", 0);

    //Creating new img element
    var image1 = document.createElement("img");
    
    //Set attributes for the image1
    image1.setAttribute("src", "images/me1.png");
    image1.setAttribute("alt", "headshot");

    //Inserts image after the <h1> tag in the <body>
    body.insertBefore(image1, body.firstChild.nextSibling.nextSibling);

    // EventListener for a click on the image to run the function ChangePic()
    image1.addEventListener("click", ChangePic);
}

// Randomly picks a number 0-5 to switch the src attribute on image to switch the image to another one
function ChangePic(e)
{
    e.target.setAttribute("src", "images/me" + Math.floor(Math.random()*6) + ".png");
}