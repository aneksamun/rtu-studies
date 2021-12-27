package lab2.concepts;

import java.util.ArrayList;
import java.util.Collections;
import java.util.Comparator;

public class Company implements CompanyService {
    private String title;
    private ArrayList<Employee> employees = new ArrayList<Employee>();
    
    public Company(String name) {
        this.title = name;
    }
    
    public String getTitle() {
        return title;
    }

    public void setTitle(String title) {
        this.title = title;
    }
    
    public void add(Employee employee) {
        employees.add(employee);
    }

    public double findMaxSalary() {
        double maxSalary = 0; 
            
        for (Employee e : employees)
            if (e.getSalary() > maxSalary)
                maxSalary = e.getSalary();

        return maxSalary;
    }
    
    public class SalDesc implements Comparator<Employee> {
        @Override
        public int compare(Employee e0, Employee e1) {
            return e0.getSalary() > e1.getSalary() ? -1 :
                e0.getSalary() < e1.getSalary() ? 1 : 0;
        }
    }
    
    public void sortSalariesAsc() {
        Collections.sort(employees);
    }
    
    public void sortSalariesDesc() {
        Collections.sort(employees, new SalDesc());
    }

    @Override
    public String toString() {
        String s = "Firma: " + title + ".\n";
        
        for (int i = 0; i < employees.size(); i++)
            s += (i + 1) + ". " + employees.get(i).toString() + "\n";
        
        return s;
    }
}
