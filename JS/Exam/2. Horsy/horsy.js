// Generated by CoffeeScript 1.7.1
(function() {
  var Solve, test1, test2, test3, test4, test5;

  Solve = function(args) {
    var caught, col, cols, escaped, jumpMatrix, jumps, oldCol, oldRow, posCol, posRow, row, rows, sumOfWeeds, totalNumberOfJumps, visited, _i, _j, _ref, _ref1, _ref2, _ref3;
    _ref = args[0].split(" ").map(Number), rows = _ref[0], cols = _ref[1];
    _ref1 = [rows - 1, cols - 1], posRow = _ref1[0], posCol = _ref1[1];
    jumps = args.slice(1).map(function(x) {
      return x.split("").map(Number);
    });
    sumOfWeeds = Math.pow(2, posRow) - posCol;
    totalNumberOfJumps = 0;
    escaped = false;
    caught = false;
    visited = [];
    jumpMatrix = [[], [-2, 1], [-1, 2], [1, 2], [2, 1], [2, -1], [1, -2], [-1, -2], [-2, -1]];
    for (row = _i = 0; 0 <= rows ? _i < rows : _i > rows; row = 0 <= rows ? ++_i : --_i) {
      visited[row] = [];
      for (col = _j = 0; 0 <= cols ? _j < cols : _j > cols; col = 0 <= cols ? ++_j : --_j) {
        visited[row][col] = false;
      }
    }
    while ((0 <= (_ref2 = posRow + jumpMatrix[jumps[posRow][posCol]][0]) && _ref2 < rows) && (0 <= (_ref3 = posCol + jumpMatrix[jumps[posRow][posCol]][1]) && _ref3 < cols)) {
      visited[posRow][posCol] = true;
      oldRow = posRow;
      oldCol = posCol;
      posRow += jumpMatrix[jumps[oldRow][oldCol]][0];
      posCol += jumpMatrix[jumps[oldRow][oldCol]][1];
      totalNumberOfJumps++;
      sumOfWeeds += Math.pow(2, posRow) - posCol;
      if (visited[posRow][posCol]) {
        return "Sadly the horse is doomed in " + totalNumberOfJumps + " jumps";
      }
    }
    return "Go go Horsy! Collected " + sumOfWeeds + " weeds";
  };

  test1 = ['3 5', '54561', '43328', '52388'];

  test2 = ['3 5', '54361', '43326', '52188'];

  test3 = [];

  test4 = [];

  test5 = [];

  console.log(Solve(test1));

  console.log(Solve(test2));

}).call(this);
