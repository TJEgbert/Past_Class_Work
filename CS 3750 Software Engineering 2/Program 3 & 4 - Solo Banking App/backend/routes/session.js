const express = require("express");
const routes = express.Router();

// Used to login in the user and set up a session for them
routes.route("/session_set/:id").get(async function(req, res) {
    const userID = req.params.id;
    console.log("session started" + req.session);
    let status = "";
    if(!req.session.username) {
        // Sets the session if the user is not logged in already
        req.session.username = userID;
        status = "Session set";
        console.log(status);
    } else {
        // Informs the front end the user is already logged in
        status = "user is already logged in";
        console.log(status);
    }
    // saves the session object to the database
    const resultObj = {status: status};
    res.status(200).json(resultObj);
});

// Used to check if the user is logged in 
routes.route("/session_get").get(async function (req, res) {
    let loggedIn = false;
    console.log("In /session_get, session is: " + req.session);
    let status = "";
    if(!req.session.username) {
        // Informs the frontend the user is logged out
        status = "logged out";
        console.log(status);
    } else {
        // Sets the status to the users name 
        status = req.session.username;
        console.log(status);
        loggedIn = true;
    }
    const resultObj = {status: status};
    // If the user is logged in 
    if(loggedIn){
        // Returns ok with user name as a Json object
        res.status(200).json(resultObj);
    } else {
        // Returns an error with status being logged out
        res.status(400).json(resultObj);
    }

});

// Used to delete the user session and also logs out the user
// Returns a successful message about logging out
routes.route("/session_delete").get(async function (req, res) {
    console.log("User has logged out " + req.session);
    req.session.destroy();
    let status = "User has been logged out successfully";
    const resultObj = {status: status};

    res.json(resultObj);
});

module.exports = routes;