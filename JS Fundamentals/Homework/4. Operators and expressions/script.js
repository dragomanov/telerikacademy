// Generated by CoffeeScript 1.7.1
(function() {
  var IsPointInCircle, IsPointInRectangle, RandomInt, binaryNumber, divisibleBy35, even, isInCircle, isInCircleAndOutOfRectangle, isOutOfRectangle, isPrime, isThirdDigit7, num, numberParity, randomBigNumber, randomNumber, rectangleHeight, rectangleSurface, rectangleWidth, thirdBit, trapezoidArea, trapezoidHeight, trapezoidSideA, trapezoidSideB, x, y, _i, _ref;

  RandomInt = function(min, max) {
    if (min == null) {
      min = 0;
    }
    if (max == null) {
      max = 100;
    }
    return min + Math.random() * (max - min + 1) >> 0;
  };

  IsPointInCircle = function(x, y, circleRadius, kx, ky) {
    if (kx == null) {
      kx = 0;
    }
    if (ky == null) {
      ky = 0;
    }
    if ((x - kx) * (x - kx) + (y - ky) * (y - ky) <= circleRadius * circleRadius) {
      return true;
    } else {
      return false;
    }
  };

  IsPointInRectangle = function(x, y, top, left, width, height) {
    if ((left < x && x < left + width) && (top > y && y > top - height)) {
      return true;
    } else {
      return false;
    }
  };

  randomNumber = RandomInt();

  even = 0;

  numberParity = randomNumber % 2 === even ? "even" : "odd";

  document.writeln("" + randomNumber + " is " + numberParity + " <br />");

  divisibleBy35 = 0;

  divisibleBy35 = randomNumber % (5 * 7) === divisibleBy35 ? "yes" : "no";

  document.writeln("Is " + randomNumber + " divisible by both 5 and 7: " + divisibleBy35 + " <br />");

  rectangleHeight = RandomInt(1, 10);

  rectangleWidth = RandomInt(1, 10);

  rectangleSurface = rectangleHeight * rectangleWidth;

  document.writeln("The surface of a rectangle with height " + rectangleHeight + " and width " + rectangleWidth + " is " + rectangleSurface + "<br />");

  randomBigNumber = RandomInt(1000, 10000);

  isThirdDigit7 = Math.floor(randomBigNumber / 100) % 10 === 7 ? "yes" : "no";

  document.writeln("Is the third digit of " + randomBigNumber + " a 7: " + isThirdDigit7 + " <br />");

  thirdBit = randomNumber >> 3 & 1;

  binaryNumber = randomNumber.toString(2);

  document.writeln("The third bit of " + randomNumber + " (" + binaryNumber + ") is " + thirdBit + " <br />");

  _ref = [RandomInt(-5, 5), RandomInt(-5, 5)], x = _ref[0], y = _ref[1];

  isInCircle = IsPointInCircle(x, y, 5) ? "yes" : "no";

  document.writeln("Is the point (" + x + "," + y + ") in circle with radius 5: " + isInCircle + " <br />");

  isPrime = "yes";

  for (num = _i = 2; 2 <= randomNumber ? _i < randomNumber : _i > randomNumber; num = 2 <= randomNumber ? ++_i : --_i) {
    if (randomNumber % num === 0) {
      isPrime = "no";
    }
  }

  document.writeln("Is " + randomNumber + " prime: " + isPrime + " <br />");

  trapezoidSideA = RandomInt(1, 10);

  trapezoidSideB = RandomInt(1, 10);

  trapezoidHeight = RandomInt(1, 10);

  trapezoidArea = (trapezoidSideA + trapezoidSideB) * trapezoidHeight / 2;

  document.writeln("The area of a trapezoid with sides " + trapezoidSideA + " and " + trapezoidSideB + ", and height " + trapezoidHeight + " is " + trapezoidArea + "<br />");

  isInCircle = IsPointInCircle(x, y, 3, 1, 1);

  isOutOfRectangle = !IsPointInRectangle(x, y, 1, -1, 6, 2);

  isInCircleAndOutOfRectangle = isInCircle && isOutOfRectangle ? "yes" : "no";

  document.writeln("Is the point (" + x + "," + y + ") in circle and outside of rectangle: " + isInCircleAndOutOfRectangle + " <br />");

}).call(this);
