namespace MatrixMultiplication;

public class Matrix
{
    public int[,] MatrixData { get; private set; }
    public int Rows { get; private set; }
    public int Columns { get; private set; }

    public Matrix(int[,] data)
    {
        MatrixData = data;
        Rows = data.GetLength(0);
        Columns = data.GetLength (1);
    }

    public Matrix Multiply(Matrix secondMatrix)
    {
        if (!MultiplicationMatching(secondMatrix))
        {
            throw new ArgumentException();
        }

        var newMatrixData = new int[Rows, secondMatrix.Columns];
        for (var i = 0; i < Rows; ++i)
        {
            for (var j = 0; j < secondMatrix.Columns; ++j)
            {
                for (var k = 0; k < Columns; ++k)
                {
                    newMatrixData[i, j] += MatrixData[i, k] * secondMatrix.MatrixData[k, j];
                }
            }
        }

        var newMatrix = new Matrix(newMatrixData);
        return newMatrix;
    }

    bool MultiplicationMatching (Matrix secondMatrix)
    {
        if (Columns != secondMatrix.Rows)
        {
            return false;
        }

        return true;
    }
}
