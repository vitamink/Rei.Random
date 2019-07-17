# A .NET Pseudo-Random Number Generator

C# implementation of [Mersenne Twister](http://www.math.sci.hiroshima-u.ac.jp/~m-mat/MT/mt.html), [SFMT](http://www.math.sci.hiroshima-u.ac.jp/~m-mat/MT/SFMT/index.htm), and five other algorithms, [written by Rei Hobara](http://www.rei.to/random.html).

Mersenne Twister (MT) is arguably the most popular pseudo-random number generator. SFMT is an optimized version of MT which is roughly twice as fast.

All credit goes to the original authors of Mersenne Twister, SFMT and other algorithms.<br>
Thanks to Rei for translating the original C code into C#, bringing together a number of pseudo-random algorithms, and giving permission to re-publish her work here!

## Implemented Algorithms
*   [Linear Congruential (LCG)](http://en.wikipedia.org/wiki/Linear_congruential_generator)
*   [Mother of All](http://www.codecogs.com/library/statistics/random/motherofall.php)
*   [Mersenne Twister](http://en.wikipedia.org/wiki/Mersenne_twister)
*   [SFMT](http://en.wikipedia.org/wiki/Mersenne_twister#SFMT)
*   [Xorshift](http://en.wikipedia.org/wiki/Xorshift)
*   [Well](http://en.wikipedia.org/wiki/Well_Equidistributed_Long-period_Linear)
*   [Ranrot-B](http://www.agner.org/random/randomc.htm)

## Todo
1.  Add original unit tests to project.
2.  Sign assembly.
3.  Nant build script.
4.  Publish package on nuget.
