using Newtonsoft.Json.Linq;
using rPay.DB;
using rPay.Service;
using rPay.Windows;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;


namespace rPay.Windows
{
    /// <summary>
    /// Логика взаимодействия для crtOrder.xaml
    /// </summary>
    

    public partial class crtOrder : Window
    {
        public string fio = "";
        
        public crtOrder()
        {
            InitializeComponent();
        }

       

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
                using (var context = new ApplicationContext())
                {
                    RespPayment respPayment = new RespPayment();
                    var value = context.RespPayment.Count();
                    rPay.Service.resultPay valuePayLoad = new rPay.Service.resultPay();
                    urlResult.Text = valuePayLoad.payLoad(value).ToString();
                if (mailPacient.Text != "")
                    {
                    Service.mailSender mailSender = new Service.mailSender();
                    mailSender.mailForward(mailPacient.Text, valuePayLoad.payLoad(value).ToString(), patientsСard.Text);
                    }
                resultSend.Foreground = System.Windows.Media.Brushes.Black;
                resultSend.Content = "Отправлено";
            }
            
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                actionUser action = new actionUser();
                action.createAction(fio, "Создание", patientsСard.Text, payment.Text);
                DateTime date = DateTime.Now;
                var patMD5 = Service.md5encrypt.EncryptMd5Hash(patientsСard.Text+date.ToString());
                API.Registry.post.createOrder(payment.Text,patMD5, correctDate(), pacient(patientsСard.Text));
                MessageBox.Show("Платёж успешно создан", "Создание QR!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
           
        public string correctDate()
        {
            DatePicker datetimepicker = endData;
            datetimepicker.SelectedDate.Value.ToString("yyyy-MM-dd");
            string date = datetimepicker.SelectedDate.Value.ToString("yyyy-MM-dd") + "T00:00:00+03:00";
            return date;
        }
        public string pacient(string pacientCard)
        {
            return "ООО Медика НСК - "+pacientCard;
        }

      
    }
}
