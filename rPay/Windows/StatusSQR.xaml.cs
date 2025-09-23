using rPay.DB;
using rPay.Windows.WindowsAdmin;
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


namespace rPay.Windows
{
    /// <summary>
    /// Логика взаимодействия для StatusSQR.xaml
    /// </summary>
    public partial class StatusSQR : Window
    {
        string QRcode = "";
        public StatusSQR()
        {
            InitializeComponent();
            using (var context = new ApplicationContext())
            {
                ListStatus.Items.Refresh();
                foreach (PayStatus payStatus in context.PayStatus)
                {
                    ListStatus.Items.Add(payStatus.ToString());
                }
            }
        }

        private void getPay_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new ApplicationContext())
            {
                resultPay resultPay = new resultPay();
                   
                for (int i = 1; i <= context.RespPayment.Count(); i++)
                {
                    API.Status.get.statusOrder(QRcode);
                }
                ListStatus.Items.Refresh();
                foreach (PayStatus payStatus in context.PayStatus)
                {
                    ListStatus.Items.Add(payStatus).ToString(); // asd
                }
            }
        }
        private void selectKassa_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (selectKassa.Text)
            {
                case "Регистратура - 1 этаж":
                    QRcode = "BS1A0005H4VFUP2P85D8L3B3VCC31RJP";
                    break;
                case "Регистратура - 2 этаж":
                    QRcode = "BS1A0001SNVVRUVP8KDQ5R799CM5RFQK";
                    break;
                case "Регистратура - стационар":
                    QRcode = "BS1A000FRIBGI1CI8H4BBN5561OOTOLK";
                    break;
            }


         


        }
    }


}
