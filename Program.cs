// See https://aka.ms/new-console-template for more information
using Matrix;

Random random = new Random();
int[,] matrix = new int[9, 9];

MatrixHelper.FillInMatrix(matrix, random);
var result = MatrixChecker.MatrixEvalution(matrix, random);
MatrixHelper.DisplayMatrix(result, "Final result");