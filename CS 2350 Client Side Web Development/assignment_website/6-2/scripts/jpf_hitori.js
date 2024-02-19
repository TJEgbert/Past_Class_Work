"use strict";

/*
   New Perspectives on HTML5, CSS3, and JavaScript 6th Edition
   Tutorial 11
   Review Assignment

   Author: Trevor Egbert
   Date: 11/6/2022

   Global Variables
   ================
   
   allCells
      References the TD cells within the Hitori table grid.   
      
   Function List
   =============

   startUp()
      Run when the web page is loaded; displays puzzle 1
      and loads the event handlers for the web page buttons.
      
   setupPuzzle()
      Sets up a new puzzle, adding the event handlers for
      every puzzle cell.      

   switchPuzzle(e)
      Swaps one puzzle for another based on the button being clicked
      by the user. Confirms the change before swapping in the
      new puzzle.

   findErrors()
      Highlights the errors in the Hitori puzzle in a red font.
      
   showSolution()
      Shows the solution to the Hitori puzzle
    
   checkSolution()
      Checks the current user's puzzle to verify whether it contains
      the complete and correct solution.

   drawHitori(numbers, blocks, rating)
      Returns a text string of the HTML code to
      display a Hitori puzzle table based on the contents of
      the numbers, blocks, and rating parameters.
	
*/

//Global variable
var allCells;

// On window load it runs the startUp functions
window.onload = startUp;


function startUp()
{

   // Sets up the title 
   document.getElementById("puzzleTitle").innerHTML = "Puzzle 1";

   // Sets up the puzzle
   document.getElementById("puzzle").innerHTML = 
   drawHitori(hitori1Numbers, hitori1Blocks, hitori1Rating);

   // Sets up the puzzle Buttons
   var puzzleButtons = document.getElementsByClassName("puzzles");

   // Loops through the buttons calling the switchPuzzle function
   for(var i = 0; i < puzzleButtons.length; i++)
   {
      puzzleButtons[i].onclick = switchPuzzle;
   }

   // Runs the setupPuzzle function
   setupPuzzle();

   // Sets the eventListeneres for Check and show Solution 
   document.getElementById("check").addEventListener("click", findErrors);
   document.getElementById("solve").addEventListener("click", showSolution);
}

function switchPuzzle(e)
{
   // Brings up confirm window checking if the user is ok with switching puzzle
   if(confirm("You well lose all progress if you switch to a different puzzle. Continue?"))
   {
      // Gets the id for the puzzle that well be loaded and
      var puzzleID = e.target.id;

      // Stores puzzleID inserts into the element with id puzzleTitle
      document.getElementById("puzzleTitle").innerHTML = puzzleID;
   
      // Depending on the puzzleID that got passed in it will use the drawHitori to draw the puzzle
      // it inserts this at the element with id puzzle
      switch(puzzleID)
      {
         case "puzzle1":
            document.getElementById("puzzle").innerHTML = 
            drawHitori(hitori1Numbers, hitori1Blocks, hitori1Rating);
            break;
   
         case "puzzle2":
            document.getElementById("puzzle").innerHTML =
            drawHitori(hitori2Numbers, hitori2Blocks, hitori2Rating);
            break;
   
         case "puzzle3" :
            document.getElementById("puzzle").innerHTML =
            drawHitori(hitori3Numbers, hitori3Blocks, hitori3Rating);
      }
   
      // Runs the setupPuzzle functions
      setupPuzzle();      
   }

}

