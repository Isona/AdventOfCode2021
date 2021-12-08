string[] lines = File.ReadAllLines(@"Day3Input.txt");

Console.WriteLine("Part 1");
part1(lines);

Console.WriteLine();

Console.WriteLine("Part 2");
part2(lines);

void part1(string[] lines)
{
    double[] sum = new double[lines[0].Length];
    
    for (int i = 0; i < lines.Length; i++)
    {
        for(int j = 0; j < lines[i].Length; j++)
        {
            sum[j] += Char.GetNumericValue(lines[i][j]);
        }
    }

    string epsilon = "";
    string gamma = "";

    for (int i = 0; i < sum.Length; i++)
    {
        if (sum[i] > lines.Length/2)
        {
            gamma += "1";
            epsilon += "0";
        }
        else
        {
            gamma += "0";
            epsilon += "1";
        }
    }

    int realEpsilon = Convert.ToInt32(epsilon, 2);
    Console.WriteLine("Epsilon = " + realEpsilon);

    int realGamma = Convert.ToInt32(gamma, 2);
    Console.WriteLine("Gamma = " + realGamma);
    Console.WriteLine(realGamma * realEpsilon);
}

void part2(string[] lines)
{
    string oxygenRating = "";
    while (oxygenRating.Length != lines[0].Length)
    {
        oxygenRating = getRating(lines, oxygenRating, 1);
    }


    string co2ScrubberRating = "";
    while (co2ScrubberRating.Length != lines[0].Length)
    {
        co2ScrubberRating = getRating(lines, co2ScrubberRating, 0);
    }

    Console.WriteLine(oxygenRating);
    int realOxygenRating = Convert.ToInt32(oxygenRating, 2);
    Console.WriteLine("Oxygen rating = " + realOxygenRating);

    Console.WriteLine(co2ScrubberRating);
    int realco2ScrubberRating = Convert.ToInt32(co2ScrubberRating, 2);
    Console.WriteLine("CO2 Scrubber Rating = " + realco2ScrubberRating);

    Console.WriteLine(realOxygenRating * realco2ScrubberRating);
}

string getRating(string[] lines, string startsWith, int toggle)
{
    double mostCommonSum = 0;
    int numberFound = 0;

    for (int i = 0; i < lines.Length; i++)
    {
        if (lines[i].StartsWith(startsWith))
        {
            numberFound++;
            mostCommonSum += Char.GetNumericValue(lines[i][startsWith.Length]);
        }
    }

    if (numberFound == 1)
    {
        for (int i = 0; i < lines.Length; i++)
        {
            if (lines[i].StartsWith(startsWith))
            {
                return lines[i];
            }
        }
    }

    if ((toggle == 1 && mostCommonSum >= (numberFound + 1) / 2)
        || (toggle == 0 && mostCommonSum < (numberFound + 1) / 2))
    {
        startsWith += "1";
    }
    else
    {
        startsWith += "0";
    }

    return startsWith;
}