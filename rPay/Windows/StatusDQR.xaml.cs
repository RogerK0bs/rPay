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
        public int _value;
        public string _qrId;
        
        rPay.Service.resultPay result = new rPay.Service.resultPay();
        public StatusDQR()
        {
            InitializeComponent();
            using (var context = new ApplicationContext())
            {
                RespPayment respPayment = new RespPayment();
                var value = context.RespPayment.Count();
                qrId.Content = result.qrId(_value);
            }

        }

        private void updateStatus_Click(object sender,  RoutedEventArgs e)
        {                                   
            getStatus();
        }
        private async Task getStatus ()
        {
           // PayStatus payStatus = await rPay.API.Status.get.GetStatus<PayStatus>(qrId.Content.ToString());
            PayStatus payStatus = await rPay.API.Status.get.GetStatus<PayStatus>(result.qrId(_value));
            if (payStatus != null)
            {
                numberPacient.Content = payStatus.order;
                if (payStatus.paymentStatus == "SUCCESS")
                {
                    statusPay.Content = "Оплачено";
                }
                else statusPay.Content = "Нет оплаты";
                    price.Content = payStatus.amount;
            } 
        }
    }
}
