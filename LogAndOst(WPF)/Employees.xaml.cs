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
            try
            {
                List<DB.Users> users = DB.LogAndOstEntities.GetContext().Users.Where(user => user.RoleId != 3).ToList();
                EmpList.ItemsSource = users;
                List<DB.Genders> genders = DB.LogAndOstEntities.GetContext().Genders.ToList();
                foreach (var pole in genders)
                    GenderBox.Items.Add(pole.Name);
                List<DB.Roles> roles = DB.LogAndOstEntities.GetContext().Roles.Where(role => role.Name != "клиент").ToList();
                foreach (var pole in roles)
                    RoleBox.Items.Add(pole.Name);
                List<DB.Countries> countries = DB.LogAndOstEntities.GetContext().Countries.ToList();
                foreach (var pole in countries)
                    CountryBox.Items.Add(pole.Name);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (EmpList.SelectedItem is DB.Users)
                {
                    DB.LogAndOstEntities.GetContext().Users.Remove(EmpList.SelectedItem as DB.Users);
                    DB.LogAndOstEntities.GetContext().SaveChanges();
                    List<DB.Users> users = DB.LogAndOstEntities.GetContext().Users.Where(user => user.RoleId != 3).ToList();
                    EmpList.ItemsSource = users;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!(string.IsNullOrEmpty(NameBox.Text) || string.IsNullOrEmpty(GenderBox.Text) || string.IsNullOrEmpty(RoleBox.Text)
                    || string.IsNullOrEmpty(CountryBox.Text) || string.IsNullOrEmpty(LoginBox.Text) || string.IsNullOrEmpty(PassBox.Text)))
                {
                    var userGender = DB.LogAndOstEntities.GetContext().Genders.First(gender => gender.Name == GenderBox.Text);
                    var userRole = DB.LogAndOstEntities.GetContext().Roles.First(role => role.Name == RoleBox.Text);
                    var userCountry = DB.LogAndOstEntities.GetContext().Countries.First(country => country.Name == CountryBox.Text);
                    DB.LogAndOstEntities.GetContext().Users.Add(new DB.Users() { Name = NameBox.Text, Login = LoginBox.Text,
                        Password = PassBox.Text,Countries = userCountry, Genders = userGender, Roles = userRole});
                    DB.LogAndOstEntities.GetContext().SaveChanges();
                    List<DB.Users> users = DB.LogAndOstEntities.GetContext().Users.Where(user => user.RoleId != 3).ToList();
                    EmpList.ItemsSource = users;
                }
                else
                    MessageBox.Show("Заполните все поля.");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (EmpList.SelectedItem != null && !(string.IsNullOrEmpty(NameBox.Text) || string.IsNullOrEmpty(GenderBox.Text) || string.IsNullOrEmpty(RoleBox.Text)
                    || string.IsNullOrEmpty(CountryBox.Text) || string.IsNullOrEmpty(LoginBox.Text) || string.IsNullOrEmpty(PassBox.Text)))
                {
                    var selectUser = EmpList.SelectedItem as DB.Users;
                    var editUser = DB.LogAndOstEntities.GetContext().Users.First(user => user.Id == selectUser.Id);
                    var userGender = DB.LogAndOstEntities.GetContext().Genders.First(gender => gender.Name == GenderBox.Text);
                    var userRole = DB.LogAndOstEntities.GetContext().Roles.First(role => role.Name == RoleBox.Text);
                    var userCountry = DB.LogAndOstEntities.GetContext().Countries.First(country => country.Name == CountryBox.Text);
                    editUser.Name = NameBox.Text;
                    editUser.Login = LoginBox.Text;
                    editUser.Password = PassBox.Text;
                    editUser.Roles = userRole;
                    editUser.Countries = userCountry;
                    editUser.Genders = userGender;
                    DB.LogAndOstEntities.GetContext().SaveChanges();
                    List<DB.Users> users = DB.LogAndOstEntities.GetContext().Users.Where(user => user.RoleId != 3).ToList();
                    EmpList.ItemsSource = users;
                }
                else
                    MessageBox.Show("Заполните все поля и выберите изменяемого пользователя.");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                DB.LogAndOstEntities.GetContext().SaveChanges();
                List<DB.Users> users = DB.LogAndOstEntities.GetContext().Users.Where(user => user.RoleId != 3 && user.Name.Contains(SearchBox.Text)).ToList();
                EmpList.ItemsSource = users;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void EmpList_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            try
            {
                if (EmpList.SelectedItem != null)
                {
                    if (EmpList.SelectedItem is DB.Users)
                    {
                        DB.Users user = EmpList.SelectedItem as DB.Users;
                        NameBox.Text = user.Name;
                        LoginBox.Text = user.Login;
                        PassBox.Text = user.Password;
                        GenderBox.SelectedIndex = user.GenderId-1;
                        RoleBox.SelectedIndex = user.RoleId-1;
                        CountryBox.SelectedIndex = user.CountryId-1;
                    }
                    else
                    {
                        NameBox.Text = string.Empty;
                        LoginBox.Text = string.Empty;
                        PassBox.Text = string.Empty;
                        GenderBox.SelectedItem = null;
                        RoleBox.SelectedItem = null;
                        CountryBox.SelectedItem = null;
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
