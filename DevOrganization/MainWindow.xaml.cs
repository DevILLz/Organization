using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DevOrganization
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string defaultFileName = "BD";
        public MainWindow()
        {
            InitializeComponent();
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
        /// <summary>
        /// Открыть окно с данными сотрудников
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Show_Employees(object sender, RoutedEventArgs e)
        {
            //EmployeesWindow window = new EmployeesWindow(this);
            //window.Owner = this;
            //window.Show();
        }





        /// <summary>
        /// импорт данных
        /// </summary>
        /// <param name="filename">Имя файла</param>
        private void Import(string fileName)
        {
            string json = File.ReadAllText(fileName);
            //db_departments = JsonConvert.DeserializeObject<ObservableCollection<Departments>>(json);
            //DG_departments.ItemsSource = db_departments;

        }

        /// <summary>
        /// Экспорт данных
        /// </summary>
        /// <param name="filename">Имя файла</param>
        private void Export(string fileName)
        {
            string json = ""; //JsonConvert.SerializeObject(db_departments);
            File.WriteAllText(fileName, json);

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