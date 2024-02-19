"use strict";

/*
   New Perspectives on HTML5 and CSS3 and JavaScript, 6th Edition
   Tutorial 9

   Planisphere Script
   Author: Trevor Egbert
   Date: 10/25/2022  

*/

// Runs the mapClock function
mapClock();

// Uses setInterval to call the mapClock() every second
setInterval(mapClock, 1000);


function mapClock()
{

   // Sets thisTime to the current Date and stores the time and date into timeStr
   var thisTime = new Date();
   var timeStr = thisTime.toLocaleString();

   /**
    * Sets timeStamp to the element with the ID timeStamp 
    * Then inserts timeStr into the HTML if timeStamp
    */
   var timeStamp = document.getElementById("timeStamp");
   timeStamp.innerHTML = timeStr;

   // Sets thisHour and thisMonth the the current hour and month
   var thisHour = thisTime.getHours();
   var thisMonth = thisTime.getMonth();

   // mapNum does the calculation to correct map number and stores it  
   var mapNum = (2*thisMonth + thisHour) % 24;

   /**
    * Creates imgStr and stores the img tag and information getting
    * updated image number from mapNum.
    */
   var imgStr = "<img src='images/sd_sky" + mapNum + ".png' alt='planisphere' >";

   /**
    * Sets plainsphere to the element with id planisphere 
    * Then inserts imStr after the opening tag
    */
   var planisphere = document.getElementById("planisphere");
   planisphere.insertAdjacentHTML("afterbegin", imgStr);

}

