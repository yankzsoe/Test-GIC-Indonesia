var express = require('express');
var app = express();
var port = process.env.PORT || 5000;

var bodyParser = require('body-parser');
app.use(bodyParser.urlencoded({ extended: true }));
app.use(bodyParser.json());

var contactController = require('./Controller/ContactController')();
app.use("/api/contacts", contactController);

app.listen(port, function () {
    var datetime = new Date();
    var message = "Server running on port: " + port + ". Stareted at: " + datetime;
    console.log(message);
});