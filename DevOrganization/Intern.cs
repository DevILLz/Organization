using System;

namespace DevOrganization
{
    public class Intern : Employees
    {
        private long id;
        private int salary;
        private int numbOfProjects;
        public Intern()
        {
            this.FirstName = "Unnamed";
            this.SecondName = "Nobody";
            this.Age = 29;
            this.DepartmentID = 0;
            SetSalary(500);
            this.numbOfProjects = new Random().Next(0, 5);
            id = StaticId;
            StaticId++;
        }
        public Intern(long department)
        {
            this.FirstName = "Unnamed";
            this.SecondName = "Nobody";
            this.Age = 29;
            this.DepartmentID = department;
            SetSalary(12);
            this.numbOfProjects = new Random().Next(0, 5);
            id = StaticId;
            StaticId++;
        }
        /// <summary>
        /// Костыль
        /// </summary>
        /// <param name="val"></param>
        public Intern(long val, int s)
        {
            StaticId = val;
        }
        /// <summary>
        /// Создания экземпляра класса "Интерн"
        /// </summary>
        /// <param name="firstName">Имя</param>
        /// <param name="secondName">Фамилия</param>
        /// <param name="age">Возраст</param>
        /// <param name="department">Департамент</param>
        /// <param name="salary">Зарплата ($ в час)</param>
        /// <param name="numbOfProjects">колличество проектов в которм задействован сотрудник</param>
        public Intern(string firstName, string secondName, int age, long department, int salary, int numbOfProjects)
        {
            this.FirstName = firstName;
            this.SecondName = secondName;
            this.Age = age;
            this.DepartmentID = department;
            this.salary = salary;
            this.numbOfProjects = numbOfProjects;
            id = StaticId;
            StaticId++;
        }
        /// <summary>
        /// задаёт зарплату стажеру
        /// </summary>
        /// <param name="selary">зарплата</param>
        public void SetSalary(int selary)
        {
            this.salary = selary;
        }

        #region автосвойства
        public override long Id
        {
            get { return this.id; }
        }
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
        public override long DepartmentID { get; set; }
        /// <summary>
        /// Колличество проектов, в которых задействован сотрудник
        /// </summary>
        public override int NumbOfProjects { get { return this.numbOfProjects; } }
        public void ChangeNumbOfProjects(int number)
        {
            this.numbOfProjects = 0;
        }
        #endregion
    }
}
