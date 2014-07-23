require ['BullsAndCows', 'BullsAndCowsUI','jquery', 'Storage'], (BullsAndCows, UI, $, Storage) ->
  container = new UI('#game')
  gameManager = new BullsAndCows()

  updateHighScores = (score) ->
    name = $('.hi-score-name').val()
    storage = new Storage()
    highScores = storage.getStorage()
    highScores = gameManager.updateHighScores({name: name, score: score}, highScores)
    storage.setStorage(highScores)
    container.drawHighScores(highScores)
    container.drawStartScreen()
    $('.btn-start-new-game').focus().click(startNewGame)

  endGame = (score) ->
    container.drawWinScreen(score)
    $('.add-name').click(() -> updateHighScores(score))
    $('.hi-score-name').focus().keypress((key) -> $('.add-name').focus().click() if key.which is 13)


  makeGuess = () ->
    guessedNumber = $('.input').val()
    $('.input').val('')
    if gameManager.isNumberValid(guessedNumber)
      result = gameManager.makeGuess(guessedNumber)
      container.drawGuess(result)
      endGame(gameManager.getGuesses()) if result.bulls is 4
    else
      console.error("Wrong number: '#{guessedNumber}'")

  startNewGame = () ->
    gameManager.startGame()
    container.drawGameScreen()
    $('.btn-make-guess').click(makeGuess)
    $('.input').focus().keypress((key) -> $('.btn-make-guess').click() if key.which is 13)

  container.drawStartScreen()
  $('.btn-start-new-game').focus().click(startNewGame)


