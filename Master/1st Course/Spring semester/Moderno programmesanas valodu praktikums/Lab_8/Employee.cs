using System;

namespace Lab8 {

    public class Employee : Human, IComparable<Employee> {

        public double Salary { get; set; }

        public Employee() { }

        public Employee(string name, string surname, double salary) 
            : base(name, surname) {
            Salary = salary;
        }

        public Employee(Employee employee) : base(employee) {
            Salary = employee.Salary;
        }

        public int CompareTo(Employee other) {
            return Salary == other.Salary ? 0 : Salary > other.Salary ? 1 : -1;
        }

        public override string ToString() {
            return base.ToString() + string.Format(" alga: {0}", Salary);
        }
    }
}
