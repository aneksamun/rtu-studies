package threading.example;

public class Producer implements Runnable {
    private Queue queue;
    
    public Producer(Queue queue) {
        this.queue = queue;
        new Thread(this).start();
    }
    
    @Override
    public void run() {
        for (byte i = 1; i <= 5; i++)
            queue.put(i);
    }
}
