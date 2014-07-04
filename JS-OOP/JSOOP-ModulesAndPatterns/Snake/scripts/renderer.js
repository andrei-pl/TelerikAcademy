var Renderer = (function () {
    "use strict";

    function drawAll(score) {
        MyCanvas.clear();
        drawScore(score);
        drawSnake();
        drawApple();
    }

    function drawScore(score) {
        MyCanvas.drawText(40, 40, score, 30, "Arial", "red");
    }

    function drawSnake() {
        var i, x, y;
        var coordinates = Snake.getCoordinates();

        for (i = 0; i < coordinates.length; i += 1) {
            x = coordinates[i].x;
            y = coordinates[i].y;

            MyCanvas.drawRectangle(x, y, 10, 10, 'white', "red");
        }
    }

    function drawApple() {
        MyCanvas.drawRectangle(Apple.getCoordinate().x, Apple.getCoordinate().y, 10, 10, 'white', 'blue');
    }

    return {
        drawAll: drawAll
    }

})();