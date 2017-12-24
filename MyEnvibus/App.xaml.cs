using MyEnvibus.Views;
using Xamarin.Forms;

namespace MyEnvibus
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new HomePage();

            //Task.Run(async ()=>{
            //    await RequestEnvibusInfoAsync();
            //});
        }


        //public async Task<string> RequestEnvibusInfoAsync()
        //{

        //    HttpResponseMessage response = null;
        //    String result = string.Empty;
        //    using (HttpClient client = new HttpClient())
        //    {
        //        HttpContent content = new StringContent("id_arret=420%2C421&from_ligne=false");
        //        content = new FormUrlEncodedContent(new[]
        //        {
        //            new KeyValuePair<string, string>("id_arret", "420,421"),
        //            new KeyValuePair<string, string>("from_ligne","false")
        //        });
        //        response = await client.PostAsync("http://www.envibus.fr/?dklik_boutique%5Baction%5D=select_arret", content);
        //        result = await response.Content.ReadAsStringAsync();
        //    }
        //    var htmlDoc = new HtmlDocument();
        //    htmlDoc.LoadHtml(result);
        //    // slit with hr balise
        //    List<HtmlNode> listLineBus = htmlDoc.DocumentNode.Descendants("p").Where(p => p.Attributes["class"]?.Value == "desc_ligne helvetica").ToList();
        //    List<HtmlNode> listDivHours = htmlDoc.DocumentNode.Descendants("div").Where(p => p.Attributes["class"]?.Value == "horraire_passage_container").ToList();
        //    for (int i = 0; i < listLineBus.Count(); i++)
        //    {
        //        List<HtmlNode> listHours = listDivHours[i].Descendants("p").ToList();
        //        foreach (HtmlNode hour in listHours)
        //        {
        //            Debug.WriteLine(hour.InnerText);
        //        }
        //    }
        //    return result;
        //}


        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
