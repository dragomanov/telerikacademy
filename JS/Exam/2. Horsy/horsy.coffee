Solve = (args) ->
  [rows, cols] = args[0].split(" ").map(Number)
  [posRow, posCol] = [rows - 1, cols - 1]
  jumps = args[1..].map((x) -> x.split("").map(Number))
  sumOfWeeds = Math.pow(2, posRow) - posCol
  totalNumberOfJumps = 0
  escaped = no
  caught = no
  visited = []
  jumpMatrix = [
    []
    [-2, 1]
    [-1, 2]
    [1, 2]
    [2, 1]
    [2, -1]
    [1, -2]
    [-1, -2]
    [-2, -1]
  ]

  for row in [0...rows]
    visited[row] = []
    for col in [0...cols]
      visited[row][col] = no

  while 0 <= posRow + jumpMatrix[jumps[posRow][posCol]][0] < rows and
        0 <= posCol + jumpMatrix[jumps[posRow][posCol]][1] < cols
    visited[posRow][posCol] = yes
    oldRow = posRow
    oldCol = posCol
    posRow += jumpMatrix[jumps[oldRow][oldCol]][0]
    posCol += jumpMatrix[jumps[oldRow][oldCol]][1]
    totalNumberOfJumps++
    sumOfWeeds += Math.pow(2, posRow) - posCol
    if visited[posRow][posCol]
      return "Sadly the horse is doomed in #{totalNumberOfJumps} jumps"
  #console.log posRow, posCol

  "Go go Horsy! Collected #{sumOfWeeds} weeds"

test1 = [
  '3 5',
  '54561',
  '43328',
  '52388',
]

test2 = [
  '3 5',
  '54361',
  '43326',
  '52188',
]

test3 = []
test4 = []
test5 = []

console.log Solve test1
console.log Solve test2
#console.log Solve test3
#console.log Solve test4
#console.log Solve test5


# input =
# calculations =
# output =
