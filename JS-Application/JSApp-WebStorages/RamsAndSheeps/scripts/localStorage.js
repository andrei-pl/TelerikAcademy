/// <reference path="./libs/jquery/dist/jquery.min.js" />
define(["jquery", "init"], function ($, init) {

    function loadPairs() {
        if (!localStorage.length || localStorage.length === 0) {
            document.getElementById("results").innerHTML = "{ key:empty, value=empty}";
            return;
        }
        var keys = {},
            resultHTML = "<ul>";

        for (var i = 0; i < localStorage.length; i++) {
            var key = localStorage.key(i);

            keys[parseInt(key)] = localStorage.getItem(key);
        }

        for (var i in keys) {
            resultHTML +=
            '<li>' +
            '<strong>' + keys[i] + '</strong>: ' + i + '</li>';
        }
        resultHTML += "</ul>";
        document.getElementById("results").innerHTML = resultHTML;
    }

    function saveStorage() {
        var key = parseInt(init.count);
        var value = prompt("Please enter you name");
        if (value) {
            localStorage.setItem(key, value);
        }
        loadPairs();
        $("#results").css('display', 'block');
    }

    function loadStorage() {
        loadPairs();
    }

    return {
        saveStorage: saveStorage,
        loadStorage: loadStorage
    };
})