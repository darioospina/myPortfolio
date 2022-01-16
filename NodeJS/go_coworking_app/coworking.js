////////////////////////////////////////////////////////////
/////////////////// GLOBAL FUNCTIONS
////////////////////////////////////////////////////////////

// Function to check if an object is empty
isEmpty = (obj) => {
    for(var key in obj) {
        if(obj.hasOwnProperty(key))
            return false;
    }
    return true;
}

// Checks from the input if a value is there (e.g. list of amenities vs. amenity x)
CheckIfMatch = (obj1,obj2) => {
    let array = obj1.split(",")
    for(let i=0;i<array.length;i++) {
        if(array[i].trim() == obj2) {
            return true
        }
    }
    return false
}

// Converts the checkboxes into a string for the DB
selectAmenities = () => {
    var Amenities = []
    if($("#wifi").is(":checked")) {
        Amenities.push("wifi")
    } if($("#printer").is(":checked")) {
        Amenities.push("printer") 
    } if($("#fax").is(":checked")) {
        Amenities.push("fax") 
    } if($("#showers").is(":checked")) {
        Amenities.push("showers") 
    } if($("#bike").is(":checked")) {
        Amenities.push("bike") 
    } if($("#meeting").is(":checked")) {
        Amenities.push("meeting") 
    } if($("#projector").is(":checked")) {
        Amenities.push("projector") 
    } 
    return Amenities.toString().replaceAll(/\s/g,'')
}

////////////////////////////////////////////////////////////
/////////////////// LOGIN PAGE
////////////////////////////////////////////////////////////

// Checks if the credentials are correct.
login = () => {
    var user = $("#uName").val()
    var pass = $("#Password").val()
    if (isEmpty(user) || isEmpty(pass)) {
        alert("Please introduce a username and password")
    } else {
        var url = "http://localhost:3000/users/" + user + "/" + pass 
        $.ajax({
                url: url,
                type: 'GET',
                success: function(data){
                    if (isEmpty(data)){   
                        alert("The user and/or the password were not found in the DB")
                    }
                    else{
                        var StoreDataFromOwner = data
                        userInfo(StoreDataFromOwner)
                        loadProperties_Owner(StoreDataFromOwner)
                        hideLoginBox()
                    }
                },
                error: function(data) {
                    alert("Please introduce a user and a password")
                }
        })  
    }
}

// Welcome message and storing the info from the owner
userInfo = (data) => {
    var html = "<span id='hello'>"
    html += "Welcome to Coworking Dear "
    html += data.data.UserName 
    html += "</span>"
    html += "<span id='divUserID'>"
    html += data.data.UserID
    html += "</span>"
    $("#welcome").append(html).css({"visibility":"visible","background-color":"grey"})
    $("#divUserID").css({"visibility":"hidden"})
}

// Hides the Login box
hideLoginBox = () => {
    $("#login_box").css("visibility", "hidden")
}

// Loads all the properties from the owner after login in
loadProperties_Owner = (DataFromOwner) => {
    var ownerid = DataFromOwner.data.UserID
    var url = "http://localhost:3000/properties/userid/" + ownerid
    $.get(url, (data) => {
        var properties = data.data
        for(let i=0;i<properties.length;i++) {
            let HTML = "<tr>"
            HTML += "<td>" + properties[i].PropertyID + "</td>" 
            HTML += "<td>" + properties[i].PropName + "</td>" 
            HTML += "<td>" + properties[i].Address + "</td>" 
            HTML += "<td>" + properties[i].Description + "</td>"
            HTML += "<td>" + properties[i].Type + "</td>" 
            HTML += "<td>" + properties[i].Amenities + "</td>" 
            HTML += "<td>" + properties[i].Price + "</td>" 
            HTML += "<td>" + properties[i].Status + "</td>" 
            HTML += "<td>" + properties[i].RatingID + "</td>" 
            HTML += "<td>" + properties[i].Longitude + "</td>" 
            HTML += "<td>" + properties[i].Latitude + "</td>" 
            HTML += "<td>" + properties[i].Pic1 + "</td>" 
            HTML += "<td>" + properties[i].Pic2 + "</td>" 
            HTML += "<td>" + properties[i].Pic3 + "</td>"
            HTML += "<td>" + "<button onclick='deleteProp(" + properties[i].PropertyID + ")'>" + "Delete" + "</button>" + "</td>"
            HTML += "<td>" + "<button onclick='updateProp(" + ownerid + "," + properties[i].PropertyID + ")'>" + "Update" + "</button>" + "</td>"
            $("#table_properties").append(HTML)
        }
    })
}

