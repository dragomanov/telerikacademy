define () ->
  class Item
    NAME_MIN_CHARS = 6
    NAME_MAX_CHARS = 40
    constructor: (@type, @name, @price) ->
      unless NAME_MIN_CHARS <= name.length <= NAME_MAX_CHARS
        throw new Error("Name must be between #{NAME_MIN_CHARS} and #{NAME_MAX_CHARS} characters!")
      unless type in ['accessory', 'smart-phone', 'notebook', 'pc', 'tablet']
        throw new Error("Type can only be 'accessory', 'smart-phone', 'notebook', 'pc' or 'tablet'")