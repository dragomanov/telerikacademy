// Generated by CoffeeScript 1.7.1
(function() {
  var __indexOf = [].indexOf || function(item) { for (var i = 0, l = this.length; i < l; i++) { if (i in this && this[i] === item) return i; } return -1; };

  define(['RNG'], function(RNG) {
    var BullsAndCows;
    BullsAndCows = (function() {
      var MAX_HIGH_SCORES;

      MAX_HIGH_SCORES = 5;

      function BullsAndCows() {
        this._rng = new RNG();
        this._secretNumber = '';
        this._guesses = 0;
      }

      BullsAndCows.prototype.getGuesses = function() {
        return this._guesses;
      };

      BullsAndCows.prototype.startGame = function() {
        this._secretNumber = this._rng.getSecretNumber();
        this._guesses = 0;
        return console.log(this._secretNumber);
      };

      BullsAndCows.prototype.makeGuess = function(number) {
        this._guesses++;
        return this.countBullsAndCows(number);
      };

      BullsAndCows.prototype.isNumberValid = function(number) {
        var digit, i, _i, _len;
        number = number.toString();
        if (number.length !== 4) {
          return false;
        }
        if (number[0] === '0') {
          return false;
        }
        for (i = _i = 0, _len = number.length; _i < _len; i = ++_i) {
          digit = number[i];
          if (!/^\d$/.test(digit)) {
            return false;
          }
          if (number.indexOf(digit, i + 1) !== -1) {
            return false;
          }
        }
        return true;
      };

      BullsAndCows.prototype.countBullsAndCows = function(number) {
        var bulls, cows, i, _i, _ref;
        bulls = 0;
        cows = 0;
        for (i = _i = 0; _i <= 3; i = ++_i) {
          if (number[i] === this._secretNumber[i]) {
            bulls++;
          } else if (_ref = number[i], __indexOf.call(this._secretNumber.split(''), _ref) >= 0) {
            cows++;
          }
        }
        return {
          bulls: bulls,
          cows: cows
        };
      };

      BullsAndCows.prototype.updateHighScores = function(result, highScores) {
        if (highScores == null) {
          highScores = [];
        }
        if (highScores.length < MAX_HIGH_SCORES) {
          highScores.push(result);
        }
        highScores.sort(function(a, b) {
          return b.score - a.score;
        });
        if (highScores.length === MAX_HIGH_SCORES && highScores[0].score > result.score) {
          highScores[0] = result;
        }
        return highScores.sort(function(a, b) {
          return a.score - b.score;
        });
      };

      return BullsAndCows;

    })();
    return BullsAndCows;
  });

}).call(this);
