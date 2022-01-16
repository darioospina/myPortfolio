// Project Name: Coworking Registry(Milestone 2)
// Course Code: SODV1201
// Class: Software Development Diploma Program
// Author: Dario, Candace & Palak 


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

// Creating Database
let db = new sqlite3.Database('workDart.db', (err) => {
  if (err) {
    return console.error(err.message);
  } else {
    console.log("database created successfully");
    console.log("Table Created!");
    // Creating Property Table
    db.run("CREATE TABLE IF NOT EXISTS Property(propertyID INTEGER PRIMARY KEY, name TEXT, address TEXT, lat TEXT, lng TEXT, neighborhood TEXT, type_coworking TEXT, price MONEY, status TEXT, rating INTEGER, description TEXT, wifi INTEGER, printer INTEGER, fax INTEGER, showers INTEGER, bike INTEGER, meeting INTEGER,projector INTEGER)");
    db.run("CREATE TABLE IF NOT EXISTS User(username TEXT PRIMARY KEY, Firstname TEXT, Lastname TEXT, Address TEXT, Phone TEXT, email TEXT)");
  }
})

// Opening the DB 
db = new sqlite3.Database('./workDart.db', sqlite3.OPEN_READWRITE,(err) => {
  if(err){
      return console.error(err.message);
  }
  console.log("Connected to WorkDart database");
});

// Getting the information from the DB
db.serialize(() => {
  db.each(`SELECT name,address,lat,lng,neighborhood,type_coworking,price,status,rating,description,wifi,printer,fax,showers,bike,meeting,projector FROM Property`, (err, row) => {
    
    if(err){
          console.error(err.message);
      }
      console.log(row.name + "\t" + row.address + "\t" + row.lat + "\t" + row.lng + "\t" + row.neighborhood + "\t" + row.type_coworking + "\t" + row.price +"\t" + row.status +"\t" + row.rating +"\t" + row.description +"\t" + row.wifi + "\t" +row.printer + "\t" +row.fax + "\t" +row.showers +"\t" + row.bike + "\t" +row.meeting + "\t" +row.projector);

    })
  })



 

var propFields = ["propertyID","name","address","lat","lng","neighborhood","type_coworking","price","status","rating","description","wifi","printer","fax","showers","bike","meeting","projector"];
// var userFields = ["userID","Firstname","Lastname","Address","Phone","email"];

app.get('/properties', function(req, res){ 
    db.all("SELECT " + propFields.join(", ") + " FROM Property", function(err, rows) {
        if (err) {
            res.status(200).json({error :err.message});
            return;
          }
        res.json(rows); 
    });  

});

app.get('/properties/:id', function(req,res){
  const PropID = req.params.id;
  db.get("SELECT * FROM Property WHERE propertyID = ?", PropID, (err, row) => {
      if(err){
          res.status(400).json({"error":err.message});
          return;
      }
      res.json({"data": row})
  })
})

// info in /user 
app.get('/user', function(req, res){ 

  db.all("SELECT  * FROM User", function(err, rows) {
      if (err) {
          res.status(200).json({error :err.message});
          return;
        }
      res.json(rows); 
  });  
});

//update user page
app.post("/user/update", (req,res)=>{
  var profile={
    username: req.body.Username,
    fname:req.body.Firstname,
    lname:req.body.Lastname,
    address:req.body.Address,
    phone:req.body.Phone,
    email:req.body.email
  }
  db.run("UPDATE User SET Firstname=?, Lastname=?, Address=?,Phone=?,email=? WHERE username=?",[profile.fname,profile.lname,profile.address,profile.phone,profile.email,profile.username], (err)=>{
    if(err)
    {
      console.log(err);
    }else{
      console.log("User update successful");
    }
  })
  res.redirect("/profile_owner.html")
})

