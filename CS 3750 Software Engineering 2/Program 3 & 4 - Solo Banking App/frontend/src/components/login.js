import React, { useState } from "react";
import { useNavigate } from "react-router";

export default function Login () {
    // Used to store the user login information
    const [form, setForm] = useState("");

    // Used to navigate to a new page
    const navigate = useNavigate();

    // Used to update the Json object from the form
    function updateForm(jsonObj){
        return setForm((prevJsonObj) => {
            return {...prevJsonObj, ...jsonObj};
        });
    }

    // After the user clicks the submit button
    // Checks with the backend to make the user 
    // exists and verifies there login
    async function onSubmit(e) {
        let response;
        e.preventDefault();

        // Json object for the login information
        const loginInfo = {
            email: form.email,
            password: form.password
        };
        // sends a request to the backend to login the usr
        response = await fetch(`http://localhost:4000/login`, {
            method: "POST",
            headers: {
                "Content-Type" : "application/json",
            },
            body: JSON.stringify(loginInfo),
        })
        .catch(error => {
            // If the request has an issue
            window.alert(error);
            return;
        });
        // If the user was successfully logged in
        if(response.status === 200){
            // Store the user information 
            const user = await response.json();
            console.log(user._id);
            // Calls the backend to create a session for the user
            await fetch(`http://localhost:4000/session_set/${user._id}`,
                {
                    method: "GET",
                    credentials: "include"  
                }
            )
            // once the request is done takes the user to account info page
            navigate("/account_info")
        } else {
            // If the user was information was incorrect
            window.alert("User name or password is incorrect please try again");
        }
       
    }

    // The HTML with the functionality to run the page
    return (
        <div>
        <h3>Login</h3>
        <form onSubmit={onSubmit}>
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
                    value="Login"
                />
            </div>
        </form>
    </div>
    );
        
    
}