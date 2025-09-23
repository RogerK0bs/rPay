using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace rPay.Service
{
    public class resultPay
    {
        public string qrId (int id)
        {
            string resultAsString = "";
            using (var context = new ApplicationContext())
            {
                var parameter = id;
                var result = context.RespPayment
                                    .Where(x => x.id == parameter)
                                    .Select(x => x.qrId)
                                    .FirstOrDefault();
                resultAsString = result?.ToString();
            }
            return resultAsString;

           
        }
        public string payLoad(int id )
        {
            string resultAsString = "";
            using (var context = new ApplicationContext())
            {
                var parameter = id;
                var result = context.RespPayment
                                    .Where(x => x.id == parameter)
                                    .Select(x => x.payload)
                                    .FirstOrDefault();
                resultAsString = result?.ToString();
            }
            return resultAsString;

        }
        public string qrUrl (int id)
        {
            string resultAsString = "";
            using (var context = new ApplicationContext())
            {
                var parameter = id;
                var result = context.RespPayment
                                    .Where(x => x.id == parameter)
                                    .Select(x => x.qrUrl)
                                    .FirstOrDefault();
                resultAsString = result?.ToString();
            }
            return resultAsString;

        }
    }
}
