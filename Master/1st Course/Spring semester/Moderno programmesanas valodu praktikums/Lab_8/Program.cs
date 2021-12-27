using System;

namespace Lab8 {

    class Program {
    
        public static void Main(string[] args) {
        
            Company company = new Company("VEF");

            company.Add(new Employee { Name = "Juris", Surname = "Jansons", Salary = 450.0 });
            company.Add(new Employee { Name = "Uldis", Surname = "Petrovs", Salary = 430.0 });
            company.Add(new Employee { Name = "Jānis", Surname = "Strods", Salary = 480.0 });

            Console.Write(company.ToString());
            Console.WriteLine("Maksimālā alga: {0}.\n", company.FindMaxSalary());

            company.SortSalariesAsc();

            Console.WriteLine(company.ToString());

            company.SortSalariesDesc();

            Console.WriteLine(company.ToString());

            Console.ReadLine();
        }
    }
}
