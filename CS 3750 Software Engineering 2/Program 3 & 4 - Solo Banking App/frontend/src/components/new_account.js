import React, { useState } from "react";
import { useNavigate } from "react-router";


export default function NewAccount () {
    // Used to move to another page
    const navigate = useNavigate();

    // a Json object to store a new account
    const [form, setForm] = useState({
        fristName: "",
        lastName: "",
        email: "",
        phoneNumber: "",
        password: ""
    });

    // Updates the Json object
    function updateForm(jsonObj){
        return setForm((prevJsonObj) => {
            return {...prevJsonObj, ...jsonObj};
        });
    }
    
    //  Gets called once the submit button is clicked
    // Send the data to the backend to save the new object
    // If the email entered is already in the use it will let the user know
    async function onSubmit(e) {
        e.preventDefault();
        // Creates the object to send to the backend
        const newPerson = {...form};

        // Creates a request to the backend to add the new user
        const response = await fetch("http://localhost:4000/add/account", {
            method: "POST",
            credentials: "include",  
            headers: {
                "Content-Type": "application/json",
            },
            body: JSON.stringify(newPerson),
        })
        .catch(error => {
            // Lets the user know if something went wrong with the request
            window.alert(error);
            return;
        });
        // If the status returns ok status
        if(response.ok){
            // Sends a request to set the new users session
            const userId = await response.json();
            await fetch(`http://localhost:4000/session_set/${userId}`,
                {
                    method: "GET",
                    credentials: "include"  
                }
            )
            // Takes the user to the account_info page
            navigate("/account_info");
        } else {
            // Notifies the user that the email is already taken
            window.alert("That email has already been used.  Please enput a different email")
        }
    }
    // HTML for the page and functionality it needs to work
    return (
        <div>
            <h3>Create Account</h3>
            <form onSubmit={onSubmit}>
                <div>
                    <label>First Name: </label>
                    <input
                        type="text"
                        id="fristName"
                        value={form.fristName}
                        onChange={(e) => updateForm({ fristName: e.target.value})}
                    />
                </div>
                <div>
                    <label>Last Name: </label>
                    <input
                        type="text"
                        id="lastName"
                        value={form.lastName}
                        onChange={(e) => updateForm({ lastName: e.target.value})}
                    />
                </div>
                <div>
                    <label>Email: </label>
                    <input
                        type="text"
                        id="email"
                        value={form.email}
                        onChange={(e) => updateForm({ email: e.target.value})}
                    />
                </div>

                <div>
                    <label>Phone Number: </label>
                    <input
                        type="text"
                        id="phoneNumber"
                        value={form.phoneNumber}
                        onChange={(e) => updateForm({ phoneNumber: e.target.value})}
                    />
                </div>

                <div>
                    <label>Password: </label>
                    <input
                        type="text"
                        id="password"
                        value={form.password}
                        onChange={(e) => updateForm({ password: e.target.value})}
                    />
                </div>
                <br/>
                <div>
                    <input
                        type="submit"
                        value="Create Account"
                    />
                </div>
            </form>
        </div>
    );
}