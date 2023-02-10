using System.Text;

int GetIntFromConsole(string message)
{
    Console.WriteLine(message);
    return int.Parse(Console.ReadLine() ?? "");
}

IEnumerable<int[]> GetLine(int n)
{
    if (n % 2 == 0)
        n++;
    int[] newLine = new int[n];
    newLine[n / 2] = 1;
    while (true)
    {
        yield return newLine;
        int[] tmpLine = new int[n];
        for (int i = 0; i < n; i++)
        {
            if (newLine[i] > 0)
            {
                if (i != 0)
                    tmpLine[i - 1] += newLine[i];
                if (i != n - 2)
                    tmpLine[i + 1] += newLine[i];
            }
        }
        newLine = tmpLine;
    }
}

void printLine(int[] line)
    {
        int len = line.Length;
        StringBuilder lineString = new StringBuilder();
        for (int i = 0; i < len; i++)
        {
            if (line[i] == 0)
                lineString.Append("     ");
            else
                lineString.Append($"{line[i]}".PadLeft(3).PadRight(5));
        }
        Console.WriteLine(lineString.ToString());
    }

var n = GetIntFromConsole("Введите количество элементов: ");
foreach(var line in GetLine(n))
{
    printLine(line);
    if (Console.KeyAvailable)
        break;
    Thread.Sleep(1000);
}