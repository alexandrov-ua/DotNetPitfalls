using System.Threading.Tasks;
using DotNetPitfalls;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace System.Threading
{
    public class Monitor
    {
        public static void Enter(object obj, ref bool taken)
        {
            if (obj is OverrideMonitor t)
            {
                t.Locked = true;
            }

            taken = true;
        }

        public static void Exit(object obj)
        {
            if (obj is OverrideMonitor t)
            {
                t.Locked = false;
            }
        }
    }
}

namespace DotNetPitfalls
{
    public class OverrideMonitor
    {
        public bool Locked { get; set; } = false;

        [Fact]
        public void Magic()
        {
            lock (this)
            {
                Locked.Should().BeTrue();
            }

            Locked.Should().BeFalse();
        }
    }
}