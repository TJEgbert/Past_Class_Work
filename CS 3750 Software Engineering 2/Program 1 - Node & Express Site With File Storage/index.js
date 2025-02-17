const express = require("express");
const router = require("./routes/user");

const app = express();
const port = 3000;

app.use("/user_routes", router);

app.get("/", (req, res) =>{
    res.send("Please type in any of the following url<br>" +
        "localhost:3000/form.html<br>" +
        "localhost:3000/user_routes/displaydata<br>" +
        "localhost:3000/foodSearch.html"
    );
});


app.use(express.static("public"));


app.listen(port, () =>{
    console.log("Server started on port " + port);
});