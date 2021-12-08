// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


public class Point
{
    public int x;
    public int y;

    public bool Equals (Point other)
    {
        return x == other.x && y == other.y;
    }
}

public class Line
{
    public Point startPoint;
    public Point endPoint;
    public Point[] points; 

    public bool diagonal()
    {
        if (startPoint.x == endPoint.x || startPoint.y == endPoint.y)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public Point[] intersections(Line testLine)
    {

    }
}