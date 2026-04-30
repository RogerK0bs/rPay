using rPay.DB;
using rPay.Service;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

namespace rPay
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Exit(object sender, ExitEventArgs e)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                reportFile report = new reportFile();
                foreach (UserAction userAction in context.UserActions)
                {
                    report.GetFile(userAction.FileExist());
                }
               
            }
        }
    }
}
