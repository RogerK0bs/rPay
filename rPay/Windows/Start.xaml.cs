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
using rPay.Service;
using rPay.Windows.WindowsUserAdmin;
using rPay.Windows.WindowsAdmin;

namespace rPay.Windows
{
    /// <summary>
    /// Логика взаимодействия для Start.xaml
    /// </summary>

    public partial class Start : Window
    {
        userStructure user = new userStructure();

        public Start()
        {
            InitializeComponent();
            {
                fioUser.Content = user.FIO(MainWindow._userActive);
            }
        }

        private void createOrder_Click(object sender, RoutedEventArgs e)
        {
            crtOrder crtOrder = new crtOrder();
            crtOrder.Show();
        }

        private void returnPay_Click(object sender, RoutedEventArgs e)
        {
            bckOrder bckOrder = new bckOrder();
            bckOrder.Show();
        }

        private void statusQRdynamic_Click(object sender, RoutedEventArgs e)
        {
            StatusSQR staticOrder = new StatusSQR();
            staticOrder.Show();
        }
        private void userList_Click(object sender, RoutedEventArgs e)
        {
            if (user.Permissions(MainWindow._userActive) == "Admin")
            {
                UserList userList = new UserList();
            userList.Show();
            }
            else MessageBox.Show("У вас недостаточно правю", "Error", MessageBoxButton.OK, MessageBoxImage.Information);

        }

        private void deletOrder_Click(object sender, RoutedEventArgs e)
        {
            if ((user.Permissions(MainWindow._userActive) == "Admin") || (user.Permissions(MainWindow._userActive) == "UserAdmin"))
            {
                deleteQRD deleteQRD = new deleteQRD();
                deleteQRD.Show();
            }
            else MessageBox.Show("У вас недостаточно правю", "Error", MessageBoxButton.OK, MessageBoxImage.Information);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
    }
}
