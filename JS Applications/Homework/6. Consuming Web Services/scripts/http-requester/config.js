require.config({
    baseUrl: 'scripts/bower_components',
    paths: {
        jQuery: 'jquery/dist/jquery',
        Q: 'q/q',
        underscore: 'underscore/underscore',
        httpRequester: '../http-requester/httpRequester'
    }
});

require(['../http-requester/app']);