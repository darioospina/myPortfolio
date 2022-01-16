var x = document.getElementById("testButton")
x.addEventListener("click", display, count)

var counting = 0;
function count(event) {
    counting++;
    console.log(counting)
}

function display(event) {
    count();
    if(counting % 2 != 0) {
        document.getElementById("displayText").innerText="You just clicked the button";        
    } else if(counting % 2 == 0) {
        document.getElementById("displayText").innerText="";        
    }
}

var y = document.getElementById("testButton2")
y.addEventListener("click", display2)

function display2(event) {
    alert("Leave me alone!!");
}

function addition(event) {
    var Num1 = document.getElementById("Num1").value
    var Num2 = document.getElementById("Num2").value
    Num1 = parseInt(Num1)
    Num2 = parseInt(Num2)
    var x = Num1 + Num2;
    document.getElementById("Result").innerHTML = x    
}

function subtraction(event) {
    var Num1 = document.getElementById("Num1").value
    var Num2 = document.getElementById("Num2").value
    Num1 = parseInt(Num1)
    Num2 = parseInt(Num2)
    var x = Num1 - Num2;
    document.getElementById("Result").innerHTML = x    
}

function multiplication(event) {
    var Num1 = document.getElementById("Num1").value
    var Num2 = document.getElementById("Num2").value
    Num1 = parseInt(Num1)
    Num2 = parseInt(Num2)
    var x = Num1 * Num2;
    document.getElementById("Result").innerHTML = x    
}

function division(event) {
    var Num1 = document.getElementById("Num1").value
    var Num2 = document.getElementById("Num2").value
    Num1 = parseInt(Num1)
    Num2 = parseInt(Num2)
    var x = Num1 / Num2;
    document.getElementById("Result").innerHTML = x    
}

var str = document.getElementById("string");
str.addEventListener("keyup", function() {
    document.getElementById("strLower").innerHTML = str.value.toLowerCase();
    document.getElementById("strUpper").innerHTML = str.value.toUpperCase();
    document.getElementById("strLength").innerHTML = str.value.length;
})

function sortingArray() {
    var element1 = document.getElementById("El_1").value
    var element2 = document.getElementById("El_2").value
    var element3 = document.getElementById("El_3").value
    var element4 = document.getElementById("El_4").value
    var element5 = document.getElementById("El_5").value
    var array1 = [element1, element2, element3, element4, element5]
    document.getElementById("arraySorted").innerText = array1.sort()
}

function sortingArrayReverse() {
    var element1 = document.getElementById("El_1").value
    var element2 = document.getElementById("El_2").value
    var element3 = document.getElementById("El_3").value
    var element4 = document.getElementById("El_4").value
    var element5 = document.getElementById("El_5").value
    var array1 = [element1, element2, element3, element4, element5]
    document.getElementById("arraySorted2").innerText = array1.reverse()
}