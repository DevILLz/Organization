using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;


namespace DevOrganization
{
    public partial class MainWindow : Window
    {
        readonly string defaultFileName = "BD.json";
        public ObservableCollection<Departments> Organizations = new();
        public MainWindow()
        {
            InitializeComponent();
            Import(defaultFileName);
            //CreateOrganization();
        }
        /// <summary>
        /// создаёт новую организацию
        /// </summary>
        private void CreateOrganization()
        {
            Organizations.Add(new Departments("Dev Organization", "Марк", "Серов", 23));
            Organizations[0].AddInsideDepartment(new Departments("Разработка", "Артур", "Власов", 32));
            Organizations[0].departments[0].AddInsideDepartment(new Departments("Разработка станков", "Дарья", "Олеговна", 32));
            Organizations[0].AddInsideDepartment(new Departments("HR", "Даниил", "Пыжов", 32));
            Organizations[0].AddInsideDepartment(new Departments("Маркетинг", "Юрий", "Долгоносов", 32));
            foreach (var e in Organizations[0].departments)
            {
                for (int i = 0; i < 30; i++)
                    switch (new Random().Next(0, 2))
                    {
                        case 0: e.Employees.Add(new Worker(e.Id)); break;
                        default: e.Employees.Add(new Intern(e.Id)); break;
                    }
            }
            for (int i = 0; i < 30; i++)
                switch (new Random().Next(0, 2))
                {
                    case 0: Organizations[0].departments[0].departments[0].Employees.Add(new Worker()); break;
                    default: Organizations[0].departments[0].departments[0].Employees.Add(new Intern()); break;
                }
            Organizations[0].SetDirectorSalary();
            EmployeesList.ItemsSource = Organizations[0].departments[0].Employees;
            DepartmentsTree.ItemsSource = Organizations;
        }
        /// <summary>
        /// Экспорт данных
        /// </summary>
        /// <param name="filename">Имя файла</param>
        private void Export(string fileName)
        {
            string json = JsonConvert.SerializeObject(Organizations, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            });
            File.WriteAllText(fileName, json);

        }
        /// <summary>
        /// импорт данных
        /// </summary>
        /// <param name="filename">Имя файла</param>
        private void Import(string fileName)
        {
            new Intern(0, 0);
            string json = null;
            try
            {
                json = File.ReadAllText(fileName);
            }
            catch
            {
                Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();
                dialog.Filter = "Json files (*.json)|*.json|All files (*.*)|*.*";
                dialog.FilterIndex = 0;
                dialog.DefaultExt = "json";
                Nullable<bool> result = dialog.ShowDialog();
                if (result == true)
                {
                    json = File.ReadAllText(dialog.FileName);
                }
            }
            try
            {
                Organizations = JsonConvert.DeserializeObject<ObservableCollection<Departments>>(json, new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Auto
                });
            }
            catch
            {
                switch (MessageBox.Show("Данная БД не совместима", "Error", MessageBoxButton.OKCancel))
                {
                    case MessageBoxResult.OK:
                        Import("");
                        break;
                    case MessageBoxResult.Cancel:
                        Environment.Exit(0);
                        break;
                }
                
            }
            Organizations[0].DeleteSecondDirector();//костыль, убирает дублирующихся директоров при импорте
            Organizations[0].CheckDirector();//еще один костыль, при импорте всегда выставляет ID директора в департаменте
            Organizations[0].SetDirectorSalary();//Не получается десериализовать закрытое свойство
            EmployeesList.ItemsSource = Organizations[0].Employees;
            DepartmentsTree.ItemsSource = Organizations;
        }
        private void Export_button(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dialog = new Microsoft.Win32.SaveFileDialog();
            dialog.Filter = "Json files (*.json)|*.json|All files (*.*)|*.*";
            dialog.FilterIndex = 0;
            dialog.DefaultExt = "json";
            Nullable<bool> result = dialog.ShowDialog();
            if (result == true)
            {
                Export(dialog.FileName);
            }
        }
        private void Import_button(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.Filter = "Json files (*.json)|*.json|All files (*.*)|*.*";
            dialog.FilterIndex = 0;
            dialog.DefaultExt = "json";
            Nullable<bool> result = dialog.ShowDialog();
            if (result == true)
            {
                Import(dialog.FileName);
            }
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Export(defaultFileName);
        }
        private void DepartmentsTree_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            var a = (DepartmentsTree.SelectedItem as Departments);
            if (a != null) EmployeesList.ItemsSource = a.Employees;
        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (DepartmentsTree.SelectedItem != null)
            {
                MessageBoxResult result = MessageBox.Show("Вы уверен, что хотите удалить данный департамент и уволить всех его сотрудников?",
                                "Удаление департамента",
                                MessageBoxButton.YesNo);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        Departments temp = DepartmentsTree.SelectedItem as Departments;
                        DeleteDepartment(Organizations[0], temp);
                        break;
                    case MessageBoxResult.No:

                        break;
                }
            }
        }
        /// <summary>
        /// Удаление департамента
        /// </summary>
        /// <param name="d">Организация (рекурсивно проходим по её департаментам)</param>
        /// <param name="temp">выбранный департамент для удаления</param>
        private void DeleteDepartment(Departments d, Departments temp)
        {    
            if (d.departments.Contains(temp))
                d.departments.Remove(DepartmentsTree.SelectedItem as Departments);  
            else
                foreach (var e in d.departments)
                DeleteDepartment(e,temp);
        }
        private void FindDepartment(Departments d, Employees transf, long temp2ID)
        {
            bool flag = false;
            foreach (var e in d.departments)
            {
                if (e.Id == temp2ID)
                {
                    transf.DepartmentID = temp2ID;
                    e.Employees.Add(transf);
                    flag = true;
                    break;
                }                    
            }
            if (!flag)
            {
                foreach (var e in d.departments)
                    FindDepartment(e, transf, temp2ID);
            }
                
        }
        private void EmployeeTransfer(object sender, RoutedEventArgs e)
        {
            if (EmployeesList.SelectedIndex > -1 && EmployeesList.SelectedIndex < EmployeesList.Items.Count && !(depId.Text != null || depId.Text != ""))
            {
                if (EmployeesList.SelectedItems != null && EmployeesList.SelectedItems.Count > 0)
                {
                    var toRemove = EmployeesList.SelectedItems.Cast<Employees>().ToList();
                    var items = EmployeesList.ItemsSource as ObservableCollection<Employees>;
                    if (items != null)
                    {
                        foreach (var emp in toRemove)
                        {
                            
                            FindDepartment(Organizations[0], emp, Int64.Parse(depId.Text));
                            items.Remove(emp);
                        }
                    }
                }
            }
            
        }
    }
    
}
// Задание 1.
// Спроектировать информационную систему позволяющей работать со следующей структурой:
// Организация, в которой есть департаменты и сотрудники.
// Наполнение деталями предлагается реализовать самостоятельно
// Наполнение сотрудниками и департаментами происходит автоматически из файла *.txt, 
//                                                           предпочтительнее *.xml или *.json 
//
// Сотрудники делятся на несколько групп, разделенных должностями и оплатой труда
// Есть 
//   сотрудники - управленцы (например: директор, Первй заместитель директора, начальник ведомства, 
//                                      начальник департамента)
// 
//   ОАО "Лучшие кодеры"
//       Департамент_1
//          Департамент_11
//          Департамент_12
//       Департамент_2
//          Департамент_21
//          Департамент_22
//          Департамент_23
//          Департамент_24
//       Департамент_3
//          Департамент_31
//       Департамент_4
//          Департамент_41
//          Департамент_42
//          Департамент_43
//          Департамент_44
//          Департамент_45
//          Департамент_46
//          Департамент_47
//          Департамент_48
//       Департамент_5                Начальник_5
//          Департамент_51            Начальник_51
//              Департамент_511       Начальник_511
//                  Департамент_5111  Начальник_5111
//                        Департамент_51111      Начальник_51111
//                              Сотрудник 1
//                              Сотрудник 2
//                              Сотрудник 3
//                              Интерн 1
//                              Интерн 2
//                        Департамент_51112
//                        Департамент_51113
//                        Департамент_51114
//                  Департамент_5112
//                  Департамент_5113
//              Департамент_512
//          Департамент_52
//              Департамент_521
//              Департамент_522
//              Департамент_523
//          Департамент_53
//              Департамент_531
//          Департамент_54

//   сотрудники - рабочие
//   интерны
// У интернов оплата труда фиксированная и определяется при приёме (например $500 в месяц)
// У сотрудников - рабочих оплата труда почасовая и определяется при приёме (например $12 в час)
// У сотрудников - управленцев оплата труда составляет 15% от общей выплаченной суммы всем сотрудникам 
// числящихся в его отделе, но не менее $1300. 
//
// Структура организации следующая:
// Организация, состоит из ведомств в которые включены департаменты
// У каждого ведомства и департамента есть свой начальник.
// Директор руководит Организацией
// 
// Реализовать и продемонстрировать работу информационной системы
// В консоли или с использованием UI

// * Задание 2
//
// Есть код:
//
// Ознакомиться с кодом в файле A.cs
// Реализовать интерфейсы I1, I2 в классе A
//
////// Реализовать интерфейсы I1, I2 в классе B
//
// Задание 3.
// 
// Задавать вопросы