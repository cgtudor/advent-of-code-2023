using FluentAssertions;

namespace GearRatios;

public class EngineSchematicParserTests
{
    [Test]
    public void EngineSchematicParser_SumPartNumbers_ShouldSumNumbersAdjacentToSymbols()
    {
        var simpleTest = """
        467..114..
        ...*......
        ..35..633.
        ......#...
        617*......
        .....+.58.
        ..592.....
        ......755.
        ...$.*....
        .664.598..
        """;
        var sum = EngineSchematicParser.SumPartNumbers(simpleTest);
        sum.Should().Be(4361);
    }

    [Test]
    public void EngineSchematicParser_SumPartNumbers_AdventTest()
    {
        var sum = EngineSchematicParser.SumPartNumbers(EngineSchematics.AdventTest);
        sum.Should().Be(536273);
    }
}