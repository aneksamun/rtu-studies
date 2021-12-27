package lab1.concepts;

public class Company implements CompanyService {

    private String title;
    private Employee[] employees;
    private int index;
    
    public Company(String name, int total) {
        this.title = name;
        employees = new Employee[total];
        index = 0;
    }
    
    public String getTitle() {
        return title;
    }

    public void setTitle(String title) {
        this.title = title;
    }
    
    public void add(Employee employee) {
        try {
            employees[index++] = employee;
        }
        catch (ArrayIndexOutOfBoundsException e) {
            System.out.println(e.getMessage());
        }
    }

    public double findMaxSalary() {
        double maxSalary = 0; 
            
        for (Employee e : employees)
            if (e.getSalary() > maxSalary)
                maxSalary = e.getSalary();
        
        return maxSalary;
    }

    @Override
    public String toString() {
        String s = "Firma: " + title + ". Darbinieku daudzums: " + employees.length + ".\n";
        
        for (int i = 0; i < employees.length; i++)
            s += (i + 1) + ". " + employees[i].toString() + "\n";
        
        s += "Maksimālā alga: " + findMaxSalary() + " Ls.";
            
        return s;
    }
}
