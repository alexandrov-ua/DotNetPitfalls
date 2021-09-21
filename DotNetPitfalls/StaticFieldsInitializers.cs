using FluentAssertions;
using Xunit;

namespace DotNetPitfalls
{
    public static class Foo
    {
        private static int c = a + b;
        private static int a = 1;
        private static int b = 2;

        public static int Result() => c;
    }

    public static class Bar
    {
        private static int a = 1;
        private static int b = 2;
        private static int c = a + b;

        public static int Result() => c;
    }
    
    public class StaticFieldsInitializers
    {
        [Fact]
        public void Expected()
        {
            Foo.Result().Should().Be(3);
        }
        
        [Fact]
        public void Actual()
        {
            Foo.Result().Should().Be(0);
        }
        
        [Fact]
        public void ToCheck()
        {
            Bar.Result().Should().Be(3);
        }
    }
}