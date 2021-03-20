namespace DevOrganization
{

    public abstract class Employees
    {
        //private long id;

        //public long Id
        //{
        //    get
        //    {
        //        return id;
        //    }

        //    private set
        //    {
        //        id = 0;
        //    }
        //}
        
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
        public abstract string Department { get; set; }
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
