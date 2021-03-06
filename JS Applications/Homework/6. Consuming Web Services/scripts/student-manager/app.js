// Generated by CoffeeScript 1.7.1
(function() {
  define(['studentController', 'sammy'], function(studentController, Sammy) {
    var app, controller;
    controller = new studentController();
    app = Sammy('#wrapper', function() {
      this.get('#!/students', function(ctx) {
        var buildStudents;
        buildStudents = function(students) {
          var html, student, _i, _len, _ref;
          html = '<ul>';
          _ref = students.students;
          for (_i = 0, _len = _ref.length; _i < _len; _i++) {
            student = _ref[_i];
            html += "<li>" + student.name + " - " + student.grade + "</li>";
          }
          html += '</ul>';
          return $('#wrapper').html(html);
        };
        return this.load(controller.getAllStudents(buildStudents));
      });
      this.get('#!/create', function(ctx) {
        return this.load(controller.createNewStudent());
      });
      this.get('#!/remove', function(ctx) {
        return this.load(controller.removeStudent());
      });
      return this.get('#!/', function(ctx) {});
    });
    return app.run('#!/');
  });

}).call(this);
