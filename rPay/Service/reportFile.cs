using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rPay.Service
{
    public class reportFile
    {
        public bool GetFile (string val)
        {
            bool result = true;
            try
            {
                using (ApplicationContext context = new ApplicationContext())
                {
                    DateTime dateTime = DateTime.Now;
                    string filePath = $@"\\192.168.232.33\exch\Soft\Logs\raifPay\Report\rep_{dateTime.ToString("d")}.txt";
                    File.AppendAllText(filePath, $"\n{val}");
                }
            }
            catch (Exception)
            {
                result = false;
            }
            return result;

        }
    }
}
