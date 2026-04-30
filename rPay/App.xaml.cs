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
            
            reportFile report = new reportFile();
            string dt = "";
            using (ApplicationContext context = new ApplicationContext())
            {
                DateTime timeNow = DateTime.Now.Date;

                foreach (var userAction in context.UserActions)
                {
                    DateTime parsedDate;
                    if (DateTime.TryParse(userAction.date, out parsedDate))
                    {
                        if (parsedDate.Date == timeNow)
                        {
                            report.GetFile(userAction.FileExist());
                        }
                    }
                    else
                    {
                        actionUser action = new actionUser();
                        action.createAction("SYSTEM", "ОШИБКА", "В ОТЧЁТЕ","");
                    }
                }

            }
        }
    }
}
