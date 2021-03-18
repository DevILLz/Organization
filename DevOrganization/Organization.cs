using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevOrganization
{
    public class Organization
    {
        public List<Departments> Departments;
        //public long DepartmentId;
        //public long EmployeeId;
        public Organization(string name)
        {
            this.Name = name;
            this.Departments = new List<Departments>();
            this.Director = new Director("Марк",
                "Серов",
                23,
                null,
                23);
        }
        public Director Director { get; set; }
        public string Name { get; private set; }
        public List<Employees> GetAllEmployees()
        {
            List<Employees> emp = new List<Employees>();
            emp.Add(this.Director);
            if (Departments.Count > 0)
                foreach (var e in Departments)
                {
                    emp.Union(e.GetAllEmployees());
                }
            
            return emp;
        }
        public void NewDepartament(Departments dep)
        {
            Departments.Add(dep);
        }
    }
}
