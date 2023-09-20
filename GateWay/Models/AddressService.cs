
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace GateWay.Models
{
    public class AddressService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiBaseUrl = "https://data.gov.il/api/3/action/datastore_search?resource_id=bf185c7f-1a4e-4662-88c5-fa118a244bda&limit=145515";

        public AddressService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<bool> CheckCityAndStreetExists(string cityName, string streetName)
        {
            try
            {
                var response = await _httpClient.GetAsync(_apiBaseUrl);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var root = JsonConvert.DeserializeObject<Root>(content);

                    if (root?.result?.records != null)
                    {
                        return root.result.records.Any(record => record.city_name.TrimStart().TrimEnd() == cityName.TrimStart().TrimEnd() 
                        && record.street_name.TrimStart().TrimEnd() == streetName.TrimStart().TrimEnd());
                    }
                }

                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
