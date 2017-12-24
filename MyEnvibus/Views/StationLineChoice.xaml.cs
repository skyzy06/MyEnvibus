using Xamarin.Forms;

namespace MyEnvibus.Views
{
    public partial class StationLineChoice : ContentPage
    {
        public StationLineChoice()
        {
            InitializeComponent();
            if(Device.RuntimePlatform == Device.iOS){
                Icon = "hamburger.png";
            }
        }
    }
}
