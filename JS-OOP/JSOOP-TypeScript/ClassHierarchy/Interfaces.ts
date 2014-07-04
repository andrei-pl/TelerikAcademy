'use strict'

module Interfaces {

    export interface IMovable {
        move(): void;
    };

    export interface IVehicle {
        isMoving: boolean;
        company: string;
        model: string;
        year: number;
        move();
    }

    export interface IDisplayInfo {
        displayInfo(): string;
    }

    export interface IPerson {
        firstName: string;
        lastName: string;
        age: number;
    }
}