function Solve(input) {
    var cells = input[0].split(' ').map(Number);
    var position = input[1].split(' ').map(Number);
    var values = []
    var matrix = []
    var counter = 1;

    for (var i = 2; i < input.length; i++) {
        values[i - 2] = input[i];
        matrix[i-2] = []
        for (var j = 0; j < values[i - 2].length; j++) {
            matrix[i - 2][j] = counter++;
        }
    }

    var row = position[0];
    var col = position[1];
    var isOut = false;
    var result = 0;
    var count = 0;

    while (true) {
        if (row >= cells[0] || row < 0 || col >= cells[1] || col < 0) {
            isOut = true;
            break;
        }
        if (matrix[row][col] === 0) {
            isOut = false;
            break;
        }

        result += matrix[row][col];
        count++;
        matrix[row][col] = 0;
        var value = values[row][col];
        switch(value)
        {
            case 'l': col--; break;
            case 'r': col++; break;
            case 'u': row--; break;
            case 'd': row++; break;
        }
    }

    return isOut ? 'out ' + result : 'lost ' + count;
}

var x = [
"5 8",
 "0 0",
 "rrrrrrrd",
 "rludulrd",
 "lurlddud",
 "urrrldud",
 "ulllllll"];

function Solver() {
    Solve(x);
}