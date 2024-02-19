"use strict";

/*
   New Perspectives on HTML5, CSS3 and JavaScript 6th Edition
   Tutorial 12
   Tutorial Case

   Author: Trevor Egbert
   Date: 11/6/2022   

   Filename: bc_switch.js
   
   setupStyles()
   Function to set up the style sheet switcher and insert
   form buttons to allow the user to switch between web
   view and page view
   
*/

window.addEventListener("load", setupStyles);

function setupStyles()
{
   //create <link> element for style sheet

   var pageStyle = document.createElement("link");
   pageStyle.setAttribute("href", "styles/bc_page.css");
   pageStyle.setAttribute("rel", "stylesheet");
   pageStyle.setAttribute("disabled", "disabled")

   //Append that link element to the document <head>
   document.head.appendChild(pageStyle);
   pageStyle.disabled = true;

   //Insert buttons for the style switcher
   
   var buttonDIV = document.createElement("div");
   buttonDIV.setAttribute("id", "styleButtons");

   var webButtons = document.createElement("input");
   webButtons.setAttribute("type", "button");
   webButtons.setAttribute("value", "Web View");

   var pageButtons = document.createElement("input");
   pageButtons.setAttribute("type", "button");
   pageButtons.setAttribute("value", "Page View");

   buttonDIV.appendChild(webButtons);
   buttonDIV.appendChild(pageButtons);

   document.body.insertBefore(buttonDIV, document.body.firstChild);

   //Append embedded <style> in our <head>
   var buttonStyles = document.createElement("style");
   document.head.appendChild(buttonStyles);

   // Add our style rules to the embedded stylesheet
   document.styleSheets[document.styleSheets.length - 1].insertRule(
      "div#styleButtons{\
         position: fixed;\
      }",0);

   document.styleSheets[document.styleSheets.length -1 ].insertRule(
      "div#styleButtons input {\
         background-color: rgba(68,94,186,0.6);\
         border: 3px solid rgba(0,24,123,0.6);\
         border-radius: 50%;\
         cursor: pointer; \
         color: white;\
         display: inline-block;\
         font-size: 1.2em;\
         height: 60px; \
         margin: 5px 10px;\
         width: 100px; \
      }", 1);

   document.styleSheets[document.styleSheets.length -1 ].insertRule(
      "@media print { \
         dive#styleButtons {\
            display: none; \
         }", 2);

   // Turn the page view style to Off and On
   webButtons.onclick = function(){
      pageStyle.disabled = true;
   }

   pageButtons.onclick = function(){
      pageStyle.disabled = false;
   }
   
}
