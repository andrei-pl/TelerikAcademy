'use strict';
var __extends = this.__extends || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    __.prototype = b.prototype;
    d.prototype = new __();
};
var Vehicle;
(function (Vehicle) {
    var Mashine = (function () {
        function Mashine(company, model, year) {
            this._company = company;
            this._model = model;
            this._year = year;
            this._isMoving = false;
        }
        Object.defineProperty(Mashine.prototype, "company", {
            get: function () {
                return this._company;
            },
            enumerable: true,
            configurable: true
        });

        Object.defineProperty(Mashine.prototype, "model", {
            get: function () {
                return this._model;
            },
            enumerable: true,
            configurable: true
        });

        Object.defineProperty(Mashine.prototype, "year", {
            get: function () {
                return this._year;
            },
            enumerable: true,
            configurable: true
        });

        Object.defineProperty(Mashine.prototype, "isMoving", {
            get: function () {
                return this._isMoving;
            },
            enumerable: true,
            configurable: true
        });

        Mashine.prototype.move = function () {
            if (!this.isMoving) {
                this._isMoving = true;
                console.log('Started moving');
            } else {
                console.log('Already moving');
            }
        };

        Mashine.prototype.stop = function () {
            this._isMoving = false;
            console.log('Stoped');
        };

        Mashine.prototype.displayInfo = function () {
            return this.company + ' ' + this.model + ' ' + this.year + ' year.';
        };
        return Mashine;
    })();
    Vehicle.Mashine = Mashine;

    var Car = (function (_super) {
        __extends(Car, _super);
        function Car(company, model, year, power) {
            _super.call(this, company, model, year);
            this._power = power;
        }
        Object.defineProperty(Car.prototype, "power", {
            get: function () {
                return this._power;
            },
            enumerable: true,
            configurable: true
        });

        Car.beep = function () {
            console.log('Beep');
        };

        Car.prototype.displayInfo = function () {
            return _super.prototype.displayInfo.call(this) + this.power + 'hp.';
        };
        return Car;
    })(Mashine);
    Vehicle.Car = Car;

    var Bike = (function (_super) {
        __extends(Bike, _super);
        function Bike(company, model, year, gears) {
            _super.call(this, company, model, year);
            this._gears = gears;
        }
        Object.defineProperty(Bike.prototype, "gears", {
            get: function () {
                return this._gears;
            },
            enumerable: true,
            configurable: true
        });

        Bike.prototype.displayInfo = function () {
            return _super.prototype.displayInfo.call(this) + this.gears + ' gears.';
        };
        return Bike;
    })(Mashine);
    Vehicle.Bike = Bike;
})(Vehicle || (Vehicle = {}));
//# sourceMappingURL=Vehicle.js.map
