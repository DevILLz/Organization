namespace DevOrganization
{

    public abstract class Employees
    {

        protected static long StaticId { get; set; }
        static Employees()
        {
            StaticId = 0;
        }
        public abstract long Id { get; }
        /// <summary>
        /// Имя
        /// </summary>
        public abstract string FirstName { get; set; }
        /// <summary>
        /// Фамилия
        /// </summary>
        public abstract string SecondName { get; set; }
        /// <summary>
        /// Возраст
        /// </summary>
        public abstract int Age { get; set; }
        /// <summary>
        /// Департамент, к которому принадлежит сотрудник
        /// </summary>
        public abstract long DepartmentID { get; set; }
        /// <summary>
        /// Зарплата
        /// </summary>
        public abstract int Salary { get; }
        /// <summary>
        /// Колличество проектов, в которых задействован сотрудник
        /// </summary>
        public abstract int NumbOfProjects { get; }
    }
}
