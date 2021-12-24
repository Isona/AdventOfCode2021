string[] stringInput = File.ReadAllLines(@"Day7Input.txt").First().Split(",");
int[] locations = new int[stringInput.Length];
int lowestLocation = int.MaxValue;
int highestLocation = int.MinValue;

for (int i = 0; i < stringInput.Length; i++)
{
    int value = Int32.Parse(stringInput[i]);
    locations[i] = value;

    if (value < lowestLocation)
        lowestLocation = value;
    if (value > highestLocation)
        highestLocation = value;
}

part1(locations, lowestLocation, highestLocation);
part2(locations, lowestLocation, highestLocation);

void part1(int[] locations, int lowestLocation, int highestLocation)
{
    long leastFuel = int.MaxValue;
    int leastLocation = 0;
    for (int goalLocation = lowestLocation; goalLocation < highestLocation; goalLocation++)
    {
        long totalFuel = 0;
        foreach (int location in locations)
        {
            totalFuel += Math.Abs(location - goalLocation);
        }

        if (totalFuel < leastFuel)
        {
            leastFuel = totalFuel;
            leastLocation = goalLocation;
        }
    }

    Console.WriteLine("Part 1: " + leastLocation + ": " + leastFuel);
}

void part2(int[] locations, int lowestLocation, int highestLocation)
{
    long leastFuel = int.MaxValue;
    int leastLocation = 0;
    for (int goalLocation = lowestLocation; goalLocation < highestLocation; goalLocation++)
    {
        long totalFuel = 0;
        foreach (int location in locations)
        {
            int distance = Math.Abs(location - goalLocation);
            long triangleNum = distance * (distance + 1) / 2;
            totalFuel += triangleNum;
        }

        if (totalFuel < leastFuel)
        {
            leastFuel = totalFuel;
            leastLocation = goalLocation;
        }
    }

    Console.WriteLine("Part 1: " + leastLocation + ": " + leastFuel);
}