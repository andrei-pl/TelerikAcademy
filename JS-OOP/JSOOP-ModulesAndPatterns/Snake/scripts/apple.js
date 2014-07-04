var Apple = (function () {
    "use strict";

    var coordinate = Coordinate.getRandomCoordinate();

    function getCoordinate() {
        return coordinate;
    }

    function setCoordinate(position) {
        coordinate = position;
    }

    return {
        getCoordinate: getCoordinate,
        setCoordinate: setCoordinate
    }
})();

