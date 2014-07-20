define ["todo-list/section"], (Section) ->
  class Container
    constructor: () ->
      @_sections = []
    @::add = (section) ->
      if section instanceof Section then @_sections.push(section) else throw new Error("The container can only have sections")
    @::getData = () ->
      section.getData() for section in @_sections
