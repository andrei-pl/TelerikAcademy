/// <reference path="libs/jquery/dist/jquery.js" />
(function () {
    require.config({
        paths: {
            'jquery': 'libs/jquery/dist/jquery.min'
        }
    });

    require(['game', 'init', 'jquery'], function (game, init, $) {

        init.init();
        //var randNumber = init.randomNumber();

        function restoreState() {
            return localStorage["text"];
        }

        var clicked = $('#check');
        clicked.on('click', function () {
            $("#results").hide();
            game.run(init.randomNumber()); //that you don't need to refresh the page
        });
    });
}());