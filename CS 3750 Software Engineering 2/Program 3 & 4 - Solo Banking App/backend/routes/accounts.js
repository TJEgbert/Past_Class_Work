// Sets up express and the routers
const express = require("express");
const accountsRoutes = express.Router();
const ObjectId = require("mongodb").ObjectId;

// Used to connect to the mongodb database
const dbo = require("../db/conn");
const session = require("express-session");

let word = "";

// Gets all the users profiles exclude database id and passwords
// Returns the json collection of users profiles
accountsRoutes.route("/accounts").get(async (req, res) => {
    try{
        // Gets bank database
        let db_connect = dbo.getDb();
        // Used to filter out database id and passwords fields
        const options = { projection: {_id:0, password:0}};
        // Queries database and waits for the results and returns them 
        const result = await db_connect.collection("accounts").find({}, options).toArray();
        console.log("record was returned");
        res.json(result);
    } catch(err) {
        throw err;
    };
});

// Gets a user with a specific email from the database excludes database id and password
// Returns the json object of the user
accountsRoutes.route("/account/lookup").post(async (req, res) => {
    try{
        // Gets bank database
        let db_connect = dbo.getDb();
        // Used to filter out database id and passwords fields
        const options = { projection: {_id:0, password:0}};
        // Queries database and waits for the result and returns it 
        const result = await db_connect.collection("accounts").findOne({_id: new ObjectId(req.session.username)}, options);
        console.log("record was returned");
        res.json(result);
    } catch(err) {
        throw err;
    };
});

// Takes in the users information and creates 
// Returns the newly created json object or sends a response say the email
// is already in use
accountsRoutes.route("/add/account").post(async (req, res) => {
    try{
        // Gets bank database
        let db_connect = dbo.getDb();
        word = "hi";
        // Query the database seeing the email was already used
        const user = await db_connect.collection("accounts").findOne({email: req.body.email});
        // if user is not returned
        if(!user){
                // Creates a json object of a new customer profile
                let newProfile = {
                    email: req.body.email,
                    fristName: req.body.fristName,
                    lastName: req.body.lastName,
                    phoneNumber: req.body.phoneNumber,
                    password: req.body.password,
                    role: "",
                    checking: 0,
                    savings: 0
                };
                // Inserts the new bank profile into database
                const result = await db_connect.collection("accounts").insertOne(newProfile);
                const user = await db_connect.collection("accounts").findOne({email: req.body.email});
                console.log("record was added");
                res.status(200).send(user._id);
            }
            else{
                // if the email is already associated with a different user
                res.status(400).send("That email is already in use.  Please choose a different email");
            }
    } catch(err) {
        throw err;
    }
});

// Checks if entered in information is correct with a user in the database
// Returns a success of failure message accordingly
accountsRoutes.route("/login").post(async (req, res) => {
    // Gets bank database
    let db_connect = dbo.getDb();
    // The response to send back to the user
    let response = false;
    // Checks if the users email is in the database
    const user = await db_connect.collection("accounts").findOne({email: req.body.email});
    // If the user exists
    if(user){
        // Checks if the entered in password is correct
        if(user.password == req.body.password){
            // Updates the response
            console.log("user logged in");
            console.log(word);
            response = true
        } else {
            // Updates the response if the password is incorrect
            console.log("Password is incorrect.  Please try again");
        }
    }
    else{
        // Updates response if the user doesn't exists
        console.log("No user exists with this email.  Please double check and try again");
    }
    // Sends the reponse back to the user
    if (response){
        res.status(200).json(user);
    }
    else{
        res.status(400).json(user);
    }
});

// Updates a users role using there email to one of three options (customer, manager, administrator)
// Returns updated json or sends a failed respnse to the user
accountsRoutes.route("/update/role").post(async (req, res) => {
    // Gets bank database
    let db_connect = dbo.getDb();
    // Gets the user based of email
    const user = await db_connect.collection("accounts").findOne({email: req.body.email});
    // takes the role entered and locases it
    const role = req.body.role.toLowerCase();
    if(user){
        // if user exists makes sure the role is one of the three options
        if(role == "customer" || role == "manager" || role == "administrator"){
            // Starts to build the first part of the query
            const query = {_id: user._id};
            // the option used for setting the role to the passed in role
            let update = {
                $set: {
                    role: role
                },
            };
            // Updates the database and return the new updated json object
            const result = await db_connect.collection("accounts").updateOne(query, update);
            res.json(result);
        }else{
            // if the role thats gets passed in doesn't exists
            res.send("That is not one of the roles you can chose from");
        }
    } else {
        // if the email is not associated with an email in the database
        res.send("No user exists with this email.  Please double check and try again");
    }
});

