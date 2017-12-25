using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using MyEnvibus.Core;
using MyEnvibus.Model;
using Xamarin.Forms;

namespace MyEnvibus.ViewModels
{
    public class StationLineChoiceViewModel : BaseViewModel
    {
        BusLineListRequest busStopLines;

        public StationLineChoiceViewModel()
        {
            busStopLines = new BusLineListRequest();
            SearchSchedule = new Command(async () => await SearchScheduleCommand());
        }

        public ICommand SearchSchedule { get; private set; }
        async Task SearchScheduleCommand()
        {
            Dictionary<BusLine, List<string>> output = new Dictionary<BusLine, List<string>>();
            BusStopDetailRequest detailRequest = new BusStopDetailRequest();
            List<string> detailRequestResult = new List<string>();

            List<BusLine> result = await busStopLines.SendRequest(searchTerms);
            foreach (BusLine line in result)
            {
                detailRequestResult = await detailRequest.SendRequest(line.Id);
                if (!output.ContainsKey(line))
                {
                    output.Add(line, detailRequestResult);
                }
            }

            foreach(BusLine line in output.Keys){
                Debug.WriteLine(line);
                foreach(string hour in output[line]){
                    Debug.WriteLine(hour);
                }
            }
        }

        string searchTerms;
        public string SearchTerms
        {
            get { return searchTerms; }
            set
            {
                if (searchTerms != value)
                {
                    searchTerms = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
