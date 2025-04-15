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
            List<DB.Users> users = DB.LogAndOstEntities.GetContext().Users.Where(user => user.RoleId != 3).ToList();
            EmpList.ItemsSource = users;
            List<DB.Genders> genders = DB.LogAndOstEntities.GetContext().Genders.ToList();
            EmpList.ItemsSource = genders;
            List<DB.Roles> roles = DB.LogAndOstEntities.GetContext().Roles.Where(role => role.Name != "клиент").ToList();
            EmpList.ItemsSource = genders;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (EmpList.SelectedItem != null)
                DB.LogAndOstEntities.GetContext().Users.Remove(EmpList.SelectedItem as DB.Users);
            DB.LogAndOstEntities.GetContext().SaveChanges();
            List<DB.Users> users = DB.LogAndOstEntities.GetContext().Users.Where(user => user.RoleId != 3).ToList();
            EmpList.ItemsSource = users;
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            if(!(string.IsNullOrEmpty(NameBox.Text) && string.IsNullOrEmpty(GenderBox.Text) && string.IsNullOrEmpty(RoleBox.Text) && string.IsNullOrEmpty(CountryBox.Text)))
            {
                DB.LogAndOstEntities.GetContext().Users.Add(new DB.Users() {  });
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            DB.LogAndOstEntities.GetContext().SaveChanges();
            List<DB.Users> users = DB.LogAndOstEntities.GetContext().Users.Where(user => user.RoleId != 3 && user.Name.Contains(SearchBox.Text)).ToList();
            EmpList.ItemsSource = users;
        }

        private void EmpList_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if (EmpList.SelectedItem != null)
            {
                DB.Users user = EmpList.SelectedItem as DB.Users;
                NameBox.Text = user.Name;
            }
        }
    }
}
