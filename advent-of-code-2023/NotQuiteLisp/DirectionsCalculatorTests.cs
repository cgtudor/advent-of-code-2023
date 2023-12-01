using FluentAssertions;

namespace NotQuiteLisp;

public class DirectionsCalculatorTests
{
    [Test]
    public void ProcessOpenParenthesisCorrectly()
    {
        var result = DirectionsCalculator.GetFloorFromDirections("(");
        result.Should().Be(1);
    }
    
    [Test]
    public void ProcessClosedParenthesisCorrectly()
    {
        var result = DirectionsCalculator.GetFloorFromDirections(")");
        result.Should().Be(-1);
    }
    
    [Test]
    public void ProcessCombinationOfParenthesesCorrectly()
    {
        var result = DirectionsCalculator.GetFloorFromDirections(")(");
        result.Should().Be(0);
    }
}