using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using System.Windows.Shapes;
using static BusyMan.TaskWindow;

namespace BusyMan
{
    /// <summary>
    /// Логика взаимодействия для TaskWindow.xaml
    /// </summary>
    public partial class TaskWindow : Window, INotifyPropertyChanged
    {
        private NewTask selectedNewTask;

        public event PropertyChangedEventHandler? PropertyChanged;

        public ObservableCollection<NewTask> Taskes { get; set; }
        public NewTask SelectedNewTask
        {
            get => selectedNewTask;
            set
            {
                selectedNewTask = value;
                PropertyChanged?.Invoke(this,
                    new PropertyChangedEventArgs(nameof(SelectedNewTask)));
            }
        }

        public TaskWindow()
        {
            InitializeComponent();
            Taskes = new ObservableCollection<NewTask>();
            Taskes.Add(new NewTask
            {
                InfoNew = "Помидоры",
                SpeedNew = "1 кг"
            });
            DataContext = this;
        }

        public class NewTask
        {
            public string InfoNew { get; set; } = " ";
            public string SpeedNew { get; set; } = " ";


        }

        private void ButtonAdd(object sender, RoutedEventArgs e)
        {
            Taskes.Add(new NewTask());
            PropertyChanged?.Invoke(this,
                    new PropertyChangedEventArgs(nameof(SelectedNewTask)));
            MessageBox.Show("Добавлено в список задач");
        }
    }
}

