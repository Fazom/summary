using Newtonsoft.Json;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;

namespace LB4ToDoList
{
    
    


    public partial class MainWindow : Window
    {
        private string filePath = "tasks.json";
        private List<Task> tasks = new List<Task>();
        private StackPanel stackPanel;
        public MainWindow()
        {
            InitializeComponent();
            stackPanel = Base;
            LoadTasks();
        }
        private void LoadTasks()
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                tasks = JsonConvert.DeserializeObject<List<Task>>(json);
                UpdateTaskListView();
            }
        }
        private void SaveTasks()
        {
            string json = JsonConvert.SerializeObject(tasks);
            File.WriteAllText(filePath, json);
        }

        private void UpdateTaskListView()
        {
            Base.Children.Clear();
            foreach (Task task in tasks)
            {
                Border border = new Border();
                border.Margin = new Thickness(0, 40, 0, 0);
                border.CornerRadius = new CornerRadius(30);
                border.Background = Brushes.White;
                border.Padding = new Thickness(0);
                border.Height = 140;
                border.Width = 300;
                border.HorizontalAlignment = HorizontalAlignment.Center;

                Grid grid = new Grid();

                // Создание TextBlock для названия задачи
                TextBlock titleTextBlock = new TextBlock();
                titleTextBlock.Text = task.Title;
                titleTextBlock.Width = 230;
                titleTextBlock.Height = 25;
                titleTextBlock.HorizontalAlignment = HorizontalAlignment.Center;
                titleTextBlock.VerticalAlignment = VerticalAlignment.Top;
                titleTextBlock.Margin = new Thickness(0, 5, 0, 0);

                // Создание TextBlock для описания задачи
                TextBlock descriptionTextBlock = new TextBlock();
                descriptionTextBlock.Text = task.Description;
                descriptionTextBlock.TextWrapping = TextWrapping.Wrap;
                descriptionTextBlock.Width = 230;
                descriptionTextBlock.Height = 68;
                descriptionTextBlock.HorizontalAlignment = HorizontalAlignment.Center;
                descriptionTextBlock.VerticalAlignment = VerticalAlignment.Top;
                descriptionTextBlock.Margin = new Thickness(0, 30, 0, 0);

                // Создание TextBlock для дедлайна задачи
                TextBlock deadlineTextBlock = new TextBlock();
                deadlineTextBlock.Text = task.DeadLine;
                deadlineTextBlock.Width = 103;
                deadlineTextBlock.Height = 37;
                deadlineTextBlock.HorizontalAlignment = HorizontalAlignment.Left;
                deadlineTextBlock.VerticalAlignment = VerticalAlignment.Bottom;
                deadlineTextBlock.Margin = new Thickness(35, 0, 0, 0);

                // Создание кнопки для выполнения задачи
                Button addButton = new Button();
                addButton.Content = "Выполнить";
                addButton.HorizontalAlignment = HorizontalAlignment.Right;
                addButton.VerticalAlignment = VerticalAlignment.Bottom;
                addButton.Height = 40;
                addButton.Width = 115;
                addButton.Margin = new Thickness(0, 0, 27, 0);
                addButton.Tag = task;
                addButton.Click += Compleate;
                addButton.Margin = new Thickness(0,0,30,5);

                // Добавление элементов в Grid
                grid.Children.Add(titleTextBlock);
                grid.Children.Add(descriptionTextBlock);
                grid.Children.Add(deadlineTextBlock);
                grid.Children.Add(addButton);

                // Установка Grid в качестве содержимого Border
                border.Child = grid;
                Base.Children.Add(border);
            }

        }

       

        class Task
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public string DeadLine { get; set; }
            public bool IsCompleted { get; set; }
        }

        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            BorderTask.Visibility = Visibility.Visible;
        }
        private void Compleate(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;
            Task taskToRemove = (Task)clickedButton.Tag;

            // Удаление задачи из списка tasks
            tasks.Remove(taskToRemove);
            SaveTasks();
            UpdateTaskListView();
        }

        private void AddTaskThis_Click(object sender, RoutedEventArgs e)
        {
            Task newTask = new Task
            {
                Id = tasks.Count + 1,
                Title = NameT.Text,
                Description = DiscT.Text,
                DeadLine = DeadT.Text,
                IsCompleted = false,
            };
            tasks.Add(newTask);
            BorderTask.Visibility = Visibility.Hidden;
            SaveTasks();
            UpdateTaskListView();
        }
    }
}