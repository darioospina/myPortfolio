// Project Name: Coworking Registry(Milestone 2)
// Course Code: SODV1201
// Class: Software Development Diploma Program
// Author: Dario, Candace & Palak 



/*Script for the index page*/
let currentPropertyIndex = 0;

// Displays the information of the DB
function displayElements() {
  $.get("http://localhost:3000/properties", function (data) {
    console.log(data);
    $("#property_name").html(data[currentPropertyIndex].name)
    $("#address").html(data[currentPropertyIndex].address);
    $("#coworking_type").html(data[currentPropertyIndex].type_coworking);
    $("#neighborhood").html(data[currentPropertyIndex].neighborhood);
    $("#lat").html(data[currentPropertyIndex].lat);
    $("#lng").html(data[currentPropertyIndex].lng);
    $("#coworking_type").html(data[currentPropertyIndex].coworking_type);
    //$("#amenities").html(removeAmenities(), displayAmenities(data[currentPropertyIndex].description));
    $("amenities").html(removeAmenities(), displayAmenities(currentPropertyIndex))
    $("#price").html(data[currentPropertyIndex].price);
    $("#status").html(data[currentPropertyIndex].status);
    $("#rating").html(removeRating(), displayRating(data[currentPropertyIndex].rating));
    $("#property_description").html(data[currentPropertyIndex].description);
  })
}
displayElements();

// Change property info when click on next button
onNext = () => {
  removeData();
  $.get("http://localhost:3000/properties", (data) => {
    currentPropertyIndex = (currentPropertyIndex + 1) % data.length;
  })
  displayElements();
  InitMap();
}

// Change property info when click on previous button
onPrevious = () => {
  removeData();
  $.get("http://localhost:3000/properties", (data) => {
    currentPropertyIndex = (currentPropertyIndex - 1) % data.length;
    if (currentPropertyIndex == -1) {
      currentPropertyIndex = data.length - 1;
    }
  })
  displayElements();
  InitMap()
}

// Remove current data to display a new property
removeData = () => {
  $("#property_name").empty();
}

// Delete a property from the list
function deleteProp(row) {
  $.get("http://localhost:3000/properties", function (data) {
    id = data[currentPropertyIndex].propertyID
    alert("Property " + data[currentPropertyIndex].name + " successfully deleted");
    return fetch('http://localhost:3000/properties/del/' + id, {
      method: 'DELETE',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify({ propertyID: id })
    })
      .then((response) => {
        response.json().then((response) => {
          console.log(response);
          location.reload();
        })
      })
      .catch(err => {
        console.error(err)
      })
  })
}

// Displays the amenities on a list appended to the corresponding property
displayAmenities = (currentPropertyIndex) => {
  $.get("http://localhost:3000/properties", function (data) {
    let $amenities = $("#amenities");
    let x = $amenities.append("");
    if (data[currentPropertyIndex].wifi === 1) {
      x += $amenities.append("<li>" + "Wifi" + "</li>");
    }
    if (data[currentPropertyIndex].printer === 1) {
      x += $amenities.append("<li>" + "Printer" + "</li>");
    }
    if (data[currentPropertyIndex].fax === 1) {
      x += $amenities.append("<li>" + "Fax" + "</li>");
    }
    if (data[currentPropertyIndex].showers === 1) {
      x += $amenities.append("<li>" + "Showers" + "</li>");
    }
    if (data[currentPropertyIndex].bike === 1) {
      x += $amenities.append("<li>" + "Bike" + "</li>");
    }
    if (data[currentPropertyIndex].meeting === 1) {
      x += $amenities.append("<li>" + "Meeting" + "</li>");
    }
    if (data[currentPropertyIndex].projector === 1) {
      x += $amenities.append("<li>" + "Projector" + "</li>");
    }
  })
}

// Displays the rating using stars
displayRating = (PropertyIndex) => {
  let $rating = $("#rating");
  for (let i = 0; i < PropertyIndex; i++) {
    $rating.prepend($('<img>', { id: 'stars', src: 'images/star.png' }));
  }
}

// Removes the existing amendities to append the new ones when click on next/previous
removeAmenities = () => {
  $("#amenities").empty();
}

// Removes the stars to append the new ones when click on next/previous
removeRating = () => {
  $("#rating").empty();
}

