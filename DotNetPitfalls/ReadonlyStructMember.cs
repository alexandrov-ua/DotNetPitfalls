using FluentAssertions;
using Xunit;

namespace DotNetPitfalls;

public struct Counter
{
    private int _i;
    public int I => _i;

    public void Increment()
    {
        _i = _i + 1;
    }
}

public class ReadonlyStructMember
{
    private readonly Counter _counter =  new Counter();

    [Fact]
    public void Expected()
    {
       _counter.Increment();
       _counter.I.Should().Be(1);
    }

    [Fact]
    public void Actual()
    {
        _counter.Increment();
        _counter.I.Should().Be(0);
    }
}