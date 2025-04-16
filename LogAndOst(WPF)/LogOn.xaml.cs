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
using System.Windows.Shell;

namespace LogAndOst_WPF_
{
    /// <summary>
    /// Логика взаимодействия для LogOn.xaml
    /// </summary>
    public partial class LogOn : Window
    {
        public LogOn()
        {
            InitializeComponent();
            try
            {
                List<DB.Genders> genders = DB.LogAndOstEntities.GetContext().Genders.ToList();
                foreach (var pole in genders)
                    GenderBox.Items.Add(pole.Name);
                List<DB.Countries> countries = DB.LogAndOstEntities.GetContext().Countries.ToList();
                foreach (var pole in countries)
                    CountryBox.Items.Add(pole.Name);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void LogOnButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(!(string.IsNullOrEmpty(NameBox.Text) || string.IsNullOrEmpty(GenderBox.Text) || string.IsNullOrEmpty(CountryBox.Text) ||
                    string.IsNullOrEmpty(LoginBox.Text) || string.IsNullOrEmpty(PassBox.Text) || string.IsNullOrEmpty(Pass2Box.Text)))
                {
                    if (DB.LogAndOstEntities.GetContext().Users.Any(user => user.Login == LoginBox.Text))
                    {
                        var userGender = DB.LogAndOstEntities.GetContext().Genders.First(gender => gender.Name == GenderBox.Text);
                        var userRole = DB.LogAndOstEntities.GetContext().Roles.First(role => role.Name == "клиент");
                        var userCountry = DB.LogAndOstEntities.GetContext().Countries.First(country => country.Name == CountryBox.Text);
                        DB.LogAndOstEntities.GetContext().Users.Add(new DB.Users()
                        {
                            Name = NameBox.Text,
                            Login = LoginBox.Text,
                            Password = PassBox.Text,
                            Countries = userCountry,
                            Genders = userGender,
                            Roles = userRole
                        });
                        DB.LogAndOstEntities.GetContext().SaveChanges();
                        Close();
                    }
                    else
                        MessageBox.Show("пользователь с таким логином уже зарегистрирован.");
                }
                else
                    MessageBox.Show("Заполните все поля.");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void LogInButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
