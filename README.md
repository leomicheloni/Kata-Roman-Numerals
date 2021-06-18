# Kata Roman Numerals - Refactoring

This kata is taken from the book `The Coding Dojo Handbook` by Emily Bache `ISBN 978-91-981180-0-1`.

## Before start
The main branch contains a `c#` project with a test project inside.

1. Clone this repository
1. Create a branch with your name.
1. Push your branch.

## Important
1. Remember the Red-Green-Refactor cycle.
2. Name your tests using the following pattern: `method_name_With_arguments_Returns_return_value()`

## The problem
For this Kata, write a function to convert from normal (Ara- bic) numbers to Roman Numerals.
For example:
```
1 -> I 
10 -> X
7 -> VII
```
There is no need to be able to convert numbers larger than about 3000.

## More information

Symbol | Value
------------ | -------------
I | 1
V | 5
X | 10
L | 50
C | 100
D | 500
M | 100

Generally, symbols are placed in order of value, starting with the 
largest values. When smaller values precede larger values, 
the smaller values are subtracted from the larger values, and the 
result is added to the total. However, you can’t write numerals 
like `IM` for `999`, there are some additional rules:

1. A number written in Arabic numerals can be broken into digits. 
For example, 1903 is composed of 1 (one thousand), 9 (nine hundreds), 
0 (zero tens), and 3 (three units). To write the Roman numeral, 
each of the non-zero digits should be treated separately. 
In the above example, `1,000 = M, 900 = CM, and 3 = III`.
Therefore, `1903 = MCMIII`.
1. The symbols `I`, `X`, `C`, and `M` can be repeated three times in 
succession, but no more. (They may appear more than three times 
if they appear non-sequentially, such as `XXXIX`) 
1. `D`, `L`, and `V`.
can never be repeated.
1. `I` can be subtracted from `V` and `X` only. 
1. `X` can be subtracted from `L` and `C` only. 
1. `C` can be subtracted from `D` and `M` only. 
1. `V`, `L`, and `D` can never be subtracted.
1. Only one small-value symbol may be subtracted from 
any large-value symbol.

## Part II
Write a function to convert in the other direction, ie numeral to digit

## Retrospective
1. Did you manage to build up the algorithm gradually, driving development with tests?
1. Is your choice of algorithm obvious from the code, or do you need additional comments?

### Contexts to use this Kata
This is quite an easy Kata, it’s a good introduction to building up an algorithm using TDD.