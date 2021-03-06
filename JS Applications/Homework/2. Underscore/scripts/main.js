// Generated by CoffeeScript 1.7.1
require(['chance', 'underscore', 'student', 'animal', 'book', 'person'], function(Chance, _, Student, Animal, Book, Person) {
  var AUTHORS_NAMES, NAME_OF_SPECIES, NUMBER_OF_LEGS, animal, animals, animalsGroupedBySpeciesAndSortedByLegs, book, books, chance, filteredAndSortedByLastName, filteredByAge, generateMarks, groupAndSortPeopleBy, makeAnimal, makeBook, makePerson, makeStudent, mostCommonFirstNameObj, mostCommonLastNameObj, mostPopularAuthor, people, person, student, studentWithHighestMarks, students, totalNumberOfLegs;
  NUMBER_OF_LEGS = [2, 4, 6, 8, 100];
  NAME_OF_SPECIES = ['Lion', 'Horse', 'Cat', 'Dog', 'Bat', 'Centipede'];
  AUTHORS_NAMES = ['John Peterson', 'George Dickens', 'Nostradamus'];
  chance = new Chance();
  makePerson = function() {
    var person;
    return person = new Person(chance.first(), chance.last());
  };
  people = (function() {
    var _i, _results;
    _results = [];
    for (person = _i = 1; _i <= 100; person = ++_i) {
      _results.push(makePerson());
    }
    return _results;
  })();
  generateMarks = function() {
    var mark, _i, _results;
    _results = [];
    for (mark = _i = 1; _i <= 5; mark = ++_i) {
      _results.push(chance.integer({
        min: 2,
        max: 6
      }));
    }
    return _results;
  };
  makeStudent = function() {
    var student;
    return student = new Student(chance.first(), chance.last(), chance.age(), generateMarks());
  };
  students = (function() {
    var _i, _results;
    _results = [];
    for (student = _i = 1; _i <= 20; student = ++_i) {
      _results.push(makeStudent());
    }
    return _results;
  })();
  makeBook = function() {
    var book, indexOfName;
    indexOfName = chance.integer({
      min: 0,
      max: AUTHORS_NAMES.length - 1
    });
    return book = new Book(AUTHORS_NAMES[indexOfName], chance.sentence({
      words: 2
    }));
  };
  books = (function() {
    var _i, _results;
    _results = [];
    for (book = _i = 1; _i <= 20; book = ++_i) {
      _results.push(makeBook());
    }
    return _results;
  })();
  makeAnimal = function() {
    var animal, indexOfLegs, indexOfSpecies;
    indexOfSpecies = chance.integer({
      min: 0,
      max: NAME_OF_SPECIES.length - 1
    });
    indexOfLegs = chance.integer({
      min: 0,
      max: NUMBER_OF_LEGS.length - 1
    });
    return animal = new Animal(NAME_OF_SPECIES[indexOfSpecies], NUMBER_OF_LEGS[indexOfLegs]);
  };
  animals = (function() {
    var _i, _results;
    _results = [];
    for (animal = _i = 1; _i <= 20; animal = ++_i) {
      _results.push(makeAnimal());
    }
    return _results;
  })();
  filteredAndSortedByLastName = _.chain(students).filter(function(student) {
    return student.firstName < student.lastName;
  }).sortBy(function(student) {
    return student.firstName + student.lastName;
  }).reverse().value();
  console.log("Filtered by firstName compared to lastName and then sorted by fullname descending.");
  console.log(filteredAndSortedByLastName);
  filteredByAge = _.chain(students).filter(function(student) {
    var _ref;
    return (18 <= (_ref = student.age) && _ref <= 24);
  }).map(function(student) {
    return {
      firstName: student.firstName,
      lastName: student.lastName
    };
  }).value();
  console.log("Filtered by age and print object with first and last name.");
  console.log(filteredByAge);
  studentWithHighestMarks = _.chain(students).sortBy(function(student) {
    return student.marks.reduce(function(a, b) {
      return a + b;
    });
  }).last().value();
  console.log("Print student with highest marks.");
  console.log(studentWithHighestMarks);
  animalsGroupedBySpeciesAndSortedByLegs = _.chain(animals).sortBy('legs').groupBy('specie').value();
  console.log("Print animals grouped by species and sorted by number of legs.");
  console.log(animalsGroupedBySpeciesAndSortedByLegs);
  totalNumberOfLegs = _.reduce(animals, (function(acc, animal) {
    return acc + animal.legs;
  }), 0);
  console.log("Print total number of legs.");
  console.log(totalNumberOfLegs);
  mostPopularAuthor = _.chain(books).groupBy('author').sortBy('length').last().first().value().author;
  console.log("Print the most popular author.");
  console.log(mostPopularAuthor);
  groupAndSortPeopleBy = function(property) {
    var biggestGroup, count, mostCommonProperty;
    biggestGroup = _.chain(people).groupBy(property).sortBy('length').last().value();
    count = biggestGroup.length;
    mostCommonProperty = (_.last(biggestGroup))[property];
    return {
      count: count,
      mostCommonProperty: mostCommonProperty
    };
  };
  mostCommonFirstNameObj = groupAndSortPeopleBy('firstName');
  mostCommonLastNameObj = groupAndSortPeopleBy('lastName');
  console.log("The most popular first name is " + mostCommonFirstNameObj.mostCommonProperty + " - count: " + mostCommonFirstNameObj.count);
  return console.log("The most popular last name is " + mostCommonLastNameObj.mostCommonProperty + " - count: " + mostCommonLastNameObj.count);
});

//# sourceMappingURL=main.map
