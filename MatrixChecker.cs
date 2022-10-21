namespace Matrix {
    public static class MatrixChecker {
        static int Check(int[,] arrayToCheck, MatrixOperation checkType) {
            switch (checkType) {
                case MatrixOperation.CheckRow:
                    // scan each column
                    // the most leftmost value is as standard
                    for (int i = 0; i < arrayToCheck.GetLength(0); i++) {
                        int current = arrayToCheck[i, 0];
                        int count = 1;
                        // scan each row
                        // iterating through row we check left value with its neighbors
                        for (int j = 1; j < arrayToCheck.GetLength(1); j++) {
                            if (current == arrayToCheck[i, j]) {
                                count++;
                                // increment and check: do we have 3 in the row?
                                if (count == 3) {
                                    MatrixHelper.DisplayMatrix(arrayToCheck);
                                    Console.WriteLine($"row number {i + 1} contains 3 or more identical numbers \n");
                                    return i;
                                }
                            } else {
                                // sequence is broken, let's start again with count = 1 
                                current = arrayToCheck[i, j];
                                count = 1;
                            }
                        }
                    }

                    return -1;
                case MatrixOperation.CheckColumn:
                    // scan each row
                    // the most leftmost value is as standard
                    for (int i = 0; i < arrayToCheck.GetLength(0); i++) {
                        int current = arrayToCheck[0, i];
                        int count = 1;
                        // scan each column
                        // iterating through row we check left value with its neighbors
                        for (int j = 1; j < arrayToCheck.GetLength(1); j++) {

                            if (current == arrayToCheck[j, i]) {
                                count++;
                                // increment and check: do we have 3 in the column?
                                if (count == 3) {
                                    MatrixHelper.DisplayMatrix(arrayToCheck);

                                    Console.WriteLine($"column number {i + 1} contains 3 or more identical numbers \n");
                                    return i;
                                }
                            } else {
                                // sequence is broken, let's start again with count = 1 
                                current = arrayToCheck[j, i];
                                count = 1;
                            }
                        }
                    }

                    return -1;

                default:
                    return -2;
            }
        }

        static void RefillPart(int[,] arrayToRefill, int index, Random random, MatrixOperation refillType) {
            switch (refillType) {
                case MatrixOperation.RefillRow:
                    //shifting rows to bottom if it is not the 1st row contains more than 3 duplicates
                    if (index > 0) {
                        int row = index - 1;
                        for (int i = index; row >= 0; i--) {
                            for (int j = 0; j < arrayToRefill.GetLength(1); j++) {
                                arrayToRefill[i, j] = arrayToRefill[row, j];
                            }
                            row--;
                        }
                    }

                    //if it is 1st row we just fill it
                    for (int j = 0; j < arrayToRefill.GetLength(1); j++) {
                        arrayToRefill[0, j] = random.Next(0, 4);
                    }
                    break;

                case MatrixOperation.RefillColumn:
                    //shifting columns to right if it is not the 1st column contains more than 3 duplicates
                    if (index > 0) {
                        int column = index - 1;
                        for (int i = index; column >= 0; i--) {
                            for (int j = 0; j < arrayToRefill.GetLength(1); j++) {
                                arrayToRefill[j, i] = arrayToRefill[j, column];
                            }
                            column--;
                        }
                    }

                    //if it is 1st column we just fill it
                    for (int j = 0; j < arrayToRefill.GetLength(1); j++) {
                        arrayToRefill[j, 0] = random.Next(0, 4);
                    }
                    break;
                default: throw new Exception("Not acceptable type of operation");
            }
        }
        public static int[,] MatrixEvalution(int[,] array, Random random) {
            int rowResult;
            int columnResult;
            
            do {
                rowResult = Check(array, MatrixOperation.CheckRow);
                if (rowResult > -1) {
                    RefillPart(array, rowResult, random, MatrixOperation.RefillRow);
                }

                columnResult = Check(array, MatrixOperation.CheckColumn);
                if (columnResult > -1) {
                    RefillPart(array, columnResult, random, MatrixOperation.RefillColumn);
                }

            } while (rowResult != -1 || columnResult != -1);

            return array;
        }
    }
}
