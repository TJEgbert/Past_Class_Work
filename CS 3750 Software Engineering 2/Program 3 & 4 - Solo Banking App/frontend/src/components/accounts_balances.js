import React, { useEffect, useState } from "react";
import { useParams, useNavigate } from "react-router";


export default function AccountInfo () {
    // used to navigate to a new page
    const navigate = useNavigate();

    // Used to store the amount from checking account
    const [checking, setChecking] = useState();
    // Used to store the amount from savings account
    const [savings, setSavings] = useState();
    // Json object to store the required information the deposit request
    const [depositForm, setDepositForm] = useState({
        amount: "",
        type: "",

    });
    // Json object to store the required information the withdraw request
    const [withdrawForm, setWithdrawForm] = useState({
        amount: "",
        type: "",

    });

    useEffect(() => {
        // Makes sure the user is logged in
        async function getUser() {
            const loggedIn = await fetch("http://localhost:4000/session_get",
                {
                    method: "GET",
                    credentials: "include"
                }
            );
            if(!loggedIn.ok){
                // if not redirects them to the login page
                navigate("/login");

            } else {
                // if logged in retrieves the account information
                const response = await fetch("http://localhost:4000/account/lookup",
                    {
                        method: "POST",
                        credentials: "include"
                    }
                );
                if(!response.ok){
                    // sends the user an error message if something went wrong
                    const message = `Error accord while loading user information ${response.statusText}`;
                    window.alert(message);
                    return;
                }
                // Updates the checking and savings fields based on the data from the backend
                const responseUser = await response.json();
                console.log(responseUser);
                setChecking(responseUser.checking);
                setSavings(responseUser.savings);
            }
        }
        getUser();
        
        return;
    },[]); 

    // updates the Json object for the depositForm
    function updateDepositForm(jsonObj){
        return setDepositForm((prevJsonObj) => {
            return {...prevJsonObj, ...jsonObj};
        });
    }
    // updates the Json object for the widthrawForm
    function updateWithdrawForm(jsonObj){
        return setWithdrawForm((prevJsonObj) => {
            return {...prevJsonObj, ...jsonObj};
        });
    }

    // Deposites the amount entered in to the account the user chose
    // Notifies the user if succesful or not
    async function onDeposit(e) {
        e.preventDefault();
        // Creates the JSON object to send in the request
        const depositInfo = {...depositForm};
        console.log(depositForm)
        
        // Send a request to the bank to update the account
        const response = await fetch("http://localhost:4000/account/deposit", {
            method: "POST",
            credentials: "include",
            headers: {
                "Content-Type" : "application/json",
            },
            body: JSON.stringify(depositForm),
        })
        .catch(error => {
            // Lets the user know if there's an error
            window.alert(error);
            return;
        });
        if(response.ok){
            // if the request was successful lets the user send the user to the account_info page
            window.alert("Deposit was succesfull")
            navigate("/account_info");
        } else {
            // If the request fails
            window.alert("Deposit failed");
        }
    }

    // Attemps the withdraw the passed in amount to the given account
    async function onWithdraw(e) {
        e.preventDefault();
        // Creates the JSON object to send in the request
        const depositInfo = {...withdrawForm};
        console.log(withdrawForm)
        // Send a request to the bank to update the account
        const response = await fetch("http://localhost:4000/account/withdraw", {
            method: "POST",
            credentials: "include",
            headers: {
                "Content-Type" : "application/json",
            },
            body: JSON.stringify(withdrawForm),
        })
        .catch(error => {
             // Lets the user know if there's an error
            window.alert(error);
            return;
        });
        if(response.ok){
            // if the withdraw was succesfull lets the user know and
            // Sends the user to to the account_info page
            window.alert("Withdraw was succesfull")
            navigate("/account_info");
        } else {
            // If the request fails
            window.alert("Withdraw failed");
        }
    }

    // The HTML with the functionality to run the page
    return (
        <div>
            <h3>Current Balances</h3>
            <ul>
                <li>Checking: {checking}</li>
                <li>Savings: {savings}</li>
            </ul>
            <div>
                <form onSubmit={onDeposit}>
                    <h4>Deposite</h4>
                    <label>Amount </label>
                    <input
                        type="number"
                        id="amount"
                        name="deposit"
                        value={depositForm.amount}
                        onChange={(e) => updateDepositForm({ amount: e.target.value})}
                    />
                    <div>
                    <input 
                        type="radio" 
                        id="checking" 
                        value= "checking" 
                        name="deposit"
                        onChange={(e) => updateDepositForm({type : e.target.value})}
                    />
                    <lable for="checking">Checking</lable><br/>
                    <input 
                        type="radio" 
                        id="savings" 
                        value= "savings" 
                        name="deposit"
                        onChange={(e) => updateDepositForm({type : e.target.value})}
                    />
                    <lable for="checking">Savings</lable><br/>
                    </div>
                    <div>
                        <input
                            type="submit"
                            value="Deposit" 
                        />
                    </div>
                </form>
            </div>

            <div>
                <form onSubmit={onWithdraw}>
                    <h4>Withdraw</h4>
                    <label>Amount </label>
                    <input
                        type="text"
                        name="number"
                        id="withdraw_amount"
                        value={withdrawForm.amount}
                        onChange={(e) => updateWithdrawForm({ amount: e.target.value})}
                    />
                    <div>
                    <input 
                        type="radio" 
                        id="withdraw_checking" 
                        value= "checking" 
                        name="deposit"
                        onChange={(e) => updateWithdrawForm({type : e.target.value})}
                    />
                    <lable for="checking">Checking</lable><br/>
                    <input 
                        type="radio" 
                        id="withdraw_savings" 
                        value= "savings" 
                        name="deposit"
                        onChange={(e) => updateWithdrawForm({type : e.target.value})}
                    />
                    <lable for="withdraw">Savings</lable><br/>
                    </div>
                    <div>
                        <input
                            type="submit"
                            value="Withdraw" 
                        />
                    </div>
                </form>
            </div>

        </div>
    );
}