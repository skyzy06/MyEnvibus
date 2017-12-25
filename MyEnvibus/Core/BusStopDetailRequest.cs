using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace MyEnvibus.Core
{
    public class BusStopDetailRequest
    {
        public async Task<List<string>> SendRequest(string busStopId)
        {
            List<string> result = new List<string>();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpContent content = new FormUrlEncodedContent(new[]
                    {
                        new KeyValuePair<string, string>("id_arret", busStopId),
                        new KeyValuePair<string, string>("from_ligne","false")
                    });

                    HttpResponseMessage response = await client.PostAsync("http://www.envibus.fr/?dklik_boutique%5Baction%5D=select_arret", content);
                    String responseContent = await response.Content.ReadAsStringAsync();
                    HtmlDocument htmlDoc = new HtmlDocument();

                    htmlDoc.LoadHtml(responseContent);

                    List<HtmlNode> listLineBus = htmlDoc.DocumentNode.Descendants("p").Where(p => p.Attributes["class"]?.Value == "desc_ligne helvetica").ToList();
                    List<HtmlNode> listDivHours = htmlDoc.DocumentNode.Descendants("div").Where(p => p.Attributes["class"]?.Value == "horraire_passage_container").ToList();
                    for (int i = 0; i < listLineBus.Count(); i++)
                    {
                        List<HtmlNode> listHours = listDivHours[i].Descendants("p").ToList();
                        foreach (HtmlNode hour in listHours)
                        {
                            result.Add(hour.InnerText);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            return result;
        }
    }
}
