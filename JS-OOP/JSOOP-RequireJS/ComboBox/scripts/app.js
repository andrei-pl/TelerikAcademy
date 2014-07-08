(function () {
    require.config({
        paths: {
            'jquery': 'bower_components/jquery/dist/jquery.min',
            'handlebars': 'bower_components/handlebars/handlebars.min'
        }
    });

    require(['init'], function (init) {
        init.run();
    })
}());