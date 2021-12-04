package lab8.threading;

public class Program {

    public static void main(String[] args) {
        int[][] matrix = { 
                { 1, 2, 3, 4 },
                { 5, 6, 7, 8 },
                { 9, 10, 11, 12 },
                { 13, 14, 15, 16 },
                { 17, 18, 19, 20 },
                { 21, 22, 23, 24 } };
        
        MatrFun matrFun = new MatrFun();
        
        new MatrixThread(matrix, "Even", 0, 2, matrFun);
        new MatrixThread(matrix, "Odd", 1, 9, matrFun);
    }
}
