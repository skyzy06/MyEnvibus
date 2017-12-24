using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MyEnvibus.Views
{
    public partial class StationSchedules : ContentPage
    {
        public StationSchedules()
        {
            InitializeComponent();
            if(Device.RuntimePlatform == Device.iOS){
                Icon = "hamburger.png";
            }
        }
    }
}
