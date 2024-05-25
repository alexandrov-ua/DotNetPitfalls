using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace DotNetPitfalls
{
    public static class MyIntExtensions
    {
        public static IEnumerator<int> GetEnumerator(this int value)
        {
            return Enumerable.Range(0, value).GetEnumerator();
        }
    }

    public class ForeachDuckTyping
    {
        [Fact]
        public void BecauseWeCan()
        {
            int sum = 0;
            foreach (var i in 4)
            {
                sum += i;
            }

            sum.Should().Be(6);
        }
    }
}