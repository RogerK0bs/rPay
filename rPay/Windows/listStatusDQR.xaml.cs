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

namespace rPay.Windows
{
    /// <summary>
    /// Логика взаимодействия для listStatusDQR.xaml
    /// </summary>
    public partial class listStatusDQR : Window
    {
        public listStatusDQR()
        {
            InitializeComponent();
            using (var context = new ApplicationContext())
            {
                listQR.Items.Refresh();
                foreach (PaymentReceipt paymentReceipt in context.PaymentReceipt)
                {
                    listQR.Items.Add(paymentReceipt.ToString());
                }
            }
        }

        private void update_Click(object sender, RoutedEventArgs e)
        {
            listQR.Items.Clear();
            using (var context = new ApplicationContext())
            {
                listQR.Items.Refresh();
                foreach (PaymentReceipt paymentReceipt in context.PaymentReceipt)
                {
                    listQR.Items.Add(paymentReceipt.ToString());
                }
            }
        }

        private void checkPay_Click(object sender, RoutedEventArgs e)
        {
            
            numPay.Content = listQR.SelectedIndex+1;
            StatusDQR statusDQR = new StatusDQR();
            statusDQR._value = listQR.SelectedIndex+1;
            statusDQR.ShowDialog();
           
        }
    }
}
