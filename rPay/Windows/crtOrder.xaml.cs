using rPay.DB;
using rPay.Windows;
using rPay.Service;
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
        public crtOrder()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StatusDQR statusDQR = new StatusDQR();
            Close();
            statusDQR.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
           
           
          
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
               API.Registry.post.createOrder(payment.Text, patientsСard.Text, correctDate(), pacient(patientsСard.Text));
               resultSend.Content = "Успешно отправлено!";
               resultSend.Foreground = System.Windows.Media.Brushes.Green;
               

            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Information);
                resultSend.Foreground = System.Windows.Media.Brushes.Red;
                resultSend.Content="Ошибка!!!";
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
