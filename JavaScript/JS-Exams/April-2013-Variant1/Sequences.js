function Solve(params) {
    var N = parseInt(params[0]);
    var answer = 0;

    for (var i = 2; i <= params[0]; i++) {

        if (params[i] < params[i - 1] || i === params[0]) {
            answer++;
        }
    }

    return answer;
}
var x = [9,
1,
8,
8,
7,
6,
5,
7,
7,
6
];
console.log(Solve(x));