string[] lines = File.ReadAllLines(@"Day11Input.txt");

Dictionary<string, Cave> caveDict = new Dictionary<string, Cave>();

// Set up caves and connections
foreach (string line in lines)
{
    string[] currentCaves = line.Split("-");
    Cave firstCave;
    if(!caveDict.ContainsKey(currentCaves[0]))
    {
        firstCave = caveDict[currentCaves[0]];
    }
    else
    {
        firstCave = new Cave(currentCaves[0]);
        caveDict.Add(currentCaves[0], firstCave);
    }

    Cave secondCave;
    if (!caveDict.ContainsKey(currentCaves[1]))
    {
        secondCave = caveDict[currentCaves[1]];
    }
    else
    {
        secondCave = new Cave(currentCaves[1]);
        caveDict.Add(currentCaves[1], secondCave);
    }

    firstCave.addConnection(secondCave);
    secondCave.addConnection(firstCave);
}

int numberOfPaths = getPaths(new string[] { "start" }, caveDict);
Console.WriteLine("Part 1: " + numberOfPaths);

int getPaths(string[] pathTaken, Dictionary<string, Cave> caveDict)
{

}

public class Cave
{
    public string Name { get; }
    bool bigCave;
    List<Cave> Connected { get; }

    public Cave(string inName)
    {
        Name = inName;
        bigCave = char.IsUpper(inName[0]);
        Connected = new List<Cave>();
    }

    public void addConnection(Cave connectedCave)
    {
        if (!Connected.Contains(connectedCave))
        {
            Connected.Add(connectedCave);
        }
    }

    public override bool Equals(Object obj)
    {
        //Check for null and compare run-time types.
        if ((obj == null) || !this.GetType().Equals(obj.GetType()))
        {
            return false;
        }
        else
        {
            Cave p = (Cave)obj;
            return Name.Equals(p.Name);
        }
    }
}