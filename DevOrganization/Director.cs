using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevOrganization
{
    public class Director : Employees
    {
        private int numbOfProjects;
        private int salary;
        public Director()
        {
            this.FirstName = "Unnamed";
            this.SecondName = "Nobody"; ;
            this.Age = 29;
            this.Department = null;
            SetSalary();
            ChangeNumbOfProjects(3);
        }
        public Director(string firstName, string secondName, int age, Departments department, int numbOfProjects)
        {
            this.FirstName = firstName;
            this.SecondName = secondName;
            this.Age = age;
            this.Department = department;
            SetSalary();
            ChangeNumbOfProjects(3);
        }
        public void SetSalary()
        {
            if (this.Department != null)
            {
                this.salary = (int)(this.Department.GetTotalSalary() * 0.15);
                if (this.salary < 1300)
                    this.salary = 1300;
            }
            else this.salary = 1300;
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
        /// <summary>
        /// Изменение кол-ва проектов
        /// </summary>
        /// <param name="number">колличество</param>
        public void ChangeNumbOfProjects(int number)
        {
            this.numbOfProjects = number;
        }
        #endregion
    }
}
