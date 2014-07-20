# Task 1
hiThisIsInteger = 42
hiThisIsFloat = 3.14
hiThisIsBoolean = false
hiThisIsString = "And then there were none ..."

# Task 2
howYouDoin = "\"How you doin'?\", Joey said."

# Task 3
TypeOf = (x) ->
  document.writeln "'#{x}' is of type " + typeof x + "<br />"
  return

TypeOf hiThisIsInteger
TypeOf hiThisIsFloat
TypeOf hiThisIsBoolean
TypeOf hiThisIsString

# Task 4
hiThisIsNull = null
hiThisIsUndefined = undefined
TypeOf hiThisIsNull
TypeOf hiThisIsUndefined
