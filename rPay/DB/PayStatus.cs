using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rPay.DB
{
    [Table("PayStatus")]
    public class PayStatus
    {
        public int id {  get; set; } 
        public string additionalInfo { get; set; } = string.Empty;
        public string paymentPurpose { get; set; } = string.Empty;
        public float amount { get; set; }
        public string code { get; set; } = string.Empty;
        public string createDate { get; set; } = string.Empty;
        public string currency { get; set; } = string.Empty;
        public string order { get; set; } = string.Empty;
        public string paymentStatus { get; set; } = string.Empty;
        public string qrId { get; set; } = string.Empty;
        public string sbpMerchantId { get; set; } = string.Empty;
        public string transactionDate { get; set; } = string.Empty;
        public string transactionId { get; set; } = string.Empty;
        public string qrExpirationDate { get; set; } = string.Empty;
        public override string ToString()
        {
            string status = "";
            if (paymentStatus == "NO_INFO")
            {
                status = "НЕТ ОПЛАТЫ";
            }
            else if (paymentStatus == "SUCCESS") status = "ОПЛАЧЕНО";
                return "Карта пациента: " + order + " \t" + amount + " " + currency + " \t Статус платежа: " + status; 
             
        }

        

    }
}