function setupPuzzle()
{
   // Stores all the td elements from the table id hitoriGrid into allCells
   allCells = document.querySelectorAll("table#hitoriGrid td");

   // loops through allCells
   for(var i = 0; i < allCells.length; i++)
   {
      //sets backgrounds to black, font color to white, and borderRadius to 0
      allCells[i].style.backgroundColor = "white";
      allCells[i].style.color = "black";
      allCells[i].style.borderRadius = "0";

      // Adds an event listener for mousedown on allCells
      allCells[i].addEventListener("mousedown",
      function(e)
      {
         
         if(e.shiftKey)
         {
            // if the shift key is held it set the background color, font color, and borderRaduis to default
            e.target.style.backgroundColor = "white";
            e.target.style.color = "black";
            e.target.style.borderRadius = "0";
         }
         else if(e.altKey)
         {
            // if the alt key is held it will set backgorund color to black, font color to whitem and borderRaduis to zero
            e.target.style.backgroundColor = "black";
            e.target.style.color = "white";
            e.target.style.borderRadius = "0";
         }
         else
         {
            // if nothing is being pressed it will set background color to rgb(101, 101, 101), font to white, and borderRaduis to 50%
            e.target.style.backgroundColor = "rgb(101, 101, 101)";
            e.target.style.color = "white";
            e.target.style.borderRadius = "50%";
         }

         // This prevents the highlighting if the user clicks and drags on the table
         e.preventDefault();
      });

      // adds an eventListerner on allCells if the mouse is moved over
      allCells[i].addEventListener("mouseover", 
      function(e)
      {
         if(e.shiftKey)
         {  
            // if shift is being held set the cursor to an eraser
            e.target.style.cursor = "url(images/jpf_eraser.png), alias";
         }
         else if(e.altKey)
         {
            // if alt is being held set the cursor to a black block
            e.target.style.cursor = "url(images/jpf_block.png), cell";
         }
         else
         {
            // anything else it sets the cursor to a circle
            e.target.style.cursor = "url(images/jpf_circle.png), pointer"
         }
      });

      // adds an eventListener checking if when mouseup and runs the checkSolution 
      allCells[i].addEventListener("mouseup", checkSolution);
   }

}


function findErrors()
{
   // Loops the allCells checking if there is any that ara wrong
   for(var i= 0; i < allCells.length; i++)
   {
      //Checks if allCell[i] if the class name of blocks and if the backgroundColor is rgb(101, 101, 101)
      if((allCells[i].className === "blocks" && allCells[i].style.backgroundColor === "rgb(101, 101, 101)")
      ||// or

      // checks if allCells[i] if the class name of circles and if the backround color is black
      (allCells[i].className === "circles" && allCells[i].style.backgroundColor === "black"))
      {
         // if so it sets the font color to red
         allCells[i].style.color = "red";
      }
   }
   // After one second it loops back through changing any font that was red back to white
   setTimeout(
      function()
      {
         for(var i = 0; i < allCells.length; i++)
         {
            if(allCells[i].style.color === "red")
            {
               allCells[i].style.color = "white";
            }
         }
      }, 1000);
}
         
/* ================================================================= */

function checkSolution() {
   /* Set the initial solved state of the puzzle to true */
   var solved = true;

   /* Loop through the puzzle cells, exiting when an incorrect
      cell is found, setting the solved variable to false */

   for (var i = 0; i < allCells.length; i++) {
      var cellColor = allCells[i].style.backgroundColor;
      var cellClass = allCells[i].className;

      /* A cell is incorrect if it is in the block class and is not black
         or in the circle class and is not white */
      if ( (cellClass == "blocks" && cellColor !== "black") || 
           (cellClass == "circles" && cellColor !== "rgb(101, 101, 101)")) {
         solved = false;
         break;
      }
   }

   /* If solved is still true after the loop, display an alert box */
   if (solved) alert("Congratulations! You solved the puzzle!");
}

function showSolution () {
   for (var i = 0; i < allCells.length; i++) {
      allCells[i].style.color = "";
      allCells[i].style.backgroundColor = "";
      allCells[i].style.borderRadius = "";
   };   
}

function drawHitori(numbers, blocks, rating) {

   /* Initial HTML String for the Hitori Puzzle */
   var htmlString = "";

   /* numbers is a multidimensional array containing the
      Hitori numbers; blocks is a corresponding 
      multidimensional array containing the location of the
      blocks which are indicated by the # character.
      Non-blocking cells are indicated by a blank character.
  */

   /* Create a Web table with the id, hitoriGrid, containing
      the numeric values. Blocks cells have the class name,
      blocks. Non-blocking cells have the class name, circles
  */

   var totalRows = numbers.length;
   var totalCols = numbers[0].length;
   htmlString = "<table id='hitoriGrid'>";
   htmlString += "<caption>" + rating + "</caption>";
   

   for (var i = 0; i < totalRows; i++) {
      htmlString += "<tr>";

      for (var j = 0; j < totalCols; j++) {
         if (blocks[i][j] == "#") htmlString += "<td  class='blocks'>"
         else htmlString += "<td class='circles'>";

         htmlString += numbers[i][j];
         htmlString +="</td>";
      }

      htmlString += "</tr>";
   }

   htmlString += "</table>";

   return htmlString;
}