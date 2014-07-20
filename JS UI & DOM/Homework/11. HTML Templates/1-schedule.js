var schedule = [
        {
            title: 'Course Introduction',
            date1: 'Wed 18:00, 28-May-2014',
            date2: 'Thu 14:00, 29-May-2014'
        }, {
            title: 'Document Object Model',
            date1: 'Wed 18:00, 28-May-2014',
            date2: 'Thu 14:00, 29-May-2014'
        }
    ],
    templateHtml = document.getElementById('course-schedule-template').innerHTML,
    scheduleTemplate = Handlebars.compile(templateHtml);

console.log(scheduleTemplate);
document.querySelector('#schedule-container').innerHTML = scheduleTemplate({
    schedule: schedule
});
