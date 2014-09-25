/// <reference path="node_modules/jquery/dist/jquery.js" />
define(['jquery'], function ($) {

    var HTTPRequester = (function () {

        function getJSON(requestURL) {
            var deferred = $.Deferred();

            $.ajax({
                url: requestURL,
                type: 'GET',
                contentType: 'application/json',
                accepts: 'application/json',
                success: function (data) {
                    deferred.resolve(data);
                },
                error: function (err) {
                    deferred.reject(err);
                }
            });
            return deferred.promise();
        }

        function postJSON(requestURL, data) {
            var deferred = $.Deferred();

            $.ajax({
                url: requestURL,
                type: 'POST',
                contentType: 'application/json',
                accepts: 'application/json',
                data: JSON.stringify(data),
                success: function (data) {
                    deferred.resolve(data);
                },
                error: function (err) {
                    deferred.reject(err);
                }
            });
            return deferred.promise();
        }

        return {
            getJSON: getJSON,
            postJSON: postJSON
        };
    }());
    return HTTPRequester;
});
