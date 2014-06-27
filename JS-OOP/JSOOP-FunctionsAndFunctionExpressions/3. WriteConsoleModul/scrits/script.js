var specialConsole = (function () {
    'use strict';
    function format(args) {
        var result = "";

        if (args.length <= 1) {
            return args[0];
        }
        else {
            var i,
                num;

            for (i = 0; i < args[0].length; i++) {
                if (args[0][i] == '{') {
                    num = '';
                    i += 1;

                    while (args[0][i] != '}') {
                        num += args[0][i];
                        i += 1;
                    }
                    result += args[Number(num) + 1];
                }
                else {
                    result += args[0][i];
                }
            }
        }
        return result;      //nqma nujda ot toString, zashtoto taka ili inache vsichko veche e string
    }

    function writeLine() {
        console.log(format(arguments));
    }

    function writeError() {
        console.error(format(arguments));
    }

    function writeWarning() {
        console.warn(format(arguments));
    }

    return {
        writeLine: writeLine,
        writeError: writeError,
        writeWarning: writeWarning
    };
}());