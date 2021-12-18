string[] lines = File.ReadAllLines(@"Day14TestInput.txt");

List<PolymerRule> rules = new List<PolymerRule>();
for(int i = 2; i < lines.Length; i++)
{
    rules.Add(new PolymerRule(lines[i]));
}

// Do part 1
Console.WriteLine("Part 1");
doPart(10, lines[0], rules);


void doPart(int roundCount, string initialString, List<PolymerRule> rules)
{
    Dictionary<string, int> currentIter = createFreshSet(rules);
    for (int j = 0; j < initialString.Length - 1; j++)
    {
        currentIter[Char.ToString(lines[0][j]) + Char.ToString(lines[0][j + 1])]++;
    }

    for (int i = 0; i < roundCount; i++)
    {
        currentIter = doIteration(rules, currentIter);
    }

    printScore(currentIter);
}


// TODO: Write properly
void printScore(Dictionary<string, int> pairList)
{
    int maxCount = 0;
    int minCount = Int32.MaxValue;
    foreach (KeyValuePair<string, int> entry in pairList)
    {
        if (entry.Value > maxCount)
        {
            maxCount = entry.Value;
        }
        if (entry.Value < minCount)
        {
            minCount = entry.Value;
        }
    }

    Console.WriteLine()
}

Dictionary<string, int> doIteration(List<PolymerRule> rules, Dictionary<string, int> previousIter)
{
    Dictionary<string, int> currentIter = createFreshSet(rules);

    for (int i = 0; i < rules.Count; i++)
    {
        int prevCount = previousIter[rules[i].input];
        currentIter[rules[i].output1] += prevCount;
        currentIter[rules[i].output2] += prevCount;
    }

    return currentIter;
}

Dictionary<string, int> createFreshSet(List<PolymerRule> rules)
{
    Dictionary<String, int> pairs = new Dictionary<String, int>();
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