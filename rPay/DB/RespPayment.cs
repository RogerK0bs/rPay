using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rPay.DB
{
    [Table("RespPayment")]
    public class RespPayment
    {
        [Key]
        public int id { get; set; }
        public string qrId { get; set; } = string.Empty;
        public string payload { get; set; } = string.Empty;
        public string qrUrl { get; set; } = string.Empty;
        public string subscriptionId { get; set; } = string.Empty; 
    }
}
