/// <reference path="bower_components/underscore/underscore.js" />
(function () {
    if (typeof require !== 'undefined') {
        //load underscore if on Node.js
        _ = require('bower_components/underscore/underscore.js');
    }

    //Write a function that by a given array of animals, groups them by species and sorts them by number of legs

    var Animal = (function () {

        function Animals(specie, name, numberOfLegs) {
            this.specie = specie;
            this.name = name;
            this.numberOfLegs = numberOfLegs;
        }

        return Animals;
    }());

    var animals = [
            new Animal('dog', 'Sharo', 4),
            new Animal('dog', 'Max', 4),
            new Animal('dog', 'Arq', 4),
            new Animal('dog', 'Rex', 4),
            new Animal('cat', 'Pisana', 4),
            new Animal('cat', 'Chernio', 4),
            new Animal('pig', 'Koleda', 4),
            new Animal('pig', 'Velikden', 4),
            new Animal('parrot', 'Poli', 2),
            new Animal('parrot', 'Arq', 2),
            new Animal('human', 'Dimo', 2),
            new Animal('human', 'Ivan', 2),
            new Animal('spider', 'Penio', 8),
            new Animal('spider', 'Valio', 8),
            new Animal('hlebarka', 'Mima', 6),
            new Animal('hlebarka', 'Raq', 6),
            new Animal('stonojka', 'Jane', 100),
            new Animal('stonojka', 'Tushtata', 100)
    ];

    var groupBySpecies = _.groupBy(animals, "specie");
    var sortSpeciesByLegsNumber = _.sortBy(groupBySpecies, function (animal) {
                                 return animal[0].numberOfLegs;
                             })
    console.log(sortSpeciesByLegsNumber);

    //By a given array of animals, find the total number of legs
    //Each animal can have 2, 4, 6, 8 or 100 legs

    var totalNumberOfLegs = _.reduce(animals, function (memo, animal) {
                                return memo + animal.numberOfLegs;
                            }, 0);

    console.log(totalNumberOfLegs + " legs.");

}())