app.get('/properties/:id', function(req,res){
  const userID = req.params.id;
  db.get("SELECT * FROM USER WHERE userID = ?", userID, (err, row) => {
      if(err){
          res.status(400).json({"error":err.message});
          return;
      }
      res.json({"data": row})
  })
})

//uploading a new property
app.post("/properties/add", (req, res) => {
  //retrieving form values
  newProperty = {
    name: req.body.propertyName,
    neighborhood: req.body.neighborhood,
    address: req.body.address,
    lat: req.body.lat,
    lng: req.body.lng,
    wifi: (req.body.wifi == undefined) ? 0 : 1,
    printer: (req.body.printer == undefined) ? 0 : 1,
    fax: (req.body.fax == undefined) ? 0 : 1,
    showers: (req.body.showers == undefined) ? 0 : 1,
    bike: (req.body.bike == undefined) ? 0 : 1,
    meeting: (req.body.meeting == undefined) ? 0 : 1,
    projector: (req.body.projector == undefined) ? 0 : 1,
    type_coworking: req.body.spaceType,
    price: req.body.price,
    rating: req.body.rating,
    description: req.body.description,
    status: req.body.availibility
  }

  console.log(newProperty)
  // updating property table
  db.run("INSERT INTO Property(name, address, lat, lng, neighborhood, type_coworking, price, status, description,rating,wifi,printer,fax,showers,bike,meeting,projector) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)", [newProperty.name, newProperty.address, newProperty.lat, newProperty.lng, newProperty.neighborhood, newProperty.type_coworking, newProperty.price, newProperty.status, newProperty.description, newProperty.rating, newProperty.wifi, newProperty.printer, newProperty.fax, newProperty.showers, newProperty.bike, newProperty.meeting, newProperty.projector], (err) => {
    if(err)
    {
      console.log(err.message);
    }
    else
    {
      console.log("Property added successfully to the database");
    }
    res.redirect("/");
  });
});

//Editing a Property

app.post("/properties/update", (req, res) => {
  //retrieving form values
  newProperty = {
    name: req.body.propertyName,
    neighborhood: req.body.neighborhood,
    address: req.body.address,
    lat: req.body.lat,
    lng: req.body.lng,
    wifi: (req.body.wifi == undefined) ? 0 : 1,
    printer: (req.body.printer == undefined) ? 0 : 1,
    fax: (req.body.fax == undefined) ? 0 : 1,
    showers: (req.body.showers == undefined) ? 0 : 1,
    bike: (req.body.bike == undefined) ? 0 : 1,
    meeting: (req.body.meeting == undefined) ? 0 : 1,
    projector: (req.body.projector == undefined) ? 0 : 1,
    type_coworking: req.body.spaceType,
    price: req.body.price,
    rating: req.body.rating,
    description: req.body.description,
    status: req.body.availibility
  }

  console.log(newProperty)
  // Editing and Updating the property table
  db.run("UPDATE Property SET name=?, address=?, lat=?, lng=?, neighborhood=?, type_coworking=?, price=?, status=?, description=?,rating=?,wifi=?,printer=?,fax=?,showers=?,bike=?,meeting=?,projector=? WHERE name =?" , [newProperty.name, newProperty.address, newProperty.lat, newProperty.lng, newProperty.neighborhood, newProperty.type_coworking, newProperty.price, newProperty.status, newProperty.description, newProperty.rating, newProperty.wifi, newProperty.printer, newProperty.fax, newProperty.showers, newProperty.bike, newProperty.meeting, newProperty.projector,newProperty.name], (err) => {
    if(err)
    {
      console.log(err.message);
    }
    else
    {
      console.log("Property edited successfully to the database");
    }
    res.redirect("/");
  });
});



//Delete Property
app.delete('/properties/del/:id', function(req,res){
  const PropID_del = req.body.propertyID;
  db.run(`DELETE FROM Property WHERE propertyID = ?`, PropID_del, (err, row) => {
      if(err){
          return console.error(err.message);
      }
      res.json({"message":"success",
      "data": row});
  })
})
