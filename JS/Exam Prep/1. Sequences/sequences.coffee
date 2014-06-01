Solve = (args) ->
  [countOfNumbers, numbers] = [Number(args[0]), args[1..].map(Number)]
  #console.log [countOfNumbers, numbers]
  sequences = [[]]
  numberOfSequences = 0

  for number, i in numbers
    sequences[numberOfSequences].push number
    if number > numbers[i + 1]
      numberOfSequences++
      sequences[numberOfSequences] = []

  numberOfSequences++ if numberOfSequences > 0
  #console.log sequences
  numberOfSequences


test1 = ["7", "1", "2", "-3", "4", "4", "0", "1"]
test2 = ["6", "1", "3", "-5", "8", "7", "-6"]
test3 = ["9", "1", "8", "8", "7", "6", "5", "7", "7", "6"]
test4 = []

console.log Solve test1
console.log Solve test2
console.log Solve test3
console.log Solve test4


###
  input =
  calculations =
  output =
###