using System;
using System.Collections.ObjectModel;

namespace DevOrganization
{
    public class Departments 
    {
        #region автосвойства
        private static long StaticId { get; set; }
        static Departments()
        {
            StaticId = 0;
        }
        /// <summary>
        /// ID номер департамента
        /// </summary>
        public long Id { get; private set; }

        /// <summary>
        /// Имя департамента
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Дата создания департамента
        /// </summary>
        public DateTime CreationDate { get; set; }
        /// <summary>
        /// Начальник департамента
        /// </summary>
        public long DirectorID { get; set; }
        /// <summary>
        /// Колличество сотрудинков, работающих в данном департамента
        /// </summary>
        public int EmployeesCount { get { return Employees.Count; } }
        #endregion
        public ObservableCollection<Employees> Employees = new ObservableCollection<Employees>();
        public ObservableCollection<Departments> departments = new ObservableCollection<Departments>();
        /// <summary>
        /// Создание департамента
        /// </summary>
        public Departments()
        {
            this.Name = "test";
            Employees.Add(new Director(
                "Александр",
                "Александрович",
                40,
                this.Id));
            this.DirectorID = Employees[0].Id;
            
            this.CreationDate = DateTime.Now;
            Id = StaticId;
            StaticId++;
        }
        /// <summary>
        /// Создание департамента
        /// </summary>
        /// <param name="name">Название департамента</param>
        /// <param name="firstName">Имя директора</param>
        /// <param name="secondName">фамили  директора</param>
        /// <param name="age">возраст  директора</param>
        public Departments(string name, string firstName, string secondName, int age)
        {
            this.Name = name;
            this.CreationDate = DateTime.Now;
            Employees.Add(new Director(
                firstName,
                secondName,
                age,
                this.Id));
            this.DirectorID = Employees[0].Id;
            Id = StaticId;
            StaticId++;
        }
        /// <summary>
        /// Рекурсивный алгоритм получения всех работников данного и нижестоящих департаментов
        /// </summary>
        /// <returns>Возвращяет ObservableCollection<Employees></returns>
        public ObservableCollection<Employees> GetAllEmployees()
        {
            ObservableCollection<Employees> emp = new ObservableCollection<Employees>();
            foreach (var e in Employees)
            {
                emp.Add(e);
            }
            if (departments.Count > 0)
            {
                foreach (var e in departments)
                {
                    foreach (var ee in e.GetAllEmployees())
                    {
                        emp.Add(ee);
                    }
                }
            }
            return emp;
        }
        /// <summary>
        /// Создаёт новый департамент внутри текущего
        /// </summary>
        /// <param name="dep">Экземпляр нового департамента</param>
        public void AddInsideDepartment(Departments dep)
        {
            departments.Add(dep);
        }
        /// <summary>
        /// Устонавливает нового директора в текущем департаменте
        /// </summary>
        /// <param name="dir">Новый директор</param>
        public void ChangeDirector(Director dir)
        {
            Employees.Insert(0, dir);
            this.DirectorID = Employees[0].Id;
            Employees[0].DepartmentID = this.Id;
        }
        /// <summary>
        /// Добавление нового сотрудника
        /// </summary>
        /// <param name="type">Тип сотрудника: Director, Worker, Intern</param>
        /// <param name="firstName">Имя</param>
        /// <param name="secondName">Фамилия</param>
        /// <param name="age">Возраст</param>
        /// <param name="salary">Зарплата</param>
        /// <param name="numbOfProjects">Колличество проектов в котором задействован сотрудник</param>
        public void AddEmployee(string type, string firstName, string secondName, int age, int salary, int numbOfProjects)
        {
            type.ToLower();
            switch (type)
            {
                case "intern":
                    Employees.Add(new Intern(
                firstName,
                secondName,
                age,
                this.Id,
                salary,
                numbOfProjects));
                    break;
                case "director":
                    Employees.Add(new Director(
                firstName,
                secondName,
                age,
                this.Id));
                    break;
                default:
                    Employees.Add(new Worker(
                firstName,
                secondName,
                age,
                this.Id,
                salary,
                numbOfProjects));
                    break;
            }
        }
        /// <summary>
        /// Внесение в список сотрудников готового экзепаляра сотрудника
        /// </summary>
        /// <param name="worker"></param>
        public void AddEmployee(Employees worker)
        {
            Employees.Add(worker);
        }
        bool nothing = false;// очередной костыль
        /// <summary>
        /// Обновляет зарплату директора текущего департамента (призывать дважды)
        /// </summary>
        public void SetDirectorSalary()
        {
            while (!nothing)
            {
                int total = 0;
                int nothing2 = 0;
                if (departments.Count != 0)
                {
                    foreach (var e in departments)
                    {
                        if (!e.nothing) nothing2++;
                    }
                }
                if (departments.Count == 0 || nothing2 == 0)
                {
                    foreach (var e in GetAllEmployees())
                    {
                        total += e.Salary;
                    }
                    (Employees[0] as Director).SetSalary((int)(total * 0.15));
                    nothing = true;
                }
                else
                {
                    foreach (var e in departments)
                    {
                        e.SetDirectorSalary();
                    }
                }
            }
            
        }
        /// <summary>
        /// рекурсивный костыль, убирает дублирующихся директоров при импорте
        /// </summary>
        public void DeleteSecondDirector()
        {
            if (this.Employees.Count >0 )
            this.Employees.RemoveAt(0);
            foreach (var e in this.departments)
            {
                e.DeleteSecondDirector();
            }
        }
        public void CheckDirector()
        {
            this.DirectorID = Employees[0].Id;
            foreach (var e in this.departments)
            {
                e.CheckDirector();
            }
        }
    }
}
