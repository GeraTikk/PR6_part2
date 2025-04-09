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
    public partial class CreateOrder : Window
    {
        public class Service
        {
            public string Name { get; set; }
            public decimal Price { get; set; }
        }

        public class Master
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Specialization { get; set; }
        }

        public CreateOrder()
        {
            InitializeComponent();
        }

        private void CreateOrderButton_Click(object sender, RoutedEventArgs e)
        {
            ConfimOrder confimOrder = new ConfimOrder();
            confimOrder.Show();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}