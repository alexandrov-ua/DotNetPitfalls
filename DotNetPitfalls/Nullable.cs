using System;
using FluentAssertions;
using Xunit;

namespace DotNetPitfalls
{
    public class NullableInt
    {
        [Fact]
        public void Expected()
        {
            int? t = 42;
            t.GetType().Should().Be(typeof(int?));
        }
        
        [Fact]
        public void Actual()
        {
            int? t = 42;
            t.GetType().Should().Be(typeof(int));
        }
    }
}