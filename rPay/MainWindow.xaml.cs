using rPay.DB;
using rPay.Windows;
using rPay.Service;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.EntitySql;
using System.Data.SqlClient;
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
 

namespace rPay
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
 
 
    
    public partial class MainWindow : Window
    {
        public static string _userActive = "";
        public MainWindow()
        {
            InitializeComponent();

        }

        private void Connect_Click(object sender, RoutedEventArgs e)
        {
            _userActive = Login.Text;
            string _password = Password.Password;

            using (var context = new ApplicationContext())
            {
                try
                {
                    Authorization authorization = new Authorization();
                    if (authorization._authorization(_userActive, _password ) == true)
                    {
                        Start start = new Start();
                        start.Show();
                        Close();
                        
                    }
                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }
    }
}
