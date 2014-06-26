function Solve( params ) {
    var input = [];
    var objValues = [];

    for ( var i = 0; i < params.length; i++ ) {
        input[i] = params[i].trim();
        var indexDef = input[i].indexOf( 'def ' );

        if ( indexDef !== -1 && indexDef == 0 ) {
            input[i] = input[i].substring( 3 );
        }
        input[i] = input[i].substring( 0, input[i].length - 1 ).split( '[' ).map( function ( item ) { return item.trim() });
        objValues[i] = objectValues( input[i][0] );
        objValues[i].value = input[i][1].split( ',' );

        objValues[i].value = takeResult( objValues, objValues[i] );

    }

    function takeResult( obj, currentObj ) {
        var result = 0;
        currentObj.value = changeWithValue( obj, currentObj );

        if ( currentObj.operation != '' ) {
            switch ( objValues.operation ) {
                case 'min':

                    break;
            }
        }
        return currentObj.value;
    }

    function changeWithValue( obj, currentObj ) {
        for ( var i in currentObj.value ) {
            if ( !isFinite( currentObj.value[i] ) ) {
                for ( var j = 0; j < obj.length; j++ ) {
                    if ( obj[j].name == currentObj.value[i] ) {
                        currentObj.value[i] = obj[j].value;
                        break;
                    }
                }
            }
        }
        return currentObj.value[i];
    }

    function objectValues( input ) {
        var index = input.indexOf( ' ' );

        if ( index != -1 ) {
                    return {
                name: input.substring( 0, index ).trim(),
                operation: input.substring( index ).trim()
            }
                } else {
            if ( input == 'max' || input == "min" || input == 'avg' || input == 'sum' ) {
                        return {
                    name: '',
                    operation: input
                }
                    } else {
                        return {
                    name: input,
                    operation: ''
                }
                    }
        }
    }

    console.log( input );
}

var x = [
    '   def func sum[5, 3, 7, 2, 6, 3]',
    'def func2 [5, 3, 7, 2, 6,    3]     ',
    'def func3 min[func2]',
    'def func4 max[5, 3, 7, 2, 6, 3]',
    'def func5 avg[5, 3, 7, 2, 6, 3]  ',
    'def func6 sum[func2, func3, func4 ]',
    'sum[func6, func4]'
]

       Solve( x );
