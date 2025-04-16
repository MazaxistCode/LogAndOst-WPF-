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
    /// Логика взаимодействия для LogIn.xaml
    /// </summary>
    public partial class LogIn : Window
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void LogInButton_Click(object sender, RoutedEventArgs e)
        {
            if(!(string.IsNullOrEmpty(LoginBox.Text) || string.IsNullOrEmpty(PassBox.Text)))
            {
                if (DB.LogAndOstEntities.GetContext().Users.Any(user => user.Login == LoginBox.Text && user.Password == PassBox.Text))
                {
                    if (DB.LogAndOstEntities.GetContext().Users.Any(user => user.Login == LoginBox.Text && user.Password == PassBox.Text && user.Roles.Name == "админ"))
                    {
                        MainWindow form = new MainWindow();
                        Visibility = Visibility.Hidden;
                        form.ShowDialog();
                        Close();
                    }
                    else
                        MessageBox.Show("У вас недостаточно прав.");
                }
                else
                    MessageBox.Show("Неверный логин или пароль, возможно пользователь не зарегистрирован");
            }
            else 
                MessageBox.Show("Заполните все поля");
        }

        private void LogOnButton_Click(object sender, RoutedEventArgs e)
        {
            LogOn form = new LogOn();
            form.ShowDialog();
        }
    }
}
