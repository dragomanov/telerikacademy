define ['tech-store-models/item'], (Item) ->
  class Store
    NAME_MIN_CHARS = 6
    NAME_MAX_CHARS = 30
    constructor: (@name) ->
      @_items = []
      unless NAME_MIN_CHARS <= name.length <= NAME_MAX_CHARS
        throw new Error("Name must be between #{NAME_MIN_CHARS} and #{NAME_MAX_CHARS} characters!")
    addItem: (item) ->
      unless item instanceof Item
        throw new Error("Store can keep in stock only items of type Item")
      @_items.push(item)
      @
    getAll: () ->
      @_items.sort((a, b) -> a.name.localeCompare(b.name))
    getSmartPhones: () ->
      item for item in @getAll() when item.type is 'smart-phone'
    getMobiles: () ->
      item for item in @getAll() when item.type in ['smart-phone', 'tablet']
    getComputers: () ->
      item for item in @getAll() when item.type in ['pc', 'notebook']
    filterItemsByPrice: (options) ->
      min = options?.min ? 0
      max = options?.max ? Infinity
      @_items.sort((a, b) -> a.price - b.price)
      item for item in @_items when min < item.price < max
    filterItemsByType: (type) ->
      item for item in @getAll() when item.type is type
    filterItemsByName: (name) ->
      item for item in @getAll() when item.name.match(new RegExp(name, "i"))
    countItemsByType: () ->
      itemsByType = []
      for item in @getAll()
        itemsByType[item.type] ?= 0
        itemsByType[item.type]++
      itemsByType