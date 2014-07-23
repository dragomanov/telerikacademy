// Generated by CoffeeScript 1.7.1
(function() {
  define(function() {
    var Item;
    return Item = (function() {
      var NAME_MAX_CHARS, NAME_MIN_CHARS;

      NAME_MIN_CHARS = 6;

      NAME_MAX_CHARS = 40;

      function Item(type, name, price) {
        var _ref;
        this.type = type;
        this.name = name;
        this.price = price;
        if (!((NAME_MIN_CHARS <= (_ref = name.length) && _ref <= NAME_MAX_CHARS))) {
          throw new Error("Name must be between " + NAME_MIN_CHARS + " and " + NAME_MAX_CHARS + " characters!");
        }
        if (type !== 'accessory' && type !== 'smart-phone' && type !== 'notebook' && type !== 'pc' && type !== 'tablet') {
          throw new Error("Type can only be 'accessory', 'smart-phone', 'notebook', 'pc' or 'tablet'");
        }
      }

      return Item;

    })();
  });

}).call(this);