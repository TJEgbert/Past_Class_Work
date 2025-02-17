import React, { useEffect, useState } from "react";
import { useParams, useNavigate } from "react-router";


export default function AccountInfo () {
    // Variables used to store the user information from the backend
    const [firstName, setFirstName] = useState();
    const [lastName, setLastName] = useState();
    const [email, setEmail] = useState();
    const [phoneNumber, setPhoneNumber] = useState();

    // Used to navigate to a new page
    const navigate = useNavigate();

    useEffect(() => {
        // Checks if the user is logged in
        async function getUser() {
            const loggedIn = await fetch("http://localhost:4000/session_get",
                {
                    method: "GET",
                    credentials: "include"
                }
            );
            if(!loggedIn.ok){
                // If not signed in the user gets sent to the login page
                navigate("/login");

            } else {
                // If the user is logged in
                // A request is sent to the backend to get the user information
                const response = await fetch("http://localhost:4000/account/lookup",
                    {
                        method: "POST",
                        credentials: "include"
                    }
                );
                if(!response.ok){
                    // If the request does not complete lets the user knows why
                    const message = `Error accord while loading user information ${response.statusText}`;
                    window.alert(message);
                    return;
                }
                // if we succesfully sets the variables to update the HTML page
                const responseUser = await response.json();
                console.log(responseUser);
                setEmail(responseUser.email);
                setFirstName(responseUser.fristName);
                setLastName(responseUser.lastName);
                setPhoneNumber(responseUser.phoneNumber);
            }
        }
        getUser();
        
        return;
    },[]); 

    // HTML page
    return (
        <div>
            <h3>Account Information</h3>
            <ul>
                <li>First Name: {firstName}</li>
                <li>Last Name: {lastName}</li>
                <li>email: {email}</li>
                <li>Phone Number: {phoneNumber}</li>
            </ul>
        </div>
    );
}