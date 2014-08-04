define ['jquery'], ($) ->
  class studentModel
    constructor: () ->
      @url = 'http://localhost:3000/students'

    getAllStudents: (success, error) ->
      $.ajax
        url: @url
        type: 'GET'
        contentType: 'application/json'
        success: success
        error: error

    createNewStudent: (student, success, error) ->

    removeStudent: (id, success, error) ->
