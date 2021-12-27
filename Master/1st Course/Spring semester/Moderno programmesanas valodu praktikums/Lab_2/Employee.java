package lab2.concepts;

public class Employee extends Human implements Comparable<Employee> {
    private double salary;
    
    public Employee() {
        super();
    }
    
    public Employee(String name, String surname, double salary) {
        super(name, surname);
        this.salary = salary;
    }
    
    public Employee(Employee employee) {
        super(employee);
        this.salary = employee.salary;
    }

    public double getSalary() {
        return salary;
    }

    public void setSalary(double salary) {
        this.salary = salary;
    }

    @Override
    public String toString() {
        return super.toString() + ", alga: " + salary;
    }

    @Override
    public int compareTo(Employee e) {
        return this.salary > e.salary ? 1 :
            this.salary < e.salary ? -1 : 0;
    }
}
