using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using MyEnvibus.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MyEnvibus.Core
{
    public class BusLineListRequest
    {
        public async Task<List<BusLine>> SendRequest(string searchTerm)
        {
            List<BusLine> result = new List<BusLine>();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string formatedParameters = FormatGetParameters(new[]
                    {
                        new KeyValuePair<string, string>("dklik_boutique[action]", "autocomplete_arret"),
                        new KeyValuePair<string, string>("term",searchTerm)
                    });

                    HttpResponseMessage response = await client.GetAsync("http://www.envibus.fr/?" + formatedParameters);

                    JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(
                        await response.Content.ReadAsStringAsync()
                    );

                    foreach (JToken token in jsonResponse.Children())
                    {
                        result.Add(
                            new BusLine(token.Value<string>("id"),
                                        token.Value<string>("label"),
                                        token.Value<string>("category")
                                       )
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
            return result;
        }

        string FormatGetParameters(IEnumerable<KeyValuePair<string, string>> parameters)
        {
            string output = "";

            foreach (KeyValuePair<string, string> param in parameters)
            {
                output += WebUtility.UrlEncode(param.Key) + "=" + WebUtility.UrlEncode(param.Value);
                if (!param.Equals(parameters.Last()))
                {
                    output += "&";
                }
            }

            return output;
        }
    }
}
