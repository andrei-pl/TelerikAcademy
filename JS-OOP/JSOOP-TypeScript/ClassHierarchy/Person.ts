'use strict'

module Person {

    export class Human implements Interfaces.IPerson, Interfaces.IDisplayInfo {
        private _firstName: string;
        private _lastName: string;
        private _age: number;
        private _isHaveVehicle: boolean;
        private _vehicle: Vehicle.Mashine;

        constructor(firstName: string, lastName: string, age: number, isHaveVehicle: boolean) {
            this._firstName = firstName;
            this._lastName = lastName;
            this._age = age;
            this._isHaveVehicle = isHaveVehicle;
        }

        get firstName() {
            return this._firstName;
        }

        get lastName() {
            return this._lastName;
        }

        get age() {
            return this._age;
        }

        get isHaveVehicle() {
            return this._isHaveVehicle;
        }

        get vehicle() {
            return this._vehicle;
        }

        set vehicle(value: Vehicle.Mashine) {
            if (!this.isHaveVehicle) {
                console.log("This Person don't have vehicle");
            }
            this._vehicle = value;
        }

        displayInfo() {
            if (this.isHaveVehicle) {
                return this.firstName + ' ' + this.lastName + ': ' + this.age + 'years old. Have vehicle ' + this.vehicle.displayInfo();
            }
            return this.firstName + ' ' + this.lastName + ': ' + this.age + 'years old.';
        }
    }

    export enum examType {
        'JSOOP',
        'KPK',
        'BusinessSkills'
    }

    export class Student extends Human implements Interfaces.IDisplayInfo {
        private _grade: number;

        constructor(firstName: string, lastName: string, age: number, grade: number, isHaveVehicle: boolean) {
            super(firstName, lastName, age, isHaveVehicle);
            this._grade = grade;
        }


        makeExam(exam: examType) {
            console.log(this.firstName + ' ' + this.lastName + ' start ' + exam + ' exam.');
        }

        displayInfo() {
            return this._grade + ' grade.' + super.displayInfo();
        }
    }

    export class Worker extends Human implements Interfaces.IDisplayInfo {
        private _salary: number;

        constructor(firstName: string, lastName: string, age: number, salary: number, isHaveVehicle: boolean) {
            super(firstName, lastName, age, isHaveVehicle);
            this._salary = salary;
        }

        startWorking() {
            console.log(this.firstName + ' ' + this.lastName + ' is now working.');
        }

        stoptWorking() {
            console.log(this.firstName + ' ' + this.lastName + ' stoped working.');
        }

        displayInfo() {
            return super.displayInfo() + this._salary + ' is month salary.';
        }
    }
}