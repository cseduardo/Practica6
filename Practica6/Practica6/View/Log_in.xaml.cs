using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Practica6.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Log_in : ContentPage
    {
        public static MobileServiceClient cliente;
        private MobileServiceUser usuario;
        public Log_in()
        {
            InitializeComponent();
            cliente = new MobileServiceClient(AzureConnection.AzureURL);
        }

        private async void ingresar_Clicked(object sender, EventArgs e)
        {
            if (App.Authenticator != null)
                usuario = await App.Authenticator.Authenticate();
            await Navigation.PushAsync(new Practica6.View.Principal());
        }
    }
}