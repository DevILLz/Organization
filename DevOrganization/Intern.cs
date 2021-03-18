using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevOrganization
{
    public class Intern : Employees
    {
        private int salary;
        private int numbOfProjects;
        public Intern()
        {
            this.FirstName = "Unnamed";
            this.SecondName = "Nobody";
            this.Age = 29;
            this.Department = null;
            SetSalary(500);
            this.numbOfProjects = 1;
        }
        public Intern(string firstName, string secondName, int age, Departments department, int salary, int numbOfProjects)
        {
            this.FirstName = firstName;
            this.SecondName = secondName;
            this.Age = age;
            this.Department = department;
            this.salary = salary;
            this.numbOfProjects = numbOfProjects;
        }
        
        public void SetSalary(int selary)
        {
            this.salary = selary;
        }
        
        #region автосвойства
        /// <summary>
        /// Зарплата
        /// </summary>
        public override int Salary { get { return this.salary; } }
        /// <summary>
        /// Имя
        /// </summary>
        public override string FirstName { get; set; }
        /// <summary>
        /// Фамилия
        /// </summary>
        public override string SecondName { get; set; }
        /// <summary>
        /// Возраст
        /// </summary>
        public override int Age { get; set; }
        /// <summary>
        /// Департамент, к которому принадлежит сотрудник
        /// </summary>
        public override Departments Department { get; set; }
        /// <summary>
        /// Колличество проектов, в которых задействован сотрудник
        /// </summary>
        public override int NumbOfProjects { get { return this.numbOfProjects; } }
        public void ChangeNumbOfProjects(int number)
        {
            if (this.Department != null)
            {
                if (this.Department.Director.NumbOfProjects <= number)
                    this.numbOfProjects = number;
            }
            this.numbOfProjects = 0;
        }
        #endregion
    }
}
