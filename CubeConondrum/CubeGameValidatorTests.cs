using FluentAssertions;

namespace CubeConondrum;

public class Tests
{
    [Test]
    public void CubeGameValidator_ShouldRecognizeValidGame()
    {
        const string games = "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green";
        CubeGameValidator validator = new(4, 2, 6);
        validator.SumIdOfValidGames(games).Should().Be(1);
    }
    
    [Test]
    public void CubeGameValidator_ShouldRecognizeInvalidGame()
    {
        const string games = "Game 1: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red";
        CubeGameValidator validator = new(12, 13, 14);
        validator.SumIdOfValidGames(games).Should().Be(0);
    }
    
    [Test]
    public void CubeGameValidator_ShouldSumCorrectlyWithAListOfGames()
    {
        const string games = """
                             Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green
                             Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue
                             Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red
                             Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red
                             Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green
                             """;
        CubeGameValidator validator = new(12, 13, 14);
        validator.SumIdOfValidGames(games).Should().Be(8);
    }
    
    [Test]
    public void CubeGameValidator_AdventTest()
    {
        var games = CubeConondrumInput.AdventInput;
        CubeGameValidator validator = new(12, 13, 14);
        validator.SumIdOfValidGames(games).Should().Be(2683);
    }
    
    [Test]
    public void CubeGameValidator_PowerSum_AdventTest()
    {
        var games = CubeConondrumInput.AdventInput;
        CubeGameValidator validator = new(12, 13, 14);
        validator.SumPowerNeededForGames(games).Should().Be(49710);
    }
}