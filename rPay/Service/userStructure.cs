using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using rPay.DB;

namespace rPay.Service
{
    internal class userStructure
    {
        public string FIO (string login)
        {
            string resultAsString = "";
            using (var context = new ApplicationContext())
            {
                var parameter = login;
                var result = context.Users
                                    .Where(x => x.Login == parameter)
                                    .Select(x => x.FIO)
                                    .FirstOrDefault();
                resultAsString = result?.ToString();
            }
            return resultAsString;
        }
        public string Login(string login)
        {
            string resultAsString = "";
            using (var context = new ApplicationContext())
            {
                var parameter = login;
                var result = context.Users
                                    .Where(x => x.Login == parameter)
                                    .Select(x => x.Login)
                                    .FirstOrDefault();
                resultAsString = result?.ToString();
            }
            return resultAsString;
        }
        public string Password(string login)
        {
            string resultAsString = "";
            using (var context = new ApplicationContext())
            {
                var parameter = login;
                var result = context.Users
                                    .Where(x => x.Login == parameter)
                                    .Select(x => x.Password)
                                    .FirstOrDefault();
                resultAsString = result?.ToString();
            }
            return resultAsString;
        }
        public string Permissions(string login)
        {
            string resultAsString = "";
            using (var context = new ApplicationContext())
            {
                var parameter = login;
                var result = context.Users
                                    .Where(x => x.Login == parameter)
                                    .Select(x => x.Permissions)
                                    .FirstOrDefault();
                resultAsString = result?.ToString();
            }
            return resultAsString;
        }
    }
}
