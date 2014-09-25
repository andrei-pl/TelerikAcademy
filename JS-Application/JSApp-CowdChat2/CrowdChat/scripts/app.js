/// <reference path="node_modules/handlebars/handlebars.min.js" />
/// <reference path="node_modules/requirejs/require.js" />
/// <reference path="node_modules/sammy.js" />
/// <reference path="node_modules/handlebars/handlebars.min.js" />
/// <reference path="node_modules/mustache/mustache.js" />
(function () {
    require.config({
        paths: {
            'requester': 'http-requester',
            'chat': 'chat-controller',
            'login': 'login-controller',
            'jquery': 'node_modules/jquery/dist/jquery',
            'sammy': 'node_modules/sammy',
            'handlebars': 'node_modules/handlebars/handlebars.min'
        },
        shim: {
            'handlebars': {
                exports: 'handlebars'
            }
        }
    });

    require(['sammy', 'jquery', 'login', 'chat'], function (Sammy, $, logIn, chat) {

        var app = Sammy('#container', function () {

            this.get('#/login', function () {
                logIn.show();
            })

            this.get('#/chat', function () {
                chat.show();
            })
        });

        app.run('#/login');
    });
}());