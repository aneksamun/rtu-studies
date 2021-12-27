package lab1.concepts;

public class Program {

    public static void main(String[] args) {
        Company company = new Company("VEF", 3);
        
        company.add(new Employee("Juris", "Jansons", 450.0));
        company.add(new Employee("Uldis", "Petrovs", 430.0));
        company.add(new Employee("Jānis", "Strods", 480.0));
        
        System.out.println(company.toString());
    }
}
