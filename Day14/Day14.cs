string[] lines = File.ReadAllLines(@"Day14Input.txt");

List<PolymerRule> rules = new List<PolymerRule>();
for(int i = 2; i < lines.Length; i++)
{
    rules.Add(new PolymerRule(lines[i]));
}

// Do part 1
Console.WriteLine("Part 1");
doPart(10, lines[0], rules);

Console.WriteLine("");

// Do part 2
Console.WriteLine("Part 2");
doPart(40, lines[0], rules);

void doPart(int roundCount, string initialString, List<PolymerRule> rules)
{
    Dictionary<string, long> currentIter = createFreshSet(rules);
    for (int j = 0; j < initialString.Length - 1; j++)
    {
        currentIter[Char.ToString(lines[0][j]) + Char.ToString(lines[0][j + 1])]++;
    }

    for (int i = 0; i < roundCount; i++)
    {
        currentIter = doIteration(rules, currentIter);
    }

    printScore(currentIter, initialString);
}


// TODO: Write properly
void printScore(Dictionary<string, long> pairList, string initialString)
{
    Dictionary<char, long> elementCount = new Dictionary<char, long>();

    foreach (KeyValuePair<string, long> entry in pairList)
    {
        if (!elementCount.ContainsKey(entry.Key[0]))
        {
            elementCount.Add(entry.Key[0], 0);
        }

        elementCount[entry.Key[0]] += entry.Value;

        if (!elementCount.ContainsKey(entry.Key[1]))
        {
            elementCount.Add(entry.Key[1], 0);
        }

        elementCount[entry.Key[1]] += entry.Value;
    }

    elementCount[initialString[0]] += 1;
    elementCount[initialString[initialString.Length - 1]] += 1;

    foreach (KeyValuePair<char, long> entry in elementCount)
    {
        elementCount[entry.Key] = entry.Value / 2;
    }

    long leastCommon = long.MaxValue;
    long mostCommon = 0;

    foreach (KeyValuePair<char, long> entry in elementCount)
    {
        Console.WriteLine(entry.Key + ": " + entry.Value);
        if (entry.Value < leastCommon)
        {
            leastCommon = entry.Value;
        }

        if (entry.Value > mostCommon)
        {
            mostCommon = entry.Value;
        }
    }

    Console.WriteLine("Most common: " + mostCommon);
    Console.WriteLine("Least common: " + leastCommon);
    Console.WriteLine(mostCommon - leastCommon);
}

Dictionary<string, long> doIteration(List<PolymerRule> rules, Dictionary<string, long> previousIter)
{
    Dictionary<string, long> currentIter = createFreshSet(rules);

    for (int i = 0; i < rules.Count; i++)
    {
        long prevCount = previousIter[rules[i].input];
        currentIter[rules[i].output1] += prevCount;
        currentIter[rules[i].output2] += prevCount;
    }

    return currentIter;
}

Dictionary<string, long> createFreshSet(List<PolymerRule> rules)
{
    Dictionary<String, long> pairs = new Dictionary<String, long>();
    for (int i = 0; i < rules.Count; i++)
    {
        pairs.Add(rules[i].input, 0);
    }

    return pairs;
}


public class PolymerRule
{
    public string input;
    public string output1;
    public string output2;

    public PolymerRule(String line)
    {
        //CH -> B
        string original1 = Char.ToString(line[0]);
        string original2 = Char.ToString(line[1]);
        string extraChar = Char.ToString(line[line.Length - 1]);

        input = original1 + original2;
        output1 = original1 + extraChar;
        output2 = extraChar + original2;
    }

    public override bool Equals(Object obj)
    {
        //Check for null and compare run-time types.
        if((obj == null) || (obj is not PolymerRule && obj is not string))
        {
            return false;
        }
        else if (obj is string)
        {
            return input == obj;
        }
        else
        {
            PolymerRule other = (PolymerRule)obj;
            return this.input == other.input;
        }
    }
}