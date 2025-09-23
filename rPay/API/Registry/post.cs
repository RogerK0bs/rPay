using Newtonsoft.Json;
using rPay.DB;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Formatting = Newtonsoft.Json.Formatting;
namespace rPay.API.Registry
{
    
    public class post
    {
        public static async Task createOrder (string _payment, string _order, string _endData, string _patientsСard)
        {
            using (var context = new ApplicationContext()) 
            {

                float _price = Convert.ToSingle(_payment);
                PaymentReceipt paymentReceipt = new PaymentReceipt
                {
                    account = "",
                    additionalInfo = "Оплата мед. услуг",
                    amount = _price,
                    currency = "RUB",
                    order = _order,
                    paymentDetails = "",
                    qrType = "QRDynamic",
                    qrExpirationDate = _endData,
                    sbpMerchantId = "MB0001785506",
                    redirectUrl = "https://medica-nsk.clinic",
                    qrDescription = _patientsСard,
                };
                context.PaymentReceipt.Add(paymentReceipt);
                context.SaveChanges();
                var json = JsonConvert.SerializeObject(paymentReceipt, Formatting.Indented);
                var url = "https://pay.raif.ru/api/sbp/v2/qrs";
                var token = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJNQjAwMDE3ODU1MDYiLCJqdGkiOiJiNTEyNjhiOC05MGY3LTQzYTgtODBiNC01NDY2NjM4YmM3MDgifQ.ePn0Aljny3HFjzv50bPoU8G0fTvCfhd_idDBUsuiroM"; // Замените на ваш токен
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    var contentJson = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(url, contentJson);
                    if (response.IsSuccessStatusCode)
                    {
                        var jsonResult = await response.Content.ReadAsStringAsync();
                        {
                           RespPayment respPayment =JsonConvert.DeserializeObject<RespPayment>(jsonResult);
                           context.RespPayment.Add(respPayment);
                           context.SaveChanges();
                        }
                    }

                 
                }

        }   }

    }
}
