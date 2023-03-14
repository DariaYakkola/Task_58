Console.Write("Введите количество строк для первой матрицы: ");
int matrixRows1 = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите количество столбцов для первой матрицы: ");
int matrixCols1 = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите количество строк для второй матрицы: ");
int matrixRows2 = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите количество столбцов для второй матрицы: ");
int matrixCols2 = Convert.ToInt32(Console.ReadLine());
if (matrixCols1 != matrixRows2)
{
  Console.Write("Матрицы с такими параметрами невозможно перемножить!");
  return;
}
/// <summary>
/// Метод, который заполняет двумерный массив рандомными целыми числами
/// </summary>
/// <param name="rows">Количество строк в массиве</param>
/// <param name="cols">Количество столбцов в массиве</param>
/// <param name="minValue">Минимальное число для рандома</param>
/// <param name="maxValue">Максимальное число для рандома</param>
/// <returns>Возвращаем заполненный двумерных массив</returns>
int[,] GetMatrix (int rows, int cols, int minValue, int maxValue)
{
  int[,] matrix = new int[rows, cols];
  for (int i = 0; i < rows; i++)
  {
    for (int j = 0; j < cols; j++)
    {
      matrix[i, j] = new Random().Next(minValue, maxValue + 1);
    }
  }
  return matrix;
}
/// <summary>
/// Метод, который печатает двумерный массив
/// </summary>
/// <param name="array2D">Двумерный массив целых чисел</param>
void PrintMatrix (int[,] array2D)
{
  int rows = array2D.GetLength(0);
  int cols = array2D.GetLength(1);
  for (int i = 0; i < rows; i++)
  {
    for (int j = 0; j < cols; j++)
    {
      Console.Write(array2D[i,j] + "\t");
    }
    Console.WriteLine();
  }
}
int[,] matrix1 = GetMatrix(matrixRows1, matrixCols1, 1, 10);
PrintMatrix(matrix1);
Console.WriteLine();
int[,] matrix2 = GetMatrix(matrixRows2, matrixCols2, 1, 10);
PrintMatrix(matrix2);
/// <summary>
/// Метод, который умножает первый двумерный массив с целыми числами на второй 
/// </summary>
/// <param name="firstArray2D">Двумерный массив целых чисел</param>
/// <param name="secondArray2D">Двумерный массив целых чисел</param>
/// <returns>Возвращаем результат умножания массивов</returns>
int[,] MultiplicationMatrix (int[,] firstArray2D, int[,] secondArray2D)
{
int[,] resultMatrix = new int[matrixRows1, matrixCols2];
int rows = resultMatrix.GetLength(0);
int cols = resultMatrix.GetLength(1);
for (int i = 0; i < rows; i++)
{
  for (int j = 0; j < cols; j++)
  {
    int sum = 0;
    for (int k = 0; k < matrixCols1; k++)
    {
      sum += matrix1[i, k] * matrix2[k, j];
    }
    resultMatrix[i, j] = sum;
  }
}
return resultMatrix;
}
int[,] resultMatrix = MultiplicationMatrix (matrix1, matrix2);
Console.WriteLine("Результат умножения матриц: ");
PrintMatrix(resultMatrix);