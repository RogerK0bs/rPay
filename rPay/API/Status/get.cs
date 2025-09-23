using Newtonsoft.Json;
using rPay.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace rPay.API.Status
{
    internal class get
    {
        public static async Task statusOrder(string qrId)
        {
            using (var context = new ApplicationContext())
            {
                var url = "https://pay.raif.ru/api/sbp/v1/qr/"+qrId+"/payment-info";
                var token = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJNQjAwMDE3ODU1MDYiLCJqdGkiOiJiNTEyNjhiOC05MGY3LTQzYTgtODBiNC01NDY2NjM4YmM3MDgifQ.ePn0Aljny3HFjzv50bPoU8G0fTvCfhd_idDBUsuiroM"; // Замените на ваш токен
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    var response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        var jsonResult = await response.Content.ReadAsStringAsync();
                        {
                            PayStatus payStatus = JsonConvert.DeserializeObject<PayStatus>(jsonResult);
                            context.PayStatus.Add(payStatus);
                            context.SaveChanges();
                        }
                    }

                }
            }
        }
    }
}
