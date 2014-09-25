define(['jquery'], function($) {
    var HttpRequester = (function() {
        var makeHttpRequest = function(url, type, data) {
            var deferred = $.Deferred();

            $.ajax({
                url: url,
                type: type,
                data: data ? JSON.stringify(data) : "",
                contentType: "application/json",
                timeout: 5000,
                success: function(resultData) {
                    deferred.resolve(resultData);
                },
                error: function(errorData) {
                    deferred.reject(errorData);
                }
            });

            return deferred.promise();
        };

        var getJSON = function(url) {
            return makeHttpRequest(url, "GET");
        };

        var postJSON = function(url, data) {
            return makeHttpRequest(url, "POST", data);
        };

        var getUser = function (url, data) {
            return makeHttpRequest(url, "GET", data);
        };

        var logOutUser = function (url, user) {
            var deferred = $.Deferred(),
                xhr = new XMLHttpRequest();

            $.ajax({
                url: url,
                type: 'PUT',
                beforeSend: function (xhr) { xhr.setRequestHeader('X-SessionKey', user); },
                contentType: "application/json",
                timeout: 5000,
                success: function (resultData) {
                    deferred.resolve(resultData);
                },
                error: function (errorData) {
                    deferred.reject(errorData);
                }
            });

            return deferred.promise();
        };

        var postMessage = function (url, data, user) {
            var deferred = $.Deferred(),
                xhr = new XMLHttpRequest();

            $.ajax({
                url: url,
                type: 'POST',
                beforeSend: function (xhr) { xhr.setRequestHeader('X-SessionKey', user); },
                data: JSON.stringify(data),
                contentType: "application/json",
                timeout: 5000,
                success: function(resultData) {
                    deferred.resolve(resultData);
                },
                error: function(errorData) {
                    deferred.reject(errorData);
                }
            });

            return deferred.promise();
        };

        return {
            getJSON: getJSON,
            postJSON: postJSON,
            getUser: getUser,
            postMessage: postMessage,
            logOutUser: logOutUser
        }
    }());

    return HttpRequester;
});