using rPay.DB;
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
    /// Логика взаимодействия для UserList.xaml
    /// </summary>
    public partial class UserList : Window
    {
        public UserList()
        {
            InitializeComponent();
                using (var context = new ApplicationContext())
                {
                    foreach (Users users in context.Users)
                    {
                        userList.Items.Add(users.ToString());
                    }
                }
        }

      

        private void deletUser_Click(object sender, RoutedEventArgs e)
        {
            rPay.Service.deletUser.deleteUser(userList.SelectedIndex+1);
            userList.Items.Refresh();
        }

        private void updateUserList_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new ApplicationContext())
            {
                userList.Items.Clear();
                foreach (Users users in context.Users)
                {
                    userList.Items.Add(users.ToString());
                }

            }

        }

        private void createUser_Click(object sender, RoutedEventArgs e)
        {
            CreateUser createUser = new CreateUser();
            createUser.Show();
        }
    }
}
