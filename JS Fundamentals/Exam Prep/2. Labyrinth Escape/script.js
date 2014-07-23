// Generated by CoffeeScript 1.7.1
(function() {
  var Solve, test1, test2, test3;

  Solve = function(args) {
    var C, M, N, R, directions, escaped, i, j, jumps, lost, nextC, nextR, pathSum, visited, _i, _j, _ref, _ref1, _ref2, _ref3;
    _ref = args[0].split(' ').map(Number), N = _ref[0], M = _ref[1];
    _ref1 = args[1].split(' ').map(Number), R = _ref1[0], C = _ref1[1];
    directions = [];
    visited = [];
    for (i = _i = 0; 0 <= N ? _i < N : _i > N; i = 0 <= N ? ++_i : --_i) {
      directions[i] = args[2 + i].split('');
      visited[i] = [];
      for (j = _j = 0; 0 <= M ? _j < M : _j > M; j = 0 <= M ? ++_j : --_j) {
        visited[i][j] = false;
      }
    }
    lost = false;
    escaped = false;
    jumps = 0;
    pathSum = 0;
    while (!(lost || escaped)) {
      jumps++;
      pathSum += R * M + C + 1;
      visited[R][C] = true;
      _ref2 = [R, C], nextR = _ref2[0], nextC = _ref2[1];
      switch (directions[R][C]) {
        case 'l':
          nextC = C - 1;
          break;
        case 'r':
          nextC = C + 1;
          break;
        case 'u':
          nextR = R - 1;
          break;
        case 'd':
          nextR = R + 1;
          break;
        default:
          console.log("Invalid direction!");
      }
      if (!((0 <= nextC && nextC < M) && (0 <= nextR && nextR < N))) {
        escaped = true;
        break;
      }
      if (visited[nextR][nextC]) {
        lost = true;
      }
      _ref3 = [nextC, nextR], C = _ref3[0], R = _ref3[1];
    }
    if (escaped) {
      return "out " + pathSum;
    } else {
      return "lost " + jumps;
    }
  };

  test1 = ["3 4", "1 3", "lrrd", "dlll", "rddd"];

  test2 = ["5 8", "0 0", "rrrrrrrd", "rludulrd", "durlddud", "urrrldud", "ulllllll"];

  test3 = ["5 8", "0 0", "rrrrrrrd", "rludulrd", "lurlddud", "urrrldud", "ulllllll"];

  console.log(Solve(test1));

  console.log(Solve(test2));

  console.log(Solve(test3));

}).call(this);