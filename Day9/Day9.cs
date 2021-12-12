// Currently gets wrong answer on real input, 1796 is too high

string[] lines = File.ReadAllLines(@"Day9Input.txt");
HeightMap inputMap = new HeightMap(lines);

Console.WriteLine("Part 1");
part1(inputMap);

void part1(HeightMap inputMap)
{

    List<Coordinate> lowPoints = new List<Coordinate>();

    for(int x = 0; x < inputMap.xLength; x++)
    {
        for(int y = 0; y < inputMap.yLength; y++)
        {
            Coordinate currentPoint = new Coordinate(x, y);
            if (inputMap.isLowPoint(currentPoint))
            {
                lowPoints.Add(currentPoint);
            }
        }
    }

    int lowPointSum = 0;
    foreach (Coordinate currentPoint in lowPoints)
    {
        lowPointSum += inputMap.getValue(currentPoint) + 1;
    }

    Console.WriteLine(lowPointSum);
}

public class HeightMap
{
    int[,] points;
    public int xLength;
    public int yLength;

    public HeightMap(string[] lines)
    {
        points = new int[lines[0].Length, lines.Length];

        for(int y = 0; y < lines.Length; y++)
        {
            for(int x = 0; x < lines[y].Length; x++)
            {
                // points[x, y] = Convert.ToInt32(lines[y][x]);
                points[x, y] = Convert.ToInt32(Char.GetNumericValue(lines[y][x]));
            }
        }

        xLength = lines[0].Length;
        yLength = lines.Length;
    }

    public int getValue(Coordinate coord)
    {
        return points[coord.x, coord.y];
    }

    public Boolean isLowPoint(Coordinate coord)
    {
        int currentValue = points[coord.x, coord.y];
        List<Coordinate> adjacentPoints = getAdjacent(coord);

        bool lowPoint = true;
        foreach (Coordinate point in adjacentPoints)
        {
            int adjValue = points[point.x, point.y];
            if (adjValue < currentValue)
            {
                lowPoint = false;
                break;
            }
        }

        return lowPoint;
    }

    public Boolean isInBounds(Coordinate coord)
    {
        return coord.x >= 0 && coord.y >= 0 && 
            coord.x < points.GetLength(0) && coord.y < points.GetLength(1);
    }

    public List<Coordinate> getAdjacent(Coordinate coord)
    {
        List<Coordinate> adjacentPoints = new List<Coordinate>();

        Coordinate up = new Coordinate(coord.x, coord.y-1);
        if(isInBounds(up))
        {
            adjacentPoints.Add(up);
        }

        Coordinate down = new Coordinate(coord.x, coord.y+1);
        if(isInBounds(down))
        {
            adjacentPoints.Add(down);
        }

        Coordinate left = new Coordinate(coord.x - 1, coord.y);
        if(isInBounds(left))
        {
            adjacentPoints.Add(left);
        }

        Coordinate right = new Coordinate(coord.x + 1, coord.y);
        if(isInBounds(right))
        {
            adjacentPoints.Add(right);
        }

        return adjacentPoints;
        
    }
}

public class Coordinate
{
    public int x;
    public int y;

    public Coordinate (int inX, int inY)
    {
        x = inX;
        y = inY;
    }
}