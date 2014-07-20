# Helper functions
randomInt = (min = 0, max = 100) -> min + Math.random() * (max - min + 1) >> 0
print = (str) -> print "#{str} <br />"

isPointInCircle = (x, y, circleRadius, kx = 0, ky = 0) ->
  if (x - kx) * (x - kx) + (y - ky) * (y - ky) <= circleRadius * circleRadius
  then yes else no

isPointInRectangle = (x, y, top, left, width, height) ->
  if left <= x <= left + width and top >= y >= top - height then yes else no


# Task 1
randomNumber = randomInt()
even = 0
numberParity = if randomNumber % 2 is even then "even" else "odd"
print "#{randomNumber} is #{numberParity} <br />"

# Task 2
divisibleBy35 = 0
divisibleBy35 = if randomNumber % (5 * 7) is divisibleBy35 then "yes" else "no"
print "Is #{randomNumber} divisible by both 5 and 7: #{divisibleBy35} <br />"

# Task 3
rectangleHeight = randomInt 1, 10
rectangleWidth = randomInt 1, 10
rectangleSurface = rectangleHeight * rectangleWidth
print "The surface of a rectangle with height #{rectangleHeight}
  and width #{rectangleWidth} is #{rectangleSurface}<br />"

# Task 4
randomBigNumber = randomInt 1000, 10000
isThirdDigit7 = if randomBigNumber // 100 % 10 == 7 then "yes" else "no"
print "Is the third digit of #{randomBigNumber} a 7:
  #{isThirdDigit7} <br />"

# Task 5
thirdBit = randomNumber >> 3 & 1
binaryNumber = randomNumber.toString(2);
print "The third bit of #{randomNumber} (#{binaryNumber}) is #{thirdBit} <br />"

# Task 6
[x, y] = [randomInt(-5, 5), randomInt(-5, 5)]
isInCircle = if isPointInCircle x, y, 5 then "yes" else "no"
print "Is the point (#{x},#{y}) in circle
  with radius 5: #{isInCircle} <br />"

# Task 7
isPrime = "yes"
for num in [2...randomNumber] when randomNumber % num == 0
  isPrime = "no"
print "Is #{randomNumber} prime: #{isPrime} <br />"

# Task 8
trapezoidSideA = randomInt 1, 10
trapezoidSideB = randomInt 1, 10
trapezoidHeight = randomInt 1, 10
trapezoidArea = (trapezoidSideA + trapezoidSideB) * trapezoidHeight / 2
print "The area of a trapezoid with sides #{trapezoidSideA}
  and #{trapezoidSideB}, and height #{trapezoidHeight} is #{trapezoidArea}<br />"

# Task 9
isInCircle = isPointInCircle x, y, 3, 1, 1
isOutOfRectangle = !isPointInRectangle x, y, 1, -1, 6, 2
isInCircleAndOutOfRectangle = if isInCircle and isOutOfRectangle then "yes" else "no"
print "Is the point (#{x},#{y}) in circle
  and outside of rectangle: #{isInCircleAndOutOfRectangle} <br />"
