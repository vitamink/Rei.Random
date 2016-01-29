using System;

namespace Rei.Random
{
    public static class RandomExtensions
    {
        /// <summary>
        /// Returns a non-negative random integer.
        /// </summary>
        /// <param name="random"></param>
        /// <returns></returns>
        public static int Next(this RandomBase random)
        {
            return Math.Abs(random.NextInt32());
        }

        /// <summary>
        /// Returns a non-negative random integer that is less than the specified maximum.
        /// </summary>
        /// <param name="random"></param>
        /// <param name="maxValue">The exclusive upper bound of the random number to be generated. maxValue must be greater than or equal to 0.</param>
        /// <returns></returns>
        public static int Next(this RandomBase random, int maxValue)
        {
            if (maxValue < 0)
            {
                throw new ArgumentOutOfRangeException("maxValue", "maxValue is less than 0.");
            }
            return (int) (random.NextDouble()*maxValue);
        }

        /// <summary>
        /// Returns a random integer that is within a specified range.
        /// </summary>
        /// <param name="random"></param>
        /// <param name="minValue">The inclusive lower bound of the random number returned.</param>
        /// <param name="maxValue">The exclusive upper bound of the random number returned. maxValue must be greater than or equal to minValue.</param>
        /// <returns></returns>
        public static int Next(this RandomBase random, int minValue, int maxValue)
        {
            if (minValue > maxValue)
            {
                throw new ArgumentOutOfRangeException("minValue", "minValue is greater than maxValue.");
            }
            return minValue + (int) (random.NextDouble()*(maxValue - minValue));
        }
    }
}
