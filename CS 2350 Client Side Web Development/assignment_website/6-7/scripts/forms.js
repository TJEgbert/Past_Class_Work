"use strict";

/*
   
   Author: Trevor Egbert
   Date: 11/12/2022  
   
   Filename: forms.js
   
*/

// Listens for the the page to load to run the function
window.addEventListener("load", function(){

    // Stores the element with id = size
    var kennelSize = document.getElementById("size");

    // Stores the element with id = weight
    var petWeight = document.getElementById("weight");

    // Eventlistener for the weight form element any time there is an input it
    document.getElementById("weight").addEventListener("input",function(){

        // if statement checking petWeight value
        if(isNaN(parseInt(petWeight.value)))
        {
            // if not Not a number is sets kennelSize to a empty stirng
            kennelSize.value = "";
        }
        // if it petWeight less than or equal to 4 sets kennelSize to mini
        else if(parseInt(petWeight.value) <= 4)
        {
            kennelSize.value = "mini";
        }
        // if it petWeight greater than 4 and less or equal to 12 sets kennelSize to small
        else if(parseInt(petWeight.value) > 4 && parseInt(petWeight.value) <= 12)
        {
            kennelSize.value = "small"
        }
        // if it petWeight greater than 12 and less or equal to 50 sets kennelSize to medium
        else if(parseInt(petWeight.value) > 12 && parseInt(petWeight.value) <= 50)
        {
            kennelSize.value = "medium";
        }
        // if petWeight is greater than 50 sets kennelSize to larger
        else if(parseInt(petWeight.value) > 50)
        {
            kennelSize.value = "large";
        }

    });

    // Stores the element with id = days
    var boardingDays = document.getElementById("days");
    
    // Stores the element with id = boardingFee
    var boardingFee = document.getElementById("boardingFee");

    // Adds a listener on boardingDays for whenever this is an input
    boardingDays.addEventListener("input", function(){

        // sets days to the value of boardingDays
        var days = parseInt(boardingDays.value);

        // Checks to see if days not a number
        if(isNaN(days))
        {
            // if so its boardingDays and boardingFee to 0
            boardingDays.value = 0;

            // Makes boardingFee have to decimals
            boardingFee.value = 0.00.toLocaleString(undefined, 
            {
                minimumFractionDigits: 2,
                maximumFractionDigits: 2
            });
        }
        else
        {
            // It sets boardingDays = to days
            boardingDays.value = days;
            //Sets the value of boardingFee = days * 19.99 formated with two decimals
            boardingFee.value = parseFloat((days * 19.99)).toLocaleString(undefined,
                {
                    minimumFractionDigits: 2,
                    maximumFractionDigits: 2
                })
        }
        // Runs the totalCost function to update totals at the bottom of the form
        totalCost();
    });


    // Adds an eventListener onto the checkbox with id = sing for anytime it is changed
    document.getElementById("sing").addEventListener("change", function()
    {
        //If its true it updates the display style to block
        if(document.getElementById("sing").checked === true)
        {
            document.getElementById("singAdd").style.display = "block";
        }
        else
        {   
            //If its false it updates the display style to none
            document.getElementById("singAdd").style.display = "none";
        }

        //Then it runs the totalCost functions to update totals at the bottom of the form
        totalCost();
    });

    // Adds an eventListener onto the checkbox with id = cut for anytime it is changed
    document.getElementById("cute").addEventListener("change", function()
    {
        //If its true it updates the display style to block
        if(document.getElementById("cute").checked === true)
        {
            document.getElementById("cuteAdd").style.display = "block";
        }
        else
        {
            //If its false it updates the display style to none
            document.getElementById("cuteAdd").style.display = "none";
        }

        //Then it runs the totalCost functions to update totals at the bottom of the form
        totalCost();
    });

    // Adds an eventListener onto the checkbox with id = trick for anytime it is changed
    document.getElementById("trick").addEventListener("change", function()
    {
        //If its true it updates the display style to block
        if(document.getElementById("trick").checked === true)
        {
            document.getElementById("trickAdd").style.display = "block";
        }
        else
        {
            //If its false it updates the display style to none
            document.getElementById("trickAdd").style.display = "none";
        }

        //Then it runs the totalCost functions to update totals at the bottom of the form
        totalCost();
    });

});




function totalCost()
{
    // Sets up variables to be used in calculations
    var regCost = 0;
    var numEvents = 0;
    var boardCost = 0;
    
    // Checks boardingFee to see if its not a number if so sets boarCost = 0
    if(isNaN(parseFloat(document.getElementById("boardingFee").value)))
    {
        boardCost = 0;
    }
    else
    {
        // Else sets board cost to the value of the element with id = boardingFee
        boardCost = document.getElementById("boardingFee").value;
    }

    /*
        Checks to see if the checkbox of elements sing, cute, and trick are true
        if so it increase numEvents by 1
    */
    if(document.getElementById("sing").checked === true)
    {
        numEvents++;
    }
    if(document.getElementById("cute").checked === true)
    {
        numEvents++;
    }
    if(document.getElementById("trick").checked === true)
    {
        numEvents++;
    }

    // takes numbEvents and times it by 120 and stores it in regCost
    regCost = (120 * numEvents);

    // Sets the value of the element with boardingCost to boardCost and formats it with two decimal places
    document.getElementById("boardingCost").value = boardCost.toLocaleString(undefined,
        {
            minimumFractionDigits: 2,
            maximumFractionDigits: 2 
        });

    // Sets the value of the element with registrationCost to regCost and formats it with two decimal places
    document.getElementById("registrationCost").value = regCost.toLocaleString(undefined,
        {
            minimumFractionDigits: 2,
            maximumFractionDigits: 2 
        });

    // Calculates the totalCost by adding regCost + boarcost and formats it with two decimal places
    document.getElementById("totalCost").value = (regCost + parseFloat(boardCost.replaceAll(",", ""))).toLocaleString(undefined,
        {
            minimumFractionDigits: 2,
            maximumFractionDigits: 2 
        });
}
