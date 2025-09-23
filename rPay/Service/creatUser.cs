using rPay.DB;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.IdentityModel.Metadata;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace rPay.Service
{
    public class creatUser
    {
        public static bool CreatUser (string _FIO, string _Login, string _Password, string _Permissions)
        {
            using (var context = new ApplicationContext())
                try
                {
                    userStructure userStructure = new userStructure();
                    if (_Login == userStructure.Login(_Login))
                    {
                        var refPass = MessageBox.Show("Такой пользователь уже существует, обновить пароль ?", "Обновить пароль", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (refPass == MessageBoxResult.Yes)
                        {
                            var use = context.Users
                                        .Where(c => c.Login == _Login)
                                        .FirstOrDefault();
                            use.Password = _Password;
                            context.SaveChanges();
                            MessageBox.Show("Пароль был изменён", "", MessageBoxButton.OK, MessageBoxImage.Information);
                            
                        }
                        return true;
                    }
                else
                {
                    {
                        Users users = new Users() { FIO = _FIO, Login = _Login, Password = _Password, Permissions = _Permissions };
                        context.Users.Add(users);
                        context.SaveChanges();
                        MessageBox.Show("Пользователь успешно создан", "Готово!", MessageBoxButton.OK, MessageBoxImage.Information);
                            return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return false;
            }
        }
    }
}
