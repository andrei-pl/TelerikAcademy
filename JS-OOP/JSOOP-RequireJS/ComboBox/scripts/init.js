'use stricrt'

define(["jquery", "comboBox"], function ($, controls) {
    var people = [
                  { id: 1, name: "Doncho Minkov", age: 18, avatarUrl: "images/minkov.jpg" },
                  { id: 2, name: "Todor Stoyanov", age: 19, avatarUrl: "images/todor.jpg" },
                  { id: 3, name: "Nikolay Kostov", age: 18, avatarUrl: "images/niki.jpg" },
                  { id: 4, name: "Ivaylo Kenov", age: 19, avatarUrl: "images/ivo.jpg" }
                ];

    run = function () {
        var comboBox = controls.ComboBox(people);
        var template = $("#person-template").html();
        var comboBoxHtml = comboBox.render(template);
        $('#comboBox-container').html(comboBoxHtml);
    };

    return {
        run: run
    };
})