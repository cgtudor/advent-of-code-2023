using System.Text.RegularExpressions;

public class CubeGameValidator
{
    public int MaxRedCubes { get; init; }
    public int MaxGreenCubes { get; init; }
    public int MaxBlueCubes { get; init; }

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
