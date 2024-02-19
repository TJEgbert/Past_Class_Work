"use strict";

/*
   New Perspectives on HTML5 and CSS3, 7th Edition
   Tutorial 10
   Review Assignment

   Author: Trevor Egbert
   Date: 10/28/2022  

*/

// creates thisDay and sets it to Date("August 30, 2018")
var thisDay = new Date("August 30, 2018");

// creates tableHTML and starts the HTML code for the table
var tableHTML = "<table id='eventTable'> \
                  <caption>Upcoming Events </caption> \
                  <tr>\
                     <th>Date</th>\
                     <th>Event</th>\
                     <th>Price</th>\
                  </tr>";

// creates endDate and sets it to a date that is 14 days after thisDay
var endDate = new Date((thisDay.getTime() + 14*24*60*60*1000));

for(var i = 0; i < eventDates.length; i++)
{  
   // creates a new Date object from array eventDates each loop
   var eventDate = new Date(eventDates[i]);

   // creates eventDay and eventTime and stores the string information
   var eventDay = eventDate.toDateString();
   var eventTime = eventDate.toLocaleTimeString();

   /*
      First it checks to see if thisDay is less than or equal to evenDate
      then it checks to see if evenDate less than or equal to endDate
   */
   if(thisDay <= eventDate && eventDate <= endDate)
   {
      // add the rest of table infomation and HTML code and adds it to tableHTML
      tableHTML += "<tr> \
                     <td>" + eventDay + "@" + eventTime + "</td> \
                     <td>" + eventDescriptions[i] + "</td> \
                     <td>" + eventPrices[i] + "</td> \
                  </tr>";
   }
}

// adds the closing table tag and inserts the string into HTML file at id eventList
tableHTML += "</table>";
document.getElementById("eventList").innerHTML = tableHTML;