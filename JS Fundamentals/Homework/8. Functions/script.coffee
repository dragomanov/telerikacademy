# Helper functions
randomInt = (min = 0, max = 100) -> min + Math.random() * (max - min + 1) >> 0
print = (str) -> document.writeln "#{str} <br />"
occurancesInString = (word, text, sensitive = false) ->
  pattern = "/\b#{word}\b/g"
  text.match pattern


print "Task 1:"
randomNumber = randomInt 0, 1000
word = switch randomNumber % 10
  when 0 then "Zero"
  when 1 then "One"
  when 2 then "Two"
  when 3 then "Three"
  when 4 then "Four"
  when 5 then "Five"
  when 6 then "Six"
  when 7 then "Seven"
  when 8 then "Eight"
  when 9 then "Nine"
  else "Invalid digit!"
print "Random number: : #{randomNumber}"
print "Last digit: #{word}"

print "<br />Task 2:"
print Number randomNumber.toString().split("").reverse().join("")

print "<br />Task 3:"
text = "as asdf, zxc? asdf!"
print occurancesInString "asdf", text

