var Shape = (function () {

    function Shape(canvas) {
        if (!(this instanceof arguments.callee)) {
            return new Shape(canvas);
        }

        this.context = canvas;
    }

    function fillShape() {
        context.fillStyle = fillColor;
        context.strokeStyle = strokeColor;
        context.fill();
        context.stroke();
    }

    Shape.prototype = {
        drawCircle: function (centerX, centerY, radius, fillColor, strokeColor) {
            context.beginPath();
            context.arc(centerX, centerY, radius, 0, 2 * Math.PI, false);
            fillShape.call(this);
            context.closePath();
        },

        drawRect: function (left, top, width, height, fillColor, strokeColor) {
            context.beginPath();
            context.rect(left, top, width, height);
            fillShape.call(this);
            context.closePath();
        },

        drawLine: function (startX, startY, endX, endY, fillColor, strokeColor) {
            context.beginPath();
            context.moveTo(startX, startY);
            context.lineTo(endX, endY);
            fillShape.call(this);
            context.closePath();
        }
    }

    return Shape;
}())