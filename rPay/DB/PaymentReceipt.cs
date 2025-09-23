using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rPay.DB
{
    [Table("PaymentReceipt")]
    public class PaymentReceipt
    {
   
       public int id { get; set; }
       public string account { get; set; }
       public string additionalInfo { get; set; } = string.Empty;
       public float amount { get; set; }
       public string currency { get; set; } = string.Empty;
       public string order {  get; set; } = string.Empty;
       public string paymentDetails { get; set; } = string.Empty;
       public string qrType { get; set; } = string.Empty;
       public string qrExpirationDate { get; set; } = string.Empty;
       public string sbpMerchantId { get; set; } = string.Empty;
       public string redirectUrl {  get; set; } = string.Empty;
       public string qrDescription { get; set; } = string.Empty;
    }
}
