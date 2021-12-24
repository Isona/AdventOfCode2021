// See https://aka.ms/new-console-template for more information

string[] stringInput = File.ReadAllLines(@"Day6Input.txt").First().Split(",");
Dictionary<long, long> inputPairs = new Dictionary<long, long>();

foreach(string input in stringInput)
{
    int value = Int32.Parse(input);
    if (!inputPairs.ContainsKey(value))
    {
        inputPairs.Add(value, 0);
    }
    inputPairs[value]++;
}

// Do part 1
Console.WriteLine("Part 1");
doPart(80, inputPairs);

Console.WriteLine();
Console.WriteLine("Part 2");
doPart(256, inputPairs);

void doPart(int dayCount, Dictionary<long, long> inputPairs)
{
    Dictionary<long, long> currentFish = inputPairs;
    for (int i = 0; i < dayCount; i++)
    {
        currentFish = doDay(currentFish);
    }

    Console.WriteLine(getLanternfishCount(currentFish));
}


Dictionary<long, long> doDay(Dictionary<long, long> inputLanternfish)
{
    Dictionary<long, long> outputLanternfish = new Dictionary<long, long>();

    foreach (KeyValuePair<long, long> day in inputLanternfish)
    {
        if (day.Key == 0)
        {
            outputLanternfish.Add(8, day.Value);

            if (!outputLanternfish.ContainsKey(6))
            {
                outputLanternfish.Add(6, 0);
            }

            outputLanternfish[6] += day.Value;
        }
        else
        {
            if (!outputLanternfish.ContainsKey(day.Key-1))
            {
                outputLanternfish.Add(day.Key-1, 0);
            }

            outputLanternfish[day.Key-1] += day.Value;
        }
    }

    return outputLanternfish;
}

long getLanternfishCount(Dictionary<long, long> lanternfish)
{
    long count = 0;
    foreach (KeyValuePair<long , long> day in lanternfish)
    {
        count += day.Value;
    }
    return count;
}