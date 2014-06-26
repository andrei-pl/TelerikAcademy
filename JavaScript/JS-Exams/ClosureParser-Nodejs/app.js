function Solve( input ) {


    return result;
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

Solve( x1 );