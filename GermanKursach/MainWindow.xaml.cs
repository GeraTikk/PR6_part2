using System;
using System.Collections.Generic;
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

namespace GermanKursach
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Auth(login.Text, password.Password);
        }

        public bool Auth(String log, String pass)
        {
            if (string.IsNullOrEmpty(log) && string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Введите логин и пароль");
                return false;
            }
            if (string.IsNullOrEmpty(log))
            {
                MessageBox.Show("Введите логин");
                return false;
            }
            if (string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Введите пароль");
                return false;
            }
            using (var db = new CarEntities())
            {
                var user = db.Users.AsNoTracking().FirstOrDefault(u => u.Login == log && u.Password == pass);

                if (user == null)
                {
                    MessageBox.Show("Пользователь с такими данными не найден");
                    return false;
                }
                if (user.Role == "User")
                {
                    MessageBox.Show("Успешный вход в систему!");
                    Profile userWindow = new Profile();
                    userWindow.Show();
                }
                else if (user.Role == "Employee" || user.Role == "Admin")
                {
                    MessageBox.Show("Успешный вход в систему!");
                    ProfileEmployee empWindow = new ProfileEmployee();
                    empWindow.Show();
                }
                this.Close();
                return true;
            }
        }
    }
}
