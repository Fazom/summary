using System.Data.Common;
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
using System.Data.Odbc;

namespace BD3LB
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        class User
        {
            public int id { get; set; }
            public string name { get; set; }
            public string password { get; set; }
        }
        public MainWindow()
        {
            InitializeComponent();
        }
        List<User> users = new List<User>();
        User selected_user = new User();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = "Driver={PostgreSQL ODBC Driver(ANSI)};Server=localhost;Database=streetwear;Uid=postgres;Pwd=yalokin4002";
            OdbcConnection connection = new OdbcConnection(connectionString);
            connection.Open();
            OdbcCommand command = new OdbcCommand("SELECT id, name, password FROM users", connection);
            OdbcDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                users.Add(new User {id = Convert.ToInt32(reader["id"]) , name = reader["name"].ToString(), password = reader["password"].ToString() });
            }
            connection.Close();

            int login = 0;
            int password = 0;
            for (int i = 0; i < users.Count; i++)
            {
                if (LogBlock.Text == users[i].name)
                {
                    if (PasBlock.Text == users[i].password)
                    {
                        selected_user = users[i];
                        LogWindow.Visibility = Visibility.Hidden;
                        ShopWindow.Visibility = Visibility.Visible;
                        HelloText.Text = $"Здравствуйте, {selected_user.name}!";
                        break;
                    }
                    else
                    {
                        password += 1;

                    }
                }
                else if (LogBlock.Text != users[i].name)
                {
                    login += 1;

                }
            }
            if (login >= users.Count)
            {
                MessageBox.Show("Неправильный пользователь");
            }
            else if (password >= users.Count)
            {
                MessageBox.Show("Неправильный пользователь");
            }
        }

        private void BackLog_Click(object sender, RoutedEventArgs e)
        {
            ShopWindow.Visibility = Visibility.Hidden;
            LogWindow.Visibility = Visibility.Visible;
            
        }

        private void AddShirt_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = "Driver={PostgreSQL ODBC Driver(ANSI)};Server=localhost;Database=streetwear;Uid=postgres;Pwd=yalokin4002";
            OdbcConnection connection = new OdbcConnection(connectionString);
            connection.Open();
            string queryString = $"INSERT INTO orders (product_id, user_id) VALUES (1, {selected_user.id})";

            {
                using (OdbcCommand command = new OdbcCommand(queryString, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
            connection.Close();
        }

        private void AddShort_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = "Driver={PostgreSQL ODBC Driver(ANSI)};Server=localhost;Database=streetwear;Uid=postgres;Pwd=yalokin4002";
            OdbcConnection connection = new OdbcConnection(connectionString);
            connection.Open();
            string queryString = $"INSERT INTO orders (product_id, user_id) VALUES (2, {selected_user.id})";

            {
                using (OdbcCommand command = new OdbcCommand(queryString, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
            connection.Close();
        }

        private void AddKepka_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = "Driver={PostgreSQL ODBC Driver(ANSI)};Server=localhost;Database=streetwear;Uid=postgres;Pwd=yalokin4002";
            OdbcConnection connection = new OdbcConnection(connectionString);
            connection.Open();
            string queryString = $"INSERT INTO orders (product_id, user_id) VALUES (3, {selected_user.id})";

            {
                using (OdbcCommand command = new OdbcCommand(queryString, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
            connection.Close();
        }

        private void GoBasket_Click(object sender, RoutedEventArgs e)
        {
            ShopWindow.Visibility = Visibility.Hidden;
            BasketWindow.Visibility = Visibility.Visible;

            string connectionString = "Driver={PostgreSQL ODBC Driver(ANSI)};Server=localhost;Database=streetwear;Uid=postgres;Pwd=yalokin4002";
            OdbcConnection connection = new OdbcConnection(connectionString);
            connection.Open();
            
            OdbcCommand command = new OdbcCommand($"SELECT product.name, product.price FROM orders JOIN product ON orders.product_id = product.id WHERE orders.user_id = {selected_user.id};", connection);

            OdbcDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                description.Text += reader["name"] + "   |   " + reader["price"] + "\n";
            }
            connection.Close();


            //string connectionString = "Driver={PostgreSQL ODBC Driver(ANSI)};Server=localhost;Database=streetwear;Uid=postgres;Pwd=yalokin4002";
            //OdbcConnection connection = new OdbcConnection(connectionString);
            //connection.Open();
            //OdbcCommand command = new OdbcCommand($"SELECT product.name, product.price FROM order JOIN product ON order.product_id = product.id WHERE order.user_id = {selected_user.id};", connection);
            //OdbcDataReader reader = command.ExecuteReader();
            //while (reader.Read())
            //{
            //    description.Text += reader["name"] + " " + reader["price"];
            //    //users.Add(new User { id = Convert.ToInt32(reader["id"]), name = reader["name"].ToString(), password = reader["password"].ToString() });
            //}
            //connection.Close();
        }

        private void ByAll_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = "Driver={PostgreSQL ODBC Driver(ANSI)};Server=localhost;Database=streetwear;Uid=postgres;Pwd=yalokin4002;";
            string sql = $"DELETE FROM orders WHERE user_id = {selected_user.id}"; // Замените на ваш SQL-запрос

            using (OdbcConnection connection = new OdbcConnection(connectionString))
            {
                connection.Open();
                using (OdbcCommand command = new OdbcCommand(sql, connection))
                {
                    int rowsAffected = command.ExecuteNonQuery();
                    description.Text = "";
                    MessageBox.Show($"Куплено {rowsAffected} товаров.");

                }
            }
        }

        private void BackToShop_Click(object sender, RoutedEventArgs e)
        {
            BasketWindow.Visibility = Visibility.Hidden;
            ShopWindow.Visibility = Visibility.Visible;
            
        }
    }
}