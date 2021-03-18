using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevOrganization
{
    public class Departments 
    {
        public List<Departments> departments = new List<Departments>();
        public List<Employees> Employees = new List<Employees>();
        public Departments()
        {
            this.Name = "test";
            this.Director = new Director(
                "Александр",
                "Александрович",
                40,
                this,
                5);
            Employees.Add(Director);
            this.CreationDate = DateTime.Now;
        }
        public Departments(string name, Director director)
        {
            this.Name = name;
            this.CreationDate = DateTime.Now;
            this.Director = director;
        }
        /// <summary>
        /// Департамент
        /// </summary>
        /// <param name="name">Имя департамента</param>
        /// <param name="creationDate">Дата создания департамента</param>
        /// <param name="director">Начальник департамента</param>
        public Departments(string name, Director director, DateTime creationDate)
        {
            this.Name = name;
            this.Director = director;
            this.CreationDate = creationDate;
        }
        
        public Employees this[int index]
        {
            get { return Employees[index]; }
            set { Employees[index] = value; }
        }

        public List<Employees> GetAllEmployees()
        {
            List<Employees> emp = new List<Employees>();
            if (departments.Count>0)
            foreach (var e in departments)
            {
                emp.Union(e.GetAllEmployees());
            }
            emp.Union(Employees);
            return emp;
        }
        public void AddInsideDepartment(Departments dep)
        {
            departments.Add(dep);
        }
        public void SetDirector(string firstName, string secondName, int age, int numbOfProjects)
        {
            this.Director = new Director(
                firstName,
                secondName,
                age,
                this,
                numbOfProjects);
            Employees.Add(Director);
        }
        public void ChangeDirector(Director dir)
        {
            this.Director = dir;
            this.Director.Department = this;
            Employees.Add(Director);
        }
        public void AddWorker(string firstName, string secondName, int age, int salary, int numbOfProjects)
        {
            Employees.Add(new Worker(
                firstName,
                secondName,
                age,
                this,
                salary,
                numbOfProjects));
        }
        public void AddIntern(string firstName, string secondName, int age, int salary, int numbOfProjects)
        {
            Employees.Add(new Intern(
                firstName,
                secondName,
                age,
                this,
                salary,
                numbOfProjects));
        }
        public int GetTotalSalary()
        {
            int total = 0;
            foreach (var e in Employees)
            {
                total += e.Salary;
            }
            return total;
        }
        #region автосвойства
        /// <summary>
        /// ID номер департамента
        /// </summary>
        public int Id { get; private set; }
        /// <summary>
        /// Имя департамента
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Дата создания департамента
        /// </summary>
        public DateTime CreationDate { get; private set; }
        /// <summary>
        /// Колличество сотрудинков, работающих в данном департамента
        /// </summary>
        public int EmployeesCount { get { return Employees.Count; } }
        /// <summary>
        /// Начальник департамента
        /// </summary>
        public Director Director { get; set; }
        #endregion
    }
}
