using FluentAssertions;

namespace JobNimbus.Tests;

public class BracketsTests
{
    public BracketsTests()
    {
        Sut = new Brackets();
    }

    public Brackets Sut { get; }

    [Theory]
    [InlineData("{}", true)]
    [InlineData("{}{}", true)]
    [InlineData("{{},{}}", true)]
    [InlineData("{abc...xyz}", true)]
    [InlineData("", true)]
    [InlineData("abc...xyz", true)]
    [InlineData("}{", false)]
    [InlineData("{{}", false)]
    [InlineData("{}}", false)]
    [InlineData("{}{{", false)]    
    public void Should_test_brackets(string input, bool expected)
    {
        var result = Sut.IsBracketsMatch(input);

        result.Should().Be(expected);
    }
}