package lab3.concepts;

import java.util.HashMap;

public class Main {

    public static void main(String[] args) {
        Object[] streets = {
            new Human(),
            new Auto(),
            new Vehicle(),
            new Bus(),
            new Bus(),
            new Human(),
            new Human(),
            new String()
        };
        
        check1(streets);
        System.out.println();
        check2(streets);
        System.out.println();
        System.out.print("HashMap + Get class...");
        System.out.println(check3(streets));
    }
    
    public static void check1(Object[] objs) {
        int h = 0, a = 0, b = 0, v = 0, u = 0;
        
        for (Object obj : objs) {
            if (obj instanceof Human)
                h++;
            else if (obj instanceof Auto)
                a++;
            else if (obj instanceof Bus)
                b++;
            else if (obj instanceof Vehicle)
                v++;
            else
                u++;
        }
        
        System.out.println("Instance of..");
        System.out.println("Vehicle: " + v + 
                ", Auto: " + a + 
                ", Bus: " + b + 
                ", Human: " + h + 
                ", Unknown object: " + u);
    }

    public static void check2(Object[] objs) {
        int h = 0, a = 0, b = 0, v = 0, u = 0;
        
        for (Object obj : objs) {
            if (Human.class.isInstance(obj))
                h++;
            else if (Auto.class.isInstance(obj))
                a++;
            else if (Bus.class.isInstance(obj))
                b++;
            else if (Vehicle.class.isInstance(obj))
                v++;
            else
                u++;
        }
        
        System.out.println("Instance of..");
        System.out.println("Vehicle: " + v + 
                ", Auto: " + a + 
                ", Bus: " + b + 
                ", Human: " + h + 
                ", Unknown object: " + u);
    }
    
    public static String check3(Object[] objs) {
        HashMap<String, Integer> results =
            new HashMap<String, Integer>();
        
        for (Object obj : objs) {
            String className = obj.getClass().getName();
            
            if (results.containsKey(className))
                results.put(className, results.get(className) + 1);
            else
                results.put(className, 1);
        }
        
        return results.toString();
    }
}
