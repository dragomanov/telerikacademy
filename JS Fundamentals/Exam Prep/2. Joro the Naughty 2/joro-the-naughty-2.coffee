Solve = (args) ->
  getNumberFromArgs = (x, y) ->
    Number(args[x].split(" ")[y])
  N = getNumberFromArgs 0, 0
  M = getNumberFromArgs 0, 1
  J = getNumberFromArgs 0, 2
  R = getNumberFromArgs 1, 0
  C = getNumberFromArgs 1, 1
  jumps = ([getNumberFromArgs(i, 0), getNumberFromArgs(i, 1)] for i in [2...args.length])
  SUM_OF_NUMBERS = 0
  NUMBER_OF_JUMPS = 0
  escaped = no
  caught = no
  currJump = 0

  visited = []
  for row in [0...N]
    visited[row] = []
    for col in [0...M]
      visited[row][col] = no

  until escaped or caught
    escaped = yes unless (0 <= R + jumps[currJump][0] < N and 0 <= C + jumps[currJump][1] < M)
    caught = yes if visited[R][C]
    currJump = ++currJump % J
  if escaped then return "escaped #{SUM_OF_NUMBERS}"
  if caught then return "caught #{NUMBER_OF_JUMPS}"



test1 = ["1 1 1", "0 0", "1 1"] #escaped 1
test2 = ["2 4 2", "1 3", "2 2", "-3 3"] #escaped 8
test3 = ["6 7 3", "0 0", "2 2", "-2 2", "3 -1"] #escaped 89
test4 = ["500 500 1", "0 0", "0 10"]
test5 = []

console.log Solve test1
console.log Solve test2
console.log Solve test3
#console.log Solve test4
#console.log Solve test5


# input =
# calculations =
# output =
