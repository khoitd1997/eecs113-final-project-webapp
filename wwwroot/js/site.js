// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

var utils = {
    hasClass: function (element, className) {
        return (' ' + element.className + ' ').indexOf(' ' + className + ' ') > -1;
    },

    toggleVisibility: function (element) {
        if (element.style.display === "none") {
            element.style.display = "block";
        } else {
            element.style.display = "none";
        }
    },

    turnVisibilityOff: function (element) {
        element.style.display = "none";
    },

    turnVisibilityOn: function (element) {
        element.style.display = "block";
    }
}

// window.onload = function () {
//     var buttons = document.getElementById('navbar').getElementsByTagName('*');
//     for (let button of buttons) {
//         button.onclick = changeTab(button.id);
//     }
// }

// Write your JavaScript code.
function changeTab(currButtonID) {
    var buttons = document.getElementById('navbar').getElementsByTagName('*');
    for (let button of buttons) {
        if (utils.hasClass(button, "w3-white")) {
            button.classList.remove("w3-white");
            utils.turnVisibilityOff(document.getElementById("main_content" + button.id.match(/\d+$/)));
        }
    }

    var currButton = document.getElementById(currButtonID)
    currButton.classList.add("w3-white");
    utils.turnVisibilityOn(document.getElementById("main_content" + currButton.id.match(/\d+$/)));
    // utils.toggleVisibility(document.getElementById("main_content" + currButtonID.match(/\d+$/)));
}