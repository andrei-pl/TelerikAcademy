define(['http-requester', 'validation-controller', 'ui'], function (HttpRequester, ValidationController, UI) {
    var Controller = (function () {
        var Controller = function (resourceUrl) {
            this.resourseUrl = resourceUrl;
            this.refreshTimeMS = 4000;
            this.showLastMessagesCount = 200;
        };

        Controller.prototype.getUsername = function () {
            return sessionStorage.getItem('username');
        };

        Controller.prototype.setUser = function (username, password) {
            sessionStorage.setItem('username', username);
            sessionStorage.setItem('authCode', password);
        };

        Controller.prototype.destroyUsername = function () {
            sessionStorage.clear();
        };

        Controller.prototype.isLoggedIn = function () {
            return this.getUsername() != null;
        };

        Controller.prototype.loadChatBox = function () {
            var _this = this;

            $.when(
                $.get('views/chat-template.html', function (data) {
                    $('#wrapper').html(data);
                    $('.username-box').html(_this.getUsername());
                    _this.updateChatBox();
                    setInterval(function () {
                        _this.updateChatBox();
                    }, _this.refreshTimeMS);
                }));
        };

        Controller.prototype.updateChatBox = function () {
            var _this = this;
            HttpRequester.getJSON('http://localhost:3000/post')
                .then(function (data) {
                    var chatBoxHtml = UI.buildChatBox(data, _this.showLastMessagesCount);
                    $('#chatbox').html(chatBoxHtml)
                });
        };

        Controller.prototype.loadLoginForm = function () {
            $('#wrapper').load('views/login-template.html');
        };

        Controller.prototype.loadRegisterForm = function () {
            $('#wrapper').load('views/register-template.html');
        };

        Controller.prototype.setEventHandler = function () {
            var _this = this,
                $wrapper = $('#wrapper');

            $wrapper.on('click', '#login-btn', function () {
                var $loginInput = $('#login-name'),
                    username = $loginInput.val(),
                    $passwordInput = $('#password-name'),
                     passwordName = $passwordInput.val(),

                     isValidUsername = ValidationController.isUsernameCorrect(username),
                     isValidPassword = ValidationController.isPasswordCorrect(passwordName);


                if (isValidUsername && passwordName) {
                    HttpRequester.getUser('http://localhost:3000/auth', {
                        username: username,
                        autCode: passwordName
                    })
                    .then(function () {
                        _this.setUser(username, passwordName);
                        $loginInput.removeClass('error-validation');
                        window.location = '#/chat';
                    },
                        function (err) {
                            alert('Invalid user');
                        }
                );

                }
                else {
                    $loginInput.addClass('error-validation');
                }
            });

            $wrapper.on('click', '#exit-btn', function () {
                var exit = confirm("Are you sure you want to end the session?");
                if (exit === true) {
                    HttpRequester.logOutUser('http://localhost:3000/user', sessionStorage.getItem('username'))
                    .then(function () {
                        _this.destroyUsername();
                        window.location = '#/login';
                    }, function (err) {
                        console.log(err);
                    })

                    _this.destroyUsername(); //zashtoto gornoto ne raboti
                    window.location = '#/login';
                }
            });

            $wrapper.on('click', '#register-btn', function () {
                if (_this.isLoggedIn()) {
                    window.location = '#/chat';
                    return;
                }
                window.location = '#/register';
            });

            $wrapper.on('click', '#register-user-btn', function () {
                var $regInput = $('#register-name'),
                     username = $regInput.val(),
                     $passwordInput = $('#register-rassword'),
                     passwordName = $passwordInput.val(),

                     isValidUsername = ValidationController.isUsernameCorrect(username),
                     isValidPassword = ValidationController.isPasswordCorrect(passwordName);

                if (isValidUsername && passwordName) {

                    HttpRequester.postJSON('http://localhost:3000/user', {
                        username: username,
                        authCode: passwordName
                    })
                    .then(function () {
                        _this.setUser(username, passwordName);
                        $regInput.removeClass('error-validation');
                        window.location = '#/chat';
                    },
                    function (err) {
                        alert(err.responseJSON.message)
                    }
                    );
                }
                else {
                    $regInput.addClass('error-validation');
                }
            });

            $wrapper.on('click', '#submitmsg', function () {
                var $messageInput = $('#usermsg'),
                    enteredMessage = $messageInput.val().trim(),
                    $title = $('#userTitle'),
                    enteredTitle = $title.val().trim(),
                    postBy = _this.getUsername();

                if (enteredMessage) {
                    HttpRequester.postMessage('http://localhost:3000/post', {
                        title: enteredTitle,
                        body: enteredMessage
                    }, sessionStorage.getItem('username'))
                        .then(function () {
                            $messageInput.val('');
                            var postHtml = UI.buildMessage(enteredTitle, enteredMessage);
                            $('#chatbox').prepend(postHtml);
                            $messageInput.removeClass('error-validation');
                        }, function (err) {
                            $messageInput.addClass('error-validation');
                            alert(err.responseJSON.message);
                        })
                }
                else {
                    $messageInput.addClass('error-validation');
                }
            });
        };

        return Controller;
    }());

    return Controller;
});