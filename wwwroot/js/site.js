// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function toggleVisibility() {
    var x = document.getElementById("target");
    if (x.style.display === "none") {
        x.style.display = "block";
    } else {
        x.style.display = "none";
    }
}

// Used to toggle the menu on small screens when clicking on the menu button
function myFunction() {
    alert("BLA");
    var level = document.getElementById("navDemo").getElementById("l1");
    level.textContent = "Goodbye world!";

    var x = document.getElementById("navDemo");
    if (x.className.indexOf("w3-show") == -1) {
        x.className += " w3-show";
    } else {
        x.className = x.className.replace(" w3-show", "");
    }
}