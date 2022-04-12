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
    /// Логика взаимодействия для addVidAvto.xaml
    /// </summary>
    public partial class addVidAvto : Window
    {
        arendaEntities context;
        public addVidAvto(arendaEntities context, ВыданныеАвто выданныеАвто)
        {
            InitializeComponent();
            this.context = context;
            CmbКлиент.ItemsSource = context.Клиенты.ToList();
            CmbГосномер.ItemsSource = context.Авто.ToList();
            CmbШтрафы.ItemsSource = context.Штрафы.ToList();
            CmbСкидки.ItemsSource = context.Скидки.ToList();
            this.DataContext = выданныеАвто;
        }

        private void BtnSaveData_Click(object sender, RoutedEventArgs e)
        {
            context.SaveChanges();
            this.Close();
        }
    }
}
