// This examples is using RestSharp as a REST client - http://restsharp.org
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Text;


namespace GateWay.Models
{
    public class ImaggaModel
    {
        public async Task<bool> CheckImage(string imageUrl, string description)
        {
            string apiKey = "acc_99243853ec106fb";
            string apiSecret = "e158559864c958a22ea9325862b3eeb4";

            if (string.IsNullOrEmpty(imageUrl))
            {
                throw new Exception("Image URL is required.");
            }

            string basicAuthValue = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{apiKey}:{apiSecret}"));

            var client = new RestClient("https://api.imagga.com/v2/tags");
            var request = new RestRequest();
            request.AddParameter("image_url", imageUrl);
            request.AddHeader("Authorization", $"Basic {basicAuthValue}");

            RestResponse response = client.Execute(request);

            if (response.IsSuccessful)
            {
                // Parse the JSON response
                var jsonResponse = JObject.Parse(response.Content);

                // Extract the tags in English ("en")
                var tags = jsonResponse["result"]["tags"];

                // Create a list to store the tags
                var tagList = new List<string>();

                foreach (var tag in tags)
                {
                    var tagName = tag["tag"]["en"].ToString();
                    tagList.Add(tagName);
                }

                // Define the tags to check for
                var tagsToCheck = description.Split(' ');

                // Check if any of the desired tags exist in the list
                foreach (var tagToCheck in tagsToCheck)
                {
                    if (tagList.Contains(tagToCheck))
                    {
                        return true;
                    }
                }
                return false;
            }
            else
            {
                // Handle API request failure
                throw new Exception("API request failed.");
            }
        }
    }
}
