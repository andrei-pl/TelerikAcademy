'use strict'

/// <reference path="Interfaces.ts" />
/// <reference path="Vehicle.ts" />
/// <reference path="Person.ts" />
var student1 = new Person.Student('Pesho', 'Ivanov', 21, 1, false);
var student2 = new Person.Student('Gosho', 'Petrov', 23, 1, true);
var worker = new Person.Worker('Ivan', 'Ivanov', 32, 1200, true);
var car = new Vehicle.Car('Renault', 'Megane', 2007, 100);
worker.vehicle = car;
student1.vehicle = new Vehicle.Bike('BMW', 'X5', 2009, 150);
student2.vehicle = new Vehicle.Bike('Balkanche', 'Planinsko', 1992, 3);

student1.makeExam(Person.examType.JSOOP);
student2.makeExam(Person.examType.KPK);

worker.vehicle.move();
worker.vehicle.stop();
console.log(worker.displayInfo());
console.log(student1.displayInfo());
console.log(student2.displayInfo());
Vehicle.Car.beep();