package lab8.threading;

public class MatrFun {	
    synchronized static void printRow(int row, int[][] matrix) {
        System.out.print("Row: " + row + ". Elements: ");
        
        for (int j = 0; j < matrix[row].length; j++) {
            System.out.print(matrix[row][j] + " ");
            
            try {
                Thread.sleep(0);
            }
            catch(InterruptedException e) {
                System.out.println(e.getMessage());
            }
        }
        
        System.out.println();
    }
}