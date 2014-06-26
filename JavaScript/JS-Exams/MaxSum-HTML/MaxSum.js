function Solve(input) {

    var inputArr = parseInt(input[0]);
    var values = [];

    for (var i = 1; i < input.length; i++) {
        values[i - 1] = parseInt(input[i]);
    }

    var tempCount = 1;
    var count = 1;
    var tempResult = values[0];
    var result = values[0];

    for (var m = 0; m < values.length; m++) {
        tempCount = 0;
        tempResult = 0;

        for (var n = m; n < values.length; n++) {
            tempCount++;
            tempResult += values[n];

            if (tempResult >= result) {
                result = tempResult;
                count = tempCount;

            }
        }
    }

    return result;
}

var x = [
9,
- 9,
- 8,
- 8,
- 7,
- 6,
- 5,
- 1,
- 7,
- 6

];

function Solver() {
    Solve(x);
}