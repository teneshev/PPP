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
    /// Логика взаимодействия для btnaddclient.xaml
    /// </summary>
    public partial class btnaddclient : Window
    {
        arendaEntities context;
        public btnaddclient(arendaEntities context, Клиенты клиенты)
        {
            InitializeComponent();
            this.context = context;
            this.DataContext = клиенты;
        }

        private void BtnSAve_Click(object sender, RoutedEventArgs e)
        {
            context.SaveChanges();
            this.Close();
        }
    }
}
