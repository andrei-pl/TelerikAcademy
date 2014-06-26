function Solve( params ) {

    var N = parseInt( params[0] );
    var answer = 0;
    params = params.map(Number);
    for ( var i = 2; i <= params[0]; i++ ) {

        if ( params[i] < params[i - 1] || i == params[0] ) {
            answer++;
        }
        if ( params[i] < params[i - 1] && i == params[0] ) {
            answer++;
        }
    }

    //params = params.map( Number );
    //var answer = 1;
    //for ( var i = 2; i <= params[0]; i++ ) {

    //    if ( params[i] < params[i - 1] ) {
    //        answer++;
    //    }
    //}
    return answer;
}
var x = [6,
    1,
    3,
    -5,
    8,
    7,
    -6
];
console.log( Solve( x ) );