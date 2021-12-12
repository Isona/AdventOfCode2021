using System.Text.RegularExpressions;

string[] lines = File.ReadAllLines(@"Day8Input.txt");

Console.WriteLine("Part 1");
part1(lines);

Console.WriteLine();
Console.WriteLine("Part 2");
part2(lines);

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

void part2(string[] lines)
{
    int outputSum = 0;

    foreach (string line in lines)
    {
        string[] digits = new string[10];
        string[] parts = line.Split('|');
        string[] inputNumbers = parseArray(parts[0]);
        string[] outputValues = parseArray(parts[1]);

        // Find 1,4,7,8
        foreach (string v in inputNumbers)
        {
            // 1
            if (v.Length == 2)
            {
                digits[1] = v;
            }
            // 4
            else if (v.Length == 4)
            {
                digits[4] = v;
            }
            // 7
            else if (v.Length == 3)
            {
                digits[7] = v;
            }
            // 8
            else if (v.Length == 7)
            {
                digits[8] = v;
            }
        }

        // Use deduction to find all but 2 and 5
        foreach (string v in inputNumbers)
        {
            //0
            if (v.Length == 6 && digits[7].All(v.Contains) && !digits[4].All(v.Contains))
            {
                digits[0] = v;
            }
            //3
            else if(v.Length == 5 && digits[7].All(v.Contains))
            {
                digits[3] = v;
            }
            // 6
            else if(v.Length == 6 && !digits[7].All(v.Contains))
            {
                digits[6] = v;
            }
            // 9
            else if (v.Length == 6 && digits[4].All(v.Contains))
            {
                digits[9] = v;
            }
        }

        foreach (string v in inputNumbers)
        {
            // 5
            if (v.Length == 5 && v != digits[3] && v.All(digits[6].Contains))
            {
                digits[5] = v;
            }
            // 2
            else if(v.Length == 5 && v != digits[3])
            {
                digits[2] = v;
            }
        }

        int displayValue = 0;
        foreach (string v in outputValues)
        {
            displayValue = displayValue * 10 + Array.IndexOf(digits, v);
        }
        outputSum += displayValue;

    }

    Console.WriteLine(outputSum);
}

string[] parseArray(string values)
{
    string[] returnArray = Regex.Split(values.Trim(), "[ ]+");

    for (int i = 0; i < returnArray.Length; i++)
    {
        returnArray[i] = String.Concat(returnArray[i].OrderBy(c => c));
    }

    return returnArray;
}