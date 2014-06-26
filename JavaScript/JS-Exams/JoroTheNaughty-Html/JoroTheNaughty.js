function Solve(args) {
    var firstRow = args[0].split(' ').map(Number);
    var rows = firstRow[0];
    var cols = firstRow[1];
    var jumps = firstRow[2];

    var secondRow = args[1].split(' ').map(Number);
    var row = secondRow[0];
    var col = secondRow[1];

    var jumpsArr = [];
    for (var m = 2; m < jumps + 2; m += 1) {
        var jumpMoves = args[m].split(' ').map(Number);
        var obj = {
            row: jumpMoves[0],
            col: jumpMoves[1]
        };
        jumpsArr.push(obj);
    }

    var points = 0;
    var jumpsNumber = 0;
    var indexJumpsArr = 0;
    var isEscaped = true;
    var matrix = [];
    var count = 1;

    for (var i = 0; i < rows; i++) {
        matrix[i] = [];
        for (var j = 0; j < cols; j++) {
            matrix[i][j] = count++;
        }
    }

    while (true) {

        if (row >= rows || row < 0 || col >= cols || col < 0) {
            break;
        }
        if (matrix[row][col] === 0) {
            isEscaped = false;
            break
        }

        jumpsNumber += 1;
        points += matrix[row][col];
        matrix[row][col] = 0;

        row += jumpsArr[indexJumpsArr].row;
        col += jumpsArr[indexJumpsArr].col;

        indexJumpsArr += 1;
        if (indexJumpsArr >= jumpsArr.length) {
            indexJumpsArr = 0;
        }
    }

    console.log( isEscaped ? 'escaped ' + points : 'caught ' + jumpsNumber);
}


var x = [
    '6 7 3',
    '0 0',
    '2 2',
    '-2 2',
    '3 -1'
];

function Solver(){
    Solve(x);
};
