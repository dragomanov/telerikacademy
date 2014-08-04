define ['jQuery', '../bower_components/q/q', 'underscore'], ($, Q, _) ->
  class httpRequester
    constructor: () ->

    getJSON: (url, headers, success, error) ->
      $.ajax
        url: url
        type: 'GET'
        header: headers
        success: success
        error: error


    postJSON: (url, headers) ->

