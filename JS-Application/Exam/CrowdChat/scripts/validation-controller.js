define(function() {
    var ValidationController = (function() {
        function isUsernameCorrect(username) {
            var isValidUsername = username && typeof username == 'string' &&
                                  username.length >= 4 && username.length <= 20;
            return isValidUsername;
        }

        function isPasswordCorrect(password) {
            var isValidPassword = password && typeof password == 'string' &&
                                  password.length >= 6;
            return isValidPassword;
        }

        return {
            isUsernameCorrect: isUsernameCorrect,
            isPasswordCorrect: isPasswordCorrect
        }
    }());

    return ValidationController;
});