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
using rPay.API.Status;
using rPay.DB;
using rPay.Service;

namespace rPay.Windows
{
    /// <summary>
    /// Логика взаимодействия для StatusDQR.xaml
    /// </summary>
    public partial class StatusDQR : Window
    {
        rPay.Service.resultPay result = new rPay.Service.resultPay();
        public StatusDQR()
        {
            InitializeComponent();
            qrId.Content = result.qrId(123);

        }

        private void updateStatus_Click(object sender,  RoutedEventArgs e)
        {                                   
            getStatus();
           
        }
        private async Task getStatus ()
        {
            PayStatus payStatus = await rPay.API.Status.get.GetStatus<PayStatus>(qrId.Content.ToString());
            if (payStatus != null)
            {
                numberPacient.Content = payStatus.order;
                if (payStatus.paymentStatus == "SUCCESS")
                {
                    statusPay.Content = "Оплачено";
                }
                else statusPay.Content = "нет данных";
                    price.Content = payStatus.amount;
            } 
        }
    }
}
