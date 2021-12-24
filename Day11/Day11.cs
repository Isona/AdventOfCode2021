string[] lines = File.ReadAllLines(@"Day11Input.txt");
int[,] octopi = new int[10, 10];

for (int x = 0; x < 10; x++)
{
    for (int y = 0; y < 10; y++)
    {
        octopi[x, y] = (int)Char.GetNumericValue(lines[x][y]);
    }
}

int flashCount = 0;
bool allHaveFlashed = false;

for (int i = 0; i < 100; i++)
{
    flashCount += doPass(octopi);
    if (allFlashed(octopi))
    {
        allHaveFlashed = true;
        Console.WriteLine("All flashed: " + i);
    }
}

Console.WriteLine("Part 1: " + flashCount);

int rounds = 100;

while(!allHaveFlashed)
{
    doPass(octopi);
    allHaveFlashed = allFlashed(octopi);
    rounds ++;
}

Console.WriteLine("Part 2: " + rounds);

int doPass(int[,] octopi)
{
    int flashCount = 0;

    for (int x = 0; x < 10; x++)
    {
        for(int y = 0; y < 10; y++)
        {
            octopi[x, y] += 1;
        }
    }

    bool changedOnPass = true;

    while(changedOnPass)
    {
        changedOnPass = false;
        for(int x = 0;x < 10; x++)
        {
            for(int y = 0; y < 10; y++)
            {
                if(octopi[x, y] > 9)
                {
                    flashCount++;
                    octopi[x, y] = 0;
                    changedOnPass = true;

                    List<Tuple<int, int>> adjPoints = getAdjacent(x, y);

                    foreach(Tuple<int, int> adjPoint in adjPoints)
                    {
                        if (!(octopi[adjPoint.Item1, adjPoint.Item2] == 0))
                        {
                            octopi[adjPoint.Item1, adjPoint.Item2]++;
                        }
                    }

                }
            }
        }
    }

    return flashCount;
}

List<Tuple<int, int>> getAdjacent(int inX, int inY)
{
    List<Tuple<int, int>> adjacentPoints = new List<Tuple<int, int>>();

    for (int x = inX - 1; x <= inX + 1; x++)
    {
        for ( int y = inY - 1; y <= inY + 1; y++)
        {
            if(inX == x && inY == y)
            {
                continue;
            }

            if(isInBounds(x, y))
            {
                adjacentPoints.Add(new Tuple<int, int>(x, y));
            }
        }
    }

    return adjacentPoints;
}

bool isInBounds(int x, int y)
{
    return (x >= 0 && y >= 0 && x < 10 && y < 10);
}

bool allFlashed(int[,] octopi)
{
    for(int x = 0; x < 10; x++)
    {
        for( int y = 0; y < 10; y++)
        {
            if(octopi[x, y] != 0)
            {
                return false;
            }
        }
    }
    return true;
}