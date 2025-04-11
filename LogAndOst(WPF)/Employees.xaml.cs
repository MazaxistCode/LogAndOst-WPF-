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

namespace LogAndOst_WPF_
{
    /// <summary>
    /// Логика взаимодействия для Employees.xaml
    /// </summary>
    public partial class Employees : Window
    {
        public Employees()
        {
            InitializeComponent();
            List<DB.Users> users = DB.LogAndOstEntities.GetContext().Users.ToList();
            EmpList.ItemsSource = users;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (EmpList.SelectedItem != null)
                DB.LogAndOstEntities.GetContext().Users.Remove(EmpList.SelectedItem as DB.Users);
            DB.LogAndOstEntities.GetContext().SaveChanges();
            List<DB.Users> users = DB.LogAndOstEntities.GetContext().Users.ToList();
            EmpList.ItemsSource = users;
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
