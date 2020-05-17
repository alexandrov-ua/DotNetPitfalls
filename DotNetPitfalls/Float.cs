using FluentAssertions;
using Xunit;

namespace DotNetPitfalls
{
    //Not C# pitfall, it's related to Float specification
    public class Float
    {
        [Fact]
        public void Expected()
        {
            (9999999999999999.0 
             - 
             9999999999999998.0)
                .Should()
                .Be(1.0);
        }
        
        [Fact]
        public void Actual()
        {
            (9999999999999999.0 
             - 
             9999999999999998.0)
                .Should()
                .Be(2.0);
        }
    }
}