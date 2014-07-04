'use strict'

module Vehicle {

    export class Mashine implements Interfaces.IMovable, Interfaces.IDisplayInfo {
        private _isMoving: boolean;
        private _company: string;
        private _model: string;
        private _year: number;

        constructor(company: string, model: string, year: number) {
            this._company = company;
            this._model = model;
            this._year = year;
            this._isMoving = false;
        }

        get company() {
            return this._company;
        }

        get model() {
            return this._model;
        }

        get year() {
            return this._year;
        }

        get isMoving() {
            return this._isMoving;
        }

        move() {
            if (!this.isMoving) {
                this._isMoving = true;
                console.log('Started moving');
            }
            else {
                console.log('Already moving');
            }
        }

        stop() {
            this._isMoving = false;
            console.log('Stoped');
        }

        displayInfo() {
            return this.company + ' ' + this.model + ' ' + this.year + ' year.'
        }
    }

    export class Car extends Mashine implements Interfaces.IDisplayInfo {
        private _power: number;

        constructor(company: string, model: string, year: number, power: number) {
            super(company, model, year);
            this._power = power;
        }

        get power() {
            return this._power;
        }

        static beep() {
            console.log('Beep');
        }

        displayInfo() {
            return super.displayInfo() + this.power + 'hp.';
        }
    }

    export class Bike extends Mashine implements Interfaces.IDisplayInfo {
        private _gears: number;

        constructor(company: string, model: string, year: number, gears: number) {
            super(company, model, year);
            this._gears = gears;
        }

        get gears() {
            return this._gears;
        }

        displayInfo() {
            return super.displayInfo() + this.gears + ' gears.';
        }
    }
}