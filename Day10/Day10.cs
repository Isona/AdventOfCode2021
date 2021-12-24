string[] lines = File.ReadAllLines(@"Day10Input.txt");

//Part 1
Console.WriteLine("Part 1");
doParts(lines);

void doParts(string[] lines)
{
    Dictionary<char, char> bracesDict = getBracesDictionary();

    long syntaxCheckerScore = 0;
    List<long> autoCompleteScores = new List<long>();

    foreach(string line in lines)
    {
        bool syntaxError = false;
        Stack<char> openBraces = new Stack<char>();

        foreach(char c in line)
        {
            if(bracesDict.Keys.Contains(c))
            {
                openBraces.Push(c);
            }
            else
            {
                //Queue empty
                if(openBraces.Count == 0)
                {
                    syntaxCheckerScore += getSyntaxCheckScore(c);
                    syntaxError = true;
                    break;
                }
                else if(bracesDict[openBraces.Peek()] == c)
                {
                    openBraces.Pop();
                }
                else
                {
                    syntaxCheckerScore += getSyntaxCheckScore(c);
                    syntaxError = true;
                    break;
                }
            }
        }

        if (syntaxError)
        {
            continue;
        }

        long autoCompleteScore = 0;

        while(openBraces.Count > 0)
        {
            autoCompleteScore = autoCompleteScore * 5 + getAutoCompleteScore(openBraces.Pop());
        }
        autoCompleteScores.Add(autoCompleteScore);
    }

    Console.WriteLine("Part 1: " + syntaxCheckerScore);

    autoCompleteScores.Sort();
    Console.WriteLine("Part 2: " + autoCompleteScores[autoCompleteScores.Count / 2]);
}

Dictionary<char, char> getBracesDictionary()
{
    return new Dictionary<char, char>(){
        {'[', ']' },
        {'(', ')' },
        {'<', '>' },
        {'{', '}' } 
    };
}

int getSyntaxCheckScore(char closingBrace)
{
    switch (closingBrace)
    {
        case ')':
            return 3;
        case ']':
            return 57;
        case '}':
            return 1197;
        case '>':
            return 25137;
        default:
            return 0;
    }
}

int getAutoCompleteScore(char openingBrace)
{
    switch (openingBrace)
    {
        case '(':
            return 1;
        case '[':
            return 2;
        case '{':
            return 3;
        case '<':
            return 4;
        default:
            return 0;
    }
}