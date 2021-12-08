// See https://aka.ms/new-console-template for more information
string[] stringDepths = File.ReadAllLines(@"Day1Input.txt");
int[]depths = new int[stringDepths.Length];
for (int i = 0; i < stringDepths.Length; i++)
    depths[i] = int.Parse(stringDepths[i]);

Console.WriteLine("Part 1");
part1(depths);

Console.WriteLine("Part 2");
part2(depths);


void part1(int[] depths) {
    int previousDepth = depths[0];
    int increaseCount = 0;

    foreach (var depth in depths)
    {
        if (depth > previousDepth)
            increaseCount++;
        previousDepth = depth;
    }

    Console.WriteLine(increaseCount);
}

void part2(int[] depths)
{
    int[] depthTriples = new int[depths.Length-2];
    for (int i = 0; i < depthTriples.Length; i++)
        depthTriples[i] = depths[i]+depths[i+1]+depths[i+2];

    int previousDepthTriple = depthTriples[0];
    int increaseCount = 0;

    foreach (var depthTriple in depthTriples)
    {
        if (depthTriple > previousDepthTriple)
            increaseCount++;
        previousDepthTriple = depthTriple;
    }

    Console.WriteLine(increaseCount);
}