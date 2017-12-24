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
            SearchSchedule = new Command(searchScheduleCommand);
        }

        public ICommand SearchSchedule { get; private set; }
        void searchScheduleCommand()
        {
            Task.Run(async () =>
            {
                List<BusLine> result = await busStopLines.SendRequest(searchTerms);
                foreach (BusLine line in result)
                {
                    Debug.WriteLine(line);
                }

            });
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
