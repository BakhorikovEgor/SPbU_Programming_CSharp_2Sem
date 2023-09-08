using MatrixMultiplication;


var firstMatrix = new Matrix(new int[2, 2] { { 1, 1 }, { 2, 2 } });
var secondMatrix = new Matrix(new int[2, 2] { { 3, 3 }, { 4, 4 } });

var resultMatrixData = firstMatrix.Multiply(secondMatrix).MatrixData;


for (var i = 0; i < resultMatrixData.GetLength(0); ++i)
{
    Console.WriteLine();
    for (var j = 0; j < resultMatrixData.GetLength(1); ++j)
    {
        Console.Write(resultMatrixData[i,j] + " ");
    }
}


