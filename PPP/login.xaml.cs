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

namespace PPP
{
    /// <summary>
    /// Логика взаимодействия для login.xaml
    /// </summary>
    public partial class login : Window
    {
        arendaEntities context;
        public login()
        {
            InitializeComponent();
            context = new arendaEntities();
        }

        private void Login_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void BtnAuth_Click(object sender, RoutedEventArgs e)
        {
            var user = context.Клиенты.FirstOrDefault(u => ("1" == Login.Text || "1" == Password.Text));
            if (user == null)
            {
                MessageBox.Show("Неверные данные");
                return;
            }
            else
            {
                if (user.ID == 1)
                {
                    MessageBox.Show("Hello");
                    var admin = new MainWindow();
                    admin.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Hello");
                    var tables = new MainWindow();
                    tables.Show();
                    this.Close();
                }
            }
        
    }
    }
}
