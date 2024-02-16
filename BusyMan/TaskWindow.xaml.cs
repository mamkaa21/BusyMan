using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
        public NewTask SelectedProducti
        {
            get => selectedNewTask;
            set
            {
                selectedNewTask = value;
                PropertyChanged?.Invoke(this,
                    new PropertyChangedEventArgs(nameof(SelectedProducti)));
            }
        }

        public TaskWindow()
        {
            InitializeComponent();
            Taskes = new ObservableCollection<NewTask>();
            Taskes.Add(new NewTask
            {
                Info = "Помидоры",
                Speed = "1 кг",
            });
            DataContext = this;
        }

        public class NewTask
        {
            public string Info { get; set; }
            public string Speed{ get; set; }

            internal static void Add(NewTask newTask)
            {
                throw new NotImplementedException();
            }
        }

        private void ButtonAdd(object sender, RoutedEventArgs e)
        {
            NewTask.Add(new NewTask());
            PropertyChanged?.Invoke(this,
                    new PropertyChangedEventArgs(nameof(SelectedProducti)));
        }
    }
}

