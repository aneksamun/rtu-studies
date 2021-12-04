package threading.example;

public class Queue {
    private int x;
    private boolean isValue = false;
    
    public synchronized int get() {
        while(!isValue) {
            try {
                wait();
            } 
            catch(InterruptedException e) {
                
            }
        }
        
        System.out.println("Get: " + x + " ");
        isValue = false;
        
        notify();
        return x;
    }
    
    public synchronized void put(int x) {
        while(isValue) {
            try {
                wait();
            }
            catch(InterruptedException e) {
                
            }
        }
        
        this.x = x;
        isValue = true;
        
        System.out.print("Put: " + this.x + " ");
        
        notify();
    }
}
