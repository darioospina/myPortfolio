// Project Name: Coworking Registry
// Author: Dario Ospina

////////////////////////////////////////////////////////////
/////////////////// SET UP
////////////////////////////////////////////////////////////

var express = require("express");
var path = require("path");
var sqlite3 = require("sqlite3").verbose();

var app = express();
app.use(express.static(__dirname));
app.use(express.urlencoded({ extended: false }));
app.use(express.json());
var port = 3000;

app.listen(port, () => {
  console.log("The server is listening on port ", port);
});

// opening index.html when localhost is opened
app.get('/', function (req, res) {
    res.sendFile(path.join(__dirname, './index.html'));
  });

// Opening the DB 
let db = new sqlite3.Database('./coworking.db', sqlite3.OPEN_READWRITE,(err) => {
    if(err){
        return console.error(err.message);
    }
    console.log("Connected to the Coworking database");
});

//module.exports.app = app
//module.exports.db = db

////////////////////////////////////////////////////////////
/////////////////// OWNER INTERFACE
////////////////////////////////////////////////////////////

// Creating a new user
app.post("/users/add", (req, res) => {
    newUser = {
        name: req.body.UserName, 
        password: req.body.Password, 
        email: req.body.Email, 
        cellphone: req.body.Cellphone
    }
    db.run("INSERT INTO User(UserName,Password,Email,Cellphone) VALUES(?,?,?,?)", [newUser.name, newUser.password, newUser.email, newUser.cellphone], (err) => {
        if(err) {
            console.error(err)
        } else {
            console.log("User added to the DB")
            res.redirect('/')
        }
    })
})

// Getting the list of all users --> Not encrypted for testing purposes
app.get("/users", (req, res) => {
    db.all("SELECT * FROM User", function(err,rows) {
        if(err) {
            res.status(200).json({error: err.message})
            return
        }
        res.json(rows)
    })
})

// Checking if the login credentials exist
app.get("/users/:UserName/:Password", (req,res) => {
    let sql = "SELECT * FROM User WHERE UserName = ? AND Password = ?"
    let username = req.params.UserName
    let password = req.params.Password
    db.get(sql, username, password, (err,row) => {
        if(err){
            res.status(400).json({"error":err.message});
            return;
        }
         res.json({"data": row})
    })
})

// Getting the list of properties from UserName
app.get("/properties/:UserName", (req, res) => {
    let sql = "SELECT * FROM Properties JOIN User ON Properties.UserID = User.UserID WHERE UserName = ?"
    let username = req.params.UserName    
    db.all(sql,username,(err,row) => {
        if(err){
            res.status(400).json({"error":err.message});
            return;
        }
         res.json({"data": row})        
    })
}) 

// Getting the list of properties from UserID
app.get("/properties/userid/:UserID", (req, res) => {
    let sql = "SELECT * FROM Properties WHERE UserID = ?"
    let userid = req.params.UserID    
    db.all(sql,userid,(err,row) => {
        if(err){
            res.status(400).json({"error":err.message});
            return;
        }
         res.json({"data": row})        
    })
}) 

// Getting the list of properties from UserID and PropertyID
app.get("/properties/:UserID/:PropertyID", (req, res) => {
    let sql = "SELECT * FROM Properties WHERE UserID = ? AND PropertyID = ?"
    let data = {
        userid: req.params.UserID,
        propertyid:req.params.PropertyID
    }
    db.get(sql,[data.userid,data.propertyid],(err,row) => {
        if(err){
            res.status(400).json({"error":err.message});
            return;
        }
         res.json({"data": row})  
    })
})

// Adding a new property
app.post("/properties/add", (req, res) => {
    newProperty = {
        userid: req.body.UserID,
        propname: req.body.PropName,
        address: req.body.Address,
        type: req.body.Type,
        amenities: req.body.Amenities,
        price: req.body.Price,
        status: req.body.Status,
        ratingid: req.body.RatingID,
        latitude: req.body.Latitude,
        longitude: req.body.Longitude,
        pic1: req.body.Pic1,
        pic2: req.body.Pic2,
        pic3: req.body.Pic3,
        description: req.body.Description
    }
    db.run("INSERT INTO Properties(UserID,PropName,Address,Type,Amenities,Price,Status,RatingID,Latitude,Longitude,Pic1,Pic2,Pic3,Description) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?)",
    [newProperty.userid, newProperty.propname, newProperty.address, newProperty.type, newProperty.amenities, newProperty.price, newProperty.status, newProperty.ratingid, newProperty.latitude, newProperty.longitude,newProperty.pic1, newProperty.pic2, newProperty.pic3, newProperty.description], (err) => {
        if(err) {
            console.error(err)
        } else {
            console.log("Property added to the DB")
        }
    })
})

