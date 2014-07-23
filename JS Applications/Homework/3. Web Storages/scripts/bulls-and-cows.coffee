define ['RNG'], (RNG) ->
  class BullsAndCows
    MAX_HIGH_SCORES = 5

    constructor: () ->
      @_rng = new RNG()
      @_secretNumber = ''
      @_guesses = 0

    getGuesses: () -> @_guesses

    startGame: () ->
      @_secretNumber = @_rng.getSecretNumber()
      @_guesses = 0
      console.log(@_secretNumber)

    makeGuess: (number) ->
      @_guesses++
      @countBullsAndCows(number)

    isNumberValid: (number) ->
      number = number.toString()
      return no if number.length isnt 4
      return no if number[0] is '0'
      for digit, i in number
        return no if not /^\d$/.test(digit)
        return no if number.indexOf(digit, i+1) isnt -1
      yes

    countBullsAndCows: (number) ->
      bulls = 0
      cows = 0
      for i in [0..3]
        if number[i] is @_secretNumber[i]
          bulls++
        else if number[i] in @_secretNumber.split('')
          cows++
      {bulls: bulls, cows: cows}

    updateHighScores: (result, highScores = []) ->
      highScores.push(result) if highScores.length < MAX_HIGH_SCORES
      highScores.sort((a, b) -> b.score - a.score)
      if highScores.length is MAX_HIGH_SCORES and highScores[0].score > result.score
        highScores[0] = result
      highScores.sort((a, b) -> a.score - b.score)

  BullsAndCows