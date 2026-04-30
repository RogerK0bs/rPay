using rPay.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

namespace rPay.Service
{
    public class actionUser
    {
        public void createAction(string fio, string action, string patcient, string amount)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                DateTime dateTime = DateTime.Now;
                UserAction userAction = new UserAction
                {
                    FIO = fio,
                    action = action,
                    patcient = patcient,
                    amount = amount,
                    date = dateTime.ToString()
                };
                context.UserActions.Add(userAction);
                context.SaveChanges();
            }
        }
    }
}
