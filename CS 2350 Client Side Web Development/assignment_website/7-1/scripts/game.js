"use strict";
/*
    7-1 Challenge: JavaScript Final

    Author: Trevor Egbert
    Date: 11/20/2022

    file: game.js
*/

// Add a listen for startButton when clicked and runs gameSetup()
document.getElementById("startButton").addEventListener("click", gameSetup)

// Global Variable for the number of guesses
var numbOfGuesses = 0;

function gameSetup()
{
    // Gets the value from the form and save it it numSymbols
    var numSymbols = document.getElementById("numSymbols").value;

    // Creates the symbols string and store the 8 Symbols needed 
    var symbols = "!@#$%^+*";

    // An empty string to store what symbols well be used
    var usedSymbols = "";

    /*
        Loops through the symbols and storing them into th usedSymbols
        String.  Then it sets the startForm display style to none and
        runs the boardSetUp with usedSymbols passed in.
     */

    // Checks to see if no value was passed in and sets up the usedSymbols with 2 symbols
    if(numSymbols === "")
    {
        for(var i = 0; i < 2; i++)
        {
            usedSymbols += symbols[i];
        }
        document.getElementById("startForm").style.display = "none";
        boardSetup(usedSymbols);
    }

    /*
        Checks to see numbSymbols < symbols.length if so it loops through the number
        of symbols.
    */
    else if(numSymbols < symbols.length)
    {
        for(var i = 0; i < numSymbols; i++)
        {
            usedSymbols += symbols[i];
        }

        document.getElementById("startForm").style.display = "none";
        boardSetup(usedSymbols);
    }
    // numbSymbols is greater it uses Symbols and pass that into the boardSetup
    else
    {
        document.getElementById("startForm").style.display = "none";
        boardSetup(symbols);
    }

}

function boardSetup(symbols)
{
    // Creates the new h3 element and sets its id and the innerText
    var guesses = document.createElement("h3");
    guesses.setAttribute("id", "guesses")
    guesses.innerText = "Number of guess: 0";
    
    //Appends guesses element to element with id game
    document.getElementById("game").appendChild(guesses);

    // Creates a new table element and sets id
    var gameTable = document.createElement("table");
    gameTable.setAttribute("id", "gameTable");

    // Create a new body element
    var tableBody = document.createElement("tbody");

    // Stores the number of td elements needed for the the tablle
    var numberOfSymbols = symbols.length * 2;

    /*
        Checks of the numberofSybols of % the square root of numbOfSymbols
        to make the table a square shaped  
    */
    if(numberOfSymbols % Math.sqrt(numberOfSymbols) === 0)
    {
        // Stores the square root of numberOfSymbols  to the row number
        var rowNum = Math.sqrt(numberOfSymbols);
        
        // uses the numberOfSymbols the correct number of rows and columns
        for(var i = 0; i < numberOfSymbols; ++i)
        {
            // if its the first
            if(i === 0)
            {
                // creates a new tr and td element 
                var nextrow = document.createElement("tr");
                var temptd = document.createElement("td");

                //appends the td element to tr element
                nextrow.appendChild(temptd);
            }
            // if i % rowNum is equal to zero
            else if(i % rowNum === 0)
            {
                // appends nextrow to table body
                tableBody.appendChild(nextrow);

                // creates a new tr and td elements
                var nextrow = document.createElement("tr");
                var temptd = document.createElement("td");

                // appends td element to the tr element
                nextrow.appendChild(temptd);
            }
            // all other cases
            else
            {   //creates a new td element and appends it the current newtrow element
                var temptd = document.createElement("td");
                nextrow.appendChild(temptd);
            }
        }

        // then it appends the nextrow to the tableBody element
        tableBody.appendChild(nextrow);

    }
    // in all other cases it makes a table with two rows
    else
    {
        //creates the two tr elments for the two rows
        var row1 = document.createElement("tr");
        var row2 = document.createElement("tr");

        // Uses the numberofSymbols to loop through making the correct amount of td element
        for(var i = 0; i < numberOfSymbols; ++i)
        {
            // i is less numberofSymbols divide by two
            if(i < numberOfSymbols / 2)
            {   
                // creates a new td element and appends it to row1
                var temp1td = document.createElement("td");
                row1.appendChild(temp1td);
            }
            else
            {   //creates a new td element and appends it to row2
                var temp2td = document.createElement("td");
                row2.appendChild(temp2td);
            }
        }
        // appends row1 and row2 to the tableBody
        tableBody.appendChild(row1);
        tableBody.appendChild(row2);
    }
    
    // appends the tableBody to the gameTable
    gameTable.appendChild(tableBody);

    // appends the completed gameTable to the element with it game
    document.getElementById("game").appendChild(gameTable);

    // saves all elements with the tag of td in the tdTags
    var tdTags = document.getElementsByTagName("td");
    
    // makes a copy of the symbols element
    var symbols2 = symbols;

    // Loops through all tdTags
    for(var i = 0; i < tdTags.length; i++)
    {
        // if i % 0 = 0
        if(i % 2 === 0)
        {
            // Gets a random number with the size of symbols.length
            var elementToAdd = parseInt((Math.random()*symbols.length))

            // Inserts the table into the innerHTML
            tdTags[i].innerHTML = symbols[elementToAdd];
            // then it updates the symbols by replacing the inserted symbols with a space
            symbols = symbols.replace(tdTags[i].innerHTML, "");
        }
        else
        {
            // Gets a random number with the size of symbols2.length
            var elementToAdd = parseInt((Math.random()*symbols2.length))

            // Inserts the table into the innerHTML
            tdTags[i].innerHTML = symbols2[elementToAdd];

            // then it updates the symbols2 by replacing the inserted symbols with a space
            symbols2 = symbols2.replace(tdTags[i].innerHTML, "");
        }
        // all tdTags sets attribute clicked to false
        tdTags[i].setAttribute("clicked", "false");
    }

    // runs the load function
    load();

}


