using System;
using System.Collections.ObjectModel;

namespace DevOrganization
{
    public class Departments 
    {
        #region автосвойства
        /// <summary>
        /// ID номер департамента
        /// </summary>
        public int Id { get; private set; }
        /// <summary>
        /// Имя департамента
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Дата создания департамента
        /// </summary>
        public DateTime CreationDate { get; private set; }
        /// <summary>
        /// Начальник департамента
        /// </summary>
        public Director Director { get; private set; }
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
            this.Director = new Director(
                "Александр",
                "Александрович",
                40,
                this.Name);
            //Employees.Add(Director);
            this.CreationDate = DateTime.Now;
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
            this.Director = new Director(firstName,
                secondName,
                age,
                this.Name);
            //Employees.Add(this.Director);  
        }
        /// <summary>
        /// Департамент
        /// </summary>
        /// <param name="name">Имя департамента</param>
        /// <param name="creationDate">Дата создания департамента</param>
        /// <param name="director">Начальник департамента</param>
        public Departments(string name, Director director, DateTime creationDate)
        {
            this.Name = name;
            this.Director = director;
            this.CreationDate = creationDate;
            //Employees.Add(this.Director);
        }
        /// <summary>
        /// Рекурсивный алгоритм получения всех работников данного и нижестоящих департаментов
        /// </summary>
        /// <returns>Возвращяет ObservableCollection<Employees></returns>
        public ObservableCollection<Employees> GetAllEmployees()
        {
            ObservableCollection<Employees> emp = new ObservableCollection<Employees>();
            emp.Add(this.Director);
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
            this.Director = dir;
            this.Director.Department = this.Name;
            Employees.Add(Director);
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
                this.Name,
                salary,
                numbOfProjects));
                    break;
                case "director":
                    Employees.Add(new Director(
                firstName,
                secondName,
                age,
                this.Name));
                    break;
                default:
                    Employees.Add(new Worker(
                firstName,
                secondName,
                age,
                this.Name,
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
        /// <summary>
        /// Обновляет зарплату директора текущего департамента (призывать дважды)
        /// </summary>
        public void SetDirectorSalary()
        {
            int total = 0;
            foreach (var e in GetAllEmployees())
            {
                total += e.Salary;
            }
            this.Director.SetSalary((int)(total * 0.15));
            foreach (var e in this.departments)
            {
                e.SetDirectorSalary();
            }
        }
        /// <summary>
        /// рекурсивный костыль, убирает дублирующихся директоров при импорте
        /// </summary>
        public void DeleteSecondDirector()
        {
            this.Employees.RemoveAt(0);
            foreach (var e in this.departments)
            {
                e.DeleteSecondDirector();
            }
        }
    }
}
