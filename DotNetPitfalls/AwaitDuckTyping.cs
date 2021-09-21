using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xunit;

namespace DotNetPitfalls
{
    internal static class IntExtensions
    {
        public static TaskAwaiter GetAwaiter(this int i) => Task.Delay(i).GetAwaiter();
    }

    public class AwaitDuckTyping
    {
        [Fact]
        public async Task BecauseWeCan()
        {
            await 5;
        }
    }
}