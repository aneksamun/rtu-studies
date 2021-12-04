package threading.example;

public class ThreadDemo {
    public static void main(String[] args) {
        Queue queue = new Queue();
        new Producer(queue);
        new Customer(queue);
    }
}
