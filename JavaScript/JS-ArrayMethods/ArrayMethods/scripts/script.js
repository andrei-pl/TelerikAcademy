//  1. Write a function for creating persons.
//  Each person must have firstname, lastname, age and gender (true is female, false is male)
//  Generate an array with ten person with different names, ages and genders

function Person(firstName, lastName, age, isFemale) {

    this.firstName = firstName;
    this.lastName = lastName;
    this.age = age;
    this.gender = isFemale ? "female" : "male";
}

var persons = [
new Person('Gosho', 'Potnika', 17, false),
new Person('Pesho', 'Peshev', 13, false),
new Person('Gloria', 'Gaynor', 50, true),
new Person('Marilyn', 'Monroe', 35, true),
new Person('John', 'Atanasov', 75, false),
new Person('Arnold', 'Shwarzeneger', 59, false),
new Person('Tom', 'Cruise', 45, false),
new Person('Angelina', 'Jolie', 41, true),
new Person('Brad', 'Pitt', 42, false),
new Person('Pepa', 'Ulloa', 26, true)
];

// list 10 persons
persons.forEach(function (item, index) {
    console.log('Index' + index + ' ' + JSON.stringify(item));
});

// 2. Write a function that checks if an array of person contains only people of age (with age 18 or greater)
//    Use only array methods and no regular loops (for, while)

function areAllAdult(arr) {
    return arr.every(function (item) {
        return item.age >= 18;
    })
}

console.log("All adult: " + areAllAdult(persons));

//  3. Write a function that prints all underaged persons of an array of person
//     Use Array#filter and Array#forEach
//     Use only array methods and no regular loops (for, while)


var underaged = persons.filter(function (item) {
    return item.age < 18;
});

console.log('All underaged persons: ');
underaged.forEach(function (item) {
    console.log(JSON.stringify(item));
})

//  4. Write a function that calculates the average age of all females, extracted from an array of persons
//     Use Array#filter
//     Use only array methods and no regular loops (for, while)

var allFemale = persons.filter(function (item) {
    return item.gender == "female";
})

var averageFemaleAge = allFemale.reduce(function (averageFemaleAge, person) {
    return averageFemaleAge + person.age;
}, 0);

console.log('The average age of all women is: ' + averageFemaleAge);

// 5. Write a function that finds the youngest male person in a given array of people and prints his full name
//    Use only array methods and no regular loops (for, while)
//    Use Array#find

if (!Array.prototype.find) {
    Array.prototype.find = function (callback) {
        var i, len = this.length;
        for (i = 0; i < len; i += 1) {
            if (callback(this[i], i, this)) {
                return this[i];
            }
        }
    }
}

persons.sort(function (a, b) {
    return a.age - b.age;
})

var youngestPerson = persons.find(function (item) {

    if (item !== undefined) {
        return item;
    }
});

console.log('The youngest person is: ');
console.log(youngestPerson.firstName + ' ' + youngestPerson.lastName);

//  6. Write a function that groups an array of persons by first letter of first name and returns the groups as a JavaScript Object
//     Use Array#reduce
//     Use only array methods and no regular loops (for, while)
//     Example:

//        result = {
//            'a': [{
//                firstname: 'Asen',
//                /* ... */
//            }, {
//                firstname: 'Anakonda',
//                /* ... */
//            }],
//            'j': [{
//                firstname: 'John',
//                /* ... */
//            }]
//        };

var reducedPersons = persons.reduce(function (obj, item) {
    if (!obj[item.firstName[0]]) {
        obj[item.firstName[0]] = [item];
    } else {
        obj[item.firstName[0]].push(item);
    }

    return obj;
}, {})

console.log("Grouped persons: ");
console.log(JSON.stringify(reducedPersons));