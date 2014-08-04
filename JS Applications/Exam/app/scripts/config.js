/// <reference path="require.js" />
require.config({
    paths: {
        'jquery': 'jquery-2.0.2'
    },
    shim: {
        'underscore': {
            exports: '_'
        }
    }
});

require(['app']);