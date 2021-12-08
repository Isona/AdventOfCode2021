using System.Text.RegularExpressions;

string[] lines = File.ReadAllLines(@"Day8Input.txt");

Console.WriteLine("Part 1");
part1(lines);

void part1(string[] lines)
{
    int[] lengths = new int[] { 2, 4, 3, 7 };
    int sum = 0;

    foreach (string line in lines)
    {
        string[] parts = line.Split('|');
        string[] outputValues = Regex.Split(parts[1].Trim(), "[ ]+");
        
        foreach (string value in outputValues)
        {
            if (lengths.Contains(value.Length))
            {
                sum++;
            }
        }
    }

    Console.WriteLine(sum);
}