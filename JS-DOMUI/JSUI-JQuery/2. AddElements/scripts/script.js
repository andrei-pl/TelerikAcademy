/// <reference path="jquery/dist/jquery.min.js" />
(function () {
    $("#prevBtn").on('click', AddBefore);
    $("#nextBtn").on('click', AddAfter);

    function AddBefore() {
        $('<div/>').text('Inserted before text').prependTo($('#text'));
    }

    function AddAfter() {
        $('<div/>').text('Inserted after text').appendTo($('#text'));
    }
})();