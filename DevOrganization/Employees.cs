using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevOrganization
{
    class Employees
    {
        public Employees()
        {

        }
        /// <summary>
        /// Сотрудник
        /// </summary>
        /// <param name="id">ID сотрудника</param>
        /// <param name="firstName">Имя</param>
        /// <param name="secondName">Фамилия</param>
        /// <param name="age">Возраст</param>
        /// <param name="department">Департамент, к которому принадлежит сотрудник</param>
        /// <param name="salary">Зарплата</param>
        /// <param name="numbOfProjects">Колличество проектов, в которых задействован сотрудник</param>
        public Employees(int id, string firstName, string secondName, int age, string department, int salary, int numbOfProjects)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.SecondName = secondName;
            this.Age = age;
            this.Department = department;
            this.Salary = salary;
            this.NumbOfProjects = numbOfProjects;
        }
        /// <summary>
        /// ID сотрудника
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Фамилия
        /// </summary>
        public string SecondName { get; set; }
        /// <summary>
        /// Возраст
        /// </summary>
        public int Age { get; set; }
        /// <summary>
        /// Департамент, к которому принадлежит сотрудник
        /// </summary>
        public string Department { get; set; }
        /// <summary>
        /// Зарплата
        /// </summary>
        public int Salary { get; set; }
        /// <summary>
        /// Колличество проектов, в которых задействован сотрудник
        /// </summary>
        public int NumbOfProjects { get; set; }
    }
}
