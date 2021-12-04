package lab8.threading;

public class MatrixThread implements Runnable {
    private Thread thread;
    private int[][] matrix;
    private int startRow;

    public MatrixThread(
            int[][] matr,
            String name,
            int row,
            int priority) { 
        
        matrix = matr;
        startRow = row;
        
        thread = new Thread(this);
        thread.setName(name);
        thread.setPriority(priority);
        thread.start();
    }
    
    public void run() {
        for (int i = startRow; i < matrix.length; i += 2)
            MatrFun.printRow(i, matrix);
    }
}
