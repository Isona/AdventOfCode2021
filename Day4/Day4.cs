using System.Text.RegularExpressions;

string[] lines = File.ReadAllLines(@"Day4Input.txt");

string[] stringCalls = lines[0].Split(new char[] { ',' });
int[] calls = new int[stringCalls.Length];

for (int i = 0; i < stringCalls.Length; i++)
{
    calls[i] = int.Parse(stringCalls[i]);
}

BingoBoard[] bingoBoards = getBingoBoards(lines);

bothParts(calls, bingoBoards);


static void bothParts (int[] calls, BingoBoard[] bingoBoards)
{
    BingoScore quickestWin = new BingoScore(false, calls.Length+1, 0);
    BingoScore slowestWin = new BingoScore(false, 0, 0);

    foreach (BingoBoard currentBoard in bingoBoards)
    {
        BingoScore currentScore = currentBoard.getScore(calls);
        if (currentScore.won && currentScore.winningTurn < quickestWin.winningTurn)
        {
            quickestWin = currentScore;
        }

        if (currentScore.won && currentScore.winningTurn > slowestWin.winningTurn)
        {
            slowestWin = currentScore;
        }
    }

    Console.WriteLine("Part 1");
    Console.WriteLine("Winning turn = " + quickestWin.winningTurn+1);
    Console.WriteLine("Winning score = " + quickestWin.score);

    Console.WriteLine();

    Console.WriteLine("Part 2");
    Console.WriteLine("Winning turn = " + quickestWin.winningTurn + 1);
    Console.WriteLine("Score = " + slowestWin.score);
}

static BingoBoard[] getBingoBoards(String[] lines)
{
    int numberOfBoards = (lines.Length - 1) / 6;
    BingoBoard[] boards = new BingoBoard[numberOfBoards];

    int currentBoard = 0;
    for (int i = 2; i < lines.Length; i++)
    {
        boards[currentBoard] = new BingoBoard(lines.Skip(i).Take(5).ToArray()); ;
        currentBoard++;
        i += 5;
    }

    return boards;
}

public class BingoItem
{
    public int value;
    public bool called = false;

    public BingoItem(int inputValue)
    {
        value = inputValue;
    }
}

public class BingoBoard
{
    public BingoItem[,] items = new BingoItem[5,5];

    public BingoBoard(string[] lines)
    {
        for (int i = 0; i < lines.Length; i++)
        {
            string[] splitLine = Regex.Split(lines[i].Trim(), "[ ]+");
            for (int j = 0;j < splitLine.Length; j++)
            {
                items[i, j] = new BingoItem(int.Parse(splitLine[j]));
            }
        }
    }

    public BingoScore getScore(int[] callouts)
    {
        // Do the callouts until victory
        bool won = false;
        int winningTurn = 0;
        int lastCall = 0;
        int score = 0;

        for (int i = 0;i < callouts.Length;i++)
        {
            callNumber(callouts[i]);
            if (hasWon())
            {
                won = true;
                lastCall = callouts[i];
                winningTurn = i;
                break;
            }
        }

        if (won)
        {
            int uncalledSum = 0;
            for (int x = 0; x < 5; x++)
            {
                for (int y = 0; y < 5; y++)
                {
                    if (!items[x, y].called)
                    {
                        uncalledSum += items[x, y].value;
                    }
                }
            }

            score = uncalledSum * callouts[winningTurn];
        }

        return (new BingoScore(won, winningTurn, score));
    }

    void callNumber(int callout)
    {
        for (int x = 0; x < 5; x++)
        {
            for (int y = 0; y < 5; y++)
            {
                if (items[x, y].value == callout)
                {
                    items[x, y].called = true;
                }
            }
        }
    }

    bool hasWon()
    {
        // Horizontal
        for (int x = 0; x < 5; x++)
        {
            bool wonRow = true;
            for(int y = 0; y < 5; y++)
            {
                if (!this.items[x, y].called)
                {
                    wonRow = false;
                    break;
                }
            }

            if (wonRow)
            {
                return true;
            }
        }


        // Vertical
        for (int y = 0; y < 5; y++)
        {
            bool wonCol = true;
            for(int x = 0; x < 5;x++)
            {
                if(!this.items[x, y].called)
                {
                    wonCol = false;
                    break;
                }
            }

            if (wonCol)
            {
                return true;
            }
        }
        return false;
    }
}

public class BingoScore
{
    public bool won;
    public int winningTurn;
    public int score;

    public BingoScore(bool wonGame, int turn, int boardScore)
    {
        won = wonGame;
        winningTurn = turn;
        score = boardScore;
    }
}