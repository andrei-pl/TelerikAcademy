/// <reference path="./libs/jquery/dist/jquery.min.js" />
define(["jquery", "init", "localStorage"], function ($, init, storage) {

    run = function (number) {
        var textForCheck = $("#inputText").val(),
            found = {
                rams: 0,
                sheeps: 0
            },
            strTextForCheck = textForCheck.toString(),
            strNumber = number.toString();

        init.count++;

        if (!init.isDigitsDifferent(textForCheck)) {
            alert("Invalid Number");
        } else {

            for (var i = 0; i < strNumber.length; i++) {
                for (var j = 0; j < strTextForCheck.length; j++) {
                    if (strTextForCheck[j] === strNumber[i]) {
                        if (i === j) {
                            found.rams++;
                        } else {
                            found.sheeps++;
                        }
                    }
                }
            }

            if (found.rams === 4) {
                storage.saveStorage();
                init.init();
            } else {
                addAnimals(found, strTextForCheck);
            }

            console.log(found.rams + ' rams, ' + found.sheeps + ' sheeps');
        };
    }

    function addAnimals(found, number) {

        var divElement = $('<div/>');
        var spanElement = $('<span/>');

        spanElement.html(number);
        divElement.append(spanElement);

        for (var i = 0; i < found.rams; i++) {
            var ramPicture = $('<img/>')
                         .attr('src', '../imgs/ram.gif');

            divElement.append(ramPicture);
        }

        for (var i = 0; i < found.sheeps; i++) {
            var sheepPictute = $('<img/>')
                         .attr('src', '../imgs/sheep.png');

            divElement.append(sheepPictute);
        }

        $("#temporaryResults").prepend(divElement);
    }

    return {
        run: run
    };
})