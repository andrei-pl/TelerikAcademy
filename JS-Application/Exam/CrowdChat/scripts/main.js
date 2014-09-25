define(function() {
    require.config({
        paths: {
            'jquery': 'vendor/jquery-2.1.1',
            'sammy': 'vendor/sammy',
            'q': 'vendor/q.min', //ne se polzva, no sym go ostavil za vseki slu4ai mazaloto da ne stane pove4e :)
            'http-requester': 'http-requester',
            'validation-controller': 'validation-controller',
            'ui': 'ui-controller',
            'controller': 'controller'
        }
    });

    require(['jquery', 'sammy', 'controller'], function($, Sammy, Controller) {
        var appController = new Controller('http://localhost:3000');
        appController.setEventHandler();

        var app = Sammy('#wrapper', function() {
            this.get("#/login", function() {
                if (appController.isLoggedIn()) {
                    window.location = '#/chat';
                    return;
                }

                appController.loadLoginForm();
            });

            this.get("#/register", function () {
                if (appController.isLoggedIn()) {
                    window.location = '#/chat';
                    return;
                }
                appController.loadRegisterForm();
            });

            this.get("#/chat", function() {
                
                appController.loadChatBox();
            });
        });

        app.run('#/chat');
    });
});