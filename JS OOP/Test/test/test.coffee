sum = () ->
  sum = 0
  for num in [0..1000]
    sum += num

numbers = [0, 1, 2, 3, 4]

Mod = () ->
  log = () ->
    console.log(3)

mod = new Mod()

[a, b, c..., f] = "ABCDEF"

console.log(a, b, c, f)