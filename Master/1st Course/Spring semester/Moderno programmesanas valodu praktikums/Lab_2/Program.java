package lab2.concepts;

public class Program {

    public static void main(String[] args) {
        
        Company company = new Company("VEF");
        
        company.add(new Employee("Juris", "Jansons", 450.0));
        company.add(new Employee("Uldis", "Petrovs", 430.0));
        company.add(new Employee("J�nis", "Strods", 480.0));
        
        System.out.println(company.toString());
        System.out.println("Maksimālā alga: " + company.findMaxSalary() + ".\n");
        
        company.sortSalariesAsc();
        
        System.out.println(company.toString());
        
        company.sortSalariesDesc();
        
        System.out.println(company.toString());
    }
}
