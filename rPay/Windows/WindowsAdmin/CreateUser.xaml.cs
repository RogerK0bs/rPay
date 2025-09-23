using rPay.Service;
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

namespace rPay.Windows.WindowsAdmin
{
    /// <summary>
    /// Логика взаимодействия для CreateUser.xaml
    /// </summary>
    public partial class CreateUser : Window
    {
        public CreateUser()
        {
            InitializeComponent();
        }

        private void addUser_Click(object sender, RoutedEventArgs e)
        {
            string fio = addFIO.Text;
            string login = addLogin.Text;
            string pass = addPassword.Text;
            string per = addPerm.Text;
            bool res = true;
            
          var _res = rPay.Service.creatUser.CreatUser(fio, login, pass, per);
            if (_res == res)
            {
                addFIO.Text = "";
                addLogin.Text = "";
                addPassword.Text = "";
            }
        }

        private void addPerm_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }
    }
}
