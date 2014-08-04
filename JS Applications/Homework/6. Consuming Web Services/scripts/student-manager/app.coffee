define ['studentController', 'sammy'], (studentController, Sammy) ->
  controller = new studentController()

  app = Sammy '#wrapper', () ->
    @get '#!/students', (ctx) ->
      buildStudents = (students) ->
        html = '<ul>'
        for student in students.students
          html += "<li>#{student.name} - #{student.grade}</li>"
        html += '</ul>'
        $('#wrapper').html(html)
      @load controller.getAllStudents(buildStudents)

    @get '#!/create', (ctx) ->
      @load controller.createNewStudent()

    @get '#!/remove', (ctx) ->
      @load controller.removeStudent()

    @get '#!/', (ctx) ->

  app.run('#!/')
