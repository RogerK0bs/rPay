using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using rPay.DB;
using System.Runtime;
using rPay.Service;

namespace rPay.Service
{
    internal class Authorization
    {
        public bool _authorization(string username, string password)
        {
            bool result = false;
            userStructure user = new userStructure();
            if ( password == user.Password(username) )
            {
                result = true;
            }
            return result;
        }
    }
}