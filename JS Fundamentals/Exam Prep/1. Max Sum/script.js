// Generated by CoffeeScript 1.7.1
(function() {
  var Solve, test1, test2, test3;

  test1 = ['8', '1', '6', '-9', '4', '4', '-2', '10', '-1'];

  test2 = [6, 1, 3, -5, 8, 7, -6];

  test3 = [9, -9, -8, -8, -7, -6, -5, -1, -7, -6];

  Solve = function(args) {
    var N, currNum, currSum, i, maxSum, numbers, parseIntArray, _i, _j, _len, _ref, _ref1;
    parseIntArray = function(numbers) {
      return numbers.map(Number);
    };
    N = parseInt(args[0]);
    numbers = parseIntArray(args.slice(1));
    maxSum = numbers[0];
    for (i = _i = 0, _ref = numbers.length; 0 <= _ref ? _i < _ref : _i > _ref; i = 0 <= _ref ? ++_i : --_i) {
      currSum = 0;
      _ref1 = numbers.slice(i);
      for (_j = 0, _len = _ref1.length; _j < _len; _j++) {
        currNum = _ref1[_j];
        currSum += currNum;
        if (currSum > maxSum) {
          maxSum = currSum;
        }
      }
    }
    return maxSum;
  };

  console.log(Solve(test1));

  console.log(Solve(test2));

  console.log(Solve(test3));

}).call(this);