// Deleting a property
app.delete("/properties/delete/:PropertyID", (req,res) => {
    let sql = "DELETE FROM Properties WHERE PropertyID = ?"
    let propertyid = req.params.PropertyID
    db.run(sql,propertyid,(err,row) => {
        if(err){
            return console.error(err.message);
        }
        res.json({"message":"success",
        "data": row});     
    })    
}) 

// Update a property
app.patch("/properties/update/:PropertyID"), (req,res) => {
    let sql = "UPDATE Properties SET PropName = ?,Address = ?,Type = ?,Amenities = ?,Price = ?,Status = ?,RatingID = ?,Latitude = ?,Longitude = ?,Pic1 = ?,Pic2 = ?,Pic3 = ?,Description = ? WHERE PropertyID = ?"
    data = {
        propname: req.body.PropName,
        address: req.body.Address,
        type: req.body.Type,
        amenities: req.body.Amenities,
        price: req.body.Price,
        status: req.body.Status,
        ratingid: req.body.RatingID,
        latitude: req.body.Latitude,
        longitude: req.body.Longitude,
        pic1: req.body.Pic1,
        pic2: req.body.Pic2,
        pic3: req.body.Pic3,
        description: req.body.Description,
        propertyid: req.params.PropertyID
    }
    db.run(sql,[data.propname,data.address,data.type,data.amenities,data.price,data.status,data.ratingid,data.latitude,data.longitude,data.pic1,data.pic2,data.pic3,data.description,data.propertyid],(err,row) => {
        if(err) {
            console.error(err)
        } else {
            res.json({"message":"success",
            "data": row});   
        }
    })
}

////////////////////////////////////////////////////////////
/////////////////// PROPERTIES INTERFACE
////////////////////////////////////////////////////////////

// Getting the list of all properties
app.get("/properties", (req, res) => {
    db.all("SELECT * FROM Properties WHERE Status = 'Not rented'", (err,rows) => {
        if(err) {
            res.status(200).json({error: err.message})
            return
        }
        res.json(rows)
    })
})

// Getting the list of all properties ordered by price or rating in ascending or descending order
app.get("/properties_orderby_PriceAsc", (req, res) => {
    db.all("SELECT * FROM Properties WHERE Status = 'Not rented' ORDER BY Price ASC", (err,rows) => {
        if(err) {
            res.status(200).json({error: err.message})
            return
        }
        res.json(rows)
    })
})

app.get("/properties_orderby_PriceDesc", (req, res) => {
    db.all("SELECT * FROM Properties WHERE Status = 'Not rented' ORDER BY Price DESC", req.params.criteria, (err,rows) => {
        if(err) {
            res.status(200).json({error: err.message})
            return
        }
        res.json(rows)
    })
})

app.get("/properties_orderby_RatingAsc", (req, res) => {
    db.all("SELECT * FROM Properties WHERE Status = 'Not rented' ORDER BY RatingID ASC", (err,rows) => {
        if(err) {
            res.status(200).json({error: err.message})
            return
        }
        res.json(rows)
    })
})

app.get("/properties_orderby_RatingDesc", (req, res) => {
    db.all("SELECT * FROM Properties WHERE Status = 'Not rented' ORDER BY RatingID DESC", (err,rows) => {
        if(err) {
            res.status(200).json({error: err.message})
            return
        }
        res.json(rows)
    })
})

// Getting the list of all properties applying filters
app.get("/properties/filters/:Amenities/:Type/:PriceFrom/:PriceTo/:Status", (req, res) => {
    let sql = "SELECT * FROM Properties WHERE Amenities = ? AND Type = ? AND (Price BETWEEN ? AND ?) AND Status = ?"
    let data = {
        amenities: req.params.Amenities,
        type: req.params.Type,
        price_from: req.params.PriceFrom,
        price_to: req.params.PriceTo,
        status: req.params.Status
    }
    db.all(sql,[data.amenities,data.type,data.price_from,data.price_to,data.status],(err,row) => {
        if(err){
            res.status(400).json({"error":err.message});
            return;
        }
         res.json({"data": row})  
    })
})
