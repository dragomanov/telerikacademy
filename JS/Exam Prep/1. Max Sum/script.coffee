

# Tests
test1 = ['8', '1',  '6',  '-9',  '4',  '4',  '-2',  '10',  '-1']
test2 = [6, 1, 3, -5, 8, 7, -6]
test3 = [9, -9, -8, -8, -7, -6, -5, -1, -7, -6]

Solve = (args) ->
  # Helper functions
  parseIntArray = (numbers) ->
    numbers.map(Number)
  N = parseInt args[0]
  numbers = parseIntArray args[1..]
  maxSum = numbers[0]
  for i in [0...numbers.length]
    currSum = 0
    for currNum in numbers[i..]
      currSum += currNum
      maxSum = currSum if currSum > maxSum
  return maxSum


# Log tests
console.log Solve test1
console.log Solve test2
console.log Solve test3