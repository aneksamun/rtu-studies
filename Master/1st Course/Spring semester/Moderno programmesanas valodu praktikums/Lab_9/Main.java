
public class Main {
    
    public static void main(String... args) {
        
        Swap<Integer> op1 = new Swap<Integer>(5);
        Swap<Integer> op2 = new Swap<Integer>(3);
        
        System.out.println(op1.operand + " " + op2.operand);
        
        swap(op1, op2);
        
        System.out.println(op1.operand + " " + op2.operand);
        
        Gen<Integer> iOb = new Gen<Integer>(88);
        
        Gen2<Integer> iOb2 = new Gen2<Integer>(99);
        
        Gen2<String> sOb = new Gen2<String>("Common test");
        
        if (iOb instanceof Gen<?>)
            System.out.println("iOb is instance of Gen<?>.");
        
        if (iOb instanceof Gen2<?>)
            System.out.println("iOb is instance of Gen2<?>.");
        
        if (sOb instanceof Gen<?>)
            System.out.println("sOb is instance of Gen<?>.");
        
        if (iOb2 instanceof Gen<?>)
            System.out.println("iOb2 is instance of Gen<?>.");
    }
    
    public static <T> void swap(Swap<T> op1, Swap<T> op2) {
        Swap<T> temp = new Swap<T>(op1.operand); 
        op1.operand = op2.operand;
        op2.operand = temp.operand;
    }
}
