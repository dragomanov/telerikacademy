define ["todo-list/item"], (Item) ->
  class Section
    constructor: (@_title) ->
    @_items = {}
    @::add = (item) ->
      console.log('add item')
    @::getData = () ->
      (item.getData() for item in @_items)
