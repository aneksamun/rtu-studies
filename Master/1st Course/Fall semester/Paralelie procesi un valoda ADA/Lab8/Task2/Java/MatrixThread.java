package lab8.threading;

public class MatrixThread implements Runnable {
    private Thread thread;
    private int[][] matrix;
    private int startRow;
    private MatrFun matrFun;

    public MatrixThread(
            int[][] matr,
            String name,
            int row,
            int priority,
            MatrFun objMatr) { 
        
        matrix = matr;
        startRow = row;
        matrFun = objMatr;
        
        thread = new Thread(this);
        thread.setName(name);
        thread.setPriority(priority);
        thread.start();
    }
    public void run() {
        for (int i = startRow; i < matrix.length; i += 2) {
            synchronized(this.matrFun) {
                matrFun.printRow(i, matrix);
            }
        }
    }
}
