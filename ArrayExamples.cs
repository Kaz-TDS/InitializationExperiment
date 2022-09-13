using BenchmarkDotNet.Attributes;

namespace InitializationExperiment;

public class ArrayExamples
{
    public const int SIZE = 10000;
    public const int SIZE_SQARE = SIZE * SIZE;
    
    [Benchmark]
    public void RowFirstTwoDimArray()
    {
        var matrix = new int[SIZE, SIZE];
        for (int row = 0; row < SIZE; row++) {
            for (int column = 0; column < SIZE; column++) {
                matrix[row, column] = row * SIZE + column;
            }
        }
    }

    [Benchmark]
    public void ColumnFirstTwoDimArray()
    {
        var matrix = new int[SIZE, SIZE];
        for (int column = 0; column < SIZE; column++) {
            for (int row = 0; row < SIZE; row++) {
                matrix[row, column] = row * SIZE + column;
            }
        }
    }

    [Benchmark]
    public void OneDimensionalArray()
    {
        var matrix = new int[SIZE_SQARE];
        for (int row = 0; row < SIZE; row++) {
            var offset = row * SIZE;
            for (int column = 0; column < SIZE; column++) {
                matrix[offset + column] = row * SIZE + column;
            }
        }
    }
    
    [Benchmark]
    public void OneDimensionalArrayWithSpan()
    {
        var matrix = new int[SIZE_SQARE];
        for (int row = 0; row < SIZE; row++) {
            var span = new Span<int>(matrix, row * SIZE, SIZE);
            var rowSize = row * SIZE;
            for (int column = 0; column < SIZE; column++) {
                span[column] = rowSize + column;
            }
        }
    }
}