package lab7.threading;

public class MatrixThread implements Runnable {
    private Thread thread;
    private int[][] matrix;
    private int row, delay, sum;
    
    public MatrixThread(
        int[][] matr, 
        int startRow,
        String name,
        int priority,
        int delay) {
        
        matrix = matr;
        row = startRow;
        this.delay = delay;
        sum = 0;
        
        thread = new Thread(this);
        thread.setName(name);
        thread.setPriority(priority);
    }
    
    public Thread getThread() {
        return thread;
    }
    
    public int getSum() {
        return sum;
    }
    
    public void run() {
        for (int i = row; i < matrix.length; i += 2) {
            for (int j = 0; j < matrix[i].length; j++) {
                sum += matrix[i][j];
                
                try {
                    Thread.sleep(delay);
                }
                catch (InterruptedException e) {
                    System.out.println(e.getMessage());
                }
            }
        }
        
        System.out.println(Thread.currentThread() + ", Sum: " + sum);
    }
}
