using FluentAssertions;
using Xunit;

namespace DotNetPitfalls
{
    public static class Generic<T>
    {
        private static int _i = 0;

        public static void Increment()
        {
            _i += 1;
        }

        public static int GetI() => _i;
    }

    public class StaticGenerics
    {
        [Fact]
        public void Actual()
        {
            Generic<int>.Increment();
            Generic<int>.GetI().Should().Be(1);
            Generic<int>.Increment();
            Generic<int>.GetI().Should().Be(2);

            Generic<string>.GetI().Should().Be(0);
        }
    }
}