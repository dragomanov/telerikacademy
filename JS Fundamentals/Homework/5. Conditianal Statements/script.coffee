# Helper functions
randomInt = (min = 0, max = 100) -> min + Math.random() * (max - min + 1) >> 0
print = (str) -> document.writeln "#{str} <br />"
printBiggestNumber = (numbers) ->
  maxNumber = num[0]
  maxNumber = num for num in numbers when num > maxNumber
  print "The biggest of the numbers #{numbers} is #{maxNumber}"

print "Task 1:"
a = randomInt()
b = randomInt()
print "a = #{a}, b = #{b}"
[a, b] = [b, a] if a > b
print "After comparison:"
print "a = #{a}, b = #{b}"

print "<br />Task 2:"
numbers = (randomInt -10, 10 for a in [1..3])
productSign = 0
productSign = productSign ^ 1 for num in numbers when num < 0
productSign =
  if 0 in numbers then 'none'
  else if productSign is 0 then 'plus' else 'minus'
print "The sign of the product of the numbers #{numbers} is #{productSign}"

print "<br />Task 3:"
printBiggestNumber numbers

print "<br />Task 4:"
print "Unsorted array: #{numbers}"
if numbers[0] > numbers[1] then [numbers[0], numbers[1]] = [numbers[1], numbers[0]]
if numbers[1] > numbers[2] then [numbers[1], numbers[2]] = [numbers[2], numbers[1]]
if numbers[0] > numbers[1] then [numbers[0], numbers[1]] = [numbers[1], numbers[2]]
print "Sorted array: #{numbers}"

print "<br />Task 5:"
digit = randomInt 0, 9
word = switch digit
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
print "Digit: #{digit}"
print "Word: #{word}"

print "<br />Task 6:"
a = randomInt 0, 10
b = randomInt 0, 10
c = randomInt 0, 10
print "Coefficients are: #{a}, #{b}, #{c}"
x1 = -b/2/a+Math.pow(Math.pow(b,2)-4*a*c,0.5)/2/a;
x2 = -b/2/a-Math.pow(Math.pow(b,2)-4*a*c,0.5)/2/a;
quadraticSolutions =
  if isNaN(x1) then 0
  else if x1 == x2 then 1
  else 2
print "The equation has #{quadraticSolutions} solutions" +
  switch quadraticSolutions
    when 0 then ""
    when 1 then ", which is: #{x1}"
    when 2 then ", which are: #{x1}, #{x2}"

print "<br />Task 7:"
printBiggestNumber (randomInt() for a in [1..5])

print "<br />Task 8:"
bigNumber = randomInt 0, 999
englishOnes = [
  "", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine"
]
englishTeens = [
  "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen",
  "Sixteen", "Seventeen", "Eighteen", "Nineteen"
]
englishTens = [
  "", "", "Twenty", "Thirty", "Forty", "Fifty",
  "Sixty", "Seventy", "Eighty", "Ninety"
]
englishNumber = ""
if bigNumber >= 100
  englishNumber += englishOnes[bigNumber // 100] + " hundred "
  if 0 < bigNumber % 100 < 20 or bigNumber % 10 is 0 then englishNumber += "and "

if bigNumber is 0
  englishNumber = "Zero"
else if bigNumber % 100 >= 20
  englishNumber +=
      englishTens[bigNumber // 10 % 10] + " " + englishOnes[bigNumber % 10]
else if bigNumber % 100 >= 10
  englishNumber += englishTeens[bigNumber % 10]
else
  englishNumber += englishOnes[bigNumber % 10]
print "Number: #{bigNumber}"
print "Word: #{englishNumber}"
