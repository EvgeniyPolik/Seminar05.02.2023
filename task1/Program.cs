int GetIntFromConsole(string message)
{
    Console.WriteLine(message);
    return int.Parse(Console.ReadLine() ?? "");
}

int[,] GetIntRandomArray(int arrayDimension, int startRange = 0, int endRange  = 100)  // Формирование массива
{
    var rnd = new  Random();
    int[,] result =  new int[arrayDimension, arrayDimension];
    for (var i = 0; i < arrayDimension; i++)
        for (var j = 0; j < arrayDimension; j++)
            result[i, j] = rnd.Next(startRange, endRange);
    return result;
}

void PrintArray(int[,] expArray, string message = "Сформированный массив: ")  // Печать массива
{
    Console.WriteLine(message);
    int lenghtColumn = expArray.GetLength(0);
    int lenghtLine = expArray.GetLength(1);
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

int[] GetCountOfNumbers(int[,]expArray, int leftBorderRange, int rightBorderRange)
{
    int[] result = new int[rightBorderRange - leftBorderRange];
    for (int i = 0; i < expArray.GetLength(0); i++)
        for (int j = 0; j < expArray.GetLength(1); j++)
            result[expArray[i, j] - leftBorderRange]++;
    return result;
}

void PrintResult(int[] countOfNumber, int leftBorderRange)
{
    for (int i = 0; i < countOfNumber.Length; i++)
        if (countOfNumber[i] != 0)
        {
            Console.Write($"Число {i + leftBorderRange} встречается {countOfNumber[i]} раз");
            Console.WriteLine();
        }
}

int dimensionArray = GetIntFromConsole("Введите размерность массива: ");
int leftBorderRange = GetIntFromConsole("Минимальное значение: ");
int rightBorderRange = GetIntFromConsole("Максимальное значение: ");
int[,] expArray = GetIntRandomArray(dimensionArray, leftBorderRange, rightBorderRange);
PrintArray(expArray);
var countOfNumber = GetCountOfNumbers(expArray, leftBorderRange, rightBorderRange);
PrintResult(countOfNumber, leftBorderRange);