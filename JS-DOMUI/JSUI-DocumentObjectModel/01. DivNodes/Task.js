(function () {
    //task 1
    function reverse(input) {
        var result = input.split('').reverse().join('');
        return result;
    }

    jsConsole.writeLine(reverse('String'));

    //Task 2
    function areBracketsCorrect(input) {
        var count = 0;

        for (var i = 0; i < input.length; i++) {
            if (input[i] === '(') {
                count++;
            }
            else if (input[i] === ')') {
                count--;
            }
        }

        return count == 0;
    }

    jsConsole.writeLine(areBracketsCorrect('((a+b)/5-d)..as ( 2 + 1(;')); //false
    jsConsole.writeLine(areBracketsCorrect('((a+b)/5-d)..as ( 2 + 1);')); //true

    //Task 3
    function stringOccurances(input, key) {
        input = input.toLowerCase();
        key - key.toLowerCase();
        var count = 0;
        var index = -1;

        while ((index = input.indexOf(key, index + 1)) != -1) {
            count++;
        }

        return count;
    }

    var text = "We are living in an yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";
    var key = 'in';

    jsConsole.writeLine(stringOccurances(text, key)); //9

    //Task 4

    function changeInAllReagion(input) {
        input = input.replace(/<upcase>(.+?)<\/upcase>/gi, function (match, p1) { return p1.toUpperCase() });
        input = input.replace(/<lowcase>(.+?)<\/lowcase>/gi, function (match, p1) { return p1.toLowerCase() });
        input = input.replace(/<mixcase>(.+?)<\/mixcase>/gi,
            function (match, p1) {
                var chanse;
                var result = '';

                for (var i = 0; i < p1.length; i++) {
                    chanse = Math.floor(Math.random() * 2);

                    if (chanse) {
                        result += p1[i].toLowerCase();
                    }
                    else {
                        result += p1[i].toUpperCase();
                    }

                }

                return result;
            });

        return input;
    }

    var txt = 'We are <mixcase>living</mixcase> in a <upcase>yellow submarine</upcase>. We <mixcase>don\'t</mixcase> have <lowcase>anything<\/lowcase> else.';
    jsConsole.writeLine(changeInAllReagion(txt));

    //Task 5
    function replaceSpace(input) {
        return input.replace(/ /g, 'nbsp;');
    }

    var spaces = 'text    with spaces';
    jsConsole.writeLine(replaceSpace(spaces));

    //Task 6

    function removeTags(input) {
        return input.replace(/<[^>]+>/gi, '');
    }

    var textTags = '<html><head><title>Sample site</title></head><body><div>text<div>more text</div>and more...</div>in body</body></html>';
    jsConsole.writeLine(removeTags(textTags));

    // Task 7
    function jsonURL(input) {
        var parseResult = input.match(/(.+?):\/\/(.+?)(\/.+)/i);

        return {
            protocol: parseResult[1],
            server: parseResult[2],
            resourse: parseResult[3]
        }
    }

    var url = 'http://www.supprot.devbg.org/forum/index.php';
    jsConsole.writeLine(JSON.stringify(jsonURL(url)));

    //Task 8
    function replaceAnchors(input) {
        return input.replace(/<a\s+href="(.+?)>(.+?)<\/a>/gi, '[URL=' + '$1]' + '$2' + '[/URL]');
    }

    var anchors = '<p>Please visit <a href="http://academy.telerik. com">our site</a> to choose a training course. Also visit <a href="www.devbg.org">our forum</a> to discuss the courses.</p>';
    jsConsole.writeLine(replaceAnchors(anchors));

    //Task 9
    function extractEmails(input) {
        var re = /([\w][\w\-\.]{0,49})@(([a-zA-Z0-9][a-zA-Z0-9\-]{0,49}\.)+)([a-zA-Z]{2,4})/g;
        return input.match(re);
    }

    var emailsText = 'Pesho.Hristov.Georgiev@gmail.test.papur.com, daljfagf bla bla text bulshit.... gosho, Geshev@abv.bg. Petar.hristov@avb.sektir.bg';
    jsConsole.writeLine(extractEmails(emailsText).join('; '));

    //Таск 10
    function findPolindromes(input) {
        function isPolindrome(word) {
            var isPoli = true;
            for (var i = 0; i < word.length; i++) {
                if (word[i] != word[word.length - i - 1]) {
                    isPoli = false;
                    break;
                }
            }

            return isPoli;
        }

        var words = input.match(/\b\w+\b/gi);
        for (var i = 0; i < words.length; i++) {
            if (isPolindrome(words[i])) {
                jsConsole.writeLine(words[i]);
            }
        }
    }

    var polisAndNonpolis = 'ABBA, lamal exe, Test, Void{} xhex, chllhc';

    findPolindromes(polisAndNonpolis);

    //Task 11
    function formatString(input) {
        var functionArguments = arguments;
        var result;

        result = functionArguments[0].replace(/\{(\d+)\}/g, function (match, p1) {
            return functionArguments[parseInt(p1) + 1];
        });

        return result;
    }

    jsConsole.writeLine(formatString('{0} si {1} {2}', 'Goliam', 'Pich', '!'));

    //Task 12
    function generateList(people, template) {
        var list = '<ul>'

        people.forEach(function (person) {
            list += '<li>'

            list += template.replace(/-\{(.*?)\}-/g, function (match, p1) {
                return person[p1]
            })

            list += '</li>'
        })

        list += '</ul>'

        return list
    }

    var people =
        [{ name: 'Pesho', age: 22 }
        , { name: 'Mariika', age: 19 }
        , { name: 'Gosho', age: 31 }
        , { name: 'Joro', age: 25 }
        ];

    var tmpl = document.getElementById('list-item').innerHTML;

    var result = generateList(people, tmpl);

    document.getElementById('list-item').outerHTML = result; //replace task div with the result of the function generateList()
})()