package lab7.threading;

public class MainClass {

    public static void main(String[] args) {

        int[][] matrix = {
                { 1, 1, 1, 1, 1, 1, 1, 1 },
                { 2, 2, 2, 2, 2, 2, 2, 2 },
                { 3, 3, 3, 3, 3, 3, 3, 3 },
                { 4, 4, 4, 4, 4, 4, 4, 4 },
                { 5, 5, 5, 5, 5, 5, 5, 5 },
                { 6, 6, 6, 6, 6, 6, 6, 6 },
                { 7, 7, 7, 7, 7, 7, 7, 7 } };
        
        new MatrixThread(matrix, 0, "Even", 2, 0);
        new MatrixThread(matrix, 1, "Odd", 8, 0);
    }
}