// Deposite the passed in amount to the passed in account
accountsRoutes.route("/account/deposit").post(async (req, res) => {
    try{
        // Sets up variables to be used
        let db_connect = dbo.getDb();
        const account = req.body.type.toLowerCase();
        let amount = Number(req.body.amount);
        let update;
        // Gets the user based off the email
        console.log(req.session.username);
        const user = await db_connect.collection("accounts").findOne({_id: new ObjectId(req.session.username)});
        // if the user exists in the database
        if(user){
            // Start of the query
            const query = {_id: user._id};
            // Check if the passed in number is in the correct format
            if(Number.isInteger(amount)){
                console.log("we are in deposit")
                // If checkings add the amount to checking finishes building the query
                if(account == "checking"){
                    amount += user.checking;
                    update = {
                        $set: {
                            checking: amount
                        },
                    };
                // If savings add the amount to savings finishes building the query
                } else if(account == "savings"){
                    amount += user.savings;
                    update = {
                        $set: {
                            savings: amount
                        },
                    };
                }
                if(update){
                    // Updates the database and returns the updated json object
                    const result = await db_connect.collection("accounts").updateOne(query, update);
                    res.status(200).json(result);
                }
            } else {
                res.status(400).send("something went wrong with the deposit")
            }
        }else{
            res.status(400).send("No user exists with this email.  Please double check and try again");
        }
    } catch(err) {
        throw err;
    };
});

// Depending on what accounts gets passed in the amount with get withdrawn from that account
// if there is enough fund in the account to do so
accountsRoutes.route("/account/withdraw").post(async (req, res) => {
    try{
        // Sets up variables to be used throughout the post
        let response = "";
        let db_connect = dbo.getDb();
        let statuscode = 400;
        const account = req.body.type.toLowerCase();
        let amount = Number(req.body.amount);
        // Get the user from the database from email
        const user = await db_connect.collection("accounts").findOne({_id: new ObjectId(req.session.username)});
        // if user exists
        if(user){
            // First part of query to updated the user accounts
            const query = {_id: user._id};
            // Check if the number is an integer
            if(Number.isInteger(amount)){
                // If so checks if its checking or savings
                if(account == "checking"){
                    // Makes sure the user has enough money in there account
                    if(user.checking >= amount){
                        // Updates the amount
                        let newAmount = user.checking - amount;
                        // Building the rest of the query
                        let update = {
                            $set: {
                                checking: newAmount
                            },
                    };
                    // Updates the database and the response
                    await db_connect.collection("accounts").updateOne(query, update);
                    response = "Withdrawl completed!";
                    statuscode = 200;
                    }else{
                        // if not enough in checking
                        response = "Withdrawl failed.  Not enough funds in checking";
                        status = 400;
                    }
                } else if(account == "savings"){
                    // if savings checks to see if the user as enough money in there savings
                    if(user.savings >= amount){
                        // Updates the amount
                        let newAmount = user.savings - amount;
                        // Building the rest of the query
                        let update = {
                           $set: {
                               savings: newAmount
                           },
                       };
                        // Updates the database and the response
                       await db_connect.collection("accounts").updateOne(query, update);
                       statuscode = 200;
                       response = "Withdrawl completed!";   
                    }
                    else{
                        // if not enough in savings
                        response = "Withdrawl failed.  Not enough funds in savings";
                        statuscode = 400;
                    }
                }
            }
        }
        else{
            // if the user doesn't exists in the databasee
            response = "No user exists with this email.  Please double check and try again"
        }
        res.status(statuscode).send(response);
    } catch(err) {
        throw err;
    };
});

// Transferes money between a users checking and savings account
accountsRoutes.route("/account/transfer").post(async (req, res) => {
    try{
        // Varibles used in the transfer processes
        const toAccount = req.body.toAccount.toLowerCase();
        const fromAccount = req.body.fromAccount.toLowerCase();
        const amount = req.body.amount;
        let db_connect = dbo.getDb();
        const user = await db_connect.collection("accounts").findOne({email: req.body.email});
        let toUpdated = 0;
        let fromupdated = 0;

        // Variables for the query and to send a response 
        let query;
        let update;
        let response = "The user to does not exists.  Please double check email and try again";
    
        // if the user exists
        if(user){
            // Building the first part of the query
            query = {_id: user._id};
            // Checks if user is transfering money from checkings to savings
            if(fromAccount == "checking" && toAccount == "savings"){
                // Checks to see if checking has enough money
                if(user.checking > amount){
                    // Gets the new totals for the accounts and finishes building the query
                    fromupdated = user.checking - amount;
                    toUpdated = user.savings + amount;
                    update = {
                        $set: {
                            checking: fromupdated,
                            savings: toUpdated
                        },
                    }
                }
                // Checks if user is transfering money from saving to checking
            } else if(fromAccount == "savings" && toAccount == "checking"){
                // Checks to see if the user has enough if savings
                if(user.savings > amount){
                    // Updates the total and finishes building the query
                    fromupdated = user.savings - amount;
                    toUpdated = user.checking + amount;
                    update = {
                        $set: {
                            checking: toUpdated,
                            savings: fromupdated
                        },
                    }
                }
            }
            // if a transfer was made
            if(update){
                // updates database and the response
                await db_connect.collection("accounts").updateOne(query, update);
                response = "The transfer was a success";
            }
            else{
                // if a transfer was not made update respnse
                response = "The transfered failed to lack of funds in from account";
            }
        }
        // sends the response back to the user
        res.send(response);

    } catch(err) {
        throw err;
    };
});

module.exports = accountsRoutes;