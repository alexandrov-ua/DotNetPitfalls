using System;
using FluentAssertions;
using Xunit;

namespace DotNetPitfalls
{
    /// <summary>
    /// http://sergeyteplyakov.blogspot.com/2011/02/this-null-c.html
    /// </summary>
    public class MyClass
    {
        public bool Foo() => this == null;
    }

    public class ThisEqualsNull
    {
        [Fact]
        public void Expected()
        {
            new MyClass().Foo().Should().BeFalse();
        }

        [Fact]
        public void BecauseWeCan()
        {
            var method = typeof(MyClass).GetMethod("Foo");
            var action = (Func<bool>)Delegate.CreateDelegate(typeof(Func<bool>), null, method);
            action().Should().BeTrue();
        }
    }
}