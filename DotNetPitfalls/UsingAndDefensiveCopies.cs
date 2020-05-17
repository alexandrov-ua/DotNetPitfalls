using System;
using FluentAssertions;
using Xunit;

namespace DotNetPitfalls
{
    public class UsingAndDefensiveCopies
    {
        private struct MyStruct : IDisposable
        {
            private bool _isDisposed;

            public void Dispose()
            {
                if (_isDisposed)
                    throw new ObjectDisposedException(nameof(MyStruct));
                _isDisposed = true;
            }
        }

        [Fact]
        public void Ok()
        {
            var d = new MyStruct();

            Action act = () =>
            {
                d.Dispose();
                d.Dispose();
            };

            act.Should().Throw<ObjectDisposedException>();
        }

        [Fact]
        public void StillOk()
        {
            Action act = () =>
            {
                using (var d = new MyStruct())
                {
                    d.Dispose();
                }
            };
            
            act.Should().Throw<ObjectDisposedException>();
        }
        
        [Fact]
        public void Suddenly()
        {
            Action act = () =>
            {
                var d = new MyStruct();
                using (d)
                {
                    d.Dispose();
                }
            };
            
            act.Should().Throw<Exception>();
        }
    }
}