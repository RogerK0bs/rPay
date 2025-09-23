using rPay.DB;
using System;
using System.Collections.Generic;
using System.IdentityModel.Metadata;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace rPay.Service
{
    internal class deletUser
    {
        public static bool deleteUser (int id)
        {
            using (var context = new ApplicationContext())
            {
                try
                {
                    var use = context.Users.Find(id);
                        if (use != null)
                        {
                            context.Users.Remove(use);
                            context.SaveChanges();
                            return true;
                        }
                        return false;
                  
                }
                catch (Exception ex)
                {
                    MessageBox.Show("delete", "", MessageBoxButton.OK, MessageBoxImage.Error);
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
               
            }
        }
    }
}
