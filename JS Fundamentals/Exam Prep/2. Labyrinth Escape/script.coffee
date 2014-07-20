Solve = (args) ->
  [N, M] = args[0].split(' ').map(Number)
  [R, C] = args[1].split(' ').map(Number)
  directions = []
  visited = []
  for i in [0...N]
    directions[i] = args[2+i].split('')
    visited[i] = []
    for j in [0...M]
      visited[i][j] = no

  lost = no
  escaped = no
  jumps = 0
  pathSum = 0
  until lost or escaped
    jumps++
    pathSum += R*M + C + 1
    visited[R][C] = yes
    [nextR, nextC] = [R, C]
    switch directions[R][C]
      when 'l' then nextC = C - 1
      when 'r' then nextC = C + 1
      when 'u' then nextR = R - 1
      when 'd' then nextR = R + 1
      else console.log "Invalid direction!"
    if not (0 <= nextC < M and 0 <= nextR < N)
      escaped = yes
      break
    lost = yes if visited[nextR][nextC]
    [C, R] = [nextC, nextR]

  if escaped then "out #{pathSum}" else "lost #{jumps}"


test1 = ["3 4", "1 3", "lrrd", "dlll", "rddd"]
test2 = ["5 8", "0 0", "rrrrrrrd", "rludulrd", "durlddud", "urrrldud", "ulllllll"]
test3 = ["5 8", "0 0", "rrrrrrrd", "rludulrd", "lurlddud", "urrrldud", "ulllllll"]

console.log Solve test1
console.log Solve test2
console.log Solve test3
