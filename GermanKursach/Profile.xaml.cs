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
using System.Windows.Shapes;

namespace GermanKursach
{
    public partial class Profile : Window
    {
        public Profile()
        {
            InitializeComponent();
            LoadOrdersData();
        }

        private void LoadOrdersData()
        {
            List<Order> orders = new List<Order>
            {
                new Order { OrderNumber = "12345", DateTime = "15.05.2023 10:30",
                           Services = "Химчистка салона, Полировка кузова",
                           Status = "Выполнен", Price = "5 000 ₽", Employee = "Петров А.С." },
                new Order { OrderNumber = "12346", DateTime = "20.05.2023 14:15",
                           Services = "Замена масла, Диагностика",
                           Status = "В процессе", Price = "3 200 ₽", Employee = "Сидоров В.П." },
                new Order { OrderNumber = "12347", DateTime = "25.05.2023 09:00",
                           Services = "Покраска бампера",
                           Status = "Отменен", Price = "8 500 ₽", Employee = "Иванова М.К." }
            };

            OrdersDataGrid.ItemsSource = orders;
        }

        private void OrderButton_Click(object sender, RoutedEventArgs e)
        {
            CreateOrder createOrderWindow = new CreateOrder();
            createOrderWindow.Show();
        }
    }

    public class Order
    {
        public string OrderNumber { get; set; }
        public string DateTime { get; set; }
        public string Services { get; set; }
        public string Status { get; set; }
        public string Price { get; set; }
        public string Employee { get; set; }
    }
}