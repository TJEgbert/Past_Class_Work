const express = require("express");
const fs = require("node:fs");


const router = express.Router();

// Runs when a use clicks submit on the foodSearch.html
router.get("/displaytable", (req, res) =>{

    //reads favfood.txt into a string
    fs.readFile("favfood.txt", "utf-8", (err, txtfile) => {
        if(err){
            console.error(err);
        }
        // stores the favorite food in lowercase
        const favfood = req.query.foodname.toLowerCase();

        // Creates the fist part of the html string
        let htmlstring = "<html><head></head><body> <table><thead><tr>"+
                "<th>First Name</th>"+
                "<th>Last Name</th>" +
                "</tr></thead><tbody>";
        
        // variables to be used throughout the while loop
        const fileLength = txtfile.length;
        let currentIndex = 0;
        let tablebody = "";
        let workingstring = "";
        let currentfood = "";
        let firstname = "";
        let lastname = "";

        // loops until current index greater then or equel to fileLength and does not equal -1
        while(currentIndex <= fileLength && currentIndex != -1){
            // makes a substring of the next entry in the string
            workingstring = txtfile.substring(currentIndex, txtfile.indexOf("]", currentIndex));

            // gets the food from the entry and converts it to lowercase
            currentfood = workingstring.substring(1, workingstring.indexOf(",")).toLowerCase();

            // if the currentfood is the same has the one passed in
            if(currentfood == favfood)
            {
                // Gets first and last name that added it the tablebody string
                firstname = workingstring.substring(workingstring.indexOf(",")+1, workingstring.lastIndexOf(","));
                lastname = workingstring.substring(workingstring.lastIndexOf(",")+1);

                tablebody +="<tr>";
                tablebody += ("<td>" + firstname + "</td>");
                tablebody += ("<td>" + lastname + "</td>");
                tablebody +="</tr>";

            };
            // Gets the next starting index of the next entry and if it doesn't find [ then it returns -1
            currentIndex = (txtfile.indexOf("[", currentIndex +1));
        };

        // Finishes up building the htmlstring and sends it back to the user for webpage
        htmlstring += tablebody;
        htmlstring += "</tbody></table></body></html>";
        res.send(htmlstring);

    });
});

// Runs when the user enters in url localhost:3000/user_routes/displaydata
router.get("/displaydata", (req, res) =>{

    //reads favfood.txt into a string
    fs.readFile("favfood.txt", "utf-8", (err, txtfile) => {
        if(err){
            console.error(err);
        }
        // Creates the fist part of the html string
        let htmlstring = "<html><head></head><body> <table><thead><tr>"+
                "<th>First Name</th>"+
                "<th>Last Name</th>" +
                "<th>Favorite Food</th>"
                "</tr></thead><tbody>";
        

         // variables to be used throughout the while loop       
        const fileLength = txtfile.length;
        let currentIndex = 0;
        let tablebody = "";
        let workingstring = "";
        let currentfood = "";
        let firstname = "";
        let lastname = "";

        // loops until current index greater then or equel to fileLength and does not equal -1
        while(currentIndex <= fileLength && currentIndex != -1){
            // makes a substring of the next entry in the string
            workingstring = txtfile.substring(currentIndex, txtfile.indexOf("]", currentIndex));
            
            // Gets the food, first and last name from the entry tablebody string
            currentfood = workingstring.substring(1, workingstring.indexOf(","));
            firstname = workingstring.substring(workingstring.indexOf(",")+1, workingstring.lastIndexOf(","));
            lastname = workingstring.substring(workingstring.lastIndexOf(",")+1);

            tablebody +="<tr>";
            tablebody += ("<td>" + firstname + "</td>");
            tablebody += ("<td>" + lastname + "</td>");
            tablebody += ("<td>" + currentfood + "</td>");
            tablebody +="</tr>";

            // Gets the next starting index of the next entry and if it doesn't find [ then it returns -1
            currentIndex = (txtfile.indexOf("[", currentIndex +1));
        };

        // Finishes up building the htmlstring and sends it back to the user for webpage
        htmlstring += tablebody;
        htmlstring += "</tbody></table></body></html>";
        res.send(htmlstring);

    });
});

// Runs when the submit button is pressed on the form.html
router.get("/form", (req, res) => {
    
    // loads and stores the results from the req
    const firstname = req.query.firstname;
    const lastname = req.query.lastname;
    const favfood = req.query.favfood;

    // Gets a string made to add it into favfood.txt
    const savedtext = "["+ favfood + "," + firstname + "," + lastname +"] ";

    // Sends back a thank you and other pages the user can go to
    res.send("<html><head></head><body>"+
    "<p>Thank you: " + firstname + " "+ lastname +" <br>"+
    "Check out one of these pages<br>"+
    "localhost:3000/form.html<br>" +
    "localhost:3000/user_routes/displaydata<br>" +
    "localhost:3000/foodSearch.html"
    +"</p></body></html>");

    // Appends the new entry to the favfood.txt
    fs.appendFile("favfood.txt", savedtext, err =>{
        if(err){
            console.error(err);
        };
    });

});

router.dir

module.exports = router;