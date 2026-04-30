using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace rPay.DB
{
    [Table("UserAction")]
    public class UserAction
    {
        public int id {  get; set; }
        public string FIO { get; set; } = string.Empty;
        public string action { get; set; } = string.Empty;
        public string patcient { get; set; } = string.Empty;
        public string amount { get; set; } = string.Empty;
        public string date { get; set; } = string.Empty;
        public override string ToString()
        {
            return base.ToString();
        }
        public string FileExist ()
        {
            return FIO + " " + action+" "+ date + " " + patcient + ": " +amount +" руб";
        }


    }
}
