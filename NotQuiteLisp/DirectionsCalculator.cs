namespace NotQuiteLisp;

public static class DirectionsCalculator
{
    public static int GetFloorFromDirections(string directions)
    {
        var positiveDirections = directions.Count(x => x == '(');
        var negativeDirections = directions.Count(x => x == ')');

        return positiveDirections - negativeDirections;
    }
    
    public static int GetFirstBasementPosition(string directions)
    {
        var floor = 0;
        var position = 0;

        foreach (var direction in directions)
        {
            position++;

            switch (direction)
            {
                case '(':
                    floor++;
                    break;
                case ')':
                    floor--;
                    break;
            }

            if (floor == -1)
            {
                return position;
            }
        }

        return -1;
    }
}