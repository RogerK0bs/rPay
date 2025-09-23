using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rPay.DB
{
    [Table("Users")]
    public class Users
    {
       public int id { get; set; }
       public string FIO { get; set; } = string.Empty;
       public string Login { get; set; } = string.Empty;
       public string Password { get; set; } = string.Empty;
       public string Permissions { get; set; }
        public override string ToString()
        {
            return Permissions+"           \t"+FIO;
        }
    }
}
