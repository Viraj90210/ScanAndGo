using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ScanAndGo.Models;
using ScanAndGo.Services.Payloads;

namespace ScanAndGo.Services {
    public class APIService {
        internal async Task<ProductModel> GetProductByID(string ID) {
            try {
                var httpClient = new HttpClient();
                var url = Config.BaseURL + Config.Scan + ID;
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode) {
                    var responseString = await response.Content.ReadAsStringAsync();
                    var responseContent = JsonConvert.DeserializeObject<ProductModel>(responseString);
                    responseContent.IsSuccess = true;
                    responseContent.ScannedBarcode = ID;
                    return responseContent;
                } else {
                    var responseContent = new ProductModel();
                    responseContent.IsSuccess = false;
                    return responseContent;
                }
            } catch (Exception ex) {
                Console.WriteLine("Exception in GetProductByID: " + ex.Message);
                var responseContent = new ProductModel();
                responseContent.IsSuccess = false;
                return responseContent;
            }
        }

        public async Task<string> PostOrder(OrderPayload payload)
        {
            string result = null;
            try
            {
                var httpClient = new HttpClient();
                // httpClient.BaseAddress = new Uri(Config.BaseURL);
              //  httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var jsonString = JsonConvert.SerializeObject(payload);
                //Uri uri = new Uri(string.Format("{0}{1}", Config.BaseURL, Config.PostOrderUrl));;
                Uri uri = new Uri("https://us-central1-scango-df13e.cloudfunctions.net/coreapi/api/v1/order");
                HttpContent httpContent = new StringContent(jsonString,Encoding.UTF8,"application/json");
                var response = await httpClient.PostAsync(uri, httpContent);
                response.EnsureSuccessStatusCode();
                result = await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;

        }
    }
}