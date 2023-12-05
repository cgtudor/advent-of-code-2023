using System.Text.RegularExpressions;

namespace GearRatios;

public class EngineSchematicParser
{
    public static int SumPartNumbers(string schematic)
    {
        var sum = 0;
        var lines = schematic.Split('\n');

        for (var i = 0; i < lines.Length; i++)
        {
            var matches = Regex.Matches(lines[i], @"\d+");

            foreach (Match match in matches)
            {
                var number = int.Parse(match.Value);
                var start = match.Index;
                var end = start + match.Length - 1;

                for (var j = start; j <= end; j++)
                {
                    if (HasAdjacentSymbol(lines, i, j))
                    {
                        sum += number;
                        break;
                    }
                }
            }
        }

        return sum;
    }

    private static bool HasAdjacentSymbol(string[] lines, int i, int j)
    {
        var directions = new[] { (-1, -1), (-1, 0), (-1, 1), (0, -1), (0, 1), (1, -1), (1, 0), (1, 1) };

        foreach (var (di, dj) in directions)
        {
            var ni = i + di;
            var nj = j + dj;

            if (ni >= 0 && ni < lines.Length && nj >= 0 && nj < lines[ni].Length && !Char.IsDigit(lines[ni][nj]) && lines[ni][nj] != '.')
            {
                return true;
            }
        }

        return false;
    }
}