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

namespace LogAndOst_WPF_
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<DB.Countries> countries = DB.LogAndOstEntities.GetContext().Countries.ToList();
            List<string> countryNames = new List<string>();
            foreach (var country in countries)
                countryNames.Add(country.Name);
            CountyBox.ItemsSource = countryNames;
        }

        private void CreateYZ_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Ждите меня на 3 закате рассвета\n\t - Гендельф");
        }

        private void AddCountry_Click(object sender, RoutedEventArgs e)
        {
            AddCounty form = new AddCounty();
            form.ShowDialog();
            List<DB.Countries> countries = DB.LogAndOstEntities.GetContext().Countries.ToList();
            List<string> countryNames = new List<string>();
            foreach (var country in countries)
                countryNames.Add(country.Name);
            CountyBox.ItemsSource = countryNames;
        }

        private void EmployeesButton_Click(object sender, RoutedEventArgs e)
        {
            Employees form = new Employees();
            form.ShowDialog();
        }

        private void ClientsButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Ждите меня на 3 закате рассвета\n\t - Гендельф");
        }

        private void RolesButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Ждите меня на 3 закате рассвета\n\t - Гендельф");
        }

        private void CountiesButton_Click(object sender, RoutedEventArgs e)
        {
            DBCountry form = new DBCountry();
            form.ShowDialog();
            List<DB.Countries> countries = DB.LogAndOstEntities.GetContext().Countries.ToList();
            List<string> countryNames = new List<string>();
            foreach (var country in countries)
                countryNames.Add(country.Name);
            CountyBox.ItemsSource = countryNames;
        }

        private void ServicesButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Ждите меня на 3 закате рассвета\n\t - Гендельф");
        }

        private void RequestsButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Ждите меня на 3 закате рассвета\n\t - Гендельф");
        }

        private void ReportsButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Ждите меня на 3 закате рассвета\n\t - Гендельф");
        }

        private void ControlButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Ждите меня на 3 закате рассвета\n\t - Гендельф");
        }
    }
}
