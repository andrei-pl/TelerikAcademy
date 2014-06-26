function Solve(input) {
//    var parser = [];
    
//    //Not finished... Sorry!

//    for (var i = 0; i < input.length; i++) {
//        parser[i] = input[i].toString().trim();
//        parser[i] = parser[i].replace('(', '');
//        parser[i] = parser[i].substring(0, parser[i].length - 1).trim();
//    }

//    var obj = {};
//    var op = '';
//    var parserArr = [];
//    var currResult = 0;
//    var prevResult = 0;
//    var mathematica = false;

//    for (var j = 0; j < parser.length; j++) {

//        if (j === 0) {
//            if (isAritmethicOperator(parser[j][0])) {
//                op = parser[j][0];
//                parserArr = parser[j].substring(1, parser[j].length).split(' ');
//                mathematica = true;
//            } else {
//                parserArr = parser[j].split(' ');

//                mathematica = false;
//            }

//            if (mathematica) {
//                prevResult = parserArr[0];
//                for (var m = 1; m < parserArr.length; m++) {
//                    var currNumber = parserArr[m];

//                    currResult = Calculate(currNumber);
//                    prevResult = currResult;
//                }

//            }
//        }
//    }

//    function Calculate(currentNumber) {
//        switch (op) {
//            case '+':
//                if (isNumber(currNumber)) {
//                    return prevResult + currentNumber;
//                } else {
//                    return prevResult + obj.currNumber;
//                }
//                break;
//            case '-':
//                if (isNumber(currNumber)) {
//                    return prevResult - currentNumber;
//                } else {
//                    return prevResult - obj.currNumber;
//                }
//                break;
//            case '*':
//                if (isNumber(currNumber)) {
//                    return prevResult * currentNumber;
//                } else {
//                    return prevResult * obj.currNumber;
//                }
//                break;
//            case '/':
//                if (isNumber(currNumber)) {
//                    return parseInt(prevResult / currentNumber);
//                } else {
//                    return parseInt(prevResult / obj.currNumber);
//                }
//                break;

//        }
//    }

//    function isNumber(number) {
//        if (parseInt(number) % 1 === 0) {
//            return true;
//        }
//        return false;
//    }

//    function isAritmethicOperator(op) {
//        if (op === '+' || op === '-' || op === '*' || op === '/') {
//            return true;
//        }

//        return false;
//    }

    //    return result;

    var inputArr = input;
    for (var i = 0; i < inputArr.lenght; i++) {
        inputArr[i] = inputArr[i].trim();
    }

    var currentArr = [];
}

var x1 = [
    '(def func 10)',
    '(def newFunc (+  func 2))',
    '(def sumFunc (+ func func newFunc 0 0 0))',
    '(* sumFunc 2)'
];

var x2 = [
    '(def func (+ 5 2))',
    '(def func2 (/  func 5 2 1 0))',
    '(def func3 (/ func 2))',
    '(+ func3 func)'
]

var x3 = [
    '(def myFunc 5)',
    '(def myNewFunc (+  myFunc  myFunc 2))',
    '(def MyFunc (* 2  myNewFunc))',
    '(/   MyFunc  myFunc)'
]

function Solver() {
    Solve(x1);
}