using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using rPay.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using JsonSerializer = System.Text.Json.JsonSerializer;

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
        public static async Task<T> GetStatus<T>(string qrId)
        {
            using (var client = new HttpClient())
            {
                var token = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJNQjAwMDE3ODU1MDYiLCJqdGkiOiJiNTEyNjhiOC05MGY3LTQzYTgtODBiNC01NDY2NjM4YmM3MDgifQ.ePn0Aljny3HFjzv50bPoU8G0fTvCfhd_idDBUsuiroM";
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                try
                {
                    var url = $"https://pay.raif.ru/api/sbp/v1/qr/{qrId}/payment-info";
                    // Отправляем GET-запрос
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode(); // выбросит исключение, если код ответа не 2xx

                    // Читаем содержимое ответа как строку
                    string jsonString = await response.Content.ReadAsStringAsync();

                    // Десериализуем JSON в объект типа T
                    T result = JsonSerializer.Deserialize<T>(jsonString, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true // Игнорировать регистр свойств
                    });

                    return result;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return default;
                }
            }
        }
    }
}

