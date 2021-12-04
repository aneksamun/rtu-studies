package lab7.threading;

public class MatrixThread implements Runnable {
    private Thread thread;
    private int[][] matrix;
    private int row, delay;
    
    public MatrixThread(
        int[][] matr, 
        int startRow,
        String name,
        int priority,
        int delay) {
        
        matrix = matr;
        row = startRow;
        this.delay = delay;
        
        thread = new Thread(this);
        thread.setName(name);
        thread.setPriority(priority);
        thread.start();
    }
    
    public void run() {
        int sum = 0;
        
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
            
            System.out.println(Thread.currentThread() + ". Row: " + i + ", Sum: " + sum);
            
            sum = 0;
        }
    }
}
