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
    },

}

// Write your JavaScript code.
function changeTab(tabNum) {
    var buttons = document.getElementById('sidenav').getElementsByTagName('*');
    for (let button of buttons) {
        if (utils.hasClass(button, "sidenav_entry_selected")) {
            button.classList.remove("sidenav_entry_selected");
            button.classList.add("sidenav_entry_unselected");
        }
    }

    var currButton = document.getElementById('sidenav' + tabNum)
    if (utils.hasClass(currButton, "sidenav_entry_unselected")) {
        currButton.classList.remove("sidenav_entry_unselected");
    }
    currButton.classList.add("sidenav_entry_selected");
}

/* When the user clicks on the button, 
toggle between hiding and showing the dropdown content */
function toggleDropDown(buttonID) {
    document.getElementById(buttonID).classList.toggle("show");
}

function changeDropDownOption(buttonID, inputID, newText) {
    document.getElementById(buttonID).value = newText;
    document.getElementById(inputID).value = newText;
}

// Close the dropdown menu if the user clicks outside of it
window.onclick = function (event) {
    if (!event.target.matches('.dropbtn')) {
        var dropdowns = document.getElementsByClassName("dropdown-content");
        var i;
        for (i = 0; i < dropdowns.length; i++) {
            var openDropdown = dropdowns[i];
            if (openDropdown.classList.contains('show')) {
                openDropdown.classList.remove('show');
            }
        }
    }
}