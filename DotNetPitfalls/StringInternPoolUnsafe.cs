using FluentAssertions;
using Xunit;

namespace DotNetPitfalls
{
    public class StringInternPoolUnsafe
    {
        private void Reverse(string str)
        {
            unsafe
            {
                var len = str.Length;
                fixed (char* ptr = str)
                {
                    for (var i = 0; i < len / 2; i++)
                    {
                        var tmp = ptr[i];
                        ptr[i] = ptr[len - i - 1];
                        ptr[len - i - 1] = tmp;
                    }
                }
            }
        }

        [Fact]
        public void Magic()
        {
            Reverse("Hello world");
            
            "Hello world".Should().Be("dlrow olleH");
        }
    }
}