using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RunningApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
            if (!Preferences.ContainsKey("Miles"))
                Preferences.Set("Miles", false);
            unitsSwitch.IsToggled = Preferences.Get("Miles", false);
            dob.Date = Preferences.Get("DatePref", new DateTime(2000, 1, 1));
            gender.SelectedIndex = Preferences.Get("GenderPref", 1);
        }
        public bool toggled = true;
        private void unitsSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            if(toggled == true)
        {
                unitsLabel.Text = "Meters";
                toggled = false;
                Preferences.Set("val", "meters");
        }
            else
            {
                unitsLabel.Text = "Miles";
                toggled = true;
                Preferences.Set("val", "miles");
            }
            Preferences.Set("Miles", unitsSwitch.IsToggled);
        }

        private void dob_DateSelected(object sender, DateChangedEventArgs e)
        {
            Preferences.Set("DatePref", dob.Date);
        }

        private void credits_Clicked(object sender, EventArgs e)
        {
            var url = "https://www.miamioh.edu";
            Device.OpenUri(new Uri(url));
        }

        private void gender_SelectedIndexChanged(object sender, EventArgs e)
        {
            Preferences.Set("GenderPref", gender.SelectedIndex);
        }
    }
}