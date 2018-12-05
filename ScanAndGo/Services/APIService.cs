using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ScanAndGo.Models;

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
    }
}