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
    /// Логика взаимодействия для VidAvto.xaml
    /// </summary>
    public partial class VidAvto : Window
    {
        arendaEntities context;
        
        public VidAvto()
        {
            InitializeComponent();
            context = new arendaEntities();
            ShowTable();
          
        }

        private void ShowTable()
        {
            DataGridВыданныеАвто.ItemsSource = context.ВыданныеАвто.ToList();
        }

        private void BtnAddData_Click(object sender, RoutedEventArgs e)
        {
            Button BtnEdit = sender as Button;
            var currentRental = BtnEdit.DataContext as ВыданныеАвто;
            var EdiWindow = new addVidAvto(context, currentRental);
            EdiWindow.ShowDialog();
        }

        private void BtnDeleteData_Click(object sender, RoutedEventArgs e)
        {
            var currentClientService = DataGridВыданныеАвто.SelectedItem as ВыданныеАвто;
            if (currentClientService == null)
            {
                MessageBox.Show("Выберите строку!");
                return;

            }
            MessageBoxResult messageBoxResult = MessageBox.Show("Вы действительно хотите удалить эту строку?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                context.ВыданныеАвто.Remove(currentClientService);
                context.SaveChanges();
                ShowTable();
            }
        }

        private void BtnAddClient_Click(object sender, RoutedEventArgs e)
        {
            //var NewClientServ = new ВыданныеАвто();
            //context.ВыданныеАвто.Add(NewClientServ);
            //var btnAddClientServ2 = new addVidAvto(context, NewClientServ);
            //btnAddClientServ2.ShowDialog();
        }

        private void DataGridВыданныеАвто_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtnEditData_Click(object sender, RoutedEventArgs e)
        {
            Button BtnEdit = sender as Button;
            var currentRental = BtnEdit.DataContext as ВыданныеАвто;
            var EdiWindow = new addVidAvto(context, currentRental);
            EdiWindow.ShowDialog();
        }
    }
}
