# Helper functions
randomInt = (min = 0, max = 100) -> min + Math.random() * (max - min + 1) >> 0
print = (str) -> document.writeln "#{str} <br />"
findSmallestAndBiggestProperties = (obj) ->
  sortedProperties = (prop for own prop of obj).sort((a, b) -> a.localeCompare(b))
  [sortedProperties[0], sortedProperties[-1..]]

print "<br />Task 1:"
print "N = " + n = randomInt(1, 50)
print [1..n].join(", ")

print "<br />Task 2:"
numbersNotDivisibleBy21 = (num for num in [1..n] when num % 21 isnt 0)
print numbersNotDivisibleBy21.join(", ")

print "<br />Task 3:"
randomNumbers = (randomInt() for i in [1..10])
print "Sequence: " + randomNumbers.join(", ")
print "Smallest number in sequence: " + Math.min(randomNumbers...)
print "Biggest number in sequence: " + Math.max(randomNumbers...)

print "<br />Task 4:"
for obj in [document, window, navigator]
  print "#{obj.constructor.name}: " + findSmallestAndBiggestProperties(obj)

