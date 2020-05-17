using System;
using DotNetPitfalls.Tools;
using FluentAssertions;
using Xunit;

namespace DotNetPitfalls
{
    public class NewGenericConstraintAndException
    {
        private class Foo
        {
            public Foo()
            {
                throw new MyException();
            }
        }

        private static T Create<T>()
            where T : new()
            => new T();

        [Fact]
        public void Expected()
        {
            Action act = () => Create<Foo>().Should().NotBeNull();

            act.Should().Throw<MyException>();
        }

        [Fact]
        public void Actual()
        {
            Action act = () => Create<Foo>().Should().NotBeNull();

            act.Should().Throw<System.Reflection.TargetInvocationException>()
                .WithInnerException<MyException>();
        }
    }
}