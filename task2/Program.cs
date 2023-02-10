using System.Text;

int[] GetIntArrayFromConsole(string message)
{
    Console.WriteLine(message);
    return (Console.ReadLine() ?? "").Split().Select(int.Parse).ToArray();
}


Matrix GetRandomMatrix(int[] sizeMatrix, int rangeMin = 0, int rangeMax = 99)
{
    var resultMatrix = new Matrix(sizeMatrix[0], sizeMatrix[1]);
    var rnd = new Random();
    for (int i = 0; i < sizeMatrix[0]; i++)
        for (int j = 0; j < sizeMatrix[1]; j++)
            resultMatrix[i, j] = rnd.Next(rangeMin, rangeMax);
    return resultMatrix;

}

int[] sizeMatrixA = GetIntArrayFromConsole("Введите размеры матрицы A через пробел: ");
var matrixA = GetRandomMatrix(sizeMatrixA);
int[] sizeMatrixB = GetIntArrayFromConsole("Введите размеры матрицы B через пробел: ");
var matrixB = GetRandomMatrix(sizeMatrixB);
Console.WriteLine("Матрица A:");
Console.WriteLine(matrixA);
Console.WriteLine("Матрица B:");
Console.WriteLine(matrixB);
Console.WriteLine("Проиведение матриц A и B:");
Console.WriteLine(matrixA * matrixB);

class Matrix
{
    private int[,] matrix;
    public Matrix(int lineCount, int columnCount)
    {
        this.matrix = new int[lineCount, columnCount];
    }
    public int this[int line, int column]
    {
        get { return matrix[line, column]; }
        set { matrix[line, column] = value; }
    }
    public int length 
    {
        get { return matrix.Length; }
    }
    public int GetLength(int dimension)
    {
        if (0 <= dimension && dimension < 2)
            return matrix.GetLength(dimension);
        throw new ArgumentException();
    }

    public override string ToString()
    {
        var outStringBuildel = new StringBuilder();
        for (int i = 0; i < this.GetLength(0); i++)
        {
            for (int j = 0; j < this.GetLength(1); j++)
            {
                outStringBuildel.Append(this[i, j]);
                outStringBuildel.Append("\t");
            }
            outStringBuildel.Append("\n");
        }
        return outStringBuildel.ToString();
    }
    public static Matrix operator *(Matrix matrixA, Matrix matrixB)
    {
        if (matrixA.GetLength(1) != matrixB.GetLength(0))
            throw new ArgumentException("not valid matrix");
        var result = new Matrix(matrixA.GetLength(0), matrixB.GetLength(1));
        for (int i = 0; i < matrixA.GetLength(0); i++)
            for (int j = 0; j < matrixB.GetLength(1); j++)
                for (int t = 0; t < matrixA.GetLength(1); t++)
                    result[i, j] += matrixA[i, t] * matrixB[t, j];
        return result;
    }
    public static Matrix operator *(Matrix matrixA, int x)
    {
        var result = new Matrix(matrixA.GetLength(0), matrixA.GetLength(1));
        for (int i = 0; i < matrixA.GetLength(0); i++)
            for (int j = 0; j < matrixA.GetLength(1); j++)
                matrixA[i, j] *= x;
        return result;
    }
    public static Matrix operator *(int x, Matrix matrixA)
    {
        return matrixA * x;
    }

}