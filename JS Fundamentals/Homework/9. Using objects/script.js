var nl = function(){ document.writeln("<br />"); };

// Task 1

function Point(x, y) {
    // Return point object
    return {
        X: x,
        Y: y
    }
}

function Line(pointOne, pointTwo) {
    // Return line object
    return {
        P1: pointOne,
        P2: pointTwo,
        Length: CalclulateDistance(pointOne, pointTwo)
    }
}

function CalclulateDistance(pointOne, pointTwo) {
    // Calclulate and return distance
    return (Math.sqrt((pointTwo.X - pointOne.X) * (pointTwo.X - pointOne.X) + (pointTwo.Y - pointOne.Y) * (pointTwo.Y - pointOne.Y)));
}

function CanFormTriangle(lineOne, lineTwo, lineThree) {
    // Check
    if (((lineOne.Length + lineTwo.Length) > lineThree.Length) &&
        ((lineOne.Length + lineThree.Length) > lineTwo.Length) &&
        ((lineThree.Length + lineTwo.Length) > lineOne.Length)) {
        return true;
    }

    return false;
}

var a = Point(1, 1);
var b = Point(1, 3);

var ab = Line(a, b);
var bc = Line(Point(1, 3), Point(2, 2));
var ca = Line(Point(2, 2), Point(1, 11));

if (CanFormTriangle(ab, bc, ca)) {
    document.writeln("Yes! They can! The can NOT form a triangle!")
}
else {
    document.writeln("Oh No! The can NOT form a triangle!")
}


// Task 2

Array.prototype.remove = function (thisArg) {
    var arr = this;
    for (var i = 0; i < arr.length; i++) {
        if (arr[i] == thisArg) {
            arr.splice(i, 1);

            // Go back
            i--;
        }

    }
}

var arr = [1, 1, 2, 1, 1, 1, 4, 1, 3, 4, 1, 111, 3, 2, 1, "1"];
arr.remove(1); //arr = [2,4,3,4,111,3,2,"1"];.<br />

// Print result
nl();
document.writeln("1 removed: " + arr.join(', '));


// Task 3

function Clone(obj) {
    // Initialize new object
    var result;

    if (obj instanceof Array) {
        result = [];
    }
    else {
        result = {};
    }

    for (var i in obj) {

        // If is object Clone again
        if (obj[i] && typeof obj[i] == "object") {
            result[i] = Clone(obj[i]);
        }
        else {
            result[i] = obj[i];
        }
    }
    return result;
}

var pesho = {
    a: 5,
    b: 6,
    c: [1, 2, 3],
    d: { a: 1, b: 2 }
}

var vanio = Clone(pesho);

// Edit some data
vanio.c = [7, 8, 9];
vanio.d = { a: 8, x: 9 };

// Check pesho`s data
nl();
document.writeln(pesho.c.join(', '));
document.writeln(pesho.d.b);


// Task 4

var pesho = {
    name: "Pesho",
    age: 23
}

function CheckProperty(obj, propName) {

    // Walk through object`s properties.
    for (var prop in obj) {
        if (prop == propName) {
            return true;
        }
    }
    return false;
}

nl();

if (CheckProperty(pesho, "name") == true) {
    document.writeln("YES! Property exists!");
} else {
    document.writeln("OH NO! Property does NOT exists!");
}


// Task 5

var persons = [
    {
        firstName: "Pesho",
        lastName: "Petrov",
        age: 32
    }, {
        firstName: "Bay",
        lastName: "Ivan",
        age: 81
    }, {
        firstName: "Gosho",
        lastName: "Goshov",
        age: 113
    }, {
        firstName: "Bay",
        lastName: "Miro",
        age: 132
    }
];

function FindYoungest(arr) {

    var minAge = Number.MAX_VALUE;
    var youngest = {};
    // Walk through objects.
    for (var i = 0; i < arr.length; i++) {

        // Walk through object`s properties.
        for (var prop in arr[i]) {
            if (prop == "age") {
                if (arr[i].age < minAge) {
                    minAge = arr[i].prop;
                    youngest = arr[i];
                }
            }
        }
        return youngest;
    }
}

var youngest = FindYoungest(persons);
nl();
document.writeln("Youngest person is: " + youngest.firstName + "; Age: " + youngest.age);


// Task 6

var persons = [
    {
        firstName: "Ivan",
        lastName: "Ivanov",
        age: 32
    }, {
        firstName: "Ivan",
        lastName: "Petrov",
        age: 81
    }, {
        firstName: "Stoian",
        lastName: "Ivanov",
        age: 113
    }, {
        firstName: "Petar",
        lastName: "Dimitrov",
        age: 32
    }
];

function HasKey(obj, key) {
    // Walk through object`s properties.
    for (var prop in obj) {
        if (prop == key) {
            return true;
        }
    }
    return false;
}

function GroupBy(arr, prop) {
    var result = {};
    var key;

    // Beautify person printing
    result.print = function () {

        // Walk through keys
        for (var obj in result) {

            // Print is must not be printed
            if (obj == "print") {continue;}

            document.writeln("Key: " + obj);
            document.writeln("Persons:");

            // Walk through persons in current key
            for (var person in result[obj]) {
                var currPerson = result[obj][person];
                document.writeln("FirstName: " + currPerson.firstName + "; LastName: " + currPerson.lastName + "; Age: " + currPerson.age);
            }
        }
    }

    switch (prop) {
        case "firstName":
        case "lastName":
        case "age":
            for (var person in persons) {

                key = arr[person][prop];


                if (HasKey(result, arr[person][prop])) {

                    // Push person into value
                    result[key].push(arr[person]);
                }
                else {

                    // Initialize key and push person
                    result[key] = [];
                    result[key].push(arr[person]);
                }
            }
            break;
        default:
            document.writeln("Error! You must not enter here!");
    }

    return result;
}

// Test Grouping
var people = GroupBy(persons, "firstName");
nl();
document.writeln("Group by First Name:");
people.print();
document.writeln("");

people = GroupBy(persons, "lastName");
nl();
document.writeln("Group by Last Name:");
people.print();
document.writeln("");

people = GroupBy(persons, "age");
nl();
document.writeln("Group by Age:");
people.print();
var a = 3;

nl(); nl();
document.write("asdf".trimChars('a'));