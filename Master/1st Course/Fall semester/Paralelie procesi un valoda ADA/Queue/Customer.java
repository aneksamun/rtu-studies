package threading.example;

public class Customer implements Runnable {
    private Queue queue;
    
    public Customer(Queue queue) {
        this.queue = queue;
        new Thread(this).start();
    }
    
    @Override
    public void run() {
        for (byte i = 1; i <= 5; i++)
            queue.get();
    }
}
