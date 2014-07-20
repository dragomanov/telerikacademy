Solve = (args) ->
  [rows, cols, numberOfJumps] = args[0].split(" ").map(Number)
  [posRow, posCol] = args[1].split(" ").map(Number)
  jumps = args[2..].map((x) -> x.split(" ").map(Number))
  sumOfFields = posRow * cols + posCol + 1
  totalNumberOfJumps = 0
  escaped = no
  caught = no
  jumpNo = 0
  visited = []

  for row in [0...rows]
    visited[row] = []
    for col in [0...cols]
      visited[row][col] = no

  while 0 <= posRow + jumps[jumpNo][0] < rows and
      0 <= posCol + jumps[jumpNo][1] < cols
    visited[posRow][posCol] = yes
    posRow += jumps[jumpNo][0]
    posCol += jumps[jumpNo][1]
    totalNumberOfJumps++
    sumOfFields += posRow * cols + posCol + 1
    jumpNo = ++jumpNo % numberOfJumps
    return "caught #{totalNumberOfJumps}" if visited[posRow][posCol]
    #console.log posRow, posCol

  "escaped #{sumOfFields}"


test1 = ["6 7 3","0 0","2 2","-2 2","3 -1"]
test2 = ["1 1 3","0 0","2 2","-2 2","3 -1"]
test3 = ["6 7 3","0 0","2 2","-2 -2","3 -1"]
test4 = ["6 7 1","0 0","2 2"]
test5 = ["6 7 3","5 6","2 2","-2 2","3 -1"]

console.log Solve test1
console.log Solve test2
console.log Solve test3
console.log Solve test4
console.log Solve test5


# input = rows, cols, numberOfJumps
# calculations =
# output =
