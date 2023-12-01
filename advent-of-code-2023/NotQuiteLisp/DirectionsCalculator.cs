namespace NotQuiteLisp;

public static class DirectionsCalculator
{
    public static int GetFloorFromDirections(string directions)
    {
        var floor = 0;
        foreach (var direction in directions)
        {
            switch (direction)
            {
                case '(':
                    floor++;
                    break;
                case ')':
                    floor--;
                    break;
            }
        }

        return floor;
    }
}