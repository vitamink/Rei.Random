using Xunit;

namespace Rei.Random.Tests
{
    
    public class TestGeneratedResults
    {
        [Fact]
        public void ensure_NextDouble_returns_a_value_between_0_and_1()
        {
            var random = new MersenneTwister();

            for (int i = 0; i < 10000; i++)
            {
                Assert.InRange(random.NextDouble(), 0.0, 1.0);
            }
        }
    }
}
