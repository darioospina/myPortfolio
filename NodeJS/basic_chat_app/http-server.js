//load the 'http' module that let us make outgoing HTTP requests and listen for incoming HTTP requests.

var Http = require("http");

// Make up a fancy web page to serve back to clients
var SomeHtml = "<!doctype html><html><head><title>Super World</title></head><body><h1 style='color: red'>Super World?</h1></body></html>";

// Create a server

var Server = Http.createServer(function(Request, Response){
    Response.writeHead(200, {'content-length': SomeHtml.length, 'content-type': 'text/html'});
    Response.write("msg");
    Response.write("This");
    Response.end(SomeHtml);
});

// Start listening for HTTP requests
Server.listen(3050);
console.log("Your Node.js web server is listening on port 3050, use localhost:3050 to see the result");
