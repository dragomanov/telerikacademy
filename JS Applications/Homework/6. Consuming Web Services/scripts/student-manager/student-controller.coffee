define ['studentModel'], (studentModel) ->
  class studentController
    constructor: () ->
      @model = new studentModel()

    getAllStudents: (success, error) ->
      @model.getAllStudents(success, error)

    createNewStudent: (student, success, error) ->
      @model.createNewStudent(student, success, error)

    removeStudent: (id, success, error) ->
      @model.removeStudent(id, success, error)
