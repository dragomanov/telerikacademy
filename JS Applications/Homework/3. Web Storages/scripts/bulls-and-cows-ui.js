// Generated by CoffeeScript 1.7.1
(function() {
  define(['jquery'], function($) {
    var BullsAndCowsUI;
    BullsAndCowsUI = (function() {
      function BullsAndCowsUI(container) {
        this.$container = $(container);
        this.$result = $('<div />').addClass('result-container');
      }

      BullsAndCowsUI.prototype.drawStartScreen = function() {
        return this.$container.append($('<img />').addClass('splash')).append($('<button />').addClass('btn-start-new-game').html('Start new game'));
      };

      BullsAndCowsUI.prototype.drawGameScreen = function() {
        this.$container.empty();
        this.$container.append($('<input />').addClass('input'));
        return this.$container.append($('<button />').addClass('btn-make-guess').html('Guess'));
      };

      BullsAndCowsUI.prototype.drawGuess = function(result) {
        var $result, i, _i, _j, _ref, _ref1;
        $result = this.$result.clone();
        for (i = _i = 0, _ref = result.bulls; 0 <= _ref ? _i < _ref : _i > _ref; i = 0 <= _ref ? ++_i : --_i) {
          $result.append('B');
        }
        for (i = _j = 0, _ref1 = result.cows; 0 <= _ref1 ? _j < _ref1 : _j > _ref1; i = 0 <= _ref1 ? ++_j : --_j) {
          $result.append('C');
        }
        return this.$container.append($result);
      };

      BullsAndCowsUI.prototype.drawWinScreen = function(score) {
        this.$container.empty();
        return this.getName(score);
      };

      BullsAndCowsUI.prototype.drawHighScores = function(highScores) {
        var $table, $tbody, highScore, _i, _len;
        this.$container.empty();
        $table = $('<table />').addClass('highScoreTable');
        $table.append($('<thead />').append($('<th />').html('Name')).append($('<th />').html('Score')));
        $tbody = $table.append($('<tbody />'));
        for (_i = 0, _len = highScores.length; _i < _len; _i++) {
          highScore = highScores[_i];
          $tbody.append($('<tr />').append($('<td />').html(highScore.name)).append($('<td />').html(highScore.score)));
        }
        return this.$container.append($table);
      };

      BullsAndCowsUI.prototype.getName = function(guesses) {
        this.$container.append($('<div />').addClass('winning-msg').html("You guessed the number in " + guesses + " guesses"));
        this.$container.append($('<input />').addClass('hi-score-name'));
        return this.$container.append($('<button />').addClass('add-name').html('Submit'));
      };

      return BullsAndCowsUI;

    })();
    return BullsAndCowsUI;
  });

}).call(this);
