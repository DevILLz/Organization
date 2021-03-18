using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevOrganization
{
    public class Worker : Employees
    {
        private int numbOfProjects;
        private int salary;
        public Worker()
        {
            this.FirstName = "Unnamed";
            this.SecondName = "Nobody";
            this.Age = 29;
            this.Department = null;
            SetSalary(12);
            ChangeNumbOfProjects(1);
        }
        /// <summary>
        /// Создания экземпляра класса "рабочий"
        /// </summary>
        /// <param name="firstName">Имя</param>
        /// <param name="secondName">Фамилия</param>
        /// <param name="age">Возраст</param>
        /// <param name="department">Департамент</param>
        /// <param name="salary">Зарплата ($ в час)</param>
        /// <param name="numbOfProjects">колличество проектов в которм задействован сотрудник</param>
        public Worker(string firstName, string secondName, int age, Departments department, int salary, int numbOfProjects)
        {
            this.FirstName = firstName;
            this.SecondName = secondName;
            this.Age = age;
            this.Department = department;
            SetSalary(salary);
            ChangeNumbOfProjects(numbOfProjects);
        }
        private void SetSalary(int salary)
        {
            this.salary = salary*8*20;//условно возьмём 8-и часовой рабочий день и 20 рабочих дней в месяце
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
