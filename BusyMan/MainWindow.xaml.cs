using Microsoft.Win32;
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
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace BusyMan
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private Task selectedTask;

        public event PropertyChangedEventHandler? PropertyChanged;

        public ObservableCollection<Task> Tasks { get; set; }
        public Task SelectedTask
        {
            get => selectedTask;
            set
            {
                selectedTask = value;
                PropertyChanged?.Invoke(this,
                    new PropertyChangedEventArgs(nameof(SelectedTask)));
            }
        }

        public MainWindow()
        {
            InitializeComponent();

        }

        private void NewTask_Add(object sender, RoutedEventArgs e)
        {
            TaskWindow taskWindow = new TaskWindow();
            taskWindow.Show();
        }

        private void HistoryBut(object sender, RoutedEventArgs e)
        {
            HistoryWindow historyWindow = new HistoryWindow();
            historyWindow.Show();
        }
        public class Task
        {
            public string Info { get; set; } = " ";
            public string DataStart { get; set; } = " ";
            public string Speed { get; set; } = " ";
            public string Statys { get; set; } = " ";
            public string DataEnd { get; set; } = " ";

        }



        private void Vipilnenie(object sender, RoutedEventArgs e)
        {
            if (SelectedTask != null)
                MessageBox.Show("Обьект выполнен");
            Tasks.Remove(SelectedTask);
            PropertyChanged?.Invoke(this,
                    new PropertyChangedEventArgs(nameof(SelectedTask)));

        }

        private void Otmenabut(object sender, RoutedEventArgs e)
        {
            if (SelectedTask != null)
                MessageBox.Show("Обьект отменен");
            Tasks.Remove(SelectedTask);
            PropertyChanged?.Invoke(this,
                    new PropertyChangedEventArgs(nameof(SelectedTask)));
            

        }


    }
}
