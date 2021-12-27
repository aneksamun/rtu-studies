using System;
using System.Linq;
using System.Collections.Generic;

namespace Lab8 {

    public class Company : ICompanyService {

        public string Title { get; set; }
        private List<Employee> employers = new List<Employee>();

        public Company(string title) {
            Title = title;
        }

        public void Add(Employee employee) {
            employers.Add(employee);
        }

        public double FindMaxSalary() {
            double? maxSalary = 
                employers.OrderByDescending(e => e.Salary).Select(e => e.Salary).FirstOrDefault();

            return maxSalary ?? 0;
        }

        internal class SalDesc : IComparer<Employee> {

            public int Compare(Employee e1, Employee e2) {
                return e1.Salary == e2.Salary ? 0 : e1.Salary > e2.Salary ? -1 : 1;
            }
        }

        public void SortSalariesAsc() {
            employers.Sort();
        }

        public void SortSalariesDesc() {
            employers.Sort(new SalDesc());
        }

        public override string ToString() {
            var s = string.Format("Firma: {0}.\n", Title);
            int i = 0;

            employers.ForEach(e => s += string.Format("{0}. {1}\n", ++i, e.ToString()));

            return s;
        }
    }
}
