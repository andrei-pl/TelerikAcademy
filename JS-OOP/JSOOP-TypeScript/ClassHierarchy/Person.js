'use strict';
var __extends = this.__extends || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    __.prototype = b.prototype;
    d.prototype = new __();
};
var Person;
(function (Person) {
    var Human = (function () {
        function Human(firstName, lastName, age, isHaveVehicle) {
            this._firstName = firstName;
            this._lastName = lastName;
            this._age = age;
            this._isHaveVehicle = isHaveVehicle;
        }
        Object.defineProperty(Human.prototype, "firstName", {
            get: function () {
                return this._firstName;
            },
            enumerable: true,
            configurable: true
        });

        Object.defineProperty(Human.prototype, "lastName", {
            get: function () {
                return this._lastName;
            },
            enumerable: true,
            configurable: true
        });

        Object.defineProperty(Human.prototype, "age", {
            get: function () {
                return this._age;
            },
            enumerable: true,
            configurable: true
        });

        Object.defineProperty(Human.prototype, "isHaveVehicle", {
            get: function () {
                return this._isHaveVehicle;
            },
            enumerable: true,
            configurable: true
        });

        Object.defineProperty(Human.prototype, "vehicle", {
            get: function () {
                return this._vehicle;
            },
            set: function (value) {
                if (!this.isHaveVehicle) {
                    console.log("This Person don't have vehicle");
                }
                this._vehicle = value;
            },
            enumerable: true,
            configurable: true
        });


        Human.prototype.displayInfo = function () {
            if (this.isHaveVehicle) {
                return this.firstName + ' ' + this.lastName + ': ' + this.age + 'years old. Have vehicle ' + this.vehicle.displayInfo();
            }
            return this.firstName + ' ' + this.lastName + ': ' + this.age + 'years old.';
        };
        return Human;
    })();
    Person.Human = Human;

    (function (examType) {
        examType[examType['JSOOP'] = 0] = 'JSOOP';
        examType[examType['KPK'] = 1] = 'KPK';
        examType[examType['BusinessSkills'] = 2] = 'BusinessSkills';
    })(Person.examType || (Person.examType = {}));
    var examType = Person.examType;

    var Student = (function (_super) {
        __extends(Student, _super);
        function Student(firstName, lastName, age, grade, isHaveVehicle) {
            _super.call(this, firstName, lastName, age, isHaveVehicle);
            this._grade = grade;
        }
        Student.prototype.makeExam = function (exam) {
            console.log(this.firstName + ' ' + this.lastName + ' start ' + exam + ' exam.');
        };

        Student.prototype.displayInfo = function () {
            return this._grade + ' grade.' + _super.prototype.displayInfo.call(this);
        };
        return Student;
    })(Human);
    Person.Student = Student;

    var Worker = (function (_super) {
        __extends(Worker, _super);
        function Worker(firstName, lastName, age, salary, isHaveVehicle) {
            _super.call(this, firstName, lastName, age, isHaveVehicle);
            this._salary = salary;
        }
        Worker.prototype.startWorking = function () {
            console.log(this.firstName + ' ' + this.lastName + ' is now working.');
        };

        Worker.prototype.stoptWorking = function () {
            console.log(this.firstName + ' ' + this.lastName + ' stoped working.');
        };

        Worker.prototype.displayInfo = function () {
            return _super.prototype.displayInfo.call(this) + this._salary + ' is month salary.';
        };
        return Worker;
    })(Human);
    Person.Worker = Worker;
})(Person || (Person = {}));
//# sourceMappingURL=Person.js.map
