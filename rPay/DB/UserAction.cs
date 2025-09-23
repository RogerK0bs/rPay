using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
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


    }
}
