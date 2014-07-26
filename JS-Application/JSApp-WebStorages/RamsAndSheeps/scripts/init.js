/// <reference path="./libs/jquery/dist/jquery.min.js" />
define(["jquery"], function ($) {
    'use strict'

    var rand,
        count;

    function init() {
        this.count = 0;
        rand = Math.floor(Math.random() * 8999 + 1000);

        $("#temporaryResults").html("");

        while (!isDigitsDifferent(rand)) {
            rand = Math.floor(Math.random() * 8999 + 1000);
        }
        console.log(rand);
    }

    function isDigitsDifferent(number) {
        var strNumber = number.toString(),
            arrDigits = {};

        for (var i in strNumber) {
            if (!arrDigits[strNumber[i]]) {
                arrDigits[strNumber[i]] = 1;
            } else {
                return false;
            }
        }

        return true;
    }

    function randomNumber() {
        return rand;
    }

    return {
        init: init,
        isDigitsDifferent: isDigitsDifferent,
        count: count,
        randomNumber: randomNumber
    };
})