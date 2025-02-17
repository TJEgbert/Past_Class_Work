import React from "react";
import { Route, Routes } from "react-router-dom";

// The routes used for the front end 
import Login from "./components/login";
import AccountInfo from "./components/account_info.js";
import AccountsBalances from "./components/accounts_balances.js";
import LoggedOut from "./components/log_out.js";
import NewAccount from "./components/new_account.js";


const App = () => {
  return (
    <div>
        <Routes>
            <Route path="/" element={<NewAccount />} />
            <Route path="/login" element={<Login />} />
            <Route path="/account_info" element={<AccountInfo />} />
            <Route path="/accounts_balances" element={<AccountsBalances />} />
            <Route path="/log_out" element={<LoggedOut />} />
        </Routes>
    </div>
  );
}

export default App;
