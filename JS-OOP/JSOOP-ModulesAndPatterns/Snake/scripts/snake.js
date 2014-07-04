var Snake = function () {
    "use strict";

    var INITIAL_DIRECTION = "d";

    var coordinates = [
        new Coordinate(100, 60),
        new Coordinate(110, 60),
        new Coordinate(120, 60),
        new Coordinate(130, 60),
        new Coordinate(140, 60),
        new Coordinate(150, 60),
        new Coordinate(160, 60),
        new Coordinate(170, 60)
    ];

    var speed = 10;
    var direction = INITIAL_DIRECTION;
    var isKeyPressed = false;
    var isDead = false;
    var hasApple = false;

    function updateDirection(keyCode) {
        switch (keyCode) {
            case 37:
                if (direction !== "r") {
                    direction = "l";
                    isKeyPressed = true;
                }
                break;
            case 38:
                if (direction !== "d") {
                    direction = "u";
                    isKeyPressed = true;
                }
                break;
            case 39:
                if (direction !== "l") {
                    direction = "r";
                    isKeyPressed = true;
                }
                break;
            case 40:
                if (direction !== "u") {
                    direction = "d";
                    isKeyPressed = true;
                }
                break;
        }
        move();
    }

    function getCoordinates() {
        return coordinates;
    }

    function update() {
        if (isKeyPressed) {
            isKeyPressed = false;
        } else {
            move();
        }

        return isDead;
    }

    function move() {
        var currentPosition = coordinates[0];
        var newX, newY;

        if (direction === "d") {
            newX = currentPosition.x;
            newY = currentPosition.y + speed;
        } else if (direction === "u") {
            newX = currentPosition.x;
            newY = currentPosition.y - speed;
        } else if (direction === "l") {
            newX = currentPosition.x - speed;
            newY = currentPosition.y;
        } else if (direction === "r") {
            newX = currentPosition.x + speed;
            newY = currentPosition.y;
        }

        var newPosition = new Coordinate(newX, newY);
        checkCollision(newPosition);
        coordinates.unshift(newPosition);

        if (hasApple) {
            hasApple = false;
        } else {
            coordinates.pop();
        }
    }

    function checkCollision(position) {
        if (coordinates.contains(position) || position.x < 0 || position.x > MyCanvas.width() - 1
            || position.y > MyCanvas.height() - 1 || position.y < 0) {
            isDead = true;
        }
    }

    function eat() {
        hasApple = true;
    }

    return {
        updateDirection: updateDirection,
        isKeyPressed: isKeyPressed,
        getCoordinates: getCoordinates,
        update: update,
        eat: eat
    };
}();