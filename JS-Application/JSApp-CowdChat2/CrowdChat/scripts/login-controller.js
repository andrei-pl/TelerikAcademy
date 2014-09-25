/// <reference path="node_modules/jquery/dist/jquery.js" />
define(['jquery'], function ($) {

    function isUsernameCorrect(username) {
        var isValidUsername = username && typeof username == 'string' &&
                              username.length >= 4 && username.length <= 20;
        return isValidUsername;
    }

    function success(loginHtml) {
        if (localStorage.getItem('username')) {
            window.location = '#/chat';
        } else {
            $('#container').html(loginHtml);
            $('#submit').on('click', function () {
                var username = $('#username').val();
                if (isUsernameCorrect(username)) {
                    localStorage.setItem('username', username);
                    window.location = '#/chat';
                } else {
                    alert('Username should be longer!');
                }
            });
        }
    }

    var show = function () {
         $.ajax({
             url: '../views/login-template.html',
            success: success,
            error:function() {
                alert('Cannot load log-in!');
            }
        });
    };

    return {
        show: show
    }
});