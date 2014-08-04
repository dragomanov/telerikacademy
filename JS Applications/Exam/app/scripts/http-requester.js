/// <reference path="jquery-2.0.2.js" />
define([], function() {
        function getJSON(options, success, error) {
            $.ajax({
                url: options.url,
                type: "GET",
                timeout: 5000,
                contentType: "application/json",
                data: options.data,
                headers: options.headers,
                success: success,
                error: error
            });
        }

        function postJSON(options, success, error) {
            $.ajax({
                url: options.url,
                type: "POST",
                contentType: "application/json",
                timeout: 5000,
                data: JSON.stringify(options.data),
                headers: options.headers,
                success: success,
                error: error
            });
        }

        function putJSON(options, success, error) {
            $.ajax({
                url: options.url,
                type: "PUT",
                contentType: "application/json",
                timeout: 5000,
                data: JSON.stringify(options.data),
                headers: options.headers,
                success: success,
                error: error
            });
        }

        return {
            getJSON: getJSON,
            postJSON: postJSON,
            putJSON: putJSON
        };
});