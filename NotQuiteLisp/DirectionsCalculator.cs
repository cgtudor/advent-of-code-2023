namespace NotQuiteLisp;

public static class DirectionsCalculator
{
    public static int GetFloorFromDirections(string directions)
    {
        var positiveDirections = directions.Count(x => x == '(');
        var negativeDirections = directions.Count(x => x == ')');

        return positiveDirections - negativeDirections;
    }
}