function load()
{
    // saves all elements with the tag of td in the tdTags
    var tdTags = document.getElementsByTagName("td");

    //loops through the tdTags
    for(var i = 0; i < tdTags.length; i++)
    {
        // if the style.color is not black
        if(tdTags[i].style.color != "black")
        {
            // adds in event listener to tdTags[i] click, mouseover, and mouseout 
            tdTags[i].addEventListener("click", click);
            tdTags[i].addEventListener("mouseover", hover);
            tdTags[i].addEventListener("mouseout", hoverOut);

        }
    }
}

function click(e)
{
    // creates a bool checked and sets it to false
    var checked = false;

    // a variable to keep track through the loop
    var loctionOfFirst = 0;

    // sets the target style color to black and clicked attribute to true
    e.target.setAttribute("style", "color:black");
    e.target.setAttribute("clicked", "true");

    // saves all elements with the tag of td in the tdTags
    var tdTags = document.getElementsByTagName("td");

    //loops through all the tdTags
    for(var i = 0; i < tdTags.length; i++)
    {
        // if attribute clicked is true and checked is false
        if(tdTags[i].getAttribute("clicked") === "true" && checked === false)
        {
            // sets the current tdTags target1
            var target1 = tdTags[i];
            // makes checked true and stores the current i to locationOfFirst
            checked = true;
            loctionOfFirst = i;
        }
        // it then checks locattionOfFirst is < i and && current tdTags clicked is true
        else if(loctionOfFirst < i && tdTags[i].getAttribute("clicked") === "true")
        {
            // it increase the numOfGuess by one and updates h3 element 
            numbOfGuesses++;
            document.getElementById("guesses").innerText = "Number of guess: " + numbOfGuesses;

            // runs the remove function
            remove();

            // sets target2 to the current tdTag element
            var target2 = tdTags[i];

            // checks the innerHTML are the same
            if(target2.innerHTML === target1.innerHTML)
            {
                // it runs winCheck and load
                winCheck();
                load();
            }
            else
            {
                // sets a timer and sets they style attribute color to transparent and runs load
                setTimeout(function()
                {
                    target1.setAttribute("style", "color:transparent");
                    target2.setAttribute("style", "color:transparent");
                    load();
                }, 500);
            }

            // sets target 1 and target 2 clicked attribute to false
            target1.setAttribute("clicked", "false");
            target2.setAttribute("clicked", "false");
        }

    }


}

function remove()
{
    // saves all elements with the tag of td in the tdTags
    var tdTags = document.getElementsByTagName("td");
    for(var i = 0; i < tdTags.length; i++)
    {
        // Remove the listners for click, mouseover, and mouseout
        tdTags[i].removeEventListener("click", click);
        tdTags[i].removeEventListener("mouseover", hover);
        tdTags[i].removeEventListener("mouseout", hoverOut);
    }
}


function winCheck()
{
    //// saves all elements with the tag of td in the tdTags
    var tdTags = document.getElementsByTagName("td");

    // create a correct counter 
    var correct = 0;

    //loops tdTags elements
    for(var i = 0; i < tdTags.length; i++)
    {   
        // checks if the color style is = black
        if(tdTags[i].style.color === "black")
        {
            // addes one to the correct counter
            correct++;
        }
    }
    // if correct counter equal the tdTags.length
    if(correct === tdTags.length)
    {
        //sets the display style of the element with the id gameTable to none
        document.getElementById("gameTable").setAttribute("style", "display:none");

        //creates a new img element and sets it scr to winScreen.png
        var winScreen = document.createElement("img");
        winScreen.setAttribute("src", "images/winScreen.png");

        // appends the img element to element with the id game
        document.getElementById("game").appendChild(winScreen);
    }
}


function hover(e)
{
    // saves all elements with the tag of td in the tdTags
    var tdTags = document.getElementsByTagName("td");
    //loops through the tdTags
    for(var i = 0; i < tdTags.length; i++)
    {
        // setting the backgroundColor to black
       e.target.style.backgroundColor = "black";
    }
}

function hoverOut(e)
{
        // saves all elements with the tag of td in the tdTags
        var tdTags = document.getElementsByTagName("td");
        //loops through the tdTags
        for(var i = 0; i < tdTags.length; i++)
        {
            //setting the background color to #82E21D
           e.target.style.backgroundColor = "#82E21D";
        }
}