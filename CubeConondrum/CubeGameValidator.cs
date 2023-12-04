using System.Text.RegularExpressions;

namespace CubeConondrum;

public class CubeGameValidator
{
    private int MaxRedCubes { get; init; }
    private int MaxGreenCubes { get; init; }
    private int MaxBlueCubes { get; init; }

    public CubeGameValidator(int redCubes, int greenCubes, int blueCubes)
    {
        MaxRedCubes = redCubes;
        MaxGreenCubes = greenCubes;
        MaxBlueCubes = blueCubes;
    }

    public int SumIdOfValidGames(string games)
    {
        var gamesList = games.Split(Environment.NewLine);
        return gamesList.Sum(game =>
        {
            var id = int.Parse(game.Split(":")[0].Split(" ")[1]);
            return IsValid(game) ? id : 0;
        });
    }

    public int SumPowerNeededForGames(string games)
    {
        var gamesList = games.Split(Environment.NewLine);
        return gamesList.Sum(ExtractPower);
    }

    private int ExtractPower(string game)
    {
        var maxCounts = ExtractMaxColorCounts(game);
        
        var redPower = maxCounts["red"] == 0 ? 1 : maxCounts["red"];
        var greenPower = maxCounts["green"] == 0 ? 1 : maxCounts["green"];
        var bluePower = maxCounts["blue"] == 0 ? 1 : maxCounts["blue"];

        return redPower * greenPower * bluePower;
    }

    private bool IsValid(string game)
    {
        var maxCounts = ExtractMaxColorCounts(game);
        return maxCounts["red"] <= MaxRedCubes
               && maxCounts["green"] <= MaxGreenCubes
               && maxCounts["blue"] <= MaxBlueCubes;
    }

    private Dictionary<string, int> ExtractMaxColorCounts(string input)
    {
        var colors = new[] { "red", "green", "blue" };
        var maxCounts = new Dictionary<string, int> { { "red", 0 }, { "green", 0 }, { "blue", 0 } };

        foreach (var color in colors)
        {
            var regex = new Regex($@"(\d+)\s+{color}");
            var matches = regex.Matches(input);

            foreach (Match match in matches)
            {
                var count = int.Parse(match.Groups[1].Value);
                if (count > maxCounts[color])
                {
                    maxCounts[color] = count;
                }
            }
        }

        return maxCounts;
    }
}