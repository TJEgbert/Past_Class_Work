import React, { useEffect, useState } from "react";

export default function LogOut () {
    // Used to store the status
    const [status, setStatus] = useState("");

    useEffect(()=> {
        async function run() {
            // Make a request to the backend to logout the user
            const response = await fetch(`http://localhost:4000/session_delete`,
                {
                    method: "GET",
                    credentials: "include"  
                }
            );
            if(!response.ok){
                // the request fails informs the user
                const message = `An error occurred: ${response.statusText}`;
                window.alert(message);
                return;
            }
            const statusResponse = await response.json();
            setStatus(statusResponse.status);
        }
        run();
        return;
    }, []);


    return (
        <div>
            <h3>Logged out</h3>
            <p>You have successfully been logged out</p>
        </div>
    );
}