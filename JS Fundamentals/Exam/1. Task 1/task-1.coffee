Solve = (args) ->
  [S, C1, C2, C3] = args.map(Number)

  maxSpent = 0
  spent = 0
  for a in [0..S/C1]
    spent = a * C1
    if spent > S then continue
    for b in [0..S/C2]
      spent = a * C1 + b * C2
      if spent > S then continue
      for c in [0..S/C3]
        spent = a * C1 + b * C2 + c * C3
        if spent > S then continue
        maxSpent = spent if spent > maxSpent
        #console.log("a = #{a}, b = #{b}, c = #{c}, max = #{maxSpent}")

  maxSpent

test1 = ["110", "13", "15", "17"] # 100
test2 = ["20","11","200","300"]   # 11
test3 = ["110","19","29","39"]    # 107
test4 = ["1", "11", "12", "13"]   # 0
test5 = ["21", "11", "12", "13"]  # 13

console.log Solve test1
console.log Solve test2
console.log Solve test3
console.log Solve test4
console.log Solve test5


# input = N M R C
# calculations = da logic!
# output = result
