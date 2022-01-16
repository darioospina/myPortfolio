const { response } = require("express");
var express = require("express");
const res = require("express/lib/response");
const { request } = require("http");

var app = express();

app.use(express.static(__dirname));
app.use(express.json());
app.use(express.urlencoded({extended: false}));

var messages = [
];

app.get("/messages", (request, response) => {
    response.send(messages);
})

app.post("/messages", (request, response) => {
    messages.push(request.body);
    response.sendStatus(200);
})

var server = app.listen(3000, () => {
    console.log("My server is listening on port ", server.address().port);
});


