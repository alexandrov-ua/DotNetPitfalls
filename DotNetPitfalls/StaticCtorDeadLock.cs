using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace DotNetPitfalls
{
    /// <summary>
    /// Explanation http://sergeyteplyakov.blogspot.com/2013/06/blog-post_28.html
    /// </summary>
    class A
    {
        public static readonly int Foo = GetFoo();

        static A()
        {
        }
        
        private static int GetFooImpl() { return 42; }

        private static int GetFoo()
        {
            return Task.Factory.StartNew<int>(GetFooImpl).Result;
        }
    }
    
    public class StaticCtorDeadLock
    {
        [Fact]
        public void WaitForIt()
        {
            A.Foo.Should().Be(42);
        }
    }
}