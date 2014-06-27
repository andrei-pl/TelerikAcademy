'use strict'

var MAX_SIZE = 100,
    buffer = {};

var domModule = (function () {

    function appendElement(element, selector) {
        var parent = document.querySelector(selector);
        parent.appendChild(element);
    };

    function removeElement(selector, element) {
        var parent = document.querySelector(selector),
            child = document.querySelector(element);

        if (child && child.parentNode === parent) {
            parent.removeChild(child);
        }
    };

    function appendToBuffer(selector, element) {
        var parent = document.querySelector(selector);

        if (!buffer[selector]) {
            buffer[selector] = document.createDocumentFragment()
        }
        buffer[selector].appendChild(element);

        if (buffer[selector].childNodes.length === MAX_SIZE) {
            parent.appendChild(buffer[selector]);
            buffer[selector] = null;
        }
    };

    function addHandler(selector, eventType, handler) {
        var elements = document.querySelectorAll(selector),
            i;

        for (i = 0; i < elements.length; i++) {
            elements[i].addEventListener(eventType, handler);
        }
    };

    function getElements(selector) {
        return document.querySelectorAll(selector);
    };

    return {
        appendElement: appendElement,
        removeElement: removeElement,
        appendToBuffer: appendToBuffer,
        addHandler: addHandler,
        getElements: getElements
    }
})();

var startButton = document.getElementById("start");
startButton.onclick = startModul;

function startModul() {

    var button = document.getElementsByClassName('button');
    var div = document.createElement("div");

    div.innerHTML = "Some div";

    //appends div to #wrapper
    domModule.appendElement(div, "#wrapper");

    //removes li:first-child from ul
    domModule.removeElement("ul", "li:first-child");

    //add handler to each a element with class button
    domModule.addHandler("a.button", 'click', function () { alert("Clicked") });

    domModule.appendToBuffer("container", div.cloneNode(true));

    var menu = document.createElement("li");
    for (var i = 0; i < 110; i++) {
        var navItem = menu.cloneNode(true);
        navItem.innerHTML = i;
        domModule.appendToBuffer("#main-nav ul", navItem);
    }

    var allButtons = domModule.getElements('a.button');

    for (var i = 0; i < allButtons.length; i++) {
        console.log(allButtons[i].style.color = 'pink');
    }
}