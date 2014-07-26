/// <reference path="bower_components/underscore/underscore.js" />
(function () {
    if (typeof require !== 'undefined') {
        //load underscore if on Node.js
        _ = require('bower_components/underscore/underscore.js');
    }

    //Write a method that from a given array of students finds all students whose first name is before its last name alphabetically. 
    //Print the students in descending order by full name. Use Underscore.js

    var Student = (function () {

        function Student(firstName, lastName, age, mark) {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
            this.mark = mark;
        }

        return Student;
    }());

    var students = [
        new Student('Stoqn', 'Stoqnov', 31, 6),
        new Student('Pesho', 'Ivanov', 29, 5.6),
        new Student('Ivan', 'Peshov', 25, 3.3),
        new Student('Ivan', 'Ivanov', 25, 4.5),
        new Student('Mariq', 'Kehaiova', 18, 4.3),
        new Student('Toni', 'Storaro', 24, 5.3),
    ];

    var firstNameBeforLastNameAlphabetically = _.chain(students)
                                                .filter(function (student) {
                                                return student.firstName < student.lastName;
                                                }, students)
                                                .sortBy(function (x) {
                                                    return x.firstName;
                                                });

    console.log(firstNameBeforLastNameAlphabetically);

    //Write function that finds the first name and last name of all students with age between 18 and 24. Use Underscore.js

    var findStudentsBetween18and24 = _.chain(students)
                                    .filter(function (student) {
                                    return (student.age >= 18) && (student.age <= 24);
                                    }, students)
                                    .sortBy(function (x) {
                                        return x.firstName;
                                    });

    console.log(findStudentsBetween18and24);

    //Write a function that by a given array of students finds the student with highest marks

    var sortStudentByBiggestMark = _.sortBy(students, "mark");
    var findStudentWithBiggestMark = _.last(sortStudentByBiggestMark);

    console.log(findStudentWithBiggestMark);

    //Task7
    //By an array of people find the most common first and last name. Use underscore.

    var mostCommonFirstName = _.countBy(students, "firstName"),
        mostCommonLastName = _.countBy(students, "lastName"),
        maxName,
        maxIndex;

    maxIndex = _.max(mostCommonFirstName);
    maxName = (_.invert(mostCommonFirstName))[maxIndex];

    console.log(maxName + ', it appears ' + maxIndex + ' times.')

    maxIndex = _.max(mostCommonLastName);
    maxName = (_.invert(mostCommonLastName))[maxIndex];

    console.log(maxName + ', it appears ' + maxIndex + ' times.')
}())