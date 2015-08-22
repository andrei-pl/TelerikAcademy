function solve(params) {
    var rows = parseInt(params[0]),
        cols = parseInt(params[1]),
        table = params.slice(2, rows + 2).map(function (item) {
            return item.split('');
        }),
        tests = parseInt(params[rows + 2]),
        moves = params.slice(rows + 3).map(function (item) {
            return item.split(' ');
        }),
        i = 0,
        move = '-',
        figure = '-',
        result = 0;

    for (i = 0; i < tests; i++) {
        var figureIndex = moves[i][0];
        var moveIndex = moves[i][1];

        figure = checkPosition(figureIndex);
        move = checkPosition(moveIndex);

        var canMove = checkValidMove(returnRow(figureIndex), returnCol(figureIndex), returnRow(moveIndex), returnCol(moveIndex))
        console.log(canMove ? 'yes' : 'no');
    }

    function checkValidMove(rowFigure, colFigure, rowMove, colMove) {
        switch (figure) {
            case 'Q':
                if (rowFigure == rowMove && colFigure == colMove) {
                    return false;
                }
                var rowMoves = Math.abs(rowFigure - rowMove),
                        colMoves = Math.abs(colFigure - colMove),
                        lRow, rRow, lCol, rCol,
                            isRowEmpty = true,
                            isColEmpty = true;

                if (rowFigure < rowMove) {
                    lRow = rowFigure;
                    rRow = rowMove;
                    lCol = colFigure;
                    rCol = colMove;
                } else {
                    lRow = rowMove;
                    rRow = rowFigure;
                    lCol = colMove;
                    rCol = colFigure;
                }

                if (rowFigure === rowMove || colFigure === colMove) {
                    if (lCol == colFigure && lCol != rCol) {
                        lCol++;
                    }

                    if (lRow == rowFigure && lRow != rRow) {
                        lRow++;
                    }

                    if (lCol == rCol) {
                        isRowEmpty = checkIsRowEmpty(lRow, rRow, lCol);
                    } else {
                        isColEmpty = checkIsColEmpty(lCol, rCol, lRow);
                    }

                    return isRowEmpty && isColEmpty;
                } else if (rowFigure != rowMove && colFigure != colMove) {
                    if (lCol == colFigure || lRow == rowFigure) {
                        if (lCol < rCol) {
                            lCol++;
                        } else {
                            lCol--;
                        }
                        lRow++
                    }

                    if (rowMoves === colMoves && move == '-') {
                        while (true) {
                            if (lRow == rRow && lCol == rCol) {
                                return true;
                            }

                            if (table[lRow][lCol] != '-') {
                                return false;
                            }

                            lRow++;
                            if (lCol < rCol) {
                                lCol++;
                            } else {
                                lCol--;
                            }
                        }
                    }
                }
                return false;
            case 'B':
                if (rowFigure == rowMove && colFigure == colMove) {
                    return false;
                }
                var rowMoves = Math.abs(rowFigure - rowMove),
                        colMoves = Math.abs(colFigure - colMove),
                        lRow, rRow, lCol, rCol,
                            isRowEmpty = true,
                            isColEmpty = true;

                if (rowFigure < rowMove) {
                    lRow = rowFigure;
                    rRow = rowMove;
                    lCol = colFigure;
                    rCol = colMove;
                } else {
                    lRow = rowMove;
                    rRow = rowFigure;
                    lCol = colMove;
                    rCol = colFigure;
                }

                if (rowFigure != rowMove && colFigure != colMove) {
                    if (lCol == colFigure || lRow == rowFigure) {
                        if (lCol < rCol) {
                            lCol++;
                        } else {
                            lCol--;
                        }
                        lRow++
                    }

                    if (rowMoves === colMoves && move == '-') {
                        while (true) {
                            if (lRow == rRow && lCol == rCol) {
                                return true;
                            }

                            if (table[lRow][lCol] != '-') {
                                return false;
                            }

                            lRow++;
                            if (lCol < rCol) {
                                lCol++;
                            } else {
                                lCol--;
                            }
                        }
                    }
                }
                return false;
            case 'R':
                if (rowFigure == rowMove && colFigure == colMove) {
                    return false;
                }
                if (rowFigure === rowMove || colFigure === colMove) {
                    var lRow,
                        rRow,
                        lCol,
                        rCol,
                    isRowEmpty = true,
                    isColEmpty = true;

                    if (rowFigure < rowMove) {
                        lRow = rowFigure;
                        rRow = rowMove;
                        lCol = colFigure;
                        rCol = colMove;
                    } else {
                        lRow = rowMove;
                        rRow = rowFigure;
                        lCol = colMove;
                        rCol = colFigure;
                    }

                    if (lCol == colFigure && lCol != rCol) {
                        lCol++;
                    }

                    if (lRow == rowFigure && lRow != rRow) {
                        lRow++;
                    }

                    if (lCol == rCol) {
                        isRowEmpty = checkIsRowEmpty(lRow, rRow, lCol);
                    } else {
                        isColEmpty = checkIsColEmpty(lCol, rCol, lRow);
                    }

                    return isRowEmpty && isColEmpty;
                }
                return false;
            default: return false;
        }
    }

    function checkIsRowEmpty(lRow, rRow, col) {
        if (lRow < rRow) {
            for (var m = lRow; m <= rRow; m++) {
                if (table[m, col] != '-') {
                    return false;
                }
            }
        } else {
            for (var m = lRow; m > rRow; m--) {
                if (table[m, col] != '-') {
                    return false;
                }
            }
        }

        return true;
    }

    function checkIsColEmpty(lCol, rCol, row) {
        if (lCol < rCol) {
            for (var n = lCol; n <= rCol; n++) {
                var tabSymbol = table[row][n];
                if (tabSymbol !== '-') {
                    return false;
                }
            }
        } else {
            for (var n = lCol; n > rCol; n--) {
                var tabSymbol = table[row][n];
                if (tabSymbol !== '-') {
                    return false;
                }
            }
        }
        return true;
    }

    function returnRow(val) {
        return rows - parseInt(val[1]);
    }

    function returnCol(val) {
        return 'abcdefghijklmnopqrstuvwxyz'.indexOf(val[0]);
    }

    function checkPosition(position) {
        var row = returnRow(position);
        var col = returnCol(position);

        return table[row][col];
    }
}

var x = [
        '5',
        '5',
        'Q---Q',
        '-----',
        '-B---',
        '--R--',
        'Q---Q',
        '10',
        'a1 a1',
        'a1 d4',
        'e1 b4',
        'a5 d2',
        'e5 b2',
        'b3 d5',
        'b3 a2',
        'b3 d1',
        'b3 a4',
        'c2 c5',

];
var y = [
    '3',
'4',
'--R-',
'B--B',
        'Q--Q',
        '12',
        'd1 b3',
        'a1 a3',
        'c3 b2',
        'a1 c1',
        'a1 b2',
        'a1 c3',
        'a2 b3',
        'd2 c1',
        'b1 b2',
        'c3 b1',
        'a2 a3',
        'd1 d3',

]
function Solver() {
    solve(x);
}