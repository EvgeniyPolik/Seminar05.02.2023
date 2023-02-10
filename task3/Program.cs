int GetIntFromConsole(string message)
{
    Console.WriteLine(message);
    return int.Parse(Console.ReadLine() ?? "");
}

int[,] GetIntRandomArray(int arrayDimension0, int arrayDimension1, int startRange = 0, int endRange  = 100)  // Формирование массива
{
    var rnd = new  Random();
    int[,] result =  new int[arrayDimension0, arrayDimension1];
    for (var i = 0; i < arrayDimension0; i++)
        for (var j = 0; j < arrayDimension1; j++)
            result[i, j] = rnd.Next(startRange, endRange);
    return result;
}

void PrintArray(int[,] expArray, string message = "Сформированный массив: ")  // Печать массива
{
    Console.WriteLine(message);
    int lenghtColumn = expArray.GetLength(1);
    int lenghtLine = expArray.GetLength(0);
    for (int i = 0; i < lenghtLine; i++)
    {
        for (int j = 0; j < lenghtColumn; j++)
        {
            Console.Write(expArray[i, j]);
            if (j < lenghtColumn - 1)
                Console.Write("\t");
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}

int[] GetMinLineColumn(int[,] expArray)
{
    int m = expArray.GetLength(0) - 1;
    int n = expArray.GetLength(1) - 1;
    int minLine = m;
    int minColumn = n;
    for (int i = 0; i <= m; i++)
        for (int j = 0; j <= n; j++)
            if (expArray[i, j] < expArray[minLine, minColumn])
                (minLine, minColumn) = (i, j);
    Console.WriteLine($"Минимальный элемент: {expArray[minLine, minColumn]}, находится по адресу: ({minLine+1}, {minColumn+1})");
    return new int[] {minLine, minColumn};
}

int[,] DelMinLineColumn(int[,] expArray)
{
    int[] minLineColumn = GetMinLineColumn(expArray);
    int m = expArray.GetLength(0) - 1;
    int n = expArray.GetLength(1) - 1;
    int[,] result = new int[m, n];
    int offsetM = 0;
    int offsetN = 0;
    for (int i = 0; i <= m; i++)
    {
        offsetN = 0;
        for (int j = 0; j <= n; j++)
        {
            if (i == minLineColumn[0])
                offsetM = 1;
            if (j == minLineColumn[1])
                offsetN = 1;
            if (i != minLineColumn[0] && j != minLineColumn[1])
                result[i - offsetM, j - offsetN] = expArray[i, j];
        }
    }
    return result;
}

var m = GetIntFromConsole("Введите количество строк: ");
var n = GetIntFromConsole("Введите количество столбцов: ");
var expArray = GetIntRandomArray(m, n);
PrintArray(expArray, "Исходный массив:");
var newArray = DelMinLineColumn(expArray);
PrintArray(newArray);