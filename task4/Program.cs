void GeneratorUniqueValues(RandomMarker randomMarker, int[] randomArray, int startValue, int endValue)
{
    if (randomMarker.CurrentPosition == randomArray.Length)
        return;
    Random rnd = new Random();
    int rndValue = rnd.Next(startValue, endValue);
    randomArray[randomMarker.CurrentPosition] = randomMarker.catalogValues[rndValue];
    randomMarker.CurrentPosition++;
    if (startValue < rndValue)
        GeneratorUniqueValues(randomMarker, randomArray, startValue, rndValue - 1);
    if (endValue > rndValue)
        GeneratorUniqueValues(randomMarker, randomArray, rndValue + 1, endValue);
}

int[,,] GetRandomArray(int[] sizeArray)  // Получение массива
{
    int startRange = 10;
    int endRange = 99;
    RandomMarker randomMarker = new RandomMarker(startRange, endRange);
    int[] randomArray = new int[sizeArray[0] * sizeArray[1] * sizeArray[2]];
    GeneratorUniqueValues(randomMarker, randomArray, 0, 89);
    int[,,] result = new int[sizeArray[0], sizeArray[1], sizeArray[2]];
    int counter = 0;
    for (int i = 0; i < sizeArray[0]; i++)
        for (int j = 0; j < sizeArray[1]; j++)
            for (int t = 0; t < sizeArray[2]; t++)
            {
                result[i, j, t] = randomArray[counter];
                counter++;
            }
    return result;
}

bool CheckParams(int[] sizeArray)  // Проверка на возможность заполения неповторяющимися числами
{
    return sizeArray[0] * sizeArray[1] * sizeArray[2] <= 90;
}

int[] GetIntArrayFromConsole(string message)  // Получить размерность из консоли
{
    Console.Write(message);
    return (Console.ReadLine() ?? "").Split().Select(int.Parse).ToArray();
}

void PrintArray(int[,,] expArray)  // Печать массива
{
    for (int i = 0; i < expArray.GetLength(0); i++)
        for (int j = 0; j < expArray.GetLength(1); j++)
            for (int t = 0; t < expArray.GetLength(2); t++)
                Console.WriteLine($"Значение {expArray[i, j, t]} на позиции ({i}, {j}, {t})");
}

var sizeArray = GetIntArrayFromConsole("Введите размерность трехмерного массива через пробел: ");
if (CheckParams(sizeArray))
{
    var expArray = GetRandomArray(sizeArray);
    PrintArray(expArray);
}
else 
    Console.WriteLine("Неверная размерность массива");

class RandomMarker  // Класс заполнитель без повторений
{
    public int CurrentPosition { get; set; }
    public int[] catalogValues;
    public RandomMarker(int startValue, int endValue)
    {
        CurrentPosition = 0;
        int len = endValue - startValue;
        catalogValues = new int[len];
        catalogValues = Enumerable.Range(10, len + 1).ToArray();
    }        
}
