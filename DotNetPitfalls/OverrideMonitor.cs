using System.Threading.Tasks;
using DotNetPitfalls;
using Xunit;
using Xunit.Abstractions;

namespace System.Threading
{
    public class Monitor
    {
        public static void Enter(object obj, ref bool taken)
        {
            (obj as OverrideMonitor)?.OutputHelper.WriteLine("From Enter");
            taken = true;
        }

        public static void Exit(object obj)
        {
            (obj as OverrideMonitor)?.OutputHelper.WriteLine("From Exit");
        }
    }
}


namespace DotNetPitfalls
{
    public class OverrideMonitor
    {
        public readonly ITestOutputHelper OutputHelper;

        public OverrideMonitor(ITestOutputHelper outputHelper)
        {
            OutputHelper = outputHelper;
        }

        [Fact]
        public void Magic()
        {
            lock (this)
            {
                OutputHelper.WriteLine("In lock");
            }
        }
    }    
}

