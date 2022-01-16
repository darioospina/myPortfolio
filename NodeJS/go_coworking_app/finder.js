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

// Displays the amenities on list items
listAmenities = (amenities) => {
    let html = ""
    if(amenities == null) {
            html += "<ul class='ulAmenities'><li class='liAmenities'> No amenities </li></ul>"
    } else {
        let array = amenities.split(",")
        for(let i=0;i<array.length;i++) {
            html += "<ul class='ulAmenities'>"
            html += "<li class='liAmenities'>" + array[i].trim().replaceAll('_',' ') + "</li>"
            html += "</ul>"
        }
    }
    return html
}

////////////////////////////////////////////////////////////
/////////////////// FINDER PAGE
////////////////////////////////////////////////////////////
loadProperties = (dir) => {
    $("#table_properties_filters").empty()
    $("#table_properties").css({"visibility":"visible", "display" : "inline"})
    $("#table_properties_filters").css({"visibility":"hidden", "display" : "none"})
    let url = "" 
    if(isEmpty(dir)) {
    url = "http://localhost:3000/properties"
    } else {
    url = "http://localhost:3000/" + dir.toString()
    }
    $.get(url, (data) => {
        var properties = data
        for(let i=0;i<properties.length;i++) {
            let HTML = "<tr>"
            HTML += "<td> Property # " + properties[i].PropertyID + "</td>" 
            HTML += "<tr>"
            HTML += "<td>" + listAmenities(properties[i].Amenities) + "</td>" 
            HTML += "<td>" + properties[i].Address + "</td>" 
            HTML += "<td>" + properties[i].Description + "</td>"
            HTML += "<td>" + properties[i].Type + "</td>" 
            HTML += "<td>" + properties[i].Price + "</td>" 
            HTML += "<td>" + properties[i].RatingID + "</td>" 
            //HTML += "<td id='map_" + properties[i].PropertyID + "' onload=" + InitMap(properties[i].PropertyID, properties[i].Latitude, properties[i].Longitude) + ">" + "Here is the map" + "</td>" 
            HTML += "<td>" + properties[i].Longitude + "</td>" 
            HTML += "<td>" + properties[i].Latitude + "</td>" 
            HTML += "<td>" + properties[i].Pic1 + "</td>" 
            HTML += "<td>" + properties[i].Pic2 + "</td>" 
            HTML += "<td>" + properties[i].Pic3 + "</td>"
            $("#table_properties").append(HTML)
        }
    })
}

applyFilters = () => {
    $("#table_properties").empty()
    $("#table_properties_filters").empty()
    $("#table_properties").css({"visibility":"hidden", "display" : "none"})
    $("#table_properties_filters").css({"visibility":"visible", "display" : "inline"})
    let check_price = $('input[name=price]:checked', '#filtersTable').val()
    let check_type = $('input[name=type]:checked', '#filtersTable').val()
    let check_status = $('input[name=status]:checked', '#filtersTable').val()
    if(isEmpty(check_price) || isEmpty(selectAmenities()) || isEmpty(check_type) || isEmpty(check_status)) {
        alert("Click on the filters you want to apply")
        loadProperties()
    } else {
        let Amenities = selectAmenities()
        let Type = $('input[name=type]:checked', '#filtersTable').val()
        let Status = $('input[name=status]:checked', '#filtersTable').val()
        let PriceFrom = 0 
        let PriceTo = 500
        if(check_price == "price_from0_to500") {
            PriceFrom = 0, PriceTo = 500
        } 
        if(check_price == "price_from501_to750") {
            PriceFrom = 501, PriceTo = 750
        } 
        if(check_price == "price_from751_to1000") {
            PriceFrom = 751, PriceTo = 1000
        } 
        if(check_price == "price_more_than1000") {
            PriceFrom = 1001, PriceTo = 1000000000
        }
        let url = "http://localhost:3000/properties/filters/" + Amenities + "/" + Type + "/" + PriceFrom + "/" + PriceTo + "/" + Status
        $.get(url, (data) => {
            let properties = data.data
            if(properties == '') {
                $("#table_properties_filters").append("No results matching your criteria. Try different parameters")
            }
            for(let i=0;i<properties.length;i++) {
                let HTML = "<tr>"
                HTML += "<td>" + properties[i].PropName + "</td>" 
                HTML += "<td>" + properties[i].Address + "</td>" 
                HTML += "<td>" + properties[i].Description + "</td>"
                HTML += "<td>" + properties[i].Type + "</td>" 
                HTML += "<td>" + listAmenities(properties[i].Amenities) + "</td>" 
                HTML += "<td>" + properties[i].Price + "</td>" 
                HTML += "<td>" + properties[i].Status + "</td>" 
                HTML += "<td>" + properties[i].RatingID + "</td>"
                //HTML += "<td id='map_" + properties[i].PropertyID + "' onload=" + InitMap(properties[i].PropertyID, properties[i].Latitude, properties[i].Longitude) + ">" + "Here is the map" + "</td>"  
                HTML += "<td>" + properties[i].Longitude + "</td>" 
                HTML += "<td>" + properties[i].Latitude + "</td>" 
                HTML += "<td>" + properties[i].Pic1 + "</td>" 
                HTML += "<td>" + properties[i].Pic2 + "</td>" 
                HTML += "<td>" + properties[i].Pic3 + "</td>"
                $("#table_properties_filters").append(HTML)
            }
        })
    }
}

orderBy = () => {
    $("#table_properties").empty()
    $("#table_properties_filters").empty()
    let getOrderByValue = $('#orderby').find(":selected").text();
    let getDirectionValue = ""
    let dir = "properties_orderby_"
    getDir = () => {
        if($('#direction').find(":selected").text() == "Descendent") {
            return getDirectionValue = "Desc"
        } else {
            return getDirectionValue = "Asc"
        }
    }
    dir += getOrderByValue + getDir()
    loadProperties(dir)
}

cleanFilters = () => {
    $("#table_properties").empty()
    $("#table_properties_filters").empty()
    $("#filtersTable").trigger("reset")
    loadProperties()
}
