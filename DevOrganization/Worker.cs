using System;

namespace DevOrganization
{
    public class Worker : Employees
    {
        private long id;
        private int numbOfProjects;
        private int salary;
        public Worker()
        {
            this.FirstName = "Unnamed";
            this.SecondName = "Nobody";
            this.Age = new Random().Next(21, 35);
            this.DepartmentID = 0;
            SetSalary(12);
            this.numbOfProjects = new Random().Next(0, 5);
            id = StaticId;
            StaticId++;

        }
        public Worker(long department)
        {
            this.FirstName = "Unnamed";
            this.SecondName = "Nobody";
            this.Age = new Random().Next(21, 35);
            this.DepartmentID = department;
            SetSalary(12);
            this.numbOfProjects = new Random().Next(0, 5);
            id = StaticId;
            StaticId++;

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
        public Worker(string firstName, string secondName, int age, long department, int salary, int numbOfProjects)
        {
            this.FirstName = firstName;
            this.SecondName = secondName;
            this.Age = age;
            this.DepartmentID = department;
            SetSalary(salary);
            ChangeNumbOfProjects(numbOfProjects);
            id = StaticId;
            StaticId++;
        }
        private void SetSalary(int salary)
        {
            this.salary = salary*8*20;//условно возьмём 8-и часовой рабочий день и 20 рабочих дней в месяце
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
