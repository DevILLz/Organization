namespace DevOrganization
{
    public class Director : Employees
    {
        //private int numbOfProjects;
        private int salary;
        public Director()
        {
            this.FirstName = "Unnamed";
            this.SecondName = "Nobody"; ;
            this.Age = 29;
            this.Department = null;
            SetSalary(0);
        }

        /// <summary>
        /// Создание директора
        /// </summary>
        /// <param name="firstName">Имя</param>
        /// <param name="secondName">Фамилия</param>
        /// <param name="age">Возраст</param>
        /// <param name="department">Департамент, к которому принадлежит сотрудник</param>
        public Director(string firstName, string secondName, int age, string department)
        {
            this.FirstName = firstName;
            this.SecondName = secondName;
            this.Age = age;
            this.Department = department;
            SetSalary(0);
        }

        /// <summary>
        /// Устонавливает зп директору
        /// </summary>
        /// <param name="salary"></param>
        public void SetSalary(int salary)
        {
            if (salary > 1300)
                this.salary = salary;
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
        public override string Department { get; set; }
        /// <summary>
        /// Колличество проектов, в которых задействован сотрудник
        /// </summary>
        public override int NumbOfProjects { get; } //{ return this.numbOfProjects; } }
        /// <summary>
        /// Изменение кол-ва проектов
        /// </summary>
        /// <param name="number">колличество</param>
        //public void ChangeNumbOfProjects(int number)
        //{
        //    this.numbOfProjects = number;
        //}
        #endregion
    }
}
