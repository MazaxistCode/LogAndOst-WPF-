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
using LogAndOst_WPF_.DB;

namespace LogAndOst_WPF_
{
    /// <summary>
    /// Логика взаимодействия для DBCountry.xaml
    /// </summary>
    public partial class DBCountry : Window
    {
        public DBCountry()
        {
            InitializeComponent();
            DataGrid.ItemsSource = DB.LogAndOstEntities.GetContext().Countries.ToList();
        }

        private void DeleteCountry_Click(object sender, RoutedEventArgs e)
        {
            if (DataGrid.SelectedItem != null)
                DB.LogAndOstEntities.GetContext().Countries.Remove(DataGrid.SelectedItem as Countries);
        }
    }
}
