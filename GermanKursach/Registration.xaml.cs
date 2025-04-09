using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GermanKursach
{
    /// <summary>
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void LoginTab_Click(object sender, RoutedEventArgs e)
        {
            MainWindow authorization = new MainWindow();
            authorization.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Reg(FullNameTextBox.Text, EmailTextBox.Text, PhoneTextBox.Text, CarNumberTextBox.Text, Login.Text, PasswordBox.Password, ProverkaPasswordBox.Password);
        }
        public bool Reg(String FIO, String email, String phone, String numberCar, String log, String pass, String passProverka)
        {
            if (string.IsNullOrWhiteSpace(FIO) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(numberCar) ||
                string.IsNullOrWhiteSpace(log) ||
                string.IsNullOrWhiteSpace(pass) ||
                string.IsNullOrWhiteSpace(passProverka) )
            {
                MessageBox.Show("Все обязательные поля должны быть заполнены", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            using (var db = new CarEntities())
            {
                var user = db.Users.AsNoTracking().FirstOrDefault(u => u.Login == log);
                if (user != null)
                {
                    MessageBox.Show("Пользователь с таким логином уже существует", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                var emaildb = db.Users.AsNoTracking().FirstOrDefault(s => s.Email == email);
                if (emaildb != null)
                {
                    MessageBox.Show("Пользователь с таким email уже существует", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }
            if (log.Length > 50)
            {
                MessageBox.Show("Логин должен быть меньше 50 символов", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (log.Length < 4)
            {
                MessageBox.Show("Логин должен быть больше 3 символов", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (pass.Length < 8)
            {
                MessageBox.Show("Пароль должен быть больше 8 символов", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (pass.Length > 25)
            {
                MessageBox.Show("Пароль должен быть меньше 25 символов", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            bool number = false;
            for (int i = 0; i < pass.Length; i++)
            {
                if (pass[i] >= '0' && pass[i] <= '9') number = true;
            }
            if (!number)
            {
                MessageBox.Show("Пароль должен содержать хотя бы одну цифру", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (pass != passProverka)
            {
                MessageBox.Show("Пароль должен совпадать с 'Подтверждение пароля'", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            var nameParts = FIO.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (nameParts.Length < 3)
            {
                MessageBox.Show("ФИО должно содержать 3 слова", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            foreach (var part in nameParts)
            {
                if (!part.All(c => IsRussianLetter(c)))
                {
                    MessageBox.Show("ФИО должно состоять из русских букв", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }
            if (!IsValidEmail(email))
            {
                MessageBox.Show("Неверный формат email", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error) ;
                return false;
            }
            if (!IsValidPhoneNumber(phone))
            {
                MessageBox.Show("Номер телефона должен быть в формате +7XXXXXXXXXX (11 цифр)", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (!IsValidCarNumber(numberCar))
            {
                MessageBox.Show("Номер автомобиля должен быть в формате X123XX123 (латинские буквы и цифры)", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            try
            {
                using (var db = new CarEntities())
                {
                    var user = new Users
                    {
                        Login = log,
                        Password = pass,
                        Role = "User",
                        LastName = FIO.Split(' ')[0],
                        FirstName = FIO.Split(' ')[1],
                        MiddleName = FIO.Split(' ')[2],
                        Email = email,
                        Phone = phone,
                        CarNumber = numberCar
                    };
                    db.Users.Add(user);
                    db.SaveChanges();
                    MessageBox.Show("Регистрация прошла успешно", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    this.Close();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при регистрации: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        private bool IsRussianLetter(char c)
        {
            return (c >= 'а' && c <= 'я') || (c >= 'А' && c <= 'Я') || c == 'ё' || c == 'Ё';
        }
        private bool IsValidPhoneNumber(string phone)
        {
            if (!phone.StartsWith("+"))
            {
                return false;
            }
            string digitsOnly = new string(phone.Where(char.IsDigit).ToArray());
            return digitsOnly.Length == 11 && digitsOnly.StartsWith("7");
        }
        private bool IsValidCarNumber(string carNumber)
        {
            var pattern = @"^[A-Za-z]\d{3}[A-Za-z]{2}\d{3}$";
            return Regex.IsMatch(carNumber, pattern);
        }

    }
    
}
