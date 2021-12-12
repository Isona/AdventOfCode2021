// See https://aka.ms/new-console-template for more information
using System.Text.RegularExpressions;

string[] lines = File.ReadAllLines(@"Day9TestInput.txt");
HeightMap inputMap = new HeightMap(lines);

Console.WriteLine("Part 1");


public class HeightMap
{
    int[,] points;

    public HeightMap(string[] lines)
    {
        points = new int[lines[0].Length, lines.Length];

        for(int y = 0; y < lines.Length; y++)
        {
            for(int x = 0; x < lines[y].Length; x++)
            {
                points[x, y] = Convert.ToInt32(lines[y][x]);
            }
        }
    }

    public Boolean isLowPoint(int x, int y)
    {
        return false;
    }

    public List<int> getAdjacent(int x, int y)
    {
        List<int> adjacentPoints = new List<int>();


    }
}