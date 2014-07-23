define ['jquery'], ($) ->
  class BullsAndCowsUI
    constructor: (container) ->
      @$container = $(container)
      @$result = $('<div />').addClass('result-container')

    drawStartScreen: () ->
      @$container.append($('<img />').addClass('splash'))
                 .append($('<button />').addClass('btn-start-new-game').html('Start new game'))

    drawGameScreen: () ->
      @$container.empty()
      @$container.append($('<input />').addClass('input'))
      @$container.append($('<button />').addClass('btn-make-guess').html('Guess'))

    drawGuess: (result) ->
      $result = @$result.clone()
      for i in [0...result.bulls]
        $result.append('B')
      for i in [0...result.cows]
        $result.append('C')
      @$container.append $result

    drawWinScreen: (score) ->
      @$container.empty()
      @getName(score)

    drawHighScores: (highScores) ->
      @$container.empty()
      $table = $('<table />').addClass('highScoreTable')
      $table.append($('<thead />').append($('<th />').html('Name')).append($('<th />').html('Score')))
      $tbody = $table.append($('<tbody />'))
      for highScore in highScores
        $tbody.append($('<tr />').append($('<td />').html(highScore.name)).append($('<td />').html(highScore.score)))
      @$container.append($table)

    getName: (guesses) ->
      @$container.append($('<div />').addClass('winning-msg').html("You guessed the number in #{guesses} guesses"))
      @$container.append($('<input />').addClass('hi-score-name'))
      @$container.append($('<button />').addClass('add-name').html('Submit'))

  BullsAndCowsUI