// Displays the Google Map associated to the corresponding property
function InitMap() {
  let Latitude = $('#lat').text();
  let Longitude = $('#lng').text();
  let LatLng = new google.maps.LatLng(Latitude, Longitude);
  let Map = new google.maps.Map(document.getElementById('map'), { zoom: 18, center: LatLng });
  let Marker = new google.maps.Marker({ position: LatLng, map: Map });
}
//reload the page method
/*UPLOAD AND EDIT PAGE*/

// Resets the form when reset button is clicked
resetWindow = () => {
  location.reload();
}

// declaring variables
var Name, neighborhood, address, lat, lng, wifi, printer, fax, showers, bike, meeting, projector, space, price, availibility, rating, description;
// gets user input when upload button is clicked
getPropertyInput = () => {
  Name = $("#pName").val();
  neighborhood = $("#pNeighborhood").val();
  address = $("#pAddress").val();
  lat = $("#pLat").val();
  lng = $("#pLng").val();
  wifi = $("#wifi").is(":checked") ? 1 : 0;
  printer = $("#printer").is(":checked") ? 1 : 0;
  fax = $("#fax").is(":checked") ? 1 : 0;
  showers = $("#showers").is(":checked") ? 1 : 0;
  bike = $("#bike").is(":checked") ? 1 : 0;
  meeting = $("#meeting").is(":checked") ? 1 : 0;
  projector = $("#projector").is(":checked") ? 1 : 0;
  space = $("input[name='spaceType']:checked").val();
  price = $("#price").val();
  availibility = $("input[name='availibility']:checked").val();
  rating = $("#rating").val();
  description = $("#description").val();
}

arrayList = () => {
  //displays the property names in a dropdown on the edit property page 
  //the owner can choose the property to edit

  var selectString = "";
  var select = $(".select");
  $.get("http://localhost:3000/properties", function (data) {
    for (var i = 0; i < data.length; i++) {
      selectString = "<option value='" + data[i].propertyID + "'>" + data[i].name + "</option>";
      console.log(selectString);
      select.append(selectString);
    }
  });
}

displayFormValues = () => {
  //display values of current property in the form
  console.log("arrayList open")
  var index = $(".select").val();
  var url = "http://localhost:3000/properties/" + index;
  $.get(url, (data) => {

    console.log(data)
    $("#pName").val(data.data.name);
    $("#pNeighborhood").val(data.data.neighborhood);
    $("#pAddress").val(data.data.address);
    $("#pLat").val(data.data.lat);
    $("#pLng").val(data.data.lng);
    $("#price").val(data.data.price);
    $("#rating").val(data.data.rating);
    $("#description").val(data.data.description);
    //the checkboxes and radio fields 
    if (data.data.wifi == 1) {
      $("#wifi").prop("checked", true)
    }
    if (data.data.printer == 1) {
      $("#printer").prop("checked", true)
    }
    if (data.data.fax == 1) {
      $("#fax").prop("checked", true)
    }
    if (data.data.showers == 1) {
      $("#showers").prop("checked", true)
    }
    if (data.data.bike == 1) {
      $("#bike").prop("checked", true)
    }
    if (data.data.meeting == 1) {
      $("#meeting").prop("checked", true)
    }
    if (data.data.projector == 1) {
      $("#projector").prop("checked", true)
    }
    // coworking space
    if (data.data.type_coworking == "Desk in Cubicle") {
      $("#cubicle").prop("checked", true)
    } else if (data.data.type_coworking == "Desk in Private space") {
      $("#private").prop("checked", true)
    } else {
      $("#shared").prop("checked", true)
    }
    // status type 
    if (data.data.status == "Rented") {
      $("#rented").prop("checked", true)
    } else {
      $("#not-rented").prop("checked", true)
    }
  });
}

editProperty = () => {
  // gets the new input values from the FORM
  getPropertyInput();
  // edits/updates the data of the selected property based on it's index number
  var index = $("#select").val();
  properties[index] = {
    Name: Name,
    Address: address,
    lat: lat,
    lng: lng,
    Neighborhood: neighborhood,
    Type_coworking: space,
    Amenities: addAmenities(),
    Price: price,
    Status: availibility,
    Rating: rating,
    Description: description
  };

}

// PROFILE PAGE
// display user info in form
userInfo = ()  =>{
  $.get("http://localhost:3000/user",(data)=>{
    $("#user").val(data[0].username);
    $("#fname").val(data[0].Firstname);
    $("#lname").val(data[0].Lastname);
    $("#add").val(data[0].Address);
    $("#uphone").val(data[0].Phone);
    $("#em").val(data[0].email);
  })
}




