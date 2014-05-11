# Helper functions
randomInt = (min = 0, max = 100) -> min + Math.random() * (max - min + 1) >> 0
print = (str) -> document.writeln "#{str} <br />"

print "Task 1:"
print "Array: " + (index * 5 for index in [0...20])

print "<br />Task 2:"
str1 = "pesho"
str2 = "gosho"
compareStrings = (str1, str2) ->
  if str1.length isnt str2.length then return no
  for chr, i in str1
    if chr isnt str2[i] then return no
  yes

print "Are the two character arrays \"#{str1}\" and \"#{str2}\" equal: " +
  compareStrings(str1, str2)

print "<br/ >Task 3:"
maxSequenceOfEqualElements = (arr) ->
  maxCount = 0
  maxElement = null
