require.config({
    paths: {
        studentController: 'student-controller',
        studentModel: 'student-model',
        sammy: '../bower_components/sammy/lib/sammy',
        jquery: '../bower_components/jquery/dist/jquery'
    }
});

require(['app']);
