using System;
using DotNetPitfalls.Tools;
using FluentAssertions;
using Xunit;

namespace DotNetPitfalls
{
    public class StaticCtorException
    {
        public class Singleton
        {
            private static readonly Singleton _instance;
        
            static Singleton()
            {
                _instance = new Singleton(); 
            }

            public Singleton()
            {
                throw new MyException();
            }

            public static Singleton Instance => _instance;
            public static int SomeVal => 42;
        }

        [Fact]
        public void Expected()
        {
            Action act = ()=> Singleton.Instance.Should().NotBeNull();

            act.Should().Throw<MyException>();
        }

        [Fact]
        public void Actual()
        {
            Action act = ()=> Singleton.Instance.Should().NotBeNull();

            act.Should().Throw<TypeInitializationException>()
                .WithInnerException<MyException>();
        }

        [Fact]
        public void Singleton_ShouldThrowTypeInitializationExceptionOnEveryCallOfSingleton_WhenExceptionInStaticCtorWasThrown()
        {
            Action act = ()=> Singleton.Instance.Should().NotBeNull();

            act.Should().Throw<TypeInitializationException>()
                .WithInnerException<MyException>();

            Action act2 = () => Singleton.SomeVal.Should().Be(42);

            act2.Should().Throw<TypeInitializationException>()
                .WithInnerException<MyException>();

        }
    }
}