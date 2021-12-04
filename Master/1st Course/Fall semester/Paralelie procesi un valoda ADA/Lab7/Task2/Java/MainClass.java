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
        
        MatrixThread thread1 = new MatrixThread(matrix, 0, "Even", 1, 0);
        MatrixThread thread2 = new MatrixThread(matrix, 1, "Odd", 9, 10);
        
        thread1.getThread().start();
        thread2.getThread().start();
        
        try {
            thread1.getThread().join();
            thread2.getThread().join();
        }
        catch (InterruptedException e) {
            System.out.println(e.getMessage());
        }
        
        System.out.println("Total sum: " + (thread1.getSum() + thread2.getSum()));
    }
}
