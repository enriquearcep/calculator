using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Calculator
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            // App.Current.MainPage.DisplayAlert("Exito", "Pasa", "Aceptar");
            await App.Current.MainPage.Navigation.PushAsync(new DashboardView());
        }
    }
}
