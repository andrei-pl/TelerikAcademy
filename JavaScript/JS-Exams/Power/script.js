var x = [
'10 10',
'0 1 2 3 4 5 6 7 8 9'
];

function Solver() {
    solve(x);
}

function solve(params) {
    var firstRow = params[0].split(' ').map(Number),
        secondRow = params[1].split(' ').map(Number),
        i = 0,
        j = 0,
        result = 0;

    for (j = 0; j < firstRow[1]; j++) {
        var temp = [];

        for (i = 0; i < firstRow[0]; i++) {
            
            if (i === 0) {
                temp.push(countNewResult(firstRow[0] - 1, i + 1, i, secondRow));
            } else if (i === firstRow[0] - 1) {
                temp.push(countNewResult(i - 1, 0, i, secondRow));
            } else {
                temp.push(countNewResult(i - 1, i + 1, i, secondRow));
            }
        }

        secondRow = temp;
    }

    for (i = 0; i < secondRow.length; i++) {
        result += secondRow[i];
    }


    function countNewResult(left, right, pivot, arr) {
        var result = 0,
            lNumber = arr[left],
            rNumber = arr[right],
            pNumber = arr[pivot];

        if (pNumber === 0) {
            result = lNumber - rNumber;
        } else if (pNumber === 1) {
            result = lNumber + rNumber;
        } else if (pNumber % 2 === 0) {
            result = Math.max(lNumber, rNumber);
        } else {
            result = Math.min(lNumber, rNumber);
        }

        return Math.abs(result);
    }

    console.log(result);
}