// Updates a property when clicking the 'Update' button
function updateProp(OwnerID, PropertyID) {
    $("#newProp").trigger("reset")
    $("input[name=type]").prop('checked', false);
    $("#DivNewProperty").css("visibility", "visible")
    $("#submitBttn").css({"visibility": "hidden", "display" : "none"})
    $("#updateBttn").css({"visibility": "visible", "display" : "inline"})
    var url = "http://localhost:3000/properties/" + OwnerID + "/" + PropertyID
    $.get(url, (data) => {
        var property = data.data
        var amenities = {
            wifi: $("#wifi").val(),
            printer: $("#printer").val(),
            fax: $("#fax").val(),
            showers: $("#showers").val(),
            bike: $("#bike").val(),
            meeting: $("#meeting").val(),
            projector: $("#projector").val()
        }    
        $("#propID").val(property.PropertyID)
        $("#pName").val(property.PropName)
        $("#Address").val(property.Address)
        if(property.Type == "cubicle") {$("#cubicle").prop("checked", true);}
        if(property.Type == "private") {$("#cubicle").prop("checked", true);}
        if(property.Type == "shared") {$("#cubicle").prop("checked", true);}
        if(CheckIfMatch(property.Amenities,amenities.wifi)) {$("#wifi").prop('checked', true)}
        if(CheckIfMatch(property.Amenities,amenities.printer)) {$("#printer").prop('checked', true)}
        if(CheckIfMatch(property.Amenities,amenities.fax)) {$("#fax").prop('checked', true)}
        if(CheckIfMatch(property.Amenities,amenities.showers)) {$("#showers").prop('checked', true)}
        if(CheckIfMatch(property.Amenities,amenities.bike)) {$("#bike").prop('checked', true)}
        if(CheckIfMatch(property.Amenities,amenities.meeting)) {$("#meeting").prop('checked', true)}
        if(CheckIfMatch(property.Amenities,amenities.projector)) {$("#projector").prop('checked', true)}
        $("#Price").val(property.Price) 
        $("#Status").prop('disabled', false)
        if(property.RatingID == 1) {$("#one").prop("checked", true);}
        if(property.RatingID == 2) {$("#two").prop("checked", true);}
        if(property.RatingID == 3) {$("#three").prop("checked", true);}
        if(property.RatingID == 4) {$("#four").prop("checked", true);}
        if(property.RatingID == 5) {$("#five").prop("checked", true);}
        $("#longitude").val(property.Longitude) 
        $("#latitude").val(property.Latitude) 
        $("#description").val(property.Pic1) 
        $("#pic1").val(property.Pic1) 
        $("#pic2").val(property.Pic2) 
        $("#pic3").val(property.Pic3) 
    })
}

// Deletes a property when clicking the 'Delete' button
function deleteProp(PropertyID) {
    let propertyid = PropertyID
    $.ajax({
        url: "http://localhost:3000/properties/delete/" + propertyid,
        type: 'DELETE',
        data: JSON.stringify({PropertyID: PropertyID}),
        success: function() {
            console.log("Property successfully deleted")
            location.reload()
        },
        error: function(error) {
            console.log(error)
        } 
    });
}

// Adds a new property 
postProperty = () => {
    let dataProp = {
        UserID: $("#divUserID").text(), 
        PropName: $("#pName").val(), 
        Address: $("#Address").val(), 
        Type: $('input[name=type]:checked', '#newProp').val(), 
        Amenities: selectAmenities(), 
        Price: $("#Price").val(), 
        Status: "Not rented", 
        RatingID: $('input[name=rating]:checked', '#newProp').val(), 
        Latitude: $("#latitude").val(), 
        Longitude: $("#longitude").val(), 
        Pic1: $("#pic1").val(), 
        Pic2: $("#pic2").val(),  
        Pic3: $("#pic3").val(),  
        Description: $("#description").val() 
    }
    $.post("http://localhost:3000/properties/add",dataProp)
}

// Updates the information from an existing property 
updateProperty= () => {
    let dataProp = {
        PropName: $("#pName").val(), 
        Address: $("#Address").val(), 
        Type: $('input[name=type]:checked', '#newProp').val(), 
        Amenities: selectAmenities(), 
        Price: $("#Price").val(), 
        Status: $("#Status").val(), 
        RatingID: $('input[name=rating]:checked', '#newProp').val(), 
        Latitude: $("#latitude").val(), 
        Longitude: $("#longitude").val(), 
        Pic1: $("#pic1").val(), 
        Pic2: $("#pic2").val(),  
        Pic3: $("#pic3").val(),  
        Description: $("#description").val(),
        PropertyID: $("#propID").val()
    }
    $.ajax({
        url: "http://localhost:3000/properties/update/" + dataProp.PropertyID,
        type: 'PATCH',
        data: JSON.stringify(dataProp),
        success: function() {
            console.log("Property successfully updated")
        },
        error: function(error) {
            console.log(error)
        } 
    });
}

// Displays the form to add a new property
displayform = () => {
    $("#DivNewProperty").css("visibility", "visible")
    $("#submitBttn").css({"visibility": "visible", "display" : "inline"})
    $("#updateBttn").css({"visibility": "hidden", "display" : "none"})
    $("#newProp").trigger("reset")
    $("input[name=type]").attr('checked', false);
    $("input[name=rating]").attr('checked', false);
    $("#Status").prop('disabled', true)
}