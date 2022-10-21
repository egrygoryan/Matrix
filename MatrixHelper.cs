namespace Matrix {
    public static class MatrixHelper {
        public static void DisplayMatrix(int[,] matrix, string textResult = "Processing") {
            Console.WriteLine(textResult);

            for (int i = 0; i < matrix.GetLength(0); i++) {
                for (int y = 0; y < matrix.GetLength(1); y++) {
                    Console.Write($"{matrix[i, y]} ");
                }
                Console.WriteLine();
            }
        }

        public static void FillInMatrix(int[,] matrix, Random random) {
            for (int i = 0; i < matrix.GetLength(0); i++) {
                for (int j = 0; j < matrix.GetLength(1); j++) {
                    matrix[i, j] = random.Next(0, 4);
                }
            }
        }
    }
}