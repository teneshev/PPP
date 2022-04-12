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

namespace PPP
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        arendaEntities context;
        string currentLetter = "";
        public MainWindow()
        {
            InitializeComponent();
            context = new arendaEntities();
            ShowTable();
            ShowLetters();
        }

        private void ShowTable()
        {
            if (TxtФамилия.Text == null && TxtНомер.Text == null)
                return;
            List<Клиенты> listКлиент = context.Клиенты.ToList();
            listКлиент = listКлиент.Where(x => x.Фамилия.ToLower().Contains(TxtФамилия.Text.ToLower())).ToList();
            listКлиент = listКлиент.Where(x => x.Номер_паспорта.ToLower().Contains(TxtНомер.Text.ToLower())).ToList();
            if (currentLetter.Count() == 1)
            {
                listКлиент = listКлиент.Where(x => x.Фамилия.Contains(currentLetter)).ToList();
            }
            DataGridКлиенты.ItemsSource = listКлиент.OrderBy(x => x.Фамилия).ToList();
        }

        private void ShowLetters()
        {
            for (char i = 'А'; i <= 'Я'; i++)
            {
                TextBlock letter = new TextBlock
                {
                    Text = i.ToString(),
                    FontWeight = FontWeights.Bold,
                    Foreground = Brushes.White,
                    Margin = new Thickness(10, 1, 5, 1)
                };
                letter.MouseLeftButtonDown += TextBlock_MouseLeftButtonDown;
                StackLetters.Children.Add(letter);
            }
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var label = (TextBlock)sender;
            currentLetter = label.Text;
            foreach (TextBlock letter in StackLetters.Children)
            {
                letter.Foreground = Brushes.White;
            }
            label.Foreground = Brushes.Gold;
            ShowTable();
        }

        private void TxtНомер_TextChanged(object sender, TextChangedEventArgs e)
        {
            ShowTable();
        }

        private void TxtФамилия_TextChanged(object sender, TextChangedEventArgs e)
        {
            ShowTable();
        }

       

        private void BtnEditData_Click(object sender, RoutedEventArgs e)
        {
            Button BtnEdit = sender as Button;
            var currentClient = BtnEdit.DataContext as Клиенты;
            var editClient = new btnaddclient(context, currentClient);
            editClient.ShowDialog();
        }

        private void BtnAd_Click_1(object sender, RoutedEventArgs e)
        {
            var NewClient = new Клиенты();
            context.Клиенты.Add(NewClient);
            var addRNewClient = new btnaddclient(context, NewClient);
            addRNewClient.ShowDialog();
        }

        private void BtnD_Click_1(object sender, RoutedEventArgs e)
        {
            var currentClientService = DataGridКлиенты.SelectedItem as Клиенты;
            if (currentClientService == null)
            {
                MessageBox.Show("Выберите строку!");
                return;

            }
            MessageBoxResult messageBoxResult = MessageBox.Show("Вы действительно хотите удалить эту строку?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                context.Клиенты.Remove(currentClientService);
                context.SaveChanges();
                ShowTable();
            }
        }

       

        private void DataGridКлиенты_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtnVid_Click(object sender, RoutedEventArgs e)
        {
            var RentalSelect = new VidAvto();
            RentalSelect.ShowDialog();
        }
    }
}
