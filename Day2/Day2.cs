string[] commands = File.ReadAllLines(@"Day2Input.txt");

Console.WriteLine("Part 1");
part1(commands);

Console.WriteLine("Part 2");
part2(commands);

void part1(string[] commands)
{
    int horizontal = 0;
    int depth = 0;

    foreach(string command in commands)
    {
        String[] commParts = command.Split(" ");
        switch (commParts[0])
        {
            case "forward":
                horizontal += Int32.Parse(commParts[1]);
                break;
            case "down":
                depth += Int32.Parse(commParts[1]);
                break;
            case "up":
                depth -= Int32.Parse(commParts[1]);
                break;
        }
    }    
    Console.WriteLine("Horizontal = " + horizontal);
    Console.WriteLine("Depth = " + depth);
    Console.WriteLine(depth*horizontal);
}

void part2(string[] commands)
{
    int horizontal = 0;
    int depth = 0;
    int aim = 0;

    foreach(string command in commands)
    {
        string[] commParts = command.Split(" ");
        int distance = Int32.Parse(commParts[1]);
        switch (commParts[0])
        {
            case "forward":
                horizontal += distance;
                depth += aim * distance;
                break;
            case "down":
                aim += distance;
                break;
            case "up":
                aim -= distance;
                break;
        }
    }

    Console.WriteLine("Horizontal = " + horizontal);
    Console.WriteLine("Depth = " + depth);
    long result = depth * horizontal;
    Console.WriteLine(result